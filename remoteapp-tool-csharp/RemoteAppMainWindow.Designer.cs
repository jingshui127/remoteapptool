namespace RemoteApp_Tool
{
    partial class RemoteAppMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppMainWindow));
            this.AppList = new System.Windows.Forms.ListView();
            this.ShortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RequiredCommandLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommandLineSetting = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IconPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IconIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SecurityDescriptor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShowInTSWA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.NoAppsLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CreateClientConnection = new System.Windows.Forms.Button();
            this.ToolsMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewRemoteAppadvancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HostOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveUnusedFileTypeAssociationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupAllRemoteAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackupSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnCopy = new System.Windows.Forms.Button();
            this.文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppList
            // 
            this.AppList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.AppList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppList.BackColor = System.Drawing.Color.White;
            this.AppList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ShortName,
            this.Title,
            this.Path,
            this.VPath,
            this.RequiredCommandLine,
            this.CommandLineSetting,
            this.IconPath,
            this.IconIndex,
            this.SecurityDescriptor,
            this.ShowInTSWA});
            this.AppList.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.AppList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.AppList.FullRowSelect = true;
            this.AppList.HideSelection = false;
            this.AppList.LargeImageList = this.SmallIcons;
            this.AppList.Location = new System.Drawing.Point(16, 32);
            this.AppList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AppList.MultiSelect = false;
            this.AppList.Name = "AppList";
            this.AppList.Size = new System.Drawing.Size(568, 211);
            this.AppList.SmallImageList = this.SmallIcons;
            this.AppList.TabIndex = 1;
            this.AppList.TileSize = new System.Drawing.Size(240, 48);
            this.AppList.UseCompatibleStateImageBehavior = false;
            this.AppList.View = System.Windows.Forms.View.Tile;
            this.AppList.SelectedIndexChanged += new System.EventHandler(this.AppList_SelectedIndexChanged);
            this.AppList.DoubleClick += new System.EventHandler(this.AppList_DoubleClick);
            // 
            // ShortName
            // 
            this.ShortName.Text = "短名称";
            this.ShortName.Width = 200;
            // 
            // Title
            // 
            this.Title.Text = "名称";
            // 
            // Path
            // 
            this.Path.Text = "路径";
            // 
            // VPath
            // 
            this.VPath.Text = "虚拟路径";
            // 
            // RequiredCommandLine
            // 
            this.RequiredCommandLine.Text = "必需的命令行";
            // 
            // CommandLineSetting
            // 
            this.CommandLineSetting.Text = "命令行设置";
            // 
            // IconPath
            // 
            this.IconPath.Text = "图标路径";
            // 
            // IconIndex
            // 
            this.IconIndex.Text = "图标索引";
            // 
            // SecurityDescriptor
            // 
            this.SecurityDescriptor.Text = "安全描述符";
            // 
            // ShowInTSWA
            // 
            this.ShowInTSWA.Text = "在TSWA中显示";
            // 
            // SmallIcons
            // 
            this.SmallIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.SmallIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.SmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SmallerIcons
            // 
            this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
            this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons.Images.SetKeyName(0, "");
            this.SmallerIcons.Images.SetKeyName(1, "");
            this.SmallerIcons.Images.SetKeyName(2, "");
            this.SmallerIcons.Images.SetKeyName(3, "");
            this.SmallerIcons.Images.SetKeyName(4, "");
            this.SmallerIcons.Images.SetKeyName(5, "");
            this.SmallerIcons.Images.SetKeyName(6, "");
            // 
            // NoAppsLabel
            // 
            this.NoAppsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoAppsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoAppsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NoAppsLabel.Location = new System.Drawing.Point(25, 130);
            this.NoAppsLabel.Name = "NoAppsLabel";
            this.NoAppsLabel.Size = new System.Drawing.Size(543, 65);
            this.NoAppsLabel.TabIndex = 0;
            this.NoAppsLabel.Text = "此计算机上没有托管 RemoteApp。\r\n点击 [+创建] 按钮添加一个。";
            this.NoAppsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoAppsLabel.Visible = false;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.CreateButton.FlatAppearance.BorderSize = 0;
            this.CreateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            this.CreateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.ForeColor = System.Drawing.Color.White;
            this.CreateButton.ImageIndex = 5;
            this.CreateButton.ImageList = this.SmallerIcons;
            this.CreateButton.Location = new System.Drawing.Point(16, 257);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(90, 36);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = " 创建";
            this.CreateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.BackColor = System.Drawing.Color.White;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DeleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DeleteButton.ImageIndex = 6;
            this.DeleteButton.ImageList = this.SmallerIcons;
            this.DeleteButton.Location = new System.Drawing.Point(280, 257);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 36);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = " 删除";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.BackColor = System.Drawing.Color.White;
            this.EditButton.Enabled = false;
            this.EditButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EditButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.EditButton.ImageIndex = 4;
            this.EditButton.ImageList = this.SmallerIcons;
            this.EditButton.Location = new System.Drawing.Point(112, 257);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(76, 36);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = " 编辑";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CreateClientConnection
            // 
            this.CreateClientConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateClientConnection.BackColor = System.Drawing.Color.White;
            this.CreateClientConnection.Enabled = false;
            this.CreateClientConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CreateClientConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.CreateClientConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CreateClientConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateClientConnection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CreateClientConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CreateClientConnection.ImageIndex = 3;
            this.CreateClientConnection.ImageList = this.SmallerIcons;
            this.CreateClientConnection.Location = new System.Drawing.Point(419, 257);
            this.CreateClientConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateClientConnection.Name = "CreateClientConnection";
            this.CreateClientConnection.Size = new System.Drawing.Size(165, 36);
            this.CreateClientConnection.TabIndex = 5;
            this.CreateClientConnection.Text = " 创建客户端连接...";
            this.CreateClientConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateClientConnection.UseVisualStyleBackColor = false;
            this.CreateClientConnection.Click += new System.EventHandler(this.CreateClientConnection_Click);
            // 
            // ToolsMenuStrip
            // 
            this.ToolsMenuStrip.BackColor = System.Drawing.Color.White;
            this.ToolsMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolsMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.ToolsMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ToolsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.ToolsMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolsMenuStrip.Name = "ToolsMenuStrip";
            this.ToolsMenuStrip.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.ToolsMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolsMenuStrip.Size = new System.Drawing.Size(600, 56);
            this.ToolsMenuStrip.TabIndex = 0;
            this.ToolsMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewRemoteAppadvancedToolStripMenuItem,
            this.DuplicateToolStripMenuItem,
            this.ToolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(139, 48);
            this.FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // NewRemoteAppadvancedToolStripMenuItem
            // 
            this.NewRemoteAppadvancedToolStripMenuItem.Name = "NewRemoteAppadvancedToolStripMenuItem";
            this.NewRemoteAppadvancedToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.NewRemoteAppadvancedToolStripMenuItem.Text = "新建 RemoteApp (高级)";
            this.NewRemoteAppadvancedToolStripMenuItem.Click += new System.EventHandler(this.NewRemoteAppadvancedToolStripMenuItem_Click);
            // 
            // DuplicateToolStripMenuItem
            // 
            this.DuplicateToolStripMenuItem.Enabled = false;
            this.DuplicateToolStripMenuItem.Name = "DuplicateToolStripMenuItem";
            this.DuplicateToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.DuplicateToolStripMenuItem.Text = "复制";
            this.DuplicateToolStripMenuItem.Click += new System.EventHandler(this.DuplicateToolStripMenuItem_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(501, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            // ToolsToolStripMenuItem
            // 
            this.HostStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HostStatusToolStripMenuItem.Name = "HostStatusToolStripMenuItem";
            this.HostStatusToolStripMenuItem.Size = new System.Drawing.Size(568, 54);
            this.HostStatusToolStripMenuItem.Text = "主机状态...";
            this.HostStatusToolStripMenuItem.Click += new System.EventHandler(this.HostStatusToolStripMenuItem_Click);
            // 
            // HostOptionsToolStripMenuItem
            // 
            this.HostOptionsToolStripMenuItem.Name = "HostOptionsToolStripMenuItem";
            this.HostOptionsToolStripMenuItem.Size = new System.Drawing.Size(568, 54);
            this.HostOptionsToolStripMenuItem.Text = "主机选项...";
            this.HostOptionsToolStripMenuItem.Click += new System.EventHandler(this.HostOptionsToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HostStatusToolStripMenuItem,
            this.HostOptionsToolStripMenuItem,
            this.ToolStripSeparator3,
            this.RemoveUnusedFileTypeAssociationsToolStripMenuItem,
            this.BackupAllRemoteAppsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(140, 48);
            this.ToolsToolStripMenuItem.Text = "工具(&T)";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(565, 6);
            // 
            // RemoveUnusedFileTypeAssociationsToolStripMenuItem
            // 
            this.RemoveUnusedFileTypeAssociationsToolStripMenuItem.Name = "RemoveUnusedFileTypeAssociationsToolStripMenuItem";
            this.RemoveUnusedFileTypeAssociationsToolStripMenuItem.Size = new System.Drawing.Size(568, 54);
            this.RemoveUnusedFileTypeAssociationsToolStripMenuItem.Text = "删除未使用的文件类型关联";
            this.RemoveUnusedFileTypeAssociationsToolStripMenuItem.Click += new System.EventHandler(this.RemoveUnusedFileTypeAssociationsToolStripMenuItem_Click);
            // 
            // BackupAllRemoteAppsToolStripMenuItem
            // 
            this.BackupAllRemoteAppsToolStripMenuItem.Name = "BackupAllRemoteAppsToolStripMenuItem";
            this.BackupAllRemoteAppsToolStripMenuItem.Size = new System.Drawing.Size(568, 54);
            this.BackupAllRemoteAppsToolStripMenuItem.Text = "备份所有 RemoteApp";
            this.BackupAllRemoteAppsToolStripMenuItem.Click += new System.EventHandler(this.BackupAllRemoteAppsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WebsiteToolStripMenuItem,
            this.文档ToolStripMenuItem,
            this.ToolStripSeparator1,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(145, 48);
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // WebsiteToolStripMenuItem
            // 
            this.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem";
            this.WebsiteToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.WebsiteToolStripMenuItem.Text = "网站";
            this.WebsiteToolStripMenuItem.Click += new System.EventHandler(this.WebsiteToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(445, 6);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.AboutToolStripMenuItem.Text = "关于";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // BackupSaveFileDialog
            // 
            this.BackupSaveFileDialog.DefaultExt = "reg";
            this.BackupSaveFileDialog.Filter = "注册表文件|*.reg";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.BackColor = System.Drawing.Color.White;
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCopy.ImageIndex = 2;
            this.btnCopy.ImageList = this.SmallerIcons;
            this.btnCopy.Location = new System.Drawing.Point(196, 257);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(76, 36);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "复制";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // 文档ToolStripMenuItem
            // 
            this.文档ToolStripMenuItem.Name = "文档ToolStripMenuItem";
            this.文档ToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.文档ToolStripMenuItem.Text = "文档";
            this.文档ToolStripMenuItem.Click += new System.EventHandler(this.文档ToolStripMenuItem_Click);
            // 
            // RemoteAppMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 315);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.CreateClientConnection);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.NoAppsLabel);
            this.Controls.Add(this.AppList);
            this.Controls.Add(this.ToolsMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ToolsMenuStrip;
            this.MinimumSize = new System.Drawing.Size(463, 300);
            this.Name = "RemoteAppMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoteApp Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteAppMainWindow_FormClosing);
            this.Load += new System.EventHandler(this.RemoteAppMainWindow_Load);
            this.Disposed += new System.EventHandler(this.RemoteAppMainWindow_Disposed);
            this.ToolsMenuStrip.ResumeLayout(false);
            this.ToolsMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView AppList;
        private System.Windows.Forms.ColumnHeader ShortName;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ColumnHeader VPath;
        private System.Windows.Forms.ColumnHeader RequiredCommandLine;
        private System.Windows.Forms.ColumnHeader CommandLineSetting;
        private System.Windows.Forms.ColumnHeader IconPath;
        private System.Windows.Forms.ColumnHeader IconIndex;
        private System.Windows.Forms.ColumnHeader SecurityDescriptor;
        private System.Windows.Forms.ColumnHeader ShowInTSWA;
        private System.Windows.Forms.ImageList SmallIcons;
        private System.Windows.Forms.ImageList SmallerIcons;
        private System.Windows.Forms.Label NoAppsLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CreateClientConnection;
        private System.Windows.Forms.MenuStrip ToolsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewRemoteAppadvancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DuplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HostStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HostOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem RemoveUnusedFileTypeAssociationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackupAllRemoteAppsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog BackupSaveFileDialog;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ToolStripMenuItem 文档ToolStripMenuItem;
    }
}