using System;
using System.Collections;
using Microsoft.Win32;

namespace RemoteAppLib
{
    public class RemoteAppCollection : CollectionBase
    {
        public void Add(RemoteApp remoteApp)
        {
            List.Add(remoteApp);
        }

        public void Remove(RemoteApp remoteApp)
        {
            List.Remove(remoteApp);
        }
    }

    public class RemoteApp
    {
        public string Name;
        public string FullName;
        public string Path;
        public string VPath;
        public string IconPath;
        public int IconIndex = 0;
        public string CommandLine = "";
        public int CommandLineOption = 1;
        public bool TSWA = false;
        public FileTypeAssociationCollection FileTypeAssociations;
    }

    public class FileTypeAssociation
    {
        public string Extension;
        public string IconPath;
        public string IconIndex;
    }

    public class FileTypeAssociationCollection : CollectionBase
    {
        public void Add(FileTypeAssociation fileTypeAssociation)
        {
            List.Add(fileTypeAssociation);
        }

        public void Remove(FileTypeAssociation fileTypeAssociation)
        {
            List.Remove(fileTypeAssociation);
        }

        public string GetFlatFileTypes()
        {
            string flatFileTypes = "";
            if (List.Count > 0)
            {
                foreach (FileTypeAssociation listItem in List)
                {
                    flatFileTypes += ",." + listItem.Extension;
                }
                flatFileTypes = flatFileTypes.Substring(1);
            }
            return flatFileTypes;
        }
    }

    public class IconSelection
    {
        public string IconPath;
        public string IconIndex;
    }

    public class SystemRemoteApps
    {
        private bool Legacy32bit = false;
        private string RegistryPath = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Terminal Server\\TSAppAllowList\\Applications";
        private RegistryKey BaseKey;
        private RegistryKey BaseKeyWrite;

        public SystemRemoteApps()
        {
            BaseKey = Registry.LocalMachine.OpenSubKey(RegistryPath);
            BaseKeyWrite = Registry.LocalMachine.OpenSubKey(RegistryPath, true);
        }

        public void Init()
        {
            string RegistryPathCV = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\";
            RegistryKey cvKey = Registry.LocalMachine.OpenSubKey(RegistryPathCV, true);
            RegistryKey tsKey = cvKey.CreateSubKey("Terminal Server");
            RegistryKey tsaaKey = tsKey.CreateSubKey("TSAppAllowList");
            RegistryKey appKey = tsaaKey.CreateSubKey("Applications");
        }

        public RemoteAppCollection GetAll()
        {
            RemoteAppCollection SystemAppCollection = new RemoteAppCollection();

            foreach (string App in BaseKey.GetSubKeyNames())
            {
                RemoteApp RemoteApp = GetApp(App);
                SystemAppCollection.Add(RemoteApp);
            }

            BaseKey.Close();

            return SystemAppCollection;
        }

        public RemoteApp GetApp(string Name)
        {
            RemoteApp App = new RemoteApp();

            RegistryKey AppKey = BaseKey.OpenSubKey(Name);

            if (AppKey == null) return null;

            App.Name = Name;
            App.FullName = AppKey.GetValue("Name", "").ToString();
            App.Path = AppKey.GetValue("Path", "").ToString();
            App.VPath = AppKey.GetValue("VPath", "").ToString();
            App.CommandLine = AppKey.GetValue("RequiredCommandLine", "").ToString();
            App.CommandLineOption = Convert.ToInt32(AppKey.GetValue("CommandLineSetting", "1"));
            App.IconPath = AppKey.GetValue("IconPath", "").ToString();
            App.IconIndex = Convert.ToInt32(AppKey.GetValue("IconIndex", 0));
            App.TSWA = Convert.ToInt32(AppKey.GetValue("ShowInTSWA", 0)) != 0;

            RegistryKey FTAKey = AppKey.OpenSubKey("Filetypes");
            if (FTAKey != null)
            {
                FileTypeAssociationCollection FTACol = new FileTypeAssociationCollection();

                foreach (string FTAValueName in FTAKey.GetValueNames())
                {
                    try
                    {
                        FileTypeAssociation FTA = new FileTypeAssociation();
                        string ftaValueStr = FTAKey.GetValue(FTAValueName)?.ToString() ?? "";
                        string[] FTAValue = ftaValueStr.Split(',');
                        
                        FTA.Extension = FTAValueName;
                        FTA.IconPath = FTAValue.Length > 0 ? FTAValue[0] : "";
                        FTA.IconIndex = FTAValue.Length > 1 ? FTAValue[1] : "0";

                        FTACol.Add(FTA);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"加载FileTypeAssociation错误: {ex.Message}");
                        // 继续处理其他项
                    }
                }

                App.FileTypeAssociations = FTACol;
                FTAKey.Close();
            }
            
