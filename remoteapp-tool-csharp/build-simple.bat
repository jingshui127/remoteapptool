@echo off
echo 正在编译 RemoteApp Tool C# 项目...
echo.

REM 使用 MSBuild 编译项目
echo 使用 .NET Framework MSBuild...
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" RemoteAppTool.csproj /t:Build /p:Configuration=Release /v:minimal

if %errorlevel% equ 0 (
    echo.
    echo ✓ 编译成功！
    echo 输出文件位于: bin\Release\net48\
    echo.
) else (
    echo.
    echo ✗ 编译失败，请检查错误信息。
    echo.
)

pause
