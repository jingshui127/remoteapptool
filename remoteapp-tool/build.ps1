# RemoteApp Tool 编译脚本
Write-Host "正在尝试编译RemoteApp Tool项目..." -ForegroundColor Yellow

# 检查是否存在Visual Studio环境
if (Test-Path "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe") {
    Write-Host "使用Visual Studio 2019 MSBuild" -ForegroundColor Green
    & "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" "RemoteApp Tool.vbproj" /p:Configuration=Debug
    exit $LASTEXITCODE
}

if (Test-Path "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe") {
    Write-Host "使用Visual Studio 2017 MSBuild" -ForegroundColor Green
    & "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" "RemoteApp Tool.vbproj" /p:Configuration=Debug
    exit $LASTEXITCODE
}

if (Test-Path "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe") {
    Write-Host "使用.NET Framework MSBuild" -ForegroundColor Green
    & "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" "RemoteApp Tool.vbproj" /p:Configuration=Debug
    exit $LASTEXITCODE
}

Write-Host "未找到合适的MSBuild工具，尝试使用dotnet build" -ForegroundColor Yellow
dotnet build "RemoteApp Tool.vbproj"
exit $LASTEXITCODE