using System.ComponentModel;
using System.Windows.Forms;

namespace RemoteAppTool
{
    partial class RemoteAppFileTypeAssociation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppFileTypeAssociation));
            this.FTAListView = new System.Windows.Forms.ListView();
            this.FileExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IconPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IconIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Associated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreateButton = new System.Windows.Forms.Button();
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SetAssociationButton = new System.Windows.Forms.Button();
            this.SmallerIcons2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // FTAListView
            // 
            this.FTAListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FTAListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FTAListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileExtension,
            this.IconPath,
            this.IconIndex,
            this.Associated});
            this.FTAListView.FullRowSelect = true;
            this.FTAListView.GridLines = true;
            this.FTAListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FTAListView.HideSelection = false;
            this.FTAListView.Location = new System.Drawing.Point(-1, -1);
            this.FTAListView.MultiSelect = false;
            this.FTAListView.Name = "FTAListView";
            this.FTAListView.Size = new System.Drawing.Size(496, 164);
            this.FTAListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.FTAListView.TabIndex = 0;
            this.FTAListView.UseCompatibleStateImageBehavior = false;
            this.FTAListView.View = System.Windows.Forms.View.Details;
            this.FTAListView.SelectedIndexChanged += new System.EventHandler(this.FTAListView_SelectedIndexChanged);
            this.FTAListView.DoubleClick += new System.EventHandler(this.FTAListView_DoubleClick);
            // 
            // FileExtension
            // 
            this.FileExtension.Text = "扩展名";
            this.FileExtension.Width = 64;
            // 
            // IconPath
            // 
            this.IconPath.Text = "图标路径";
            this.IconPath.Width = 305;
            // 
            // IconIndex
            // 
            this.IconIndex.Text = "索引";
            this.IconIndex.Width = 51;
            // 
            // Associated
            // 
            this.Associated.Text = "关联";
            this.Associated.Width = 76;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateButton.AutoSize = true;
            this.CreateButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateButton.FlatAppearance.BorderSize = 0;
            this.CreateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CreateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.ImageIndex = 1;
            this.CreateButton.ImageList = this.SmallerIcons;
            this.CreateButton.Location = new System.Drawing.Point(12, 169);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(29, 29);
            this.CreateButton.TabIndex = 1;
            this.CreateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SmallerIcons
            // 
            this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
            this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons.Images.SetKeyName(0, "properties.ico");
            this.SmallerIcons.Images.SetKeyName(1, "plus.ico");
            this.SmallerIcons.Images.SetKeyName(2, "minus.ico");
            this.SmallerIcons.Images.SetKeyName(3, "tick.ico");
            this.SmallerIcons.Images.SetKeyName(4, "flag2-add.ico");
            this.SmallerIcons.Images.SetKeyName(5, "settings-16.ico");
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.AutoSize = true;
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ImageIndex = 2;
            this.DeleteButton.ImageList = this.SmallerIcons;
            this.DeleteButton.Location = new System.Drawing.Point(48, 169);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(29, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.AutoSize = true;
            this.EditButton.BackColor = System.Drawing.Color.Transparent;
            this.EditButton.Enabled = false;
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditButton.ImageIndex = 0;
            this.EditButton.ImageList = this.SmallerIcons;
            this.EditButton.Location = new System.Drawing.Point(84, 169);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(29, 29);
            this.EditButton.TabIndex = 3;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ImageIndex = 3;
            this.CloseButton.ImageList = this.SmallerIcons;
            this.CloseButton.Location = new System.Drawing.Point(415, 169);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(67, 29);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "确定";
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SetAssociationButton
            // 
            this.SetAssociationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SetAssociationButton.AutoSize = true;
            this.SetAssociationButton.BackColor = System.Drawing.Color.Transparent;
            this.SetAssociationButton.Enabled = false;
            this.SetAssociationButton.FlatAppearance.BorderSize = 0;
            this.SetAssociationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SetAssociationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SetAssociationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetAssociationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetAssociationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SetAssociationButton.ImageIndex = 4;
            this.SetAssociationButton.ImageList = this.SmallerIcons;
            this.SetAssociationButton.Location = new System.Drawing.Point(119, 169);
            this.SetAssociationButton.Name = "SetAssociationButton";
            this.SetAssociationButton.Size = new System.Drawing.Size(29, 29);
            this.SetAssociationButton.TabIndex = 4;
            this.SetAssociationButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SetAssociationButton.UseVisualStyleBackColor = false;
            this.SetAssociationButton.Click += new System.EventHandler(this.SetAssociationButton_Click);
            // 
            // SmallerIcons2
            // 
            this.SmallerIcons2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons2.ImageStream")));
            this.SmallerIcons2.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons2.Images.SetKeyName(0, "cross.ico");
            // 
            // RemoteAppFileTypeAssociation
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 208);
            this.Controls.Add(this.SetAssociationButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.FTAListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 暂时注释掉图标加载，避免资源文件缺失错误
            // this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 247);
            this.Name = "RemoteAppFileTypeAssociation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文件类型关联";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView FTAListView;
        private ColumnHeader FileExtension;
        private ColumnHeader IconPath;
        private ColumnHeader IconIndex;
        private Button CreateButton;
        private Button DeleteButton;
        private Button EditButton;
        private Button CloseButton;
        private ColumnHeader Associated;
        private Button SetAssociationButton;
        private ImageList SmallerIcons;
        private ImageList SmallerIcons2;
    }
}