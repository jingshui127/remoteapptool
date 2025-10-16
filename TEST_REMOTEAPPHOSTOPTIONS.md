# RemoteAppHostOptions 功能测试指南

## 📋 功能概述

RemoteAppHostOptions 窗口用于管理 Terminal Services RemoteApp 的主机选项，通过修改 Windows 注册表来控制 RemoteApp 的行为。

---

## 🔑 注册表位置

### 1. TSAppAllowList（允许列表）
**路径：**
```
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList
```

**键值：**
- `fDisabledAllowList` (DWORD)
  - 0 = 启用允许列表（默认，只有列表中的应用可运行）
  - 1 = 禁用允许列表（所有应用都可作为 RemoteApp 运行）

---

### 2. Terminal Services 策略
**路径：**
```
HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services
```

**键值：**
- `fAllowUnlistedRemotePrograms` (DWORD)
  - 存在且为1 = 允许运行未列出的远程程序
  - 不存在 = 不允许

- `MaxDisconnectionTime` (DWORD，毫秒)
  - 断开连接会话的超时时间
  - 例如：60000 = 60秒

- `MaxIdleTime` (DWORD，毫秒)
  - 空闲会话的超时时间
  - 例如：300000 = 300秒（5分钟）

- `fResetBroken` (DWORD)
  - 存在且为1 = 超时时注销会话
  - 不存在 = 超时时断开连接

---

## 🧪 测试步骤

### 测试 1：打开窗口并读取当前设置

**步骤：**
1. 运行 RemoteApp Tool
2. 点击菜单 "工具" → "主机选项"
3. 观察窗口是否正常打开

**预期结果：**
- ✅ 窗口正常打开
- ✅ 所有复选框状态反映当前注册表设置
- ✅ 文本框显示当前超时值（秒）
- ✅ 禁用的文本框变灰

**验证方法：**
打开注册表编辑器（regedit.exe），对比以下位置的值是否与窗口显示一致：
- `TSAppAllowList\fDisabledAllowList`
- `Terminal Services\MaxDisconnectionTime`（除以1000后应等于显示值）
- `Terminal Services\MaxIdleTime`（除以1000后应等于显示值）

---

### 测试 2：禁用应用程序允许列表

**步骤：**
1. 勾选 "禁用应用程序允许列表"
2. 点击 "保存"

**预期结果：**
- ✅ 窗口关闭
- ✅ 注册表 `TSAppAllowList\fDisabledAllowList` = 1

**验证命令（PowerShell）：**
```powershell
Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList" -Name "fDisabledAllowList"
```

**回滚：**
```powershell
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList" -Name "fDisabledAllowList" -Value 0
```

---

### 测试 3：设置断开连接超时

**步骤：**
1. 勾选 "断开连接会话的超时时间"
2. 在文本框中输入 "120"（120秒）
3. 点击 "保存"

**预期结果：**
- ✅ 窗口关闭
- ✅ 注册表 `Terminal Services\MaxDisconnectionTime` = 120000（毫秒）

**验证命令（PowerShell）：**
```powershell
Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxDisconnectionTime"
```

**回滚：**
```powershell
Remove-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxDisconnectionTime" -ErrorAction SilentlyContinue
```

---

### 测试 4：设置空闲超时

**步骤：**
1. 勾选 "空闲会话的超时时间"
2. 在文本框中输入 "300"（300秒）
3. 点击 "保存"

**预期结果：**
- ✅ 窗口关闭
- ✅ 注册表 `Terminal Services\MaxIdleTime` = 300000（毫秒）

**验证命令（PowerShell）：**
```powershell
Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxIdleTime"
```

**回滚：**
```powershell
Remove-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxIdleTime" -ErrorAction SilentlyContinue
```

---

### 测试 5：启用超时时注销

**步骤：**
1. 勾选 "超时后注销会话"
2. 点击 "保存"

**预期结果：**
- ✅ 窗口关闭
- ✅ 注册表 `Terminal Services\fResetBroken` = 1

**验证命令（PowerShell）：**
```powershell
Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "fResetBroken"
```

**回滚：**
```powershell
Remove-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "fResetBroken" -ErrorAction SilentlyContinue
```

---

### 测试 6：输入验证

**步骤：**
1. 在 "断开连接会话的超时时间" 文本框中输入 "abc123xyz"
2. 观察文本框内容

**预期结果：**
- ✅ 只保留数字，显示 "123"
- ✅ 所有非数字字符被自动移除

**步骤：**
1. 在 "空闲会话的超时时间" 文本框中输入 "45.67"
2. 观察文本框内容

**预期结果：**
- ✅ 只保留数字，显示 "4567"
- ✅ 小数点被移除

---

### 测试 7：复选框联动

**步骤：**
1. 取消勾选 "断开连接会话的超时时间"
2. 观察对应的文本框

**预期结果：**
- ✅ 文本框变灰（Enabled = false）
- ✅ 无法编辑文本框

**步骤：**
1. 再次勾选 "断开连接会话的超时时间"
2. 观察对应的文本框

**预期结果：**
- ✅ 文本框恢复可编辑（Enabled = true）
- ✅ 可以输入内容

---

### 测试 8：取消编辑

**步骤：**
1. 修改任意设置
2. 点击 "取消"

**预期结果：**
- ✅ 窗口关闭
- ✅ 注册表没有任何改变

---

### 测试 9：删除已有设置

**前提：** 已经设置了断开连接超时

**步骤：**
1. 打开主机选项窗口
2. 取消勾选 "断开连接会话的超时时间"
3. 点击 "保存"

**预期结果：**
- ✅ 窗口关闭
- ✅ 注册表键 `MaxDisconnectionTime` 被删除

**验证命令（PowerShell）：**
```powershell
# 应该报错，表示键不存在
Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxDisconnectionTime"
```

---

## 🛡️ 权限要求

**重要：** 修改注册表需要管理员权限！

**测试前确认：**
1. 以管理员身份运行 RemoteApp Tool
2. 如果不是管理员，保存时会报错

**测试权限错误：**
1. 以普通用户身份运行程序
2. 尝试保存设置
3. 应该看到错误提示

---

## 🔄 完整的集成测试脚本

**PowerShell 测试脚本：**

```powershell
# 测试脚本：验证 RemoteAppHostOptions 功能
# 需要管理员权限

Write-Host "=== RemoteAppHostOptions 集成测试 ===" -ForegroundColor Green

# 备份当前设置
$backupPath = "C:\Temp\RemoteAppHostOptions_Backup.reg"
reg export "HKLM\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" $backupPath /y

# 测试 1：设置断开连接超时为 60 秒（60000 毫秒）
Write-Host "`n测试 1：设置断开连接超时" -ForegroundColor Yellow
Set-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxDisconnectionTime" -Value 60000 -Type DWord
$value = Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxDisconnectionTime"
if ($value.MaxDisconnectionTime -eq 60000) {
    Write-Host "✅ 通过：MaxDisconnectionTime = 60000" -ForegroundColor Green
} else {
    Write-Host "❌ 失败：值不正确" -ForegroundColor Red
}

# 测试 2：设置空闲超时为 300 秒（300000 毫秒）
Write-Host "`n测试 2：设置空闲超时" -ForegroundColor Yellow
Set-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxIdleTime" -Value 300000 -Type DWord
$value = Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "MaxIdleTime"
if ($value.MaxIdleTime -eq 300000) {
    Write-Host "✅ 通过：MaxIdleTime = 300000" -ForegroundColor Green
} else {
    Write-Host "❌ 失败：值不正确" -ForegroundColor Red
}

# 测试 3：设置超时注销
Write-Host "`n测试 3：设置超时注销" -ForegroundColor Yellow
Set-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "fResetBroken" -Value 1 -Type DWord
$value = Get-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services" -Name "fResetBroken"
if ($value.fResetBroken -eq 1) {
    Write-Host "✅ 通过：fResetBroken = 1" -ForegroundColor Green
} else {
    Write-Host "❌ 失败：值不正确" -ForegroundColor Red
}

# 测试 4：禁用允许列表
Write-Host "`n测试 4：禁用允许列表" -ForegroundColor Yellow
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList" -Name "fDisabledAllowList" -Value 1 -Type DWord
$value = Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList" -Name "fDisabledAllowList"
if ($value.fDisabledAllowList -eq 1) {
    Write-Host "✅ 通过：fDisabledAllowList = 1" -ForegroundColor Green
} else {
    Write-Host "❌ 失败：值不正确" -ForegroundColor Red
}

# 恢复原始设置
Write-Host "`n恢复原始设置..." -ForegroundColor Yellow
reg import $backupPath

Write-Host "`n=== 测试完成 ===" -ForegroundColor Green
Write-Host "备份文件位于：$backupPath" -ForegroundColor Cyan
```

---

## 📝 已知问题

1. **权限问题**
   - 如果不是管理员，会报错
   - 建议在错误提示中明确说明需要管理员权限

2. **策略键不存在**
   - 首次使用时，策略键可能不存在
   - 代码已经处理了自动创建的情况

3. **值类型**
   - 确保保存为 DWORD 类型
   - 时间值以毫秒为单位

---

## ✅ 测试检查清单

- [ ] 窗口正常打开并显示当前设置
- [ ] 所有复选框可以正常勾选/取消
- [ ] 文本框输入验证（只允许数字）
- [ ] 复选框和文本框联动正常
- [ ] 保存后注册表值正确（毫秒转换正确）
- [ ] 取消勾选后注册表键被删除
- [ ] 取消按钮不保存任何更改
- [ ] 无管理员权限时给出适当错误提示
- [ ] 窗口关闭后不报错
- [ ] 设置可以正常读取和保存

---

**测试完成后，请确保恢复原始设置！**
