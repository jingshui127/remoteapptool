# 剩余 ImageList 修复清单

## 📋 概述

虽然 RemoteAppEditWindow 的 ImageList 问题已修复，但还有 **5 个窗口**存在相同的问题，需要继续修复。

---

## 🔴 需要修复的窗口

### 1. RDPOptionsWindow ⚠️ 高优先级

**文件：**
- `RDPOptionsWindow.Designer.cs` (第 150-157 行)
- `RDPOptionsWindow.resx` ✅ 已复制

**ImageList：** SmallerIcons (7个图标，索引 0-6)

**图标列表：**
0. save-as_16x16.png
1. msi small.ico
2. doc_file_document_manager_paper_phone.ico
3. 16.ico
4. cross.ico
5. pictures (1).ico
6. Remote Desktop Connection.ico

**使用 ImageIndex 的按钮：**
- ResetButton: ImageIndex = 4 (cross.ico)
- DefaultsButton: ImageIndex = 3 (16.ico)
- ResetValueButton: ImageIndex = 4 (cross.ico)

**需要修改的代码：**
```csharp
// 第 150-157 行，需要取消注释：
this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
this.SmallerIcons.Images.SetKeyName(0, "save-as_16x16.png");
this.SmallerIcons.Images.SetKeyName(1, "msi small.ico");
this.SmallerIcons.Images.SetKeyName(2, "doc_file_document_manager_paper_phone.ico");
this.SmallerIcons.Images.SetKeyName(3, "16.ico");
this.SmallerIcons.Images.SetKeyName(4, "cross.ico");
this.SmallerIcons.Images.SetKeyName(5, "pictures (1).ico");
this.SmallerIcons.Images.SetKeyName(6, "Remote Desktop Connection.ico");
```

---

### 2. RemoteAppCreateClientConnection ⚠️ 高优先级

**文件：**
- `RemoteAppCreateClientConnection.Designer.cs` (第 110-120 行)
- `RemoteAppCreateClientConnection.resx` ✅ 已复制

**ImageList：** SmallerIcons (7个图标，索引 0-6)

**使用 ImageIndex 的按钮：** 11 个！
- SaveButton: ImageIndex = 0
- EditAfterSave: ImageIndex = 2
- ResetButton: ImageIndex = 3
- CancelEditButton: ImageIndex = 4
- CreateRAWebIcon: ImageIndex = 5
- CreateButton: ImageIndex = 6
- FTAButton: ImageIndex = 2
- RDPOptionsButton: ImageIndex = 6

**图标列表：**
0. favorites_16x16.png
1. folder_16x16.png
2. doc_file_document_manager_paper_phone.ico
3. 16.ico
4. cross.ico
5. pictures (1).ico
6. Remote Desktop Connection.ico

**需要修改的代码：**
```csharp
// 第 111-120 行，需要取消注释：
this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
this.SmallerIcons.Images.SetKeyName(0, "favorites_16x16.png");
this.SmallerIcons.Images.SetKeyName(1, "folder_16x16.png");
this.SmallerIcons.Images.SetKeyName(2, "doc_file_document_manager_paper_phone.ico");
this.SmallerIcons.Images.SetKeyName(3, "16.ico");
this.SmallerIcons.Images.SetKeyName(4, "cross.ico");
this.SmallerIcons.Images.SetKeyName(5, "pictures (1).ico");
this.SmallerIcons.Images.SetKeyName(6, "Remote Desktop Connection.ico");
```

---

### 3. RemoteAppFileTypeAssociation

**文件：**
- `RemoteAppFileTypeAssociation.Designer.cs`
- `RemoteAppFileTypeAssociation.resx` ✅ 已复制

**ImageList：** 
- SmallerIcons (5个图标，索引 0-4)
- SmallerIcons2 (1个图标)

**使用 ImageIndex 的按钮：**
- CreateButton: ImageIndex = 1
- DeleteButton: ImageIndex = 2
- EditButton: ImageIndex = 0
- CloseButton: ImageIndex = 3
- SetAssociationButton: ImageIndex = 4

**图标列表（SmallerIcons）：**
0. properties.ico
1. plus.ico
2. minus.ico
3. cross.ico
4. doc_file_document_manager_paper_phone.ico

**需要修改的代码：**
```csharp
// 第 119-124 行，需要取消注释：
this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
this.SmallerIcons.Images.SetKeyName(0, "properties.ico");
this.SmallerIcons.Images.SetKeyName(1, "plus.ico");
this.SmallerIcons.Images.SetKeyName(2, "minus.ico");
this.SmallerIcons.Images.SetKeyName(3, "cross.ico");
this.SmallerIcons.Images.SetKeyName(4, "doc_file_document_manager_paper_phone.ico");

// 第 213-215 行，需要取消注释：
this.SmallerIcons2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons2.ImageStream")));
this.SmallerIcons2.TransparentColor = System.Drawing.Color.Transparent;
this.SmallerIcons2.Images.SetKeyName(0, "cross.ico");
```

