namespace RemoteApp_Tool
{
    partial class RemoteAppCreateClientConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppCreateClientConnection));
            this.EditAfterSave = new System.Windows.Forms.CheckBox();
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.CreateButton = new System.Windows.Forms.Button();
            this.FileSaveRDP = new System.Windows.Forms.SaveFileDialog();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.AltServerAddress = new System.Windows.Forms.TextBox();
            this.ServerAddress = new System.Windows.Forms.TextBox();
            this.AttemptDirectCheckBox = new System.Windows.Forms.CheckBox();
            this.UseRDGatewayCheckBox = new System.Windows.Forms.CheckBox();
            this.RDGWLabel = new System.Windows.Forms.Label();
            this.GatewayAddress = new System.Windows.Forms.TextBox();
            this.MSIRadioButton = new System.Windows.Forms.RadioButton();
            this.RDPRadioButton = new System.Windows.Forms.RadioButton();
            this.CreateRAWebIcon = new System.Windows.Forms.CheckBox();
            this.FTAButton = new System.Windows.Forms.Button();
            this.FileBrowserIcon = new System.Windows.Forms.OpenFileDialog();
            this.FileSaveMSI = new System.Windows.Forms.SaveFileDialog();
            this.ShortcutDesktopCheckBox = new System.Windows.Forms.CheckBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PerMachineRadioButton = new System.Windows.Forms.RadioButton();
            this.PerUserRadioButton = new System.Windows.Forms.RadioButton();
            this.TopLevelRadioButton = new System.Windows.Forms.RadioButton();
            this.SubfolderRadioButton = new System.Windows.Forms.RadioButton();
            this.ShortcutStartCheckBox = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ShortcutTagCheckBox = new System.Windows.Forms.CheckBox();
            this.ShortcutTagTextBox = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FTACountLabel = new System.Windows.Forms.Label();
            this.DisabledFTACheckBox = new System.Windows.Forms.CheckBox();
            this.CheckBoxCreateSignedAndUnsigned = new System.Windows.Forms.CheckBox();
            this.CertificateComboBox = new System.Windows.Forms.ComboBox();
            this.CertificateLabel = new System.Windows.Forms.Label();
            this.CheckBoxSignRDPEnabled = new System.Windows.Forms.CheckBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.HostTabPage = new System.Windows.Forms.TabPage();
            this.OptionsTabPage = new System.Windows.Forms.TabPage();
            this.RDPOptionsButton = new System.Windows.Forms.Button();
            this.GatewayTabPage = new System.Windows.Forms.TabPage();
            this.FileTypesTabPage = new System.Windows.Forms.TabPage();
            this.MSIOptionsTabPage = new System.Windows.Forms.TabPage();
            this.SigningTabPage = new System.Windows.Forms.TabPage();
            this.RdpsignErrorLabel = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.HostTabPage.SuspendLayout();
            this.OptionsTabPage.SuspendLayout();
            this.GatewayTabPage.SuspendLayout();
            this.FileTypesTabPage.SuspendLayout();
            this.MSIOptionsTabPage.SuspendLayout();
            this.SigningTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditAfterSave
            // 
            this.EditAfterSave.BackColor = System.Drawing.Color.Transparent;
            this.EditAfterSave.ImageIndex = 2;
            this.EditAfterSave.ImageList = this.SmallerIcons;
            this.EditAfterSave.Location = new System.Drawing.Point(313, 13);
            this.EditAfterSave.Name = "EditAfterSave";
            this.EditAfterSave.Size = new System.Drawing.Size(165, 30);
            this.EditAfterSave.TabIndex = 3;
            this.EditAfterSave.Text = "手动编辑 RDP 文件";
            this.EditAfterSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.EditAfterSave.UseVisualStyleBackColor = false;
            this.EditAfterSave.CheckedChanged += new System.EventHandler(this.EditAfterSave_CheckedChanged);
            // 
            // SmallerIcons
            // 
            this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
            this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons.Images.SetKeyName(0, "save-as_16x16.png");
            this.SmallerIcons.Images.SetKeyName(1, "msi small.ico");
            this.SmallerIcons.Images.SetKeyName(2, "doc_file_document_manager_paper_phone.ico");
            this.SmallerIcons.Images.SetKeyName(3, "16.ico");
            this.SmallerIcons.Images.SetKeyName(4, "cross.ico");
            this.SmallerIcons.Images.SetKeyName(5, "pictures (1).ico");
            this.SmallerIcons.Images.SetKeyName(6, "Remote Desktop Connection.ico");
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CreateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CreateButton.ImageIndex = 6;
            this.CreateButton.ImageList = this.SmallerIcons;
            this.CreateButton.Location = new System.Drawing.Point(424, 158);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(80, 29);
            this.CreateButton.TabIndex = 9;
            this.CreateButton.Text = "创建...";
            this.CreateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // FileSaveRDP
            // 
            this.FileSaveRDP.DefaultExt = "rdp";
            this.FileSaveRDP.Filter = "RDP 文件|*.rdp";
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CancelEditButton.ImageIndex = 4;
            this.CancelEditButton.ImageList = this.SmallerIcons;
            this.CancelEditButton.Location = new System.Drawing.Point(351, 158);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(67, 29);
            this.CancelEditButton.TabIndex = 8;
            this.CancelEditButton.Text = "取消";
            this.CancelEditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelEditButton.UseVisualStyleBackColor = false;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(9, 53);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(111, 15);
            this.Label13.TabIndex = 4;
            this.Label13.Text = "备用服务器地址：";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(361, 24);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(46, 15);
            this.Label14.TabIndex = 2;
            this.Label14.Text = "端口：";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(9, 24);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(85, 15);
            this.Label12.TabIndex = 0;
            this.Label12.Text = "服务器地址：";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(413, 21);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(53, 23);
            this.ServerPort.TabIndex = 3;
            this.ServerPort.Text = "3389";
            this.ServerPort.TextChanged += new System.EventHandler(this.ServerPort_TextChanged);
            // 
            // AltServerAddress
            // 
            this.AltServerAddress.Location = new System.Drawing.Point(120, 50);
            this.AltServerAddress.Name = "AltServerAddress";
            this.AltServerAddress.Size = new System.Drawing.Size(347, 23);
            this.AltServerAddress.TabIndex = 5;
            this.AltServerAddress.TextChanged += new System.EventHandler(this.AltServerAddress_TextChanged);
            // 
            // ServerAddress
            // 
            this.ServerAddress.Location = new System.Drawing.Point(108, 21);
            this.ServerAddress.Name = "ServerAddress";
            this.ServerAddress.Size = new System.Drawing.Size(250, 23);
            this.ServerAddress.TabIndex = 1;
            this.ServerAddress.TextChanged += new System.EventHandler(this.ServerAddress_TextChanged);
            // 
            // AttemptDirectCheckBox
            // 
            this.AttemptDirectCheckBox.AutoSize = true;
            this.AttemptDirectCheckBox.Enabled = false;
            this.AttemptDirectCheckBox.Location = new System.Drawing.Point(12, 70);
            this.AttemptDirectCheckBox.Name = "AttemptDirectCheckBox";
            this.AttemptDirectCheckBox.Size = new System.Drawing.Size(229, 19);
            this.AttemptDirectCheckBox.TabIndex = 3;
            this.AttemptDirectCheckBox.Text = "仅在直接连接不成功时使用 RD 网关";
            this.AttemptDirectCheckBox.UseVisualStyleBackColor = true;
            // 
            // UseRDGatewayCheckBox
            // 
            this.UseRDGatewayCheckBox.AutoSize = true;
            this.UseRDGatewayCheckBox.Location = new System.Drawing.Point(12, 16);
            this.UseRDGatewayCheckBox.Name = "UseRDGatewayCheckBox";
            this.UseRDGatewayCheckBox.Size = new System.Drawing.Size(99, 19);
            this.UseRDGatewayCheckBox.TabIndex = 0;
            this.UseRDGatewayCheckBox.Text = "使用 RD 网关";
            this.UseRDGatewayCheckBox.UseVisualStyleBackColor = true;
            this.UseRDGatewayCheckBox.CheckedChanged += new System.EventHandler(this.UseRDGatewayCheckBox_CheckedChanged);
            // 
            // RDGWLabel
            // 
            this.RDGWLabel.AutoSize = true;
            this.RDGWLabel.Enabled = false;
            this.RDGWLabel.Location = new System.Drawing.Point(9, 44);
            this.RDGWLabel.Name = "RDGWLabel";
            this.RDGWLabel.Size = new System.Drawing.Size(90, 15);
            this.RDGWLabel.TabIndex = 1;
            this.RDGWLabel.Text = "RD 网关地址：";
            // 
            // GatewayAddress
            // 
            this.GatewayAddress.Enabled = false;
            this.GatewayAddress.Location = new System.Drawing.Point(138, 41);
            this.GatewayAddress.Name = "GatewayAddress";
            this.GatewayAddress.Size = new System.Drawing.Size(328, 23);
            this.GatewayAddress.TabIndex = 2;
            // 
            // MSIRadioButton
            // 
            this.MSIRadioButton.AutoSize = true;
            this.MSIRadioButton.Location = new System.Drawing.Point(12, 43);
            this.MSIRadioButton.Name = "MSIRadioButton";
            this.MSIRadioButton.Size = new System.Drawing.Size(100, 19);
            this.MSIRadioButton.TabIndex = 2;
            this.MSIRadioButton.TabStop = true;
            this.MSIRadioButton.Text = "MSI 安装程序";
            this.MSIRadioButton.UseVisualStyleBackColor = true;
            // 
            // RDPRadioButton
            // 
            this.RDPRadioButton.AutoSize = true;
            this.RDPRadioButton.Checked = true;
            this.RDPRadioButton.Location = new System.Drawing.Point(12, 18);
            this.RDPRadioButton.Name = "RDPRadioButton";
            this.RDPRadioButton.Size = new System.Drawing.Size(76, 19);
            this.RDPRadioButton.TabIndex = 1;
            this.RDPRadioButton.TabStop = true;
            this.RDPRadioButton.Text = "RDP 文件";
            this.RDPRadioButton.UseVisualStyleBackColor = true;
            this.RDPRadioButton.CheckedChanged += new System.EventHandler(this.RDPRadioButton_CheckedChanged);
            // 
            // CreateRAWebIcon
            // 
            this.CreateRAWebIcon.BackColor = System.Drawing.Color.Transparent;
            this.CreateRAWebIcon.ImageIndex = 5;
            this.CreateRAWebIcon.ImageList = this.SmallerIcons;
            this.CreateRAWebIcon.Location = new System.Drawing.Point(313, 38);
            this.CreateRAWebIcon.Name = "CreateRAWebIcon";
            this.CreateRAWebIcon.Size = new System.Drawing.Size(126, 30);
            this.CreateRAWebIcon.TabIndex = 4;
            this.CreateRAWebIcon.Text = "创建图标文件";
            this.CreateRAWebIcon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CreateRAWebIcon.UseVisualStyleBackColor = false;
            // 
            // FTAButton
            // 
            this.FTAButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FTAButton.ImageIndex = 5;
            this.FTAButton.ImageList = this.SmallerIcons;
            this.FTAButton.Location = new System.Drawing.Point(298, 15);
            this.FTAButton.Name = "FTAButton";
            this.FTAButton.Size = new System.Drawing.Size(172, 29);
            this.FTAButton.TabIndex = 2;
            this.FTAButton.Text = "文件类型关联...";
            this.FTAButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FTAButton.UseVisualStyleBackColor = false;
            this.FTAButton.Click += new System.EventHandler(this.FTAButton_Click);
            // 
            // FileBrowserIcon
            // 
            this.FileBrowserIcon.Filter = "图标|*.exe;*.dll;*.ico|所有文件|*.*";
            this.FileBrowserIcon.Title = "浏览...";
            // 
            // FileSaveMSI
            // 
            this.FileSaveMSI.DefaultExt = "msi";
            this.FileSaveMSI.Filter = "MSI 文件|*.msi";
            // 
            // ShortcutDesktopCheckBox
            // 
            this.ShortcutDesktopCheckBox.AutoSize = true;
            this.ShortcutDesktopCheckBox.Checked = true;
            this.ShortcutDesktopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShortcutDesktopCheckBox.Location = new System.Drawing.Point(118, 15);
            this.ShortcutDesktopCheckBox.Name = "ShortcutDesktopCheckBox";
            this.ShortcutDesktopCheckBox.Size = new System.Drawing.Size(52, 19);
            this.ShortcutDesktopCheckBox.TabIndex = 1;
            this.ShortcutDesktopCheckBox.Text = "桌面";
            this.ShortcutDesktopCheckBox.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Controls.Add(this.PerMachineRadioButton);
            this.Panel1.Controls.Add(this.PerUserRadioButton);
            this.Panel1.Location = new System.Drawing.Point(91, 73);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(200, 26);
            this.Panel1.TabIndex = 9;
            // 
            // PerMachineRadioButton
            // 
            this.PerMachineRadioButton.AutoSize = true;
            this.PerMachineRadioButton.Checked = true;
            this.PerMachineRadioButton.Location = new System.Drawing.Point(3, 3);
            this.PerMachineRadioButton.Name = "PerMachineRadioButton";
            this.PerMachineRadioButton.Size = new System.Drawing.Size(77, 19);
            this.PerMachineRadioButton.TabIndex = 0;
            this.PerMachineRadioButton.TabStop = true;
            this.PerMachineRadioButton.Text = "每台机器";
            this.PerMachineRadioButton.UseVisualStyleBackColor = true;
            // 
            // PerUserRadioButton
            // 
            this.PerUserRadioButton.AutoSize = true;
            this.PerUserRadioButton.Location = new System.Drawing.Point(100, 3);
            this.PerUserRadioButton.Name = "PerUserRadioButton";
            this.PerUserRadioButton.Size = new System.Drawing.Size(77, 19);
            this.PerUserRadioButton.TabIndex = 1;
            this.PerUserRadioButton.TabStop = true;
            this.PerUserRadioButton.Text = "每个用户";
            this.PerUserRadioButton.UseVisualStyleBackColor = true;
            // 
            // TopLevelRadioButton
            // 
            this.TopLevelRadioButton.AutoSize = true;
            this.TopLevelRadioButton.Location = new System.Drawing.Point(368, 14);
            this.TopLevelRadioButton.Name = "TopLevelRadioButton";
            this.TopLevelRadioButton.Size = new System.Drawing.Size(51, 19);
            this.TopLevelRadioButton.TabIndex = 4;
            this.TopLevelRadioButton.Text = "顶级";
            this.TopLevelRadioButton.UseVisualStyleBackColor = true;
            // 
            // SubfolderRadioButton
            // 
            this.SubfolderRadioButton.AutoSize = true;
            this.SubfolderRadioButton.Checked = true;
            this.SubfolderRadioButton.Location = new System.Drawing.Point(286, 14);
            this.SubfolderRadioButton.Name = "SubfolderRadioButton";
            this.SubfolderRadioButton.Size = new System.Drawing.Size(77, 19);
            this.SubfolderRadioButton.TabIndex = 3;
            this.SubfolderRadioButton.TabStop = true;
            this.SubfolderRadioButton.Text = "子文件夹";
            this.SubfolderRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShortcutStartCheckBox
            // 
            this.ShortcutStartCheckBox.AutoSize = true;
            this.ShortcutStartCheckBox.Checked = true;
            this.ShortcutStartCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShortcutStartCheckBox.Location = new System.Drawing.Point(193, 15);
            this.ShortcutStartCheckBox.Name = "ShortcutStartCheckBox";
            this.ShortcutStartCheckBox.Size = new System.Drawing.Size(91, 19);
            this.ShortcutStartCheckBox.TabIndex = 2;
            this.ShortcutStartCheckBox.Text = "开始菜单：";
            this.ShortcutStartCheckBox.UseVisualStyleBackColor = true;
            this.ShortcutStartCheckBox.CheckedChanged += new System.EventHandler(this.ShortcutStartCheckBox_CheckedChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(291, 47);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(11, 15);
            this.Label3.TabIndex = 7;
            this.Label3.Text = ")";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(112, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(11, 15);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "(";
            // 
            // ShortcutTagCheckBox
            // 
            this.ShortcutTagCheckBox.AutoSize = true;
            this.ShortcutTagCheckBox.Checked = true;
            this.ShortcutTagCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShortcutTagCheckBox.Location = new System.Drawing.Point(15, 45);
            this.ShortcutTagCheckBox.Name = "ShortcutTagCheckBox";
            this.ShortcutTagCheckBox.Size = new System.Drawing.Size(117, 19);
            this.ShortcutTagCheckBox.TabIndex = 5;
            this.ShortcutTagCheckBox.Text = "快捷方式标签：";
            this.ShortcutTagCheckBox.UseVisualStyleBackColor = true;
            this.ShortcutTagCheckBox.CheckedChanged += new System.EventHandler(this.ShortcutTagCheckBox_CheckedChanged);
            // 
            // ShortcutTagTextBox
            // 
            this.ShortcutTagTextBox.Location = new System.Drawing.Point(129, 43);
            this.ShortcutTagTextBox.Name = "ShortcutTagTextBox";
            this.ShortcutTagTextBox.Size = new System.Drawing.Size(156, 23);
            this.ShortcutTagTextBox.TabIndex = 6;
            this.ShortcutTagTextBox.Text = "remote";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 78);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 15);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "安装范围：";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(111, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "放置快捷方式于：";
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ResetButton.ImageIndex = 4;
            this.ResetButton.ImageList = this.SmallerIcons;
            this.ResetButton.Location = new System.Drawing.Point(126, 158);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(121, 29);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "重置为默认值";
            this.ResetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveButton.ImageIndex = 0;
            this.SaveButton.ImageList = this.SmallerIcons;
            this.SaveButton.Location = new System.Drawing.Point(12, 158);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(108, 29);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "保存设置";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FTACountLabel
            // 
            this.FTACountLabel.AutoSize = true;
            this.FTACountLabel.Location = new System.Drawing.Point(163, 22);
            this.FTACountLabel.Name = "FTACountLabel";
            this.FTACountLabel.Size = new System.Drawing.Size(52, 15);
            this.FTACountLabel.TabIndex = 1;
            this.FTACountLabel.Text = "计数：0";
            // 
            // DisabledFTACheckBox
            // 
            this.DisabledFTACheckBox.AutoSize = true;
            this.DisabledFTACheckBox.Location = new System.Drawing.Point(12, 21);
            this.DisabledFTACheckBox.Name = "DisabledFTACheckBox";
            this.DisabledFTACheckBox.Size = new System.Drawing.Size(65, 19);
            this.DisabledFTACheckBox.TabIndex = 0;
            this.DisabledFTACheckBox.Text = "已禁用";
            this.DisabledFTACheckBox.UseVisualStyleBackColor = true;
            this.DisabledFTACheckBox.CheckedChanged += new System.EventHandler(this.DisabledFTACheckBox_CheckedChanged);
            // 
            // CheckBoxCreateSignedAndUnsigned
            // 
            this.CheckBoxCreateSignedAndUnsigned.AutoSize = true;
            this.CheckBoxCreateSignedAndUnsigned.Location = new System.Drawing.Point(12, 42);
            this.CheckBoxCreateSignedAndUnsigned.Name = "CheckBoxCreateSignedAndUnsigned";
            this.CheckBoxCreateSignedAndUnsigned.Size = new System.Drawing.Size(130, 19);
            this.CheckBoxCreateSignedAndUnsigned.TabIndex = 1;
            this.CheckBoxCreateSignedAndUnsigned.Text = "创建签名和未签名";
            this.CheckBoxCreateSignedAndUnsigned.UseVisualStyleBackColor = true;
            this.CheckBoxCreateSignedAndUnsigned.CheckedChanged += new System.EventHandler(this.CheckBoxCreateSignedAndUnsigned_CheckedChanged);
            // 
            // CertificateComboBox
            // 
            this.CertificateComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CertificateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CertificateComboBox.FormattingEnabled = true;
            this.CertificateComboBox.Location = new System.Drawing.Point(280, 15);
            this.CertificateComboBox.Name = "CertificateComboBox";
            this.CertificateComboBox.Size = new System.Drawing.Size(191, 23);
            this.CertificateComboBox.TabIndex = 3;
            // 
            // CertificateLabel
            // 
            this.CertificateLabel.AutoSize = true;
            this.CertificateLabel.Location = new System.Drawing.Point(210, 18);
            this.CertificateLabel.Name = "CertificateLabel";
            this.CertificateLabel.Size = new System.Drawing.Size(46, 15);
            this.CertificateLabel.TabIndex = 2;
            this.CertificateLabel.Text = "证书：";
            // 
            // CheckBoxSignRDPEnabled
            // 
            this.CheckBoxSignRDPEnabled.AutoSize = true;
            this.CheckBoxSignRDPEnabled.Location = new System.Drawing.Point(12, 17);
            this.CheckBoxSignRDPEnabled.Name = "CheckBoxSignRDPEnabled";
            this.CheckBoxSignRDPEnabled.Size = new System.Drawing.Size(106, 19);
            this.CheckBoxSignRDPEnabled.TabIndex = 0;
            this.CheckBoxSignRDPEnabled.Text = "签署 RDP 文件";
            this.CheckBoxSignRDPEnabled.UseVisualStyleBackColor = true;
            this.CheckBoxSignRDPEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxSignRDPEnabled_CheckedChanged);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.HostTabPage);
            this.TabControl.Controls.Add(this.OptionsTabPage);
            this.TabControl.Controls.Add(this.GatewayTabPage);
            this.TabControl.Controls.Add(this.FileTypesTabPage);
            this.TabControl.Controls.Add(this.MSIOptionsTabPage);
            this.TabControl.Controls.Add(this.SigningTabPage);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(492, 137);
            this.TabControl.TabIndex = 10;
            // 
            // HostTabPage
            // 
            this.HostTabPage.Controls.Add(this.Label13);
            this.HostTabPage.Controls.Add(this.ServerAddress);
            this.HostTabPage.Controls.Add(this.Label14);
            this.HostTabPage.Controls.Add(this.AltServerAddress);
            this.HostTabPage.Controls.Add(this.Label12);
            this.HostTabPage.Controls.Add(this.ServerPort);
            this.HostTabPage.Location = new System.Drawing.Point(4, 24);
            this.HostTabPage.Name = "HostTabPage";
            this.HostTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HostTabPage.Size = new System.Drawing.Size(484, 109);
            this.HostTabPage.TabIndex = 0;
            this.HostTabPage.Text = "主机";
            this.HostTabPage.UseVisualStyleBackColor = true;
            // 
            // OptionsTabPage
            // 
            this.OptionsTabPage.Controls.Add(this.RDPOptionsButton);
            this.OptionsTabPage.Controls.Add(this.MSIRadioButton);
            this.OptionsTabPage.Controls.Add(this.RDPRadioButton);
            this.OptionsTabPage.Controls.Add(this.EditAfterSave);
            this.OptionsTabPage.Controls.Add(this.CreateRAWebIcon);
            this.OptionsTabPage.Location = new System.Drawing.Point(4, 24);
            this.OptionsTabPage.Name = "OptionsTabPage";
            this.OptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OptionsTabPage.Size = new System.Drawing.Size(484, 109);
            this.OptionsTabPage.TabIndex = 1;
            this.OptionsTabPage.Text = "选项";
            this.OptionsTabPage.UseVisualStyleBackColor = true;
            // 
            // RDPOptionsButton
            // 
            this.RDPOptionsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RDPOptionsButton.ImageIndex = 6;
            this.RDPOptionsButton.ImageList = this.SmallerIcons;
            this.RDPOptionsButton.Location = new System.Drawing.Point(12, 69);
            this.RDPOptionsButton.Name = "RDPOptionsButton";
            this.RDPOptionsButton.Size = new System.Drawing.Size(118, 29);
            this.RDPOptionsButton.TabIndex = 5;
            this.RDPOptionsButton.Text = "RDP 选项...";
            this.RDPOptionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RDPOptionsButton.UseVisualStyleBackColor = false;
            this.RDPOptionsButton.Click += new System.EventHandler(this.RDPOptionsButton_Click);
            // 
            // GatewayTabPage
            // 
            this.GatewayTabPage.Controls.Add(this.AttemptDirectCheckBox);
            this.GatewayTabPage.Controls.Add(this.UseRDGatewayCheckBox);
            this.GatewayTabPage.Controls.Add(this.GatewayAddress);
            this.GatewayTabPage.Controls.Add(this.RDGWLabel);
            this.GatewayTabPage.Location = new System.Drawing.Point(4, 24);
            this.GatewayTabPage.Name = "GatewayTabPage";
            this.GatewayTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GatewayTabPage.Size = new System.Drawing.Size(484, 109);
            this.GatewayTabPage.TabIndex = 2;
            this.GatewayTabPage.Text = "网关";
            this.GatewayTabPage.UseVisualStyleBackColor = true;
            // 
            // FileTypesTabPage
            // 
            this.FileTypesTabPage.Controls.Add(this.FTACountLabel);
            this.FileTypesTabPage.Controls.Add(this.FTAButton);
            this.FileTypesTabPage.Controls.Add(this.DisabledFTACheckBox);
            this.FileTypesTabPage.Location = new System.Drawing.Point(4, 24);
            this.FileTypesTabPage.Name = "FileTypesTabPage";
            this.FileTypesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FileTypesTabPage.Size = new System.Drawing.Size(484, 109);
            this.FileTypesTabPage.TabIndex = 3;
            this.FileTypesTabPage.Text = "文件类型";
            this.FileTypesTabPage.UseVisualStyleBackColor = true;
            // 
            // MSIOptionsTabPage
            // 
            this.MSIOptionsTabPage.Controls.Add(this.Panel1);
            this.MSIOptionsTabPage.Controls.Add(this.Label1);
            this.MSIOptionsTabPage.Controls.Add(this.TopLevelRadioButton);
            this.MSIOptionsTabPage.Controls.Add(this.Label4);
            this.MSIOptionsTabPage.Controls.Add(this.SubfolderRadioButton);
            this.MSIOptionsTabPage.Controls.Add(this.ShortcutTagTextBox);
            this.MSIOptionsTabPage.Controls.Add(this.ShortcutStartCheckBox);
            this.MSIOptionsTabPage.Controls.Add(this.ShortcutDesktopCheckBox);
            this.MSIOptionsTabPage.Controls.Add(this.Label3);
            this.MSIOptionsTabPage.Controls.Add(this.ShortcutTagCheckBox);
            this.MSIOptionsTabPage.Controls.Add(this.Label2);
            this.MSIOptionsTabPage.Location = new System.Drawing.Point(4, 24);
            this.MSIOptionsTabPage.Name = "MSIOptionsTabPage";
            this.MSIOptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MSIOptionsTabPage.Size = new System.Drawing.Size(484, 109);
            this.MSIOptionsTabPage.TabIndex = 4;
            this.MSIOptionsTabPage.Text = "MSI 选项";
            this.MSIOptionsTabPage.UseVisualStyleBackColor = true;
            // 
            // SigningTabPage
            // 
            this.SigningTabPage.Controls.Add(this.RdpsignErrorLabel);
            this.SigningTabPage.Controls.Add(this.CheckBoxCreateSignedAndUnsigned);
            this.SigningTabPage.Controls.Add(this.CheckBoxSignRDPEnabled);
            this.SigningTabPage.Controls.Add(this.CertificateComboBox);
            this.SigningTabPage.Controls.Add(this.CertificateLabel);
            this.SigningTabPage.Location = new System.Drawing.Point(4, 24);
            this.SigningTabPage.Name = "SigningTabPage";
            this.SigningTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SigningTabPage.Size = new System.Drawing.Size(484, 109);
            this.SigningTabPage.TabIndex = 5;
            this.SigningTabPage.Text = "签名";
            this.SigningTabPage.UseVisualStyleBackColor = true;
            // 
            // RdpsignErrorLabel
            // 
            this.RdpsignErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpsignErrorLabel.Location = new System.Drawing.Point(6, 64);
            this.RdpsignErrorLabel.Name = "RdpsignErrorLabel";
            this.RdpsignErrorLabel.Size = new System.Drawing.Size(472, 21);
            this.RdpsignErrorLabel.TabIndex = 4;
            this.RdpsignErrorLabel.Text = "签名错误";
            this.RdpsignErrorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RemoteAppCreateClientConnection
            // 
            this.AcceptButton = this.CreateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.CancelEditButton;
            this.ClientSize = new System.Drawing.Size(513, 198);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CancelEditButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteAppCreateClientConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "为 [应用名称] 创建客户端连接";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.HostTabPage.ResumeLayout(false);
            this.HostTabPage.PerformLayout();
            this.OptionsTabPage.ResumeLayout(false);
            this.OptionsTabPage.PerformLayout();
            this.GatewayTabPage.ResumeLayout(false);
            this.GatewayTabPage.PerformLayout();
            this.FileTypesTabPage.ResumeLayout(false);
            this.FileTypesTabPage.PerformLayout();
            this.MSIOptionsTabPage.ResumeLayout(false);
            this.MSIOptionsTabPage.PerformLayout();
            this.SigningTabPage.ResumeLayout(false);
            this.SigningTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox EditAfterSave;
        private System.Windows.Forms.ImageList SmallerIcons;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.SaveFileDialog FileSaveRDP;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.TextBox AltServerAddress;
        private System.Windows.Forms.TextBox ServerAddress;
        private System.Windows.Forms.CheckBox AttemptDirectCheckBox;
        private System.Windows.Forms.CheckBox UseRDGatewayCheckBox;
        private System.Windows.Forms.Label RDGWLabel;
        private System.Windows.Forms.TextBox GatewayAddress;
        private System.Windows.Forms.RadioButton MSIRadioButton;
        private System.Windows.Forms.RadioButton RDPRadioButton;
        private System.Windows.Forms.CheckBox CreateRAWebIcon;
        private System.Windows.Forms.Button FTAButton;
        private System.Windows.Forms.OpenFileDialog FileBrowserIcon;
        private System.Windows.Forms.SaveFileDialog FileSaveMSI;
        private System.Windows.Forms.CheckBox ShortcutDesktopCheckBox;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.RadioButton PerMachineRadioButton;
        private System.Windows.Forms.RadioButton PerUserRadioButton;
        private System.Windows.Forms.RadioButton TopLevelRadioButton;
        private System.Windows.Forms.RadioButton SubfolderRadioButton;
        private System.Windows.Forms.CheckBox ShortcutStartCheckBox;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.CheckBox ShortcutTagCheckBox;
        private System.Windows.Forms.TextBox ShortcutTagTextBox;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label FTACountLabel;
        private System.Windows.Forms.CheckBox DisabledFTACheckBox;
        private System.Windows.Forms.CheckBox CheckBoxCreateSignedAndUnsigned;
        private System.Windows.Forms.ComboBox CertificateComboBox;
        private System.Windows.Forms.Label CertificateLabel;
        private System.Windows.Forms.CheckBox CheckBoxSignRDPEnabled;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage HostTabPage;
        private System.Windows.Forms.TabPage OptionsTabPage;
        private System.Windows.Forms.Button RDPOptionsButton;
        private System.Windows.Forms.TabPage GatewayTabPage;
        private System.Windows.Forms.TabPage FileTypesTabPage;
        private System.Windows.Forms.TabPage MSIOptionsTabPage;
        private System.Windows.Forms.TabPage SigningTabPage;
        private System.Windows.Forms.Label RdpsignErrorLabel;
    }
}