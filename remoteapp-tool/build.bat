@echo off
powershell -Command "Write-Host '正在尝试编译RemoteApp Tool项目...'"

REM 检查是否存在Visual Studio环境
if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" (
    powershell -Command "Write-Host '使用Visual Studio 2019 MSBuild'"
    "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" "RemoteApp Tool.vbproj" /p:Configuration=Debug
    goto end
)

if exist "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" (
    powershell -Command "Write-Host '使用Visual Studio 2017 MSBuild'"
    "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" "RemoteApp Tool.vbproj" /p:Configuration=Debug
    goto end
)

if exist "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" (
    powershell -Command "Write-Host '使用.NET Framework MSBuild'"
    "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" "RemoteApp Tool.vbproj" /p:Configuration=Debug
    goto end
)

echo 未找到合适的MSBuild工具，尝试使用dotnet build
dotnet build "RemoteApp Tool.vbproj"

:end
powershell -Command "Write-Host '编译完成' -ForegroundColor Green"
timeout /t 5