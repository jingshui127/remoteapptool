namespace RemoteApp_Tool
{
    partial class RemoteAppHostOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppHostOptions));
            this.TimeoutDisconnectedCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableAllowListCheckBox = new System.Windows.Forms.CheckBox();
            this.DisconnectTimeTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TimeoutIdleCheckBox = new System.Windows.Forms.CheckBox();
            this.IdleTimeTextBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.LogoffWhenTimoutCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SmallerIcons = new System.Windows.Forms.ImageList(this.components);
            this.Label3 = new System.Windows.Forms.Label();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.AllowUnlistedRemoteProgramsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TimeoutDisconnectedCheckBox
            // 
            this.TimeoutDisconnectedCheckBox.AutoSize = true;
            this.TimeoutDisconnectedCheckBox.Location = new System.Drawing.Point(14, 64);
            this.TimeoutDisconnectedCheckBox.Name = "TimeoutDisconnectedCheckBox";
            this.TimeoutDisconnectedCheckBox.Size = new System.Drawing.Size(182, 19);
            this.TimeoutDisconnectedCheckBox.TabIndex = 2;
            this.TimeoutDisconnectedCheckBox.Text = "断开连接会话的超时时间：";
            this.TimeoutDisconnectedCheckBox.UseVisualStyleBackColor = true;
            this.TimeoutDisconnectedCheckBox.CheckedChanged += new System.EventHandler(this.TimeoutDisconnectedCheckBox_CheckedChanged);
            // 
            // DisableAllowListCheckBox
            // 
            this.DisableAllowListCheckBox.AutoSize = true;
            this.DisableAllowListCheckBox.Location = new System.Drawing.Point(14, 14);
            this.DisableAllowListCheckBox.Name = "DisableAllowListCheckBox";
            this.DisableAllowListCheckBox.Size = new System.Drawing.Size(156, 19);
            this.DisableAllowListCheckBox.TabIndex = 0;
            this.DisableAllowListCheckBox.Text = "禁用应用程序允许列表";
            this.DisableAllowListCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisconnectTimeTextBox
            // 
            this.DisconnectTimeTextBox.Location = new System.Drawing.Point(202, 62);
            this.DisconnectTimeTextBox.MaxLength = 8;
            this.DisconnectTimeTextBox.Name = "DisconnectTimeTextBox";
            this.DisconnectTimeTextBox.Size = new System.Drawing.Size(83, 23);
            this.DisconnectTimeTextBox.TabIndex = 3;
            this.DisconnectTimeTextBox.Text = "0";
            this.DisconnectTimeTextBox.TextChanged += new System.EventHandler(this.DisconnectTimeTextBox_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(293, 66);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(20, 15);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "秒";
            // 
            // TimeoutIdleCheckBox
            // 
            this.TimeoutIdleCheckBox.AutoSize = true;
            this.TimeoutIdleCheckBox.Location = new System.Drawing.Point(14, 91);
            this.TimeoutIdleCheckBox.Name = "TimeoutIdleCheckBox";
            this.TimeoutIdleCheckBox.Size = new System.Drawing.Size(156, 19);
            this.TimeoutIdleCheckBox.TabIndex = 5;
            this.TimeoutIdleCheckBox.Text = "空闲会话的超时时间：";
            this.TimeoutIdleCheckBox.UseVisualStyleBackColor = true;
            this.TimeoutIdleCheckBox.CheckedChanged += new System.EventHandler(this.TimeoutIdleCheckBox_CheckedChanged);
            // 
            // IdleTimeTextBox
            // 
            this.IdleTimeTextBox.Location = new System.Drawing.Point(201, 89);
            this.IdleTimeTextBox.MaxLength = 8;
            this.IdleTimeTextBox.Name = "IdleTimeTextBox";
            this.IdleTimeTextBox.Size = new System.Drawing.Size(83, 23);
            this.IdleTimeTextBox.TabIndex = 6;
            this.IdleTimeTextBox.Text = "0";
            this.IdleTimeTextBox.TextChanged += new System.EventHandler(this.IdleTimeTextBox_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(292, 91);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(20, 15);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "秒";
            // 
            // LogoffWhenTimoutCheckBox
            // 
            this.LogoffWhenTimoutCheckBox.AutoSize = true;
            this.LogoffWhenTimoutCheckBox.Location = new System.Drawing.Point(14, 117);
            this.LogoffWhenTimoutCheckBox.Name = "LogoffWhenTimoutCheckBox";
            this.LogoffWhenTimoutCheckBox.Size = new System.Drawing.Size(169, 19);
            this.LogoffWhenTimoutCheckBox.TabIndex = 8;
            this.LogoffWhenTimoutCheckBox.Text = "达到时间限制时注销会话";
            this.LogoffWhenTimoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SaveButton.ImageIndex = 0;
            this.SaveButton.ImageList = this.SmallerIcons;
            this.SaveButton.Location = new System.Drawing.Point(334, 190);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(67, 29);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "保存";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SmallerIcons
            // 
            this.SmallerIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallerIcons.ImageStream")));
            this.SmallerIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallerIcons.Images.SetKeyName(0, "favorites_16x16.png");
            this.SmallerIcons.Images.SetKeyName(1, "cross.ico");
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label3.ForeColor = System.Drawing.Color.Maroon;
            this.Label3.Location = new System.Drawing.Point(11, 145);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(385, 33);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "注意：此处的设置将被本地策略和组策略覆盖。某些设置需要重新启动。";
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelEditButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.ImageIndex = 1;
            this.CancelEditButton.ImageList = this.SmallerIcons;
            this.CancelEditButton.Location = new System.Drawing.Point(253, 190);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(75, 29);
            this.CancelEditButton.TabIndex = 10;
            this.CancelEditButton.Text = "取消";
            this.CancelEditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelEditButton.UseVisualStyleBackColor = false;
            this.CancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            // 
            // AllowUnlistedRemoteProgramsCheckBox
            // 
            this.AllowUnlistedRemoteProgramsCheckBox.AutoSize = true;
            this.AllowUnlistedRemoteProgramsCheckBox.Location = new System.Drawing.Point(14, 39);
            this.AllowUnlistedRemoteProgramsCheckBox.Name = "AllowUnlistedRemoteProgramsCheckBox";
            this.AllowUnlistedRemoteProgramsCheckBox.Size = new System.Drawing.Size(156, 19);
            this.AllowUnlistedRemoteProgramsCheckBox.TabIndex = 1;
            this.AllowUnlistedRemoteProgramsCheckBox.Text = "允许未列出的远程程序";
            this.AllowUnlistedRemoteProgramsCheckBox.UseVisualStyleBackColor = true;
            // 
            // RemoteAppHostOptions
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelEditButton;
            this.ClientSize = new System.Drawing.Size(413, 231);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.IdleTimeTextBox);
            this.Controls.Add(this.DisconnectTimeTextBox);
            this.Controls.Add(this.AllowUnlistedRemoteProgramsCheckBox);
            this.Controls.Add(this.DisableAllowListCheckBox);
            this.Controls.Add(this.LogoffWhenTimoutCheckBox);
            this.Controls.Add(this.TimeoutIdleCheckBox);
            this.Controls.Add(this.TimeoutDisconnectedCheckBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteAppHostOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主机选项";
            this.Load += new System.EventHandler(this.RemoteAppHostOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox TimeoutDisconnectedCheckBox;
        private System.Windows.Forms.CheckBox DisableAllowListCheckBox;
        private System.Windows.Forms.TextBox DisconnectTimeTextBox;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.CheckBox TimeoutIdleCheckBox;
        private System.Windows.Forms.TextBox IdleTimeTextBox;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.CheckBox LogoffWhenTimoutCheckBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ImageList SmallerIcons;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.CheckBox AllowUnlistedRemoteProgramsCheckBox;
    }
}