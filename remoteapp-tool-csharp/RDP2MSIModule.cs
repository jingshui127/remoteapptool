using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RemoteAppTool
{
    public static class RDP2MSIModule
    {
        public static string wxsPath;
        public static string wixobjPath;
        public static string wixpdbPath;
        public static string rdpFilePathD;

        // Commented out main method to avoid multiple entry points
        /*
        public static void Main()
        {
            string cmdRdpPath = "";
            string cmdSwitches = "DS";

            LogText("RDP2MSI" + Environment.NewLine);
            string[] args = Environment.GetCommandLineArgs();
            
            if (args.Length == 1)
            {
                ShowUsage();
                return;
            }
            else if (args.Length == 2)
            {
                cmdRdpPath = args[1];
            }
            else if (args.Length == 3)
            {
                if (args[1].StartsWith("/"))
                {
                    cmdSwitches = args[1];
                    cmdRdpPath = args[2];
                }
                else
                {
                    cmdSwitches = args[2];
                    cmdRdpPath = args[1];
                }
            }
            else if (args.Length > 3)
            {
                LogText("Error: Too many parameters provided.", true);
            }

            string relCmdRdpPath = Directory.GetCurrentDirectory() + "\\" + cmdRdpPath;
            if (!cmdRdpPath.Contains(":")) 
                cmdRdpPath = relCmdRdpPath;

            if (!File.Exists(cmdRdpPath)) 
                LogText("Error: Unable to find RDP file: " + cmdRdpPath, true);

            if (!cmdSwitches.ToUpper().Contains("D"))
            {
                if (!cmdSwitches.ToUpper().Contains("S"))
                {
                    cmdSwitches += "DS";
                }
            }

            if (cmdSwitches.ToUpper().Contains("~")) 
                LogText("命令行选项: " + cmdSwitches.ToUpper());

            RDP2MSI(cmdRdpPath, cmdSwitches.ToUpper());
        }
        */

        private static void LogText(string theText, bool doExit = false)
        {
            Console.WriteLine(theText);
            if (doExit == true)
            {
                CleanupTempFiles();
                Environment.Exit(1);
            }
        }

        public static void RDP2MSI(string rdpFilePath, string cmdParameters = "", string shortcutTag = "", string appPublisher = "", string flatFileTypes = "", bool perUser = false)
        {
            if (!File.Exists(rdpFilePath)) 
                LogText("错误: 无法找到 RDP 文件: " + rdpFilePath, true);
            if (!rdpFilePath.ToLower().EndsWith(".rdp")) 
                LogText("错误: 输入文件必须是 RDP 文件。", true);
            if (ReadRDPProperty(rdpFilePath, "remoteapplicationname") == "") 
                LogText("错误: RDP 文件不包含有效数据。", true);

            string rdpParentFolder = Path.GetDirectoryName(rdpFilePath);
            LogText("工作文件夹: " + rdpParentFolder);

            LogText("RDP 文件: " + rdpFilePath);
            string remoteAppFullName = ReadRDPProperty(rdpFilePath, "remoteapplicationname");
            LogText("应用完整名称: " + remoteAppFullName);
            string remoteAppShortName = ReadRDPProperty(rdpFilePath, "remoteapplicationprogram");
            LogText("应用简称: " + remoteAppShortName);

            string upgradeCode;
            if (cmdParameters.ToUpper().Contains("A"))
            {
                upgradeCode = GenerateGUIDfromString(remoteAppShortName);
            }
            else
            {
                var rnd = new Random();
                upgradeCode = GenerateGUIDfromString(rnd.Next().ToString());
            }
            LogText("升级代码: " + upgradeCode);

            string iconFilePath = rdpFilePath.Substring(0, rdpFilePath.Length - 4) + ".ico";

            bool hasIcon = false;
            if (File.Exists(iconFilePath))
            {
                hasIcon = true;
                LogText("找到图标: " + iconFilePath);
            }
            else
            {
                LogText("未找到图标。");
            }

            if (cmdParameters.ToUpper().Contains("T")) 
                shortcutTag = "";

            string rdpFileName = Path.GetFileName(rdpFilePath);
            string productFileName = rdpFileName.Substring(0, rdpFileName.Length - 4);

            string wxsString = GenerateWXSString(productFileName, remoteAppFullName, appPublisher, hasIcon, "1.0.0.0", upgradeCode, shortcutTag, cmdParameters, flatFileTypes, perUser);
            wxsPath = rdpParentFolder + "\\" + productFileName + ".wxs";
            wixobjPath = rdpParentFolder + "\\" + productFileName + ".wixobj";
            wixpdbPath = rdpParentFolder + "\\" + productFileName + ".wixpdb";
            string msiPath = rdpParentFolder + "\\" + productFileName + ".msi";

            var filesToDelete = new List<string>
            {
                rdpFilePath,
                wxsPath,
                wixobjPath,
                wixpdbPath
            };

            File.WriteAllText(wxsPath, wxsString, Encoding.UTF8);

            string wixPath = FindWixPath();
            if (wixPath == "")
            {
                LogText("错误: 无法找到 WiX 工具集。退出。", true);
            }
            else
            {
                LogText("在以下位置找到 WiX 工具集: " + wixPath);
            }

            string candlePath = wixPath + "\\candle.exe";
            string lightPath = wixPath + "\\light.exe";

            LogText("正在调用 WiX 工具集的 candle.exe");
            int candleExitCode = RunWait(candlePath, "-out \"" + wixobjPath + "\" \"" + wxsPath + "\"");
            if (candleExitCode == 0)
            {
                LogText("candle.exe 执行成功。");
            }
            else
            {
                LogText("错误: candle.exe 返回错误。", true);
            }

            LogText("正在调用 WiX 工具集的 light.exe");
            int lightExitCode = RunWait(lightPath, " -out \"" + msiPath + "\" \"" + wixobjPath + "\"");
            if (lightExitCode == 0)
            {
                LogText("light.exe 执行成功。");
            }
            else
            {
                LogText("错误: light.exe 返回错误。", true);
            }

            if (!cmdParameters.Contains("~"))
            {
                DeleteFiles(filesToDelete);
            }

            if (File.Exists(msiPath))
            {
                LogText(Path.GetFileName(msiPath) + " 创建成功。");
            }
            else
            {
                LogText("错误: MSI 创建失败。", true);
                MessageBox.Show("MSI 文件创建失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CleanupTempFiles()
        {
            if (File.Exists(rdpFilePathD)) File.Delete(rdpFilePathD);
            if (File.Exists(wxsPath)) File.Delete(wxsPath);
            if (File.Exists(wixobjPath)) File.Delete(wixobjPath);
            if (File.Exists(wixpdbPath)) File.Delete(wixpdbPath);
        }
        
        public static bool WixInstalled()
        {
            string wixPath = FindWixPath();
            return !string.IsNullOrEmpty(wixPath);
        }

        private static string FindWixPath()
        {
            LogText("正在查找 WiX 工具集");
            string searchExe = "\\candle.exe";
            string wixPath = "";
            string currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string wixIniPath = ReadIni(currentDir + "\\rdp2msi.ini", "WIX", "binpath", currentDir + "\\wix").TrimEnd('\\');
            
            if (File.Exists(wixIniPath + searchExe))
            {
                wixPath = wixIniPath;
            }
            else if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WIX")))
            {
                wixPath = Environment.GetEnvironmentVariable("WIX") + "bin";
            }
            else if (Directory.Exists(currentDir + "\\wix") && File.Exists(currentDir + "\\wix" + searchExe))
            {
                wixPath = currentDir + "\\wix";
            }
            else if (Directory.Exists(currentDir + "\\bin") && File.Exists(currentDir + "\\bin" + searchExe))
            {
                wixPath = currentDir + "\\bin";
            }
            return wixPath;
        }

        private static void ShowUsage()
        {
            LogText("用法: rdp2msi.exe [/DSNAT] rdpfile.rdp");
            LogText("");
            LogText("参数说明:");
            LogText("");
            LogText("  /D     MSI 将创建桌面快捷方式");
            LogText("  /S     MSI 将在开始菜单 > 程序 > (应用名称) 中创建快捷方式");
            LogText("  /N     需要 /S。MSI 不会在开始菜单 > 程序中创建子文件夹");
            LogText("  /A     基于应用名称生成升级代码，否则为随机生成");
            LogText("  /T     不在部署的快捷方式上包含 (remote) 标记");
            LogText("");
            LogText("如果未指定任何参数，则默认使用 /DS。");
            LogText("");
        }

        private static string GenerateWXSString(string productFileName, string productName, string productPublisher = "", bool hasIcon = false, string productVersion = "1.0.0.0", string productUpgradeCode = "random", string productRemoteTag = "remote", string shortcutLocations = "DS", string flatFileTypes = "", bool perUser = false)
        {
            var rnd = new Random();

            if (productUpgradeCode == "random") 
                productUpgradeCode = GenerateGUIDfromString(rnd.Next().ToString());
            if (productPublisher == "") 
                productPublisher = productName;

            string regRoot = "HKLM";
            if (perUser == true) 
                regRoot = "HKCU";

            var fileTypes = new List<string>();
            if (!string.IsNullOrEmpty(flatFileTypes)) 
                fileTypes.AddRange(flatFileTypes.Split('|'));

            string appFilesGuid = GenerateGUIDfromString("AppFiles" + productUpgradeCode);
            string appStartShortcutsGuid = GenerateGUIDfromString("AppStartShortcuts" + productUpgradeCode);
            string appDeskShortcutsGuid = GenerateGUIDfromString("AppDeskShortcuts" + productUpgradeCode);

            var wxsString = new StringBuilder();
            wxsString.AppendLine("<?xml version=\"1.0\"?>");
            wxsString.AppendLine("<?define ProductVersion = \"" + productVersion + "\"?>");
            wxsString.AppendLine("<?define ProductUpgradeCode = \"" + productUpgradeCode + "\"?>");
            wxsString.AppendLine("<?define AppFilesGuid = \"" + appFilesGuid + "\"?>");
            wxsString.AppendLine("<?define AppStartShortcutsGuid = \"" + appStartShortcutsGuid + "\"?>");
            wxsString.AppendLine("<?define AppDeskShortcutsGuid = \"" + appDeskShortcutsGuid + "\"?>");
            wxsString.AppendLine("<?define ProductName = \"" + productName + "\"?>");
            wxsString.AppendLine("<?define ProductPublisher = \"" + productPublisher + "\"?>");
            wxsString.AppendLine("<?define ProductFileName = \"" + productFileName + "\"?>");
            wxsString.AppendLine("<?define RegRoot = \"" + regRoot + "\"?>");
            if (!string.IsNullOrEmpty(productRemoteTag)) 
                productRemoteTag = " (" + productRemoteTag + ")";
            wxsString.AppendLine("<?define ProductRemoteTag = \"" + productRemoteTag + "\"?>");
            wxsString.AppendLine("<Wix xmlns=\"http://schemas.microsoft.com/wix/2006/wi\">");

            wxsString.AppendLine("   <Product Id=\"*\" UpgradeCode=\"$(var.ProductUpgradeCode)\" ");
            wxsString.AppendLine("            Name=\"$(var.ProductName)$(var.ProductRemoteTag)\" Version=\"$(var.ProductVersion)\" Manufacturer=\"$(var.ProductPublisher)\" Language=\"1033\">");
            wxsString.Append("      <Package InstallerVersion=\"200\" Compressed=\"yes\" Comments=\"Windows Installer Package\"");
            if (!perUser)
            {
                wxsString.Append(" InstallScope=\"perMachine\"");
            }
            else
            {
                wxsString.Append(" InstallPrivileges=\"limited\"");
            }

            wxsString.AppendLine("/>");
            wxsString.AppendLine("      <Media Id=\"1\" Cabinet=\"rdp2msi.cab\" EmbedCab=\"yes\"/>");
            if (!perUser) 
                wxsString.AppendLine("      <Property Id=\"AllUSERS\" Value=\"1\"/>");
            wxsString.AppendLine("      <Upgrade Id=\"$(var.ProductUpgradeCode)\">");
            wxsString.AppendLine("         <UpgradeVersion Minimum=\"$(var.ProductVersion)\" OnlyDetect=\"yes\" Property=\"NEWERVERSIONDETECTED\"/>");
            wxsString.AppendLine("         <UpgradeVersion Minimum=\"0.0.0\" Maximum=\"$(var.ProductVersion)\" IncludeMinimum=\"yes\" IncludeMaximum=\"no\" ");
            wxsString.AppendLine("                         Property=\"OLDERVERSIONBEINGUPGRADED\"/>	  ");
            wxsString.AppendLine("      </Upgrade>");
            wxsString.AppendLine("      <Condition Message=\"A newer version of this software is already installed.\">NOT NEWERVERSIONDETECTED</Condition>");
            wxsString.AppendLine("      <Property Id=\"MstscProperty\" Value=\"mstsc.exe\"/>");
            wxsString.AppendLine("      <Directory Id=\"TARGETDIR\" Name=\"SourceDir\">");
            if (!perUser)
            {
                wxsString.AppendLine("         <Directory Id=\"ProgramFilesFolder\">");
            }
            else
            {
                wxsString.AppendLine("         <Directory Id=\"LocalAppDataFolder\">");
            }
            wxsString.AppendLine("            <Directory Id=\"INSTALLDIR\" Name=\"RemotePackages\">");
            wxsString.AppendLine("               <Component Id=\"ApplicationFiles\" Guid=\"$(var.AppFilesGuid)\">");
            wxsString.AppendLine("                  <File Id=\"rdpFile1\" Source=\"$(var.ProductFileName).rdp\"/>");
            if (hasIcon) 
                wxsString.AppendLine("				  <File Id=\"rdpIcon1\" Source=\"$(var.ProductFileName).ico\"/>");
            
            if (!string.IsNullOrEmpty(flatFileTypes))
            {
                foreach (string fileType in fileTypes)
                {
                    wxsString.AppendLine("				  <File Id=\"$(var.ProductFileName)_" + fileType + ".ico\" Source=\"$(var.ProductFileName)_" + fileType + ".ico\" />");
                    wxsString.AppendLine("				  <ProgId Id=\"remote.$(var.ProductFileName)." + fileType + "file\" Description=\"$(var.ProductName) " + fileType + " file\" Icon=\"$(var.ProductFileName)_" + fileType + ".ico\">");
                    wxsString.AppendLine("				  <Extension Id=\"" + fileType + "\" ContentType=\"application/" + fileType + "\">");
                    wxsString.AppendLine("				  <Verb Id=\"open\" Command=\"Open\" TargetProperty='MstscProperty' Argument='/REMOTEFILE:\"%1\" \"[INSTALLDIR]$(var.ProductFileName).rdp\"' />");
                    wxsString.AppendLine("				  </Extension>");
                    wxsString.AppendLine("				  </ProgId>");
                }
            }
            wxsString.AppendLine("               </Component>");
            wxsString.AppendLine("            </Directory>");
            wxsString.AppendLine("		</Directory>");

            if (shortcutLocations.ToUpper().Contains("S"))
            {
                wxsString.AppendLine("         <Directory Id=\"ProgramMenuFolder\">");
                if (!shortcutLocations.ToUpper().Contains("N")) 
                    wxsString.AppendLine("            <Directory Id=\"ProgramMenuSubfolder\" Name=\"$(var.ProductName)$(var.ProductRemoteTag)\">");
                wxsString.AppendLine("               <Component Id=\"ApplicationStartShortcuts\" Guid=\"$(var.AppStartShortcutsGuid)\">");
                wxsString.AppendLine("                  <Shortcut Id=\"rdpStartShortcut1\" Name=\"$(var.ProductName)$(var.ProductRemoteTag)\" Description=\"$(var.ProductName)$(var.ProductRemoteTag)\" ");
                wxsString.Append("                            Target=\"[INSTALLDIR]$(var.ProductFileName).rdp\" WorkingDirectory=\"INSTALLDIR\"");

                if (hasIcon)
                {
                    wxsString.AppendLine(" Icon=\"rdpStartIcon.rdp\" IconIndex=\"0\">");
                    wxsString.AppendLine("							<Icon Id=\"rdpStartIcon.rdp\" SourceFile=\"$(var.ProductFileName).ico\" />");
                    wxsString.AppendLine("				  </Shortcut>");
                }
                else
                {
                    wxsString.AppendLine("/>");
                }

                wxsString.AppendLine("                  <RegistryValue Root=\"$(var.RegRoot)\" Key=\"Software\\RDP2MSI\\$(var.ProductName)\" ");
                wxsString.AppendLine("                            Name=\"installed\" Type=\"integer\" Value=\"1\" KeyPath=\"yes\"/>");
                wxsString.AppendLine("                  <RemoveFolder Id=\"ProgramMenuSubfolder\" On=\"uninstall\"/>");
                wxsString.AppendLine("               </Component>");
                if (!shortcutLocations.ToUpper().Contains("N")) 
                    wxsString.AppendLine("            </Directory>");
                wxsString.AppendLine("         </Directory>");
            }

            if (shortcutLocations.ToUpper().Contains("D"))
            {
                wxsString.AppendLine("	     <Directory Id=\"DesktopFolder\">");
                wxsString.AppendLine("		   <Component Id=\"ApplicationDesktopShortcuts\" Guid=\"$(var.AppDeskShortcutsGuid)\">");
                wxsString.AppendLine("			  <Shortcut Id=\"rdpDesktopShortcut1\" Name=\"$(var.ProductName)$(var.ProductRemoteTag)\" Description=\"$(var.ProductName)$(var.ProductRemoteTag)\" ");
                wxsString.Append("						Target=\"[INSTALLDIR]$(var.ProductFileName).rdp\" WorkingDirectory=\"INSTALLDIR\"");

                if (hasIcon)
                {
                    wxsString.AppendLine(" Icon=\"rdpDeskIcon.rdp\" IconIndex=\"0\">");
                    wxsString.AppendLine("						<Icon Id=\"rdpDeskIcon.rdp\" SourceFile=\"$(var.ProductFileName).ico\" />");
                    wxsString.AppendLine("			  </Shortcut>");
                }
                else
                {
                    wxsString.AppendLine("/>");
                }

                wxsString.AppendLine("			  <RegistryValue Root=\"$(var.RegRoot)\" Key=\"Software\\RDP2MSI\\$(var.ProductName)\" ");
                wxsString.AppendLine("						Name=\"installed\" Type=\"integer\" Value=\"1\" KeyPath=\"yes\"/>");
                wxsString.AppendLine("		   </Component>");
                wxsString.AppendLine("         </Directory>");
            }
            wxsString.AppendLine("		</Directory>");

            wxsString.AppendLine("      <InstallExecuteSequence>");
            wxsString.AppendLine("         <RemoveExistingProducts After=\"InstallValidate\"/>");
            wxsString.AppendLine("      </InstallExecuteSequence>");
            wxsString.AppendLine(" ");
            wxsString.AppendLine("      <Feature Id=\"DefaultFeature\" Level=\"1\">");
            wxsString.AppendLine("         <ComponentRef Id=\"ApplicationFiles\"/>");
            if (shortcutLocations.ToUpper().Contains("S")) 
                wxsString.AppendLine("         <ComponentRef Id=\"ApplicationStartShortcuts\"/>");
            if (shortcutLocations.ToUpper().Contains("D")) 
                wxsString.AppendLine("		 <ComponentRef Id=\"ApplicationDesktopShortcuts\"/>");
            wxsString.AppendLine("      </Feature>");
            if (hasIcon)
            {
                wxsString.AppendLine("<Icon Id=\"rdpARPIcon.rdp\" SourceFile=\"$(var.ProductFileName).ico\" />");
                wxsString.AppendLine("<Property Id=\"ARPPRODUCTICON\" Value=\"rdpARPIcon.rdp\" />");
            }
            wxsString.AppendLine("   </Product>");
            wxsString.AppendLine("</Wix>");

            return wxsString.ToString();
        }

        private static string ReadRDPProperty(string rdpFile, string rdpProperty)
        {
            string rdpFileContents = File.ReadAllText(rdpFile);
            string[] rdpFileLines = rdpFileContents.Split('\n');
            string rdpValue = "";
            
            foreach (string rdpLine in rdpFileLines)
            {
                string cleanLine = rdpLine.Replace("\r", "").Replace("|", "");
                string[] rdpLineSplit = cleanLine.Split(new char[] { ':' }, 3);
                if (rdpLineSplit.Length >= 3 && rdpLineSplit[0] == rdpProperty)
                {
                    rdpValue = rdpLineSplit[2];
                }
            }
            return rdpValue;
        }

        private static string GenerateGUIDfromString(string theString)
        {
            string theHash = GetMD5Hash(theString);
            var myGuid = new Guid(theHash);
            return myGuid.ToString();
        }

        private static string GetMD5Hash(string strToHash)
        {
            using (var md5 = MD5.Create())
            {
                byte[] bytesToHash = Encoding.ASCII.GetBytes(strToHash);
                bytesToHash = md5.ComputeHash(bytesToHash);

                var result = new StringBuilder();
                foreach (byte b in bytesToHash)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        public static void WriteIni(string iniFileName, string section, string paramName, string paramVal)
        {
            WritePrivateProfileString(section, paramName, paramVal, iniFileName);
        }

        public static string ReadIni(string iniFileName, string section, string paramName, string paramDefault)
        {
            var paramVal = new StringBuilder(1024);
            int lenParamVal = GetPrivateProfileString(section, paramName, paramDefault, paramVal, paramVal.Capacity, iniFileName);
            return paramVal.ToString().Substring(0, lenParamVal);
        }

        public static int RunWait(string app, string parameters)
        {
            var proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.FileName = app;
            proc.StartInfo.Arguments = parameters;
            proc.Start();
            proc.WaitForExit();
            return proc.ExitCode;
        }

        private static void DeleteFiles(List<string> filesToDelete)
        {
            foreach (string file in filesToDelete)
            {
                try
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }
                catch (Exception ex)
                {
                    // 记录错误但继续执行
                    Console.WriteLine("警告: 无法删除文件 " + file + ": " + ex.Message);
                }
            }
        }
    }
}