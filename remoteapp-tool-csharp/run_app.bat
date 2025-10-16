@echo off
REM 确保批处理文件在正确的目录中运行
pushd %~dp0

REM 检查可执行文件是否存在
if exist "bin\Debug\net48\RemoteApp Tool.exe" (
    echo 启动 RemoteApp Tool...
    "bin\Debug\net48\RemoteApp Tool.exe"
) else (
    echo 错误: 找不到 RemoteApp Tool.exe 文件。请确保已成功编译项目。
    echo 当前目录: %cd%
    dir "bin\Debug\net48"
    pause
)

popd