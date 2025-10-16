using System.ComponentModel;
using System.Windows.Forms;

namespace RemoteAppTool
{
    partial class RemoteAppIconPicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppIconPicker));
            this.IconList = new System.Windows.Forms.ListView();
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.IconPathTextBox = new System.Windows.Forms.TextBox();
            this.IconIndexTextBox = new System.Windows.Forms.TextBox();
            this.FileBrowserIcon = new System.Windows.Forms.OpenFileDialog();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.FileTypeTextBox = new System.Windows.Forms.TextBox();
            this.IconIndexLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IconList
            // 
            this.IconList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IconList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.IconList.GridLines = true;
            this.IconList.HideSelection = false;
            this.IconList.LargeImageList = this.SmallIcons;
            this.IconList.Location = new System.Drawing.Point(16, 41);
            this.IconList.MultiSelect = false;
            this.IconList.Name = "IconList";
            this.IconList.Size = new System.Drawing.Size(471, 143);
            this.IconList.SmallImageList = this.SmallIcons;
            this.IconList.TabIndex = 4;
            this.IconList.UseCompatibleStateImageBehavior = false;
            this.IconList.SelectedIndexChanged += new System.EventHandler(this.IconList_SelectedIndexChanged);
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
            this.SmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallIcons.ImageStream")));
            this.SmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallIcons.Images.SetKeyName(0, "smallicons.ico");
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BrowseButton.ImageIndex = 0;
            this.BrowseButton.ImageList = this.SmallerIcons;
            this.BrowseButton.Location = new System.Drawing.Point(14, 8);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(82, 29);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "浏览...";
            this.BrowseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // SmallerIcons
            // 
            this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
            this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons.Images.SetKeyName(0, "folder_16x16.png");
            this.SmallerIcons.Images.SetKeyName(1, "tick.ico");
            this.SmallerIcons.Images.SetKeyName(2, "cross.ico");
            this.SmallerIcons.Images.SetKeyName(3, "settings-16.ico");
            // 
            // IconPathTextBox
            // 
            this.IconPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IconPathTextBox.Location = new System.Drawing.Point(98, 12);
            this.IconPathTextBox.Name = "IconPathTextBox";
            this.IconPathTextBox.ReadOnly = true;
            this.IconPathTextBox.Size = new System.Drawing.Size(267, 47);
            this.IconPathTextBox.TabIndex = 1;
            // 
            // IconIndexTextBox
            // 
            this.IconIndexTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconIndexTextBox.Location = new System.Drawing.Point(420, 12);
            this.IconIndexTextBox.Name = "IconIndexTextBox";
            this.IconIndexTextBox.ReadOnly = true;
            this.IconIndexTextBox.Size = new System.Drawing.Size(67, 47);
            this.IconIndexTextBox.TabIndex = 3;
            this.IconIndexTextBox.Visible = false;
            this.IconIndexTextBox.TextChanged += new System.EventHandler(this.IconIndexTextBox_TextChanged);
            // 
            // FileBrowserIcon
            // 
            this.FileBrowserIcon.Filter = "图标|*.exe;*.dll;*.ico|所有文件|*.*";
            this.FileBrowserIcon.Title = "浏览...";
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelEditButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CancelEditButton.ImageIndex = 2;
            this.CancelEditButton.ImageList = this.SmallerIcons;
            this.CancelEditButton.Location = new System.Drawing.Point(339, 190);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(75, 29);
            this.CancelEditButton.TabIndex = 7;
            this.CancelEditButton.Text = "取消";
            this.CancelEditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelEditButton.UseVisualStyleBackColor = false;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OKButton.ImageIndex = 1;
            this.OKButton.ImageList = this.SmallerIcons;
            this.OKButton.Location = new System.Drawing.Point(420, 190);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(67, 29);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "确定";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = false;
            // 
            // FileTypeLabel
            // 
            this.FileTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileTypeLabel.AutoSize = true;
            this.FileTypeLabel.Location = new System.Drawing.Point(12, 197);
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.FileTypeLabel.Size = new System.Drawing.Size(185, 41);
            this.FileTypeLabel.TabIndex = 5;
            this.FileTypeLabel.Text = "文件类型：.";
            this.FileTypeLabel.Visible = false;
            // 
            // FileTypeTextBox
            // 
            this.FileTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileTypeTextBox.Location = new System.Drawing.Point(76, 194);
            this.FileTypeTextBox.Name = "FileTypeTextBox";
            this.FileTypeTextBox.Size = new System.Drawing.Size(80, 47);
            this.FileTypeTextBox.TabIndex = 6;
            this.FileTypeTextBox.Visible = false;
            this.FileTypeTextBox.TextChanged += new System.EventHandler(this.FileTypeTextBox_TextChanged);
            // 
            // IconIndexLabel
            // 
            this.IconIndexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconIndexLabel.AutoSize = true;
            this.IconIndexLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IconIndexLabel.Location = new System.Drawing.Point(373, 15);
            this.IconIndexLabel.Name = "IconIndexLabel";
            this.IconIndexLabel.Size = new System.Drawing.Size(114, 41);
            this.IconIndexLabel.TabIndex = 2;
            this.IconIndexLabel.Text = "索引：";
            this.IconIndexLabel.Visible = false;
            // 
            // RemoteAppIconPicker
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelEditButton;
            this.ClientSize = new System.Drawing.Size(499, 231);
            this.Controls.Add(this.IconIndexLabel);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.IconIndexTextBox);
            this.Controls.Add(this.IconPathTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.IconList);
            this.Controls.Add(this.FileTypeTextBox);
            this.Controls.Add(this.FileTypeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 270);
            this.Name = "RemoteAppIconPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " 图标选择器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView IconList;
        private ColumnHeader ShortName;
        private ColumnHeader Title;
        private ColumnHeader Path;
        private ColumnHeader VPath;
        private ColumnHeader RequiredCommandLine;
        private ColumnHeader CommandLineSetting;
        private ColumnHeader IconPath;
        private ColumnHeader IconIndex;
        private ColumnHeader SecurityDescriptor;
        private ColumnHeader ShowInTSWA;
        private Button BrowseButton;
        private TextBox IconPathTextBox;
        private TextBox IconIndexTextBox;
        private OpenFileDialog FileBrowserIcon;
        private Button CancelEditButton;
        private Button OKButton;
        private Label FileTypeLabel;
        private TextBox FileTypeTextBox;
        private ImageList SmallerIcons;
        private Label IconIndexLabel;
        private ImageList SmallIcons;
    }
}