            AppKey.Close();
            return App;
        }

        public void SaveApp(RemoteApp RemoteApp)
        {
            try
            {
                // 使用BaseKeyWrite创建子键
                BaseKeyWrite.CreateSubKey(RemoteApp.Name);

                // 使用BaseKeyWrite打开子键以进行写入操作
                RegistryKey AppKey = BaseKeyWrite.OpenSubKey(RemoteApp.Name, true);

                if (AppKey == null)
                {
                    throw new Exception($"无法打开注册表键: {RemoteApp.Name}");
                }

                AppKey.SetValue("Name", RemoteApp.FullName ?? "", RegistryValueKind.String);
                AppKey.SetValue("Path", RemoteApp.Path ?? "", RegistryValueKind.String);
                AppKey.SetValue("VPath", RemoteApp.VPath ?? "", RegistryValueKind.String);
                AppKey.SetValue("RequiredCommandLine", RemoteApp.CommandLine ?? "", RegistryValueKind.String);
                AppKey.SetValue("CommandLineSetting", RemoteApp.CommandLineOption, RegistryValueKind.DWord);
                AppKey.SetValue("IconPath", RemoteApp.IconPath ?? "", RegistryValueKind.String);
                AppKey.SetValue("IconIndex", RemoteApp.IconIndex, RegistryValueKind.DWord);
                AppKey.SetValue("ShowInTSWA", RemoteApp.TSWA ? 1 : 0, RegistryValueKind.DWord);

                if (RemoteApp.FileTypeAssociations != null)
                {
                    if (AppKey.OpenSubKey("Filetypes") != null)
                    {
                        try
                        {
                            AppKey.DeleteSubKeyTree("Filetypes");
                        }
                        catch
                        {
                            // 忽略删除错误
                        }
                    }
                    AppKey.CreateSubKey("Filetypes");
                    RegistryKey FTAKey = AppKey.OpenSubKey("Filetypes", true);
                    foreach (FileTypeAssociation fta in RemoteApp.FileTypeAssociations)
                    {
                        FTAKey.SetValue(fta.Extension, fta.IconPath + "," + fta.IconIndex, RegistryValueKind.String);
                    }
                    FTAKey.Close();
                }
                
                AppKey.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SaveApp错误: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                throw new Exception($"保存RemoteApp失败: {ex.Message}", ex);
            }
        }

        public void DuplicateApp(string Name)
        {
            RemoteApp NewApp = GetApp(Name);

            string NewName = NewApp.Name;

            while (GetApp(NewName) != null)
            {
                NewName = NewName + " copy";
            }

            NewApp.Name = NewName;

            SaveApp(NewApp);
        }

        public void RenameApp(string RemoteAppOldName, string RemoteAppNewName)
        {
            RemoteApp App = GetApp(RemoteAppOldName);
            DeleteApp(RemoteAppOldName);
            App.Name = RemoteAppNewName;
            SaveApp(App);
        }

        public void DeleteApp(string Name)
        {
            BaseKeyWrite.DeleteSubKeyTree(Name);
        }

        public bool WoW6432Node
        {
            get
            {
                return Legacy32bit;
            }
            set
            {
                Legacy32bit = value;
                string PathStart = "SOFTWARE";
                if (Legacy32bit == true) PathStart = "SOFTWARE\\Wow6432Node";
                RegistryPath = PathStart + "\\Microsoft\\Windows NT\\CurrentVersion\\Terminal Server\\TSAppAllowList\\Applications";
            }
        }
    }
}