namespace RemoteApp_Tool
{
    partial class RemoteAppEditWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppEditWindow));
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.TSWAbox = new System.Windows.Forms.ComboBox();
            this.CommandLineOptionCombo = new System.Windows.Forms.ComboBox();
            this.CommandLineText = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.FileBrowserPath = new System.Windows.Forms.OpenFileDialog();
            this.FileBrowserIcon = new System.Windows.Forms.OpenFileDialog();
            this.FileBrowserVPath = new System.Windows.Forms.OpenFileDialog();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FTAButton = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.FullNameText = new System.Windows.Forms.TextBox();
            this.ShortNameText = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.BrowseIconPath = new System.Windows.Forms.Button();
            this.IconResetButton = new System.Windows.Forms.Button();
            this.IconPathText = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.PathText = new System.Windows.Forms.TextBox();
            this.IconIndexText = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.BrowsePath = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmallerIcons
            // 
            this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
            this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons.Images.SetKeyName(0, "favorites_16x16.png");
            this.SmallerIcons.Images.SetKeyName(1, "folder_16x16.png");
            this.SmallerIcons.Images.SetKeyName(2, "dotdotdot.ico");
            this.SmallerIcons.Images.SetKeyName(3, "inside_icons_azure_marker_map_socialize_base.ico");
            this.SmallerIcons.Images.SetKeyName(4, "pictures (1).ico");
            this.SmallerIcons.Images.SetKeyName(5, "pictures.ico");
            this.SmallerIcons.Images.SetKeyName(6, "arrows_line_connector_with_draw.png");
            this.SmallerIcons.Images.SetKeyName(7, "doc_file_document_manager_paper_phone.ico");
            this.SmallerIcons.Images.SetKeyName(8, "cross.ico");
            // 
            // TSWAbox
            // 
            this.TSWAbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TSWAbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TSWAbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TSWAbox.FormattingEnabled = true;
            this.TSWAbox.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.TSWAbox.Location = new System.Drawing.Point(328, 22);
            this.TSWAbox.Name = "TSWAbox";
            this.TSWAbox.Size = new System.Drawing.Size(71, 23);
            this.TSWAbox.TabIndex = 3;
            // 
            // CommandLineOptionCombo
            // 
            this.CommandLineOptionCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CommandLineOptionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommandLineOptionCombo.FormattingEnabled = true;
            this.CommandLineOptionCombo.Items.AddRange(new object[] {
            "已禁用",
            "可选",
            "强制"});
            this.CommandLineOptionCombo.Location = new System.Drawing.Point(97, 22);
            this.CommandLineOptionCombo.Name = "CommandLineOptionCombo";
            this.CommandLineOptionCombo.Size = new System.Drawing.Size(70, 23);
            this.CommandLineOptionCombo.TabIndex = 1;
            // 
            // CommandLineText
            // 
            this.CommandLineText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandLineText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CommandLineText.Location = new System.Drawing.Point(163, 53);
            this.CommandLineText.Name = "CommandLineText";
            this.CommandLineText.Size = new System.Drawing.Size(236, 23);
            this.CommandLineText.TabIndex = 5;
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(172, 25);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(150, 15);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "在 TSWebAccess 中显示：";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(6, 25);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(85, 15);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "命令行选项：";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label6.Location = new System.Drawing.Point(6, 56);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(85, 15);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "命令行参数：";
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelEditButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CancelEditButton.ImageIndex = 8;
            this.CancelEditButton.ImageList = this.SmallerIcons;
            this.CancelEditButton.Location = new System.Drawing.Point(269, 356);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(75, 29);
            this.CancelEditButton.TabIndex = 3;
            this.CancelEditButton.Text = "取消";
            this.CancelEditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelEditButton.UseVisualStyleBackColor = false;
            this.CancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            // 
            // FileBrowserPath
            // 
            this.FileBrowserPath.Filter = "程序|*.exe;*.com;*.cmd;*.bat|所有文件|*.*";
            this.FileBrowserPath.Title = "浏览...";
            // 
            // FileBrowserIcon
            // 
            this.FileBrowserIcon.Filter = "图标|*.exe;*.dll;*.ico|所有文件|*.*";
            this.FileBrowserIcon.Title = "浏览...";
            // 
            // FileBrowserVPath
            // 
            this.FileBrowserVPath.Filter = "程序|*.exe;*.com;*.cmd;*.bat|所有文件|*.*";
            this.FileBrowserVPath.Title = "浏览...";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveButton.ImageIndex = 0;
            this.SaveButton.ImageList = this.SmallerIcons;
            this.SaveButton.Location = new System.Drawing.Point(350, 356);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(67, 29);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "保存";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FTAButton
            // 
            this.FTAButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FTAButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FTAButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FTAButton.ImageIndex = 7;
            this.FTAButton.ImageList = this.SmallerIcons;
            this.FTAButton.Location = new System.Drawing.Point(163, 82);
            this.FTAButton.Name = "FTAButton";
            this.FTAButton.Size = new System.Drawing.Size(236, 29);
            this.FTAButton.TabIndex = 7;
            this.FTAButton.Text = "配置...";
            this.FTAButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FTAButton.UseVisualStyleBackColor = false;
            this.FTAButton.Click += new System.EventHandler(this.FTAButton_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.FullNameText);
            this.GroupBox1.Controls.Add(this.ShortNameText);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(405, 91);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "标题";
            // 
            // FullNameText
            // 
            this.FullNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullNameText.Location = new System.Drawing.Point(72, 51);
            this.FullNameText.Name = "FullNameText";
            this.FullNameText.Size = new System.Drawing.Size(327, 23);
            this.FullNameText.TabIndex = 3;
            // 
            // ShortNameText
            // 
            this.ShortNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShortNameText.Location = new System.Drawing.Point(72, 22);
            this.ShortNameText.Name = "ShortNameText";
            this.ShortNameText.Size = new System.Drawing.Size(327, 23);
            this.ShortNameText.TabIndex = 1;
            this.ShortNameText.TextChanged += new System.EventHandler(this.ShortNameText_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 54);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(46, 15);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "全名：";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(6, 25);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(46, 15);
            this.Label12.TabIndex = 0;
            this.Label12.Text = "名称：";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.BrowseIconPath);
            this.GroupBox2.Controls.Add(this.IconResetButton);
            this.GroupBox2.Controls.Add(this.IconPathText);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.PathText);
            this.GroupBox2.Controls.Add(this.IconIndexText);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.BrowsePath);
            this.GroupBox2.Location = new System.Drawing.Point(12, 109);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(405, 116);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "文件";
            // 
            // BrowseIconPath
            // 
            this.BrowseIconPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseIconPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseIconPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BrowseIconPath.ImageIndex = 4;
            this.BrowseIconPath.ImageList = this.SmallerIcons;
            this.BrowseIconPath.Location = new System.Drawing.Point(372, 49);
            this.BrowseIconPath.Name = "BrowseIconPath";
            this.BrowseIconPath.Size = new System.Drawing.Size(27, 27);
            this.BrowseIconPath.TabIndex = 5;
            this.BrowseIconPath.UseVisualStyleBackColor = false;
            this.BrowseIconPath.Click += new System.EventHandler(this.BrowseIconPath_Click);
            // 
            // IconResetButton
            // 
            this.IconResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconResetButton.AutoSize = true;
            this.IconResetButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IconResetButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IconResetButton.ImageIndex = 6;
            this.IconResetButton.ImageList = this.SmallerIcons;
            this.IconResetButton.Location = new System.Drawing.Point(227, 80);
            this.IconResetButton.Name = "IconResetButton";
            this.IconResetButton.Size = new System.Drawing.Size(172, 30);
            this.IconResetButton.TabIndex = 8;
            this.IconResetButton.Text = "重置图标";
            this.IconResetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IconResetButton.UseVisualStyleBackColor = false;
            this.IconResetButton.Click += new System.EventHandler(this.IconResetButton_Click);
            // 
            // IconPathText
            // 
            this.IconPathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IconPathText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IconPathText.Location = new System.Drawing.Point(72, 51);
            this.IconPathText.Name = "IconPathText";
            this.IconPathText.Size = new System.Drawing.Size(294, 23);
            this.IconPathText.TabIndex = 4;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label11.Location = new System.Drawing.Point(6, 85);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(72, 15);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "图标索引：";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label7.Location = new System.Drawing.Point(6, 54);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(72, 15);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "图标路径：";
            // 
            // PathText
            // 
            this.PathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathText.Location = new System.Drawing.Point(72, 22);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(294, 23);
            this.PathText.TabIndex = 1;
            // 
            // IconIndexText
            // 
            this.IconIndexText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IconIndexText.Location = new System.Drawing.Point(78, 80);
            this.IconIndexText.Name = "IconIndexText";
            this.IconIndexText.Size = new System.Drawing.Size(60, 23);
            this.IconIndexText.TabIndex = 7;
            this.IconIndexText.Text = "0";
            this.IconIndexText.TextChanged += new System.EventHandler(this.IconIndexText_TextChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 25);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(98, 15);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "应用程序路径：";
            // 
            // BrowsePath
            // 
            this.BrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowsePath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowsePath.ImageIndex = 1;
            this.BrowsePath.ImageList = this.SmallerIcons;
            this.BrowsePath.Location = new System.Drawing.Point(372, 20);
            this.BrowsePath.Name = "BrowsePath";
            this.BrowsePath.Size = new System.Drawing.Size(27, 27);
            this.BrowsePath.TabIndex = 2;
            this.BrowsePath.UseVisualStyleBackColor = false;
            this.BrowsePath.Click += new System.EventHandler(this.BrowsePath_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.FTAButton);
            this.GroupBox3.Controls.Add(this.CommandLineText);
            this.GroupBox3.Controls.Add(this.CommandLineOptionCombo);
            this.GroupBox3.Controls.Add(this.TSWAbox);
            this.GroupBox3.Location = new System.Drawing.Point(12, 231);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(405, 119);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "选项";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label1.Location = new System.Drawing.Point(6, 87);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(98, 15);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "文件类型关联：";
            // 
            // RemoteAppEditWindow
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelEditButton;
            this.ClientSize = new System.Drawing.Size(429, 397);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1500, 436);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(445, 436);
            this.Name = "RemoteAppEditWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " 编辑窗口";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TSWAbox;
        private System.Windows.Forms.ComboBox CommandLineOptionCombo;
        private System.Windows.Forms.TextBox CommandLineText;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.ImageList SmallerIcons;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.OpenFileDialog FileBrowserPath;
        private System.Windows.Forms.OpenFileDialog FileBrowserIcon;
        private System.Windows.Forms.OpenFileDialog FileBrowserVPath;
        private System.Windows.Forms.Button FTAButton;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox FullNameText;
        private System.Windows.Forms.TextBox ShortNameText;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Button BrowseIconPath;
        private System.Windows.Forms.Button IconResetButton;
        private System.Windows.Forms.TextBox IconPathText;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox PathText;
        private System.Windows.Forms.TextBox IconIndexText;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Button BrowsePath;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label Label1;
    }
}