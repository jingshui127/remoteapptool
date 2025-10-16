@echo off
echo 正在编译 RemoteApp Tool C# 项目...
echo.

REM 检查是否安装了dotnet\mwhere dotnet >nul 2>nul
if %errorlevel% neq 0 (
    echo 错误: 未找到 .NET SDK。请安装 .NET SDK。
    exit /b 1
)

REM 还原NuGet包
echo 正在还原NuGet包...
dotnet restore
if %errorlevel% neq 0 (
    echo 错误: 还原NuGet包失败。
    exit /b 1
)

REM 编译项目
echo 正在编译项目...
dotnet build --configuration Release
if %errorlevel% neq 0 (
    echo 错误: 项目编译失败。
    exit /b 1
)

echo.
echo ✓ 编译成功！
echo 输出文件位于 bin\Release\net48 文件夹中。