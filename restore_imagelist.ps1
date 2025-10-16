# PowerShell 脚本：批量恢复 ImageStream 初始化代码

$projectPath = "C:\Users\Administrator\source\repos\remoteapptool\remoteapp-tool-csharp"

# 需要处理的文件列表
$files = @(
    "RDPOptionsWindow.Designer.cs",
    "RemoteAppCreateClientConnection.Designer.cs",
    "RemoteAppHostOptions.Designer.cs",
    "RemoteAppIconPicker.Designer.cs"
)

foreach ($file in $files) {
    $filePath = Join-Path $projectPath $file
    
    if (Test-Path $filePath) {
        Write-Host "处理文件: $file"
        
        # 读取文件内容
        $content = Get-Content $filePath -Raw -Encoding UTF8
        
        # 移除注释标记，恢复 ImageStream 加载
        $content = $content -replace '//\s*暂时(不使用|注释掉)ImageStream.*?\r?\n\s*//\s*', ''
        $content = $content -replace '//\s*(this\.SmallerIcons\.ImageStream)', '$1'
        $content = $content -replace '//\s*(this\.SmallIcons\.ImageStream)', '$1'
        $content = $content -replace '//\s*(this\.SmallerIcons\.Images\.SetKeyName)', '$1'
        $content = $content -replace '//\s*(this\.SmallIcons\.Images\.SetKeyName)', '$1'
        $content = $content -replace '//\s*注释掉SetKeyName.*?\r?\n', ''
        
        # 保存文件
        [System.IO.File]::WriteAllText($filePath, $content, [System.Text.UTF8Encoding]::new($false))
        
        Write-Host "  ✓ 已处理"
    } else {
        Write-Host "  ✗ 文件不存在: $file"
    }
}

Write-Host "`n所有文件处理完成！"
