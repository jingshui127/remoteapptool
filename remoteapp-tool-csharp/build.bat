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

REM 创建单文件发布目录
mkdir bin\Release\singlefile 2>nul

REM 复制主程序到单文件目录
copy bin\Release\net472\RemoteAppTool.exe bin\Release\singlefile\ 1>nul

REM 检查是否存在ILMerge
where ilmerge >nul 2>nul
if %errorlevel% neq 0 (
    echo 警告: 未找到ILMerge工具。正在尝试使用替代方法...
    
    REM 使用7-Zip自解压格式作为替代（如果7-Zip可用）
    where 7z >nul 2>nul
    if %errorlevel% neq 0 (
        echo 警告: 未找到7-Zip。单文件打包失败，但您仍可以使用bin\Release\net472目录中的文件。
        goto end
    )
    
    echo 使用7-Zip创建自解压可执行文件...
    7z a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on -sfx7z.sfx bin\Release\singlefile\RemoteAppTool_SingleFile.exe bin\Release\net472\*
    if %errorlevel% neq 0 (
        echo 错误: 创建7-Zip自解压文件失败。
        goto end
    )
    
    echo 自解压可执行文件创建成功: bin\Release\singlefile\RemoteAppTool_SingleFile.exe
    goto end
)

REM 使用ILMerge合并所有程序集
echo 使用ILMerge合并所有程序集...
ilmerge /target:winexe /out:bin\Release\singlefile\RemoteAppTool_SingleFile.exe /targetplatform:v4.7.2 bin\Release\net472\RemoteAppTool.exe bin\Release\net472\*.dll
if %errorlevel% neq 0 (
    echo 错误: ILMerge合并失败。
    
    REM 尝试使用另一种方法：将DLL嵌入到资源中
    echo 正在尝试使用替代方法...
    
    REM 使用基本复制方法，仅保留必要文件
    echo 复制最小必要文件集...
    copy bin\Release\net472\RemoteAppTool.exe bin\Release\singlefile\
    copy bin\Release\net472\*.dll bin\Release\singlefile\
    
    echo 已将文件复制到单文件目录。虽然不是真正的单文件，但已整理到一个文件夹中。
    goto end
)

echo 单文件打包成功: bin\Release\singlefile\RemoteAppTool_SingleFile.exe

echo.
echo ✓ 编译和打包成功！
echo 单文件可执行文件位于 bin\Release\singlefile 文件夹中。

:end
echo 基本输出文件位于 bin\Release\net472 文件夹中。