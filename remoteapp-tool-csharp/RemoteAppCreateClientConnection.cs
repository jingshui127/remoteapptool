using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteAppLib;
using RDPFileLib;
using RemoteAppTool;  // 添加命名空间引用，以使用RDP2MSIModule和IconModule

namespace RemoteApp_Tool
{
    public partial class RemoteAppCreateClientConnection : Form
    {
        private RemoteAppLib.RemoteApp RemoteApp = new RemoteAppLib.RemoteApp();
        private string[,] additionalOptions = new string[0, 0];

        public RemoteAppCreateClientConnection()
        {
            InitializeComponent();
            
            // 手动初始化ImageList，使用系统图标作为临时解决方案
            InitializeImageList();
            
            // 初始化Tooltip，使用用户偏好的浅黄色背景
            SetToolTips();
        }

        public void CreateClientConnection(RemoteAppLib.RemoteApp selectedRemoteApp)
        {
            RemoteApp = selectedRemoteApp;

            var rdpSign = new RDPSign.RDPSign();
            string remoteAppShortName = RemoteApp.Name;
            this.Text = "为 " + remoteAppShortName + " 创建客户端连接";
            this.RdpsignErrorLabel.Text = "";

            SetCCWindowSettings();

            if (this.ServerAddress.Text == "") this.ServerAddress.Text = System.Net.Dns.GetHostName();
            if (this.AltServerAddress.Text == "") this.AltServerAddress.Text = this.ServerAddress.Text;
            if (this.ServerPort.Text == "0") this.ServerPort.Text = "3389";

            if (!System.IO.File.Exists(RemoteApp.IconPath))
            {
                CreateRAWebIcon.Checked = false;
                CreateRAWebIcon.Enabled = false;
            }
            else
            {
                CreateRAWebIcon.Enabled = RDPRadioButton.Checked;
            }

            // 修复类型转换错误 - 第56行
            object rdpsignExeLocationObj = rdpSign.GetRdpsignExeLocation();
            string rdpsignExeLocation = rdpsignExeLocationObj?.ToString() ?? "";
            if (File.Exists(rdpsignExeLocation))
            {
                try
                {
                    // 修正方法调用并修复类型转换错误
                    object certificatesObj = rdpSign.GetCertificateFriendlyName();
                    if (certificatesObj != null)
                    {
                        // 将object转换为object[]，然后转换为string[]
                        if (certificatesObj is object[] certificatesArray)
                        {
                            string[] certificates = new string[certificatesArray.Length];
                            for (int i = 0; i < certificatesArray.Length; i++)
                            {
                                certificates[i] = certificatesArray[i]?.ToString() ?? "";
                            }
                            CertificateComboBox.Items.AddRange(certificates);
                        }
                    }
                }
                catch (Exception ex)
                {
                    RdpsignErrorLabel.Text += " 加载证书时出错: " + ex.Message;
                }
            }

            // 检查WiX是否已安装
            bool wixInstalled = RDP2MSIModule.WixInstalled();
            if (!wixInstalled)
            {
                RDPRadioButton.Checked = true;
                MSIRadioButton.Enabled = false;
                MSIRadioButton.Text = "MSI 安装程序（需要 WiX 工具集）";
            }

            // 检查rdpsign.exe是否存在
            // 第93行 - 使用已声明的变量
            if (!File.Exists(rdpsignExeLocation))
            {
                SigningTabPage.Enabled = false;
                RdpsignErrorLabel.Text += " * 需要 rdpsign.exe。";
                SigningTabPage.Tag = "noexe";
                CheckBoxSignRDPEnabled.Checked = false;
                CheckBoxCreateSignedAndUnsigned.Checked = false;
                CertificateComboBox.Text = "";
            }

            // 设置文件类型关联计数
            if (RemoteApp.FileTypeAssociations != null)
                FTACountLabel.Text = "计数: " + RemoteApp.FileTypeAssociations.Count;

            // HelpSystem.SetupTips(this);  // 暂时注释，等待HelpSystem模块恢复
            this.ShowDialog();
            //RemoteAppMainWindow.ReloadApps();
            this.Dispose();
        }