---

### 4. RemoteAppHostOptions

**文件：**
- `RemoteAppHostOptions.Designer.cs` (第 145-148 行)
- `RemoteAppHostOptions.resx` ✅ 已复制

**ImageList：** SmallerIcons (2个图标，索引 0-1)

**使用 ImageIndex 的按钮：**
- SaveButton: ImageIndex = 0
- CancelEditButton: ImageIndex = 1

**图标列表：**
0. favorites_16x16.png
1. cross.ico

**需要修改的代码：**
```csharp
// 第 146-148 行，需要取消注释：
this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
this.SmallerIcons.Images.SetKeyName(0, "favorites_16x16.png");
this.SmallerIcons.Images.SetKeyName(1, "cross.ico");
```

---

### 5. RemoteAppIconPicker

**文件：**
- `RemoteAppIconPicker.Designer.cs` (第 134-160 行)
- `RemoteAppIconPicker.resx` ✅ 已复制

**ImageList：** 
- SmallIcons (用于图标列表显示)
- SmallerIcons (1个图标，索引 0)

**使用 ImageIndex 的按钮：**
- BrowseButton: ImageIndex = 0

**图标列表（SmallerIcons）：**
0. folder_16x16.png

**需要修改的代码：**
```csharp
// 第 135-136 行，需要取消注释：
this.SmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallIcons.ImageStream")));
this.SmallIcons.Images.SetKeyName(0, "smallicons.ico");

// 第 159-160 行，需要取消注释：
this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
this.SmallerIcons.Images.SetKeyName(0, "folder_16x16.png");
```

---

## 📊 修复统计

| 窗口 | ImageList 数量 | 图标总数 | 使用图标的按钮数 | 优先级 | 状态 |
|------|---------------|---------|----------------|--------|------|
| RemoteAppEditWindow | 1 | 9 | 6 | P0 | ✅ 已完成 |
| RDPOptionsWindow | 1 | 7 | 3 | P1 | ⏳ 待修复 |
| RemoteAppCreateClientConnection | 1 | 7 | 11 | P1 | ⏳ 待修复 |
| RemoteAppFileTypeAssociation | 2 | 6 | 5 | P2 | ⏳ 待修复 |
| RemoteAppHostOptions | 1 | 2 | 2 | P2 | ⏳ 待修复 |
| RemoteAppIconPicker | 2 | 2 | 1 | P2 | ⏳ 待修复 |
| **总计** | **8** | **33** | **28** | - | **17% 完成** |

---

## 🛠️ 修复步骤

### 自动化方案（推荐）

1. ✅ **复制资源文件** - 已完成
   ```powershell
   Copy-Item "remoteapp-tool\*.resx" "remoteapp-tool-csharp\" -Force
   ```

2. ⏳ **恢复 Designer.cs 中的注释代码**
   对每个文件执行以下替换：
   - 移除 `// 暂时注释掉ImageStream...` 注释行
   - 取消注释 `this.SmallerIcons.ImageStream = ...`
   - 取消注释所有 `this.SmallerIcons.Images.SetKeyName(...)`
   - 移除 `// 注释掉SetKeyName调用...` 注释行

### 手动方案

逐个文件手动编辑，取消注释 ImageStream 相关代码。

---

## ⚡ 快速修复命令

可以使用以下 PowerShell 命令批量处理：

```powershell
# 在项目根目录执行
cd c:\Users\Administrator\source\repos\remoteapptool\remoteapp-tool-csharp

# 对每个文件执行 search_replace 工具
# 示例：RDPOptionsWindow.Designer.cs
```

---

## 🎯 预期修复效果

修复完成后：
- ✅ 所有按钮图标正常显示
- ✅ 不再出现 IndexOutOfRangeException 异常
- ✅ 不再出现 InvalidOperationException 异常
- ✅ 100% 还原 VB.NET 版本的图标功能
- ✅ 编译 0 错误，0 警告

---

## 📝 注意事项

1. **备份文件：** 修改前建议备份 Designer.cs 文件
2. **编码格式：** 确保保存为 UTF-8 无 BOM 格式
3. **测试验证：** 修复后需要测试每个窗口的图标显示
4. **资源文件：** 确保对应的 .resx 文件已从 VB.NET 项目复制

---

*生成时间：2025-10-14*  
*当前进度：1/6 窗口已修复 (17%)*
