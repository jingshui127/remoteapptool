using System.ComponentModel;
using System.Windows.Forms;

namespace RemoteAppTool
{
    partial class RDPOptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDPOptionsWindow));
            this.OptionsListBox = new System.Windows.Forms.ListBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ChangedOptionsListView = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SaveButton = new System.Windows.Forms.Button();
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.ResetButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.DefaultsButton = new System.Windows.Forms.Button();
            this.ResetValueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OptionsListBox
            // 
            this.OptionsListBox.FormattingEnabled = true;
            this.OptionsListBox.ItemHeight = 15;
            this.OptionsListBox.Location = new System.Drawing.Point(11, 12);
            this.OptionsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.OptionsListBox.Name = "OptionsListBox";
            this.OptionsListBox.Size = new System.Drawing.Size(213, 169);
            this.OptionsListBox.TabIndex = 0;
            this.OptionsListBox.SelectedIndexChanged += new System.EventHandler(this.OptionsListBox_SelectedIndexChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(228, 12);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextBox.Size = new System.Drawing.Size(347, 169);
            this.DescriptionTextBox.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 188);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 15);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "设置值：";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTextBox.Location = new System.Drawing.Point(72, 185);
            this.ValueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(476, 23);
            this.ValueTextBox.TabIndex = 3;
            this.ValueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
            // 
            // ChangedOptionsListView
            // 
            this.ChangedOptionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangedOptionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3});
            this.ChangedOptionsListView.FullRowSelect = true;
            this.ChangedOptionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ChangedOptionsListView.HideSelection = false;
            this.ChangedOptionsListView.Location = new System.Drawing.Point(11, 238);
            this.ChangedOptionsListView.Margin = new System.Windows.Forms.Padding(2);
            this.ChangedOptionsListView.MultiSelect = false;
            this.ChangedOptionsListView.Name = "ChangedOptionsListView";
            this.ChangedOptionsListView.Size = new System.Drawing.Size(564, 117);
            this.ChangedOptionsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ChangedOptionsListView.TabIndex = 6;
            this.ChangedOptionsListView.UseCompatibleStateImageBehavior = false;
            this.ChangedOptionsListView.View = System.Windows.Forms.View.Details;
            this.ChangedOptionsListView.SelectedIndexChanged += new System.EventHandler(this.ChangedOptionsListView_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "选项";
            this.ColumnHeader1.Width = 200;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "类型";
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "值";
            this.ColumnHeader3.Width = 282;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SaveButton.ImageList = this.SmallerIcons;
            this.SaveButton.Location = new System.Drawing.Point(511, 366);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(64, 29);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "关闭";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ResetButton.ImageIndex = 4;
            this.ResetButton.ImageList = this.SmallerIcons;
            this.ResetButton.Location = new System.Drawing.Point(417, 366);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(90, 29);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "清除所有";
            this.ResetButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 221);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 15);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "已选选项：";
            // 
            // DefaultsButton
            // 
            this.DefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DefaultsButton.ImageIndex = 3;
            this.DefaultsButton.ImageList = this.SmallerIcons;
            this.DefaultsButton.Location = new System.Drawing.Point(324, 366);
            this.DefaultsButton.Margin = new System.Windows.Forms.Padding(2);
            this.DefaultsButton.Name = "DefaultsButton";
            this.DefaultsButton.Size = new System.Drawing.Size(89, 29);
            this.DefaultsButton.TabIndex = 7;
            this.DefaultsButton.Text = "默认值";
            this.DefaultsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DefaultsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DefaultsButton.UseVisualStyleBackColor = false;
            this.DefaultsButton.Click += new System.EventHandler(this.DefaultsButton_Click);
            // 
            // ResetValueButton
            // 
            this.ResetValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetValueButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ResetValueButton.ImageIndex = 4;
            this.ResetValueButton.ImageList = this.SmallerIcons;
            this.ResetValueButton.Location = new System.Drawing.Point(552, 184);
            this.ResetValueButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetValueButton.Name = "ResetValueButton";
            this.ResetValueButton.Size = new System.Drawing.Size(25, 25);
            this.ResetValueButton.TabIndex = 4;
            this.ResetValueButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResetValueButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ResetValueButton.UseVisualStyleBackColor = false;
            this.ResetValueButton.Click += new System.EventHandler(this.ResetValueButton_Click);
            // 
            // RDPOptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 406);
            this.Controls.Add(this.ResetValueButton);
            this.Controls.Add(this.DefaultsButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ChangedOptionsListView);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.OptionsListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 暂时注释掉Icon资源加载，避免资源文件缺失错误
            // this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(602, 445);
            this.Name = "RDPOptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RDP 选项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox OptionsListBox;
        private TextBox DescriptionTextBox;
        private Label Label1;
        private TextBox ValueTextBox;
        private ListView ChangedOptionsListView;
        private ColumnHeader ColumnHeader1;
        private ColumnHeader ColumnHeader2;
        private ColumnHeader ColumnHeader3;
        private Button SaveButton;
        private ImageList SmallerIcons;
        private Button ResetButton;
        private Label Label2;
        private Button DefaultsButton;
        private Button ResetValueButton;
    }
}