        private void SetCCWindowSettings()
        {
            // 从设置中加载保存的窗口设置
            
            // 调试输出：查看当前加载的配置值
            System.Diagnostics.Debug.WriteLine("=== 加载配置 Settings ===");
            System.Diagnostics.Debug.WriteLine($"SavedConnectionModeMSI: {Properties.Settings.Default.SavedConnectionModeMSI}");
            System.Diagnostics.Debug.WriteLine($"SavedServerAddress: {Properties.Settings.Default.SavedServerAddress}");
            System.Diagnostics.Debug.WriteLine($"SavedServerPort: {Properties.Settings.Default.SavedServerPort}");
            System.Diagnostics.Debug.WriteLine($"SavedMSIShortcutDesktop: {Properties.Settings.Default.SavedMSIShortcutDesktop}");
            
            if (Properties.Settings.Default.SavedConnectionModeMSI)
            {
                RDPRadioButton.Checked = false;
                MSIRadioButton.Checked = true;
            }
            else
            {
                RDPRadioButton.Checked = true;
                MSIRadioButton.Checked = false;
            }
            
            EditAfterSave.Checked = Properties.Settings.Default.SavedOpenWithNotepad;
            ServerAddress.Text = Properties.Settings.Default.SavedServerAddress;
            
            // 修复类型转换错误
            ServerPort.Text = Properties.Settings.Default.SavedServerPort.ToString();
            AltServerAddress.Text = Properties.Settings.Default.SavedAltServerAddress;
            UseRDGatewayCheckBox.Checked = Properties.Settings.Default.SavedUseRDGateway;
            GatewayAddress.Text = Properties.Settings.Default.SavedRDGatewayAddress;
            AttemptDirectCheckBox.Checked = Properties.Settings.Default.SavedAttemptDirectRDGateway;
            ShortcutDesktopCheckBox.Checked = Properties.Settings.Default.SavedMSIShortcutDesktop;
            ShortcutStartCheckBox.Checked = Properties.Settings.Default.SavedMSIShortcutStart;
            
            if (Properties.Settings.Default.SavedMSIShortcutStartTopLevel)
            {
                SubfolderRadioButton.Checked = false;
                TopLevelRadioButton.Checked = true;
            }
            else
            {
                SubfolderRadioButton.Checked = true;
                TopLevelRadioButton.Checked = false;
            }
            
            ShortcutTagCheckBox.Checked = Properties.Settings.Default.SavedUseShortcutTag;
            ShortcutTagTextBox.Text = Properties.Settings.Default.SavedShortcutTag;
            MSIOptionsTabPage.Enabled = MSIRadioButton.Checked;
            CreateRAWebIcon.Checked = Properties.Settings.Default.SavedCreateRAWebIcon;
            DisabledFTACheckBox.Checked = Properties.Settings.Default.SavedDisableFTA;
            
            if (!Properties.Settings.Default.SavedMSIPerUser)
            {
                PerMachineRadioButton.Checked = true;
                PerUserRadioButton.Checked = false;
            }
            else
            {
                PerMachineRadioButton.Checked = false;
                PerUserRadioButton.Checked = true;
            }
            
            CheckBoxSignRDPEnabled.Checked = Properties.Settings.Default.SavedSignRDP;
            CertificateComboBox.Enabled = Properties.Settings.Default.SavedSignRDP;
            CheckBoxCreateSignedAndUnsigned.Checked = Properties.Settings.Default.SavedSignedAndUnsigned;
            
            // 修复类型转换错误
            if (CertificateComboBox.Items.Count >= (Properties.Settings.Default.SavedCertSelected + 1))
            {
                CertificateComboBox.SelectedIndex = Properties.Settings.Default.SavedCertSelected;
            }
            else if (CertificateComboBox.Items.Count > 0)
            {
                CertificateComboBox.SelectedIndex = 0;
            }
            else if (SigningTabPage.Tag?.ToString() != "noexe")
            {
                RdpsignErrorLabel.Text += " 未找到证书。";
                SigningTabPage.Enabled = false;
                CheckBoxSignRDPEnabled.Checked = false;
                CheckBoxCreateSignedAndUnsigned.Checked = false;
                CertificateComboBox.Text = "";
            }
            
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedRDPOptions))
            {
                additionalOptions = UnflattenArray(Properties.Settings.Default.SavedRDPOptions);
            }
            else
            {
                additionalOptions = new string[0, 0];
            }
        }

        private void RDPRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MSIOptionsTabPage.Enabled = MSIRadioButton.Checked;
            EditAfterSave.Enabled = RDPRadioButton.Checked;
            CreateRAWebIcon.Enabled = RDPRadioButton.Checked;

            if (RDPRadioButton.Checked)
            {
                CreateButton.ImageIndex = 6;
                CheckBoxCreateSignedAndUnsigned.Enabled = true;
            }
            else
            {
                CreateButton.ImageIndex = 1;
                CheckBoxCreateSignedAndUnsigned.Enabled = false;
                CheckBoxCreateSignedAndUnsigned.Checked = false;
            }
        }

        private void UseRDGatewayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UseRDGatewayCheckBox.Checked)
            {
                this.GatewayAddress.Enabled = true;
                this.RDGWLabel.Enabled = true;
                this.AttemptDirectCheckBox.Enabled = true;
            }
            else
            {
                this.GatewayAddress.Enabled = false;
                this.RDGWLabel.Enabled = false;
                this.AttemptDirectCheckBox.Enabled = false;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string rdpPath = "";
            string msiPath = "";
            string tempMsiPath = "";

            // 修复类型转换错误
            if (CheckBoxSignRDPEnabled.Checked && (CertificateComboBox.SelectedItem == null || string.IsNullOrEmpty(CertificateComboBox.SelectedItem.ToString())))
            {
                MessageBox.Show("您必须选择一个证书来签署 RDP 文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DisabledFTACheckBox.Checked && RemoteApp.FileTypeAssociations != null)
                RemoteApp.FileTypeAssociations.Clear();

            if (RDPRadioButton.Checked)
            {
                FileSaveRDP.FileName = RemoteApp.Name;
                if (FileSaveRDP.ShowDialog() != DialogResult.OK) return;
                rdpPath = FileSaveRDP.FileName;
            }
            else
            {
                FileSaveMSI.FileName = RemoteApp.Name;
                if (FileSaveMSI.ShowDialog() != DialogResult.OK) return;
                msiPath = FileSaveMSI.FileName;
                rdpPath = Path.Combine(Path.GetTempPath(), RemoteApp.Name + ".rdp");
                tempMsiPath = Path.Combine(Path.GetTempPath(), RemoteApp.Name + ".msi");
            }

            string gwaddress = "";
            bool trydirect = false;
            if (UseRDGatewayCheckBox.Checked)
            {
                gwaddress = GatewayAddress.Text;
                trydirect = AttemptDirectCheckBox.Checked;
            }

            if (RDPRadioButton.Checked)
            {
                CreateRDPFile(rdpPath, RemoteApp);
                //!!!!!!! If it's an RDP file
                if (EditAfterSave.Checked)
                {
                    string cmdLine = Path.Combine(Environment.SystemDirectory, "notepad.exe");
                    Process.Start(cmdLine, FileSaveRDP.FileName);
                }
                if (CreateRAWebIcon.Checked)
                {
                    string iconFilePath = Path.ChangeExtension(rdpPath, ".ico");
                    if (!IconModule.ExtractToIco(RemoteApp.IconPath, RemoteApp.IconIndex, iconFilePath))
                    {
                        MessageBox.Show("无法为远程应用创建图标。RDP 文件仍将会被创建。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    // Check if there are file type associations before trying to work with the file type association icons
                    if (RemoteApp.FileTypeAssociations != null)
                    {
                        foreach (RemoteAppLib.FileTypeAssociation fta in RemoteApp.FileTypeAssociations)
                        {
                            string productFileName = Path.GetFileNameWithoutExtension(rdpPath);
                            ExtractFTIcon(productFileName, fta);
                        }
                    }
                }
                this.Close();
            }
            else
            {
                //!!!!!!!  If it's an MSI
                CreateRDPFile(rdpPath, RemoteApp);

                var filesToDelete = new ArrayList();
                string productFileName = Path.GetFileNameWithoutExtension(rdpPath);
                string iconFilePath = productFileName + ".ico";

                filesToDelete.Add(rdpPath);

                if (!IconModule.ExtractToIco(RemoteApp.IconPath, RemoteApp.IconIndex, iconFilePath))
                {
                    MessageBox.Show("加载图标时出错：\n" + RemoteApp.IconPath + "," + RemoteApp.IconIndex + "\nMSI 仍将会被创建，但主图标将缺失。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    filesToDelete.Add(iconFilePath);
                }

                if (RemoteApp.FileTypeAssociations != null)
                {
                    foreach (RemoteAppLib.FileTypeAssociation fta in RemoteApp.FileTypeAssociations)
                    {
                        ExtractFTIcon(productFileName, fta);
                        filesToDelete.Add(productFileName + "." + fta.Extension + ".ico");
                    }
                    //rdp.FlatFileTypes = RemoteApp.FileTypeAssociations.GetFlatFileTypes;
                }

                // 使用RDP2MSIModule创建MSI
                CreateMSIFromRDP(rdpPath, msiPath);

                //DeleteFiles(filesToDelete);
                this.Close();
            }
        }

        private void ExtractFTIcon(string productFileName, RemoteAppLib.FileTypeAssociation fta)
        {
            //Extract icon for filetype
            string ftIconPath = productFileName + "." + fta.Extension + ".ico";
            // 修复类型转换错误 - 第353行
            int iconIndex = 0;
            if (!int.TryParse(fta.IconIndex, out iconIndex))
            {
                iconIndex = 0;
            }
            if (!IconModule.ExtractToIco(fta.IconPath, iconIndex, ftIconPath))
            {
                //If filetype icon fails to extract, then grab the default document icon from Shell32.dll
                IconModule.ExtractToIco(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ftIconPath);
                //Possibly show an error here??
            }
        }

        private void CreateRDPFile(string rdpPath, RemoteAppLib.RemoteApp remoteApp)
        {
            var fileTypeAssociations = remoteApp.FileTypeAssociations;

            string serverAddress = this.ServerAddress.Text;
            string altServerAddress = this.AltServerAddress.Text;
            string serverPort = this.ServerPort.Text;

            // 修复未使用变量警告
            // string flatFileTypes = "";
            // if (fileTypeAssociations != null) flatFileTypes = ""; //fileTypeAssociations.GetFlatFileTypes;

            // 修复类型转换错误
            int portNumber = 3389;
            if (!int.TryParse(serverPort, out portNumber))
            {
                portNumber = 3389;
            }

            var rdpFile = new RDPFileLib.RDPFile
            {
                full_address = serverAddress,
                alternate_full_address = altServerAddress,
                server_port = portNumber,
                remoteapplicationname = remoteApp.FullName,
                remoteapplicationprogram = "||" + remoteApp.Name,
                remoteapplicationmode = 1,
                alternate_shell = "rdpinit.exe",
                AdditionalOptions = ExportAdditionalOptionsRdpString()
            };

            if (UseRDGatewayCheckBox.Checked)
            {
                rdpFile.gatewayhostname = this.GatewayAddress.Text;
                rdpFile.gatewayusagemethod = this.AttemptDirectCheckBox.Checked ? 2 : 1;
                rdpFile.gatewayprofileusagemethod = 1;
            }

            //rdpFile.remoteapplicationfileextensions = flatFileTypes;

            rdpFile.SaveRDPfile(rdpPath);

            if (CheckBoxSignRDPEnabled.Checked)
            {
                var rdpSign = new RDPSign.RDPSign();
                // 修复类型转换错误 - 第409行
                object selectedItem = CertificateComboBox.SelectedItem;
                string certificateName = selectedItem?.ToString() ?? "";
                // 修复类型转换错误 - 第415行
                object thumbprintObj = rdpSign.GetThumbprint(certificateName);
                string thumbprint = thumbprintObj?.ToString() ?? "";
                bool createBackup = CheckBoxCreateSignedAndUnsigned.Checked;
                rdpSign.SignRDP(thumbprint, rdpPath, createBackup);
            }
        }

        private string ExportAdditionalOptionsRdpString()
        {
            string optionsString = "";
            int optionsLength = additionalOptions.GetLength(0);
            for (int row = 0; row < optionsLength; row++)
            {
                optionsString += additionalOptions[row, 1] + ":";
                optionsString += additionalOptions[row, 2] + ":";
                optionsString += additionalOptions[row, 3] + "\n";
            }

            return optionsString.Trim();
        }

        private void FTAButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(this, "此处对文件类型关联的更改仅适用于此客户端连接，不会保存到下次使用。\n\n要对这个远程应用的文件类型关联进行永久更改，请编辑远程应用。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var ftaWindow = new RemoteAppFileTypeAssociation();
                RemoteApp = ftaWindow.EditFileTypes(RemoteApp);
                if (RemoteApp.FileTypeAssociations != null)
                    FTACountLabel.Text = "计数: " + RemoteApp.FileTypeAssociations.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开文件类型关联窗口: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShortcutStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SubfolderRadioButton.Enabled = ShortcutStartCheckBox.Checked;
            TopLevelRadioButton.Enabled = ShortcutStartCheckBox.Checked;
        }

        private void ShortcutTagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShortcutTagTextBox.Enabled = ShortcutTagCheckBox.Checked;
        }

        private void ServerAddress_TextChanged(object sender, EventArgs e)
        {
            // 修复类型转换错误 - 确保传递正确的参数类型
            RemoteAppFunctions.ValidateDNSname(ServerAddress);
        }

        private void AltServerAddress_TextChanged(object sender, EventArgs e)
        {
            // 修复类型转换错误 - 确保传递正确的参数类型
            RemoteAppFunctions.ValidateDNSname(AltServerAddress);
        }

        private void ServerPort_TextChanged(object sender, EventArgs e)
        {
            // 修复类型转换错误 - 确保传递正确的参数类型
            RemoteAppFunctions.ValidatePort(ServerPort);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetCCWindowSettings();
            SetCCWindowSettings();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveCCWindowSettings();
        }

        private void DisabledFTACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 修复运算符错误 - 确保正确使用逻辑运算符
            if (this.DisabledFTACheckBox.Checked)
            {
                this.FTAButton.Enabled = false;
                this.FTACountLabel.Enabled = false;
            }
            else
            {
                this.FTAButton.Enabled = true;
                this.FTACountLabel.Enabled = true;
            }
        }

        private void CheckBoxSignRDPEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CertificateComboBox.Enabled = CheckBoxSignRDPEnabled.Checked;
            // 修复运算符错误 - 确保正确使用逻辑运算符
            if (EditAfterSave.Checked && CheckBoxSignRDPEnabled.Checked)
            {
                if (MessageBox.Show("您已选择\"签署 RDP 文件\"和\"手动编辑 RDP 文件\"。\n\n如果您保存对已签署 RDP 文件的任何更改，它将停止工作。\n\n您确定要签署 RDP 文件吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CheckBoxSignRDPEnabled.Checked = true;
                }
                else
                {
                    CheckBoxSignRDPEnabled.Checked = false;
                }
            }
        }

        private void EditAfterSave_CheckedChanged(object sender, EventArgs e)
        {
            // 修复运算符错误 - 确保正确使用逻辑运算符
            if (EditAfterSave.Checked && CheckBoxSignRDPEnabled.Checked)
            {
                if (MessageBox.Show("您已选择\"签署 RDP 文件\"和\"手动编辑 RDP 文件\"。\n\n如果您保存对已签署 RDP 文件的任何更改，它将停止工作。\n\n您确定要在保存后进行编辑吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    EditAfterSave.Checked = true;
                }
                else
                {
                    EditAfterSave.Checked = false;
                }
            }
        }

        private void CheckBoxCreateSignedAndUnsigned_CheckedChanged(object sender, EventArgs e)
        {
            // 修复类型转换错误
            if (CheckBoxCreateSignedAndUnsigned.Checked)
            {
                CheckBoxSignRDPEnabled.Checked = true;
            }
        }

        private void RDPOptionsButton_Click(object sender, EventArgs e)
        {
            // 打开RDP选项窗口，编辑额外的RDP配置选项
            var rdpOptionsWindow = new RDPOptionsWindow();
            additionalOptions = rdpOptionsWindow.EditAdditionalOptions(additionalOptions);
        }

        private void ResetCCWindowSettings()
        {
            Properties.Settings.Default.SavedConnectionModeMSI = false;
            Properties.Settings.Default.SavedOpenWithNotepad = false;
            Properties.Settings.Default.SavedServerAddress = Dns.GetHostName();
            Properties.Settings.Default.SavedServerPort = 3389;
            Properties.Settings.Default.SavedAltServerAddress = Properties.Settings.Default.SavedServerAddress;
            Properties.Settings.Default.SavedUseRDGateway = false;
            Properties.Settings.Default.SavedRDGatewayAddress = "";
            Properties.Settings.Default.SavedAttemptDirectRDGateway = false;
            Properties.Settings.Default.SavedMSIShortcutDesktop = true;
            Properties.Settings.Default.SavedMSIShortcutStart = true;
            Properties.Settings.Default.SavedMSIShortcutStartTopLevel = false;
            Properties.Settings.Default.SavedUseShortcutTag = true;
            Properties.Settings.Default.SavedShortcutTag = "remote";
            Properties.Settings.Default.SavedClientConnectionOptions = false;
            Properties.Settings.Default.SavedCreateRAWebIcon = false;
            Properties.Settings.Default.SavedMSIPerUser = false;
            Properties.Settings.Default.SavedDisableFTA = false;
            Properties.Settings.Default.SavedSignRDP = false;
            Properties.Settings.Default.SavedSignedAndUnsigned = false;
            Properties.Settings.Default.SavedCertSelected = 0;
            Properties.Settings.Default.SavedRDPOptions = "";
            
            // 重置 RDP 额外选项
            additionalOptions = new string[0, 0];
        }

        private void SaveCCWindowSettings()
        {
            // 调试输出：保存前的值
            System.Diagnostics.Debug.WriteLine("=== 保存配置 Settings ===");
            System.Diagnostics.Debug.WriteLine($"MSIRadioButton.Checked: {MSIRadioButton.Checked}");
            System.Diagnostics.Debug.WriteLine($"ServerAddress.Text: {ServerAddress.Text}");
            System.Diagnostics.Debug.WriteLine($"ServerPort.Text: {ServerPort.Text}");
            System.Diagnostics.Debug.WriteLine($"ShortcutDesktopCheckBox.Checked: {ShortcutDesktopCheckBox.Checked}");
                    
            Properties.Settings.Default.SavedConnectionModeMSI = MSIRadioButton.Checked;
            Properties.Settings.Default.SavedOpenWithNotepad = EditAfterSave.Checked;
            Properties.Settings.Default.SavedServerAddress = ServerAddress.Text;
            // 修复类型转换错误 - 笥353行
            string serverPortText = ServerPort.Text;
            int serverPort;
            if (int.TryParse(serverPortText, out serverPort))
            {
                Properties.Settings.Default.SavedServerPort = serverPort;
            }
            else
            {
                Properties.Settings.Default.SavedServerPort = 3389;
            }
            Properties.Settings.Default.SavedAltServerAddress = AltServerAddress.Text;
            Properties.Settings.Default.SavedUseRDGateway = UseRDGatewayCheckBox.Checked;
            Properties.Settings.Default.SavedRDGatewayAddress = GatewayAddress.Text;
            Properties.Settings.Default.SavedAttemptDirectRDGateway = AttemptDirectCheckBox.Checked;
            Properties.Settings.Default.SavedMSIShortcutDesktop = ShortcutDesktopCheckBox.Checked;
            Properties.Settings.Default.SavedMSIShortcutStart = ShortcutStartCheckBox.Checked;
            Properties.Settings.Default.SavedMSIShortcutStartTopLevel = TopLevelRadioButton.Checked;
            Properties.Settings.Default.SavedUseShortcutTag = ShortcutTagCheckBox.Checked;
            Properties.Settings.Default.SavedShortcutTag = ShortcutTagTextBox.Text;
            Properties.Settings.Default.SavedCreateRAWebIcon = CreateRAWebIcon.Checked;
            Properties.Settings.Default.SavedMSIPerUser = PerUserRadioButton.Checked;
            Properties.Settings.Default.SavedDisableFTA = DisabledFTACheckBox.Checked;
            Properties.Settings.Default.SavedSignRDP = CheckBoxSignRDPEnabled.Checked;
            Properties.Settings.Default.SavedSignedAndUnsigned = CheckBoxCreateSignedAndUnsigned.Checked;
            Properties.Settings.Default.SavedCertSelected = CertificateComboBox.SelectedIndex;
            Properties.Settings.Default.SavedRDPOptions = FlattenArray(additionalOptions);
                    
            // 持久化保存配置
            try
            {
                Properties.Settings.Default.Save();
                System.Diagnostics.Debug.WriteLine("配置保存成功！");
                        
                // 显示保存成功提示
                MessageBox.Show("当前的配置已保存为默认设置\n下次创建客户端连接时将自动使用这些配置。", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"保存配置失败：{ex.Message}");
                MessageBox.Show($"保存配置时出错：\n{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string FlattenArray(string[,] arr)
        {
            // Flatten the array to a CSV-like string
            var csvLines = new List<string>();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                var lineValues = new List<string>();

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    lineValues.Add(arr[i, j]);
                }

                csvLines.Add(string.Join("|", lineValues));
            }

            return string.Join(Environment.NewLine, csvLines);
        }

        static string[,] UnflattenArray(string csv)
        {
            // Unflatten the CSV-like string to an array
            string[] csvLines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (csvLines.Length == 0)
            {
                // Handle the case when the array is empty
                return new string[0, 0];
            }

            int numRows = csvLines.Length;
            int numCols = csvLines[0].Split('|').Length;
            var arr = new string[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                string[] lineValues = csvLines[i].Split('|');

                for (int j = 0; j < numCols; j++)
                {
                    arr[i, j] = lineValues[j];
                }
            }

            return arr;
        }
        
        private void CreateMSIFromRDP(string rdpPath, string msiPath)
        {
            try
            {
                // 构建命令参数
                string cmdParameters = "";
                if (ShortcutDesktopCheckBox.Checked) cmdParameters += "D";
                if (ShortcutStartCheckBox.Checked) cmdParameters += "S";
                if (!SubfolderRadioButton.Checked) cmdParameters += "N";
                if (ShortcutTagCheckBox.Checked && string.IsNullOrEmpty(ShortcutTagTextBox.Text)) cmdParameters += "T";
                
                string shortcutTag = ShortcutTagCheckBox.Checked ? ShortcutTagTextBox.Text : "remote";
                string appPublisher = "";
                string flatFileTypes = "";
                
                // 获取文件类型关联
                if (RemoteApp.FileTypeAssociations != null && !DisabledFTACheckBox.Checked)
                {
                    var ftaList = new List<string>();
                    foreach (RemoteAppLib.FileTypeAssociation fta in RemoteApp.FileTypeAssociations)
                    {
                        ftaList.Add(fta.Extension);
                    }
                    flatFileTypes = string.Join("|", ftaList);
                }
                
                bool perUser = PerUserRadioButton.Checked;
                
                // 调用RDP2MSIModule生成MSI
                RDP2MSIModule.RDP2MSI(rdpPath, cmdParameters, shortcutTag, appPublisher, flatFileTypes, perUser);
                
                MessageBox.Show($"MSI 文件已成功创建：\n{msiPath}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建 MSI 时出错：\n{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 初始化ImageList，仅在需要时补充图标
        /// </summary>
        private void InitializeImageList()
        {
            try
            {
                // 检查ImageList是否已经包含图标，如果已有图标则不再修改
                if (this.SmallerIcons.Images.Count == 0)
                {
                    // 添加7个图标位置（索引0-6），使用系统图标作为占位符
                    // 只在设计器未设置图标时才执行此后备方案
                    // 0: save-as_16x16.png - 保存图标
                    this.SmallerIcons.Images.Add(SystemIcons.Application.ToBitmap());
                    // 1: msi small.ico - MSI图标
                    this.SmallerIcons.Images.Add(SystemIcons.WinLogo.ToBitmap());
                    // 2: doc_file_document_manager_paper_phone.ico - 文档图标
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                    // 3: 16.ico - 信息图标
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                    // 4: cross.ico - 取消图标
                    this.SmallerIcons.Images.Add(SystemIcons.Error.ToBitmap());
                    // 5: pictures (1).ico - 图片图标
                    this.SmallerIcons.Images.Add(SystemIcons.Question.ToBitmap());
                    // 6: Remote Desktop Connection.ico - 远程桌面图标
                    this.SmallerIcons.Images.Add(SystemIcons.Application.ToBitmap());
                    
                    System.Diagnostics.Debug.WriteLine($"RemoteAppCreateClientConnection ImageList初始化完成，共{this.SmallerIcons.Images.Count}个图标");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"RemoteAppCreateClientConnection 使用设计器中已设置的图标，共{this.SmallerIcons.Images.Count}个图标");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"初始化ImageList失败: {ex.Message}");
                // 即使失败也不抛出异常，让窗口继续加载
            }
        }
        
        /// <summary>
        /// 为所有控件设置Tooltip，使用用户偏好的浅黄色背景
        /// </summary>
        private void SetToolTips()
        {
            var toolTip = new ToolTip();
            toolTip.BackColor = Color.LightYellow;  // 用户偏好的浅黄色背景
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            // 基本设置选项卡
            toolTip.SetToolTip(this.RDPRadioButton, "创建 RDP 文件\n生成远程桌面连接文件，可直接双击启动");
            toolTip.SetToolTip(this.MSIRadioButton, "创建 MSI 安装程序\n生成Windows Installer安装包，可部署到多个客户端");
            toolTip.SetToolTip(this.ServerAddress, "输入远程桌面服务器地址\nIP地址或者域名（例如：server.domain.com）");
            toolTip.SetToolTip(this.AltServerAddress, "输入备用服务器地址\n主服务器不可用时使用的备用地址");
            toolTip.SetToolTip(this.ServerPort, "输入远程桌面服务端口\n默认为3389，如果服务器修改了端口请输入实际端口");
            toolTip.SetToolTip(this.UseRDGatewayCheckBox, "启用RD网关\n通过远程桌面网关服务器连接，提高安全性");
            toolTip.SetToolTip(this.GatewayAddress, "输入RD网关服务器地址\n远程桌面网关服务器的IP地址或域名");
            toolTip.SetToolTip(this.AttemptDirectCheckBox, "尝试直接连接\n在使用网关前先尝试直接连接服务器");
            toolTip.SetToolTip(this.EditAfterSave, "保存后编辑 RDP 文件\n使用记事本打开RDP文件进行手动编辑");
            
            // MSI安装选项卡
            toolTip.SetToolTip(this.ShortcutDesktopCheckBox, "在桌面创建快捷方式\n安装后在用户桌面创建应用程序快捷方式");
            toolTip.SetToolTip(this.ShortcutStartCheckBox, "在开始菜单创建快捷方式\n安装后在用户开始菜单创建应用程序快捷方式");
            toolTip.SetToolTip(this.SubfolderRadioButton, "放置在子文件夹中\n在开始菜单中创建带标记的子文件夹");
            toolTip.SetToolTip(this.TopLevelRadioButton, "放置在顶级菜单\n直接在开始菜单根目录下创建快捷方式");
            toolTip.SetToolTip(this.ShortcutTagCheckBox, "使用快捷方式标记\n为快捷方式名称添加特定标识标记");
            toolTip.SetToolTip(this.ShortcutTagTextBox, "输入快捷方式标记文本\n将添加到快捷方式名称后面的标识文本");
            toolTip.SetToolTip(this.PerMachineRadioButton, "为所有用户安装\n安装在计算机上，所有用户都可以使用这个应用");
            toolTip.SetToolTip(this.PerUserRadioButton, "仅为当前用户安装\n只在当前用户的配置文件中安装该应用");
            
            // 高级选项卡
            toolTip.SetToolTip(this.CreateRAWebIcon, "为远程应用创建 Web 图标\n生成.ico格式的图标文件，用于Web界面显示");
            toolTip.SetToolTip(this.FTAButton, "配置文件类型关联\n设置该应用程序可以处理的文件类型");
            toolTip.SetToolTip(this.FTACountLabel, "文件类型关联数量\n显示当前配置的文件类型关联数量");
            toolTip.SetToolTip(this.DisabledFTACheckBox, "禁用文件类型关联\n不在生成的连接中包含文件类型关联信息");
            toolTip.SetToolTip(this.RDPOptionsButton, "高级 RDP 选项\n配置额外的远程桌面连接参数");
            
            // 签名选项卡
            toolTip.SetToolTip(this.CheckBoxSignRDPEnabled, "签署 RDP 文件\n使用数字证书对RDP文件进行签名，提高安全性");
            toolTip.SetToolTip(this.CertificateComboBox, "选择签名证书\n从系统中已安装的证书中选择用于签名的证书");
            toolTip.SetToolTip(this.CheckBoxCreateSignedAndUnsigned, "创建已签名和未签名版本\n同时生成签名版本和未签名版本的RDP文件");
            
            // 操作按钮
            toolTip.SetToolTip(this.CreateButton, "创建客户端连接\n根据当前配置生成RDP或MSI文件");
            toolTip.SetToolTip(this.SaveButton, "保存设置\n保存当前的配置作为默认设置");
            toolTip.SetToolTip(this.ResetButton, "重置设置\n恢复所有设置为默认值");
            
            // 错误信息标签
            toolTip.SetToolTip(this.RdpsignErrorLabel, "签名相关错误信息\n显示数字签名功能的状态和错误信息");
        }
    }
}