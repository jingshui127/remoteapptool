using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteAppLib;

namespace RemoteApp_Tool
{
    public static class LocalFtaModule
    {
        public static void RemoveUnusedFTAs()
        {
            string[] KeyNames = Microsoft.Win32.Registry.ClassesRoot.GetSubKeyNames();
            int RemoveCount = 0;

            foreach (string KeyName in KeyNames)
            {
                Microsoft.Win32.RegistryKey FTAkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(KeyName);
                // 修复类型转换错误
                object raValueObj = FTAkey.GetValue("RemoteApp", "");
                string RAvalue = raValueObj?.ToString() ?? "";
                if (RAvalue != "")
                {
                    foreach (string KeyName2 in KeyNames)
                    {
                        try
                        {
                            Microsoft.Win32.RegistryKey FTkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(KeyName2);
                            // 修复类型转换错误
                            object ftValueObj = FTkey.GetValue("", "");
                            string FTvalue = ftValueObj?.ToString() ?? "";
                            if (FTvalue == KeyName)
                            {
                                var sra = new RemoteAppLib.SystemRemoteApps();
                                bool AppExists = false;
                                foreach (RemoteAppLib.RemoteApp app in sra.GetAll())
                                {
                                    if (app.Name == GetAppForFTA(KeyName2)) AppExists = true;
                                }
                                if (!AppExists)
                                {
                                    LocalFtaModule.DeleteFTA(KeyName2);
                                    RemoveCount += 1;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            // 忽略异常
                        }
                    }
                }
            }

            System.Windows.Forms.MessageBox.Show("已移除未使用的文件类型关联：" + RemoveCount, "文件类型关联", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static string CreateFTACollection(FileTypeAssociationCollection ftaCol, string exeFile, string RemoteAppName, bool overwrite = false)
        {
            string CreateFTACollection = "";
            foreach (FileTypeAssociation fta in ftaCol)
            {
                if (DoesFTAExist(fta.Extension) && CreateFTA(fta, exeFile, RemoteAppName, overwrite) == false)
                {
                    CreateFTACollection += "|" + fta.Extension;
                }
            }
            CreateFTACollection = CreateFTACollection.Trim('|');
            return CreateFTACollection;
        }

        public static bool CreateFTA(FileTypeAssociation fta, string exeFile, string RemoteAppName, bool overwrite = false)
        {
            if (!DoesFTAExist(fta.Extension) || overwrite == true)
            {
                DeleteFTA(fta.Extension);

                Microsoft.Win32.RegistryKey FileTypeReg = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("." + fta.Extension);
                FileTypeReg.SetValue("", fta.Extension + "_file");

                Microsoft.Win32.RegistryKey FileTypeKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(fta.Extension + "_file");
                FileTypeKey.SetValue("RemoteApp", RemoteAppName);

                Microsoft.Win32.RegistryKey FileTypeKeyShell = FileTypeKey.CreateSubKey("shell");
                Microsoft.Win32.RegistryKey FileTypeKeyShellOpen = FileTypeKeyShell.CreateSubKey("open");
                Microsoft.Win32.RegistryKey FileTypeKeyShellOpenCommand = FileTypeKeyShellOpen.CreateSubKey("command");

                FileTypeKeyShellOpenCommand.SetValue("", "\"" + exeFile + "\" \"%1\"");

                Microsoft.Win32.RegistryKey FileTypeKeyDefIcon = FileTypeKey.CreateSubKey("DefaultIcon");
                FileTypeKeyDefIcon.SetValue("", "\"" + fta.IconPath + "\"," + fta.IconIndex);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetAppForFTA(string fileExtension)
        {
            fileExtension = fileExtension.TrimStart('.');
            string GetAppForFTA = "";

            if (DoesFTAExist(fileExtension) && IsFTAMine(fileExtension))
            {
                try
                {
                    Microsoft.Win32.RegistryKey HKCRext = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + fileExtension);
                    // 修复类型转换错误
                    object hkcrFtaObj = HKCRext.GetValue("", "");
                    string HKCRfta = hkcrFtaObj?.ToString() ?? "";
                    if (HKCRfta != "")
                    {
                        Microsoft.Win32.RegistryKey HKCRftaKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(HKCRfta);
                        // 修复类型转换错误
                        object remoteAppObj = HKCRftaKey.GetValue("RemoteApp", "");
                        GetAppForFTA = remoteAppObj?.ToString() ?? "";
                    }
                }
                catch (Exception)
                {
                    // 忽略异常
                }
            }
            return GetAppForFTA;
        }

        public static void DeleteFTA(string fileExtension)
        {
            fileExtension = fileExtension.TrimStart('.');
            if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + fileExtension) != null)
                Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree("." + fileExtension);

            if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(fileExtension + "_file") != null)
                Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(fileExtension + "_file");
        }

        public static bool DoesFTAExist(string fileExtension)
        {
            fileExtension = fileExtension.TrimStart('.');
            bool FTAexists = false;

            if (Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + fileExtension) != null)
            {
                FTAexists = true;
            }

            return FTAexists;
        }

        public static bool IsFTAMine(string fileExtension)
        {
            fileExtension = fileExtension.TrimStart('.');
            bool IsFTAMine = false;
            try
            {
                Microsoft.Win32.RegistryKey HKCRext = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + fileExtension);
                // 修复类型转换错误
                object hkcrFtaObj = HKCRext.GetValue("", "");
                string HKCRfta = hkcrFtaObj?.ToString() ?? "";
                if (HKCRfta != "")
                {
                    Microsoft.Win32.RegistryKey HKCRftaKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(HKCRfta);
                    // 修复类型转换错误
                    object remoteAppObj = HKCRftaKey.GetValue("RemoteApp", "");
                    string remoteAppStr = remoteAppObj?.ToString() ?? "";
                    if (remoteAppStr != "") IsFTAMine = true;
                }
            }
            catch (Exception)
            {
                // 忽略异常
            }
            return IsFTAMine;
        }
    }
}