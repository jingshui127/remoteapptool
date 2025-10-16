@echo off

REM Simple Single File Release Script
echo Building and creating single file release...

REM Ensure the target directory exists
mkdir bin\Release\singlefile 2>nul

REM Copy all necessary files to singlefile directory
echo Copying files to release directory...
copy bin\Release\net472\RemoteAppTool.exe bin\Release\singlefile\ 1>nul
copy bin\Release\net472\*.dll bin\Release\singlefile\ 1>nul
copy bin\Release\net472\*.config bin\Release\singlefile\ 1>nul 2>nul

REM Create a simple batch launcher
@echo off > bin\Release\singlefile\Launch_RemoteAppTool.bat
@echo REM RemoteApp Tool Launcher >> bin\Release\singlefile\Launch_RemoteAppTool.bat
@echo cd /d "%%~dp0" >> bin\Release\singlefile\Launch_RemoteAppTool.bat
@echo start RemoteAppTool.exe >> bin\Release\singlefile\Launch_RemoteAppTool.bat

REM Create a shortcut script that can be placed elsewhere
@echo off > bin\Release\singlefile\RemoteAppTool_Shortcut.bat
@echo REM RemoteApp Tool Shortcut >> bin\Release\singlefile\RemoteAppTool_Shortcut.bat
@echo cd /d "%%~dp0" >> bin\Release\singlefile\RemoteAppTool_Shortcut.bat
@echo start RemoteAppTool.exe >> bin\Release\singlefile\RemoteAppTool_Shortcut.bat

REM For a real "single file" experience, we need a tool like ILMerge or .NET Core's PublishSingleFile
REM This solution organizes all files into one folder for easier deployment

echo Single file release completed!
echo Files are located in: bin\Release\singlefile\
echo You can copy this folder to any location and run RemoteAppTool.exe directly