using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace RemoteApp_Tool
{
    public partial class RemoteAppAboutWindow : Form
    {
        public RemoteAppAboutWindow()
        {
            InitializeComponent();
            InitializeAboutInfo();
        }
        
        private void InitializeAboutInfo()
        {
            // 设置窗口属性
            this.Text = "关于 RemoteApp 工具";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 300);
            
            // 创建关于信息的控件
            CreateAboutControls();
        }
        
        private void CreateAboutControls()
        {
            string appName = Assembly.GetExecutingAssembly().GetName().Name;
            string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string urtl = "https://cloud.tencent.com/developer/user/8197675";
            // 产品名称标签
            var productNameLabel = new Label()
            {
                Text = "RemoteApp工具【QQ:2492123056】",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            
            // 版本信息标签
            var versionLabel = new Label()
            {
                Text = "版本: 1.0.0 ",
                AutoSize = true,
                Location = new Point(20, 50)
            };
            
            // 作者信息标签
            var authorLabel = new Label()
            {
                Text = "作者: 科控物联",
                AutoSize = true,
                Location = new Point(20, 80)
            };
            
            // 描述信息
            var descriptionLabel = new Label()
            {
                Text = "RemoteApp Tool 是一个用于管理 Windows RemoteApp 的工具。\n" +
                       "它允许您创建、编辑和管理 RemoteApp 应用程序。",
                AutoSize = false,
                Size = new Size(350, 60),
                Location = new Point(20, 110)
            };
            
            // 网站链接
            var websiteLabel = new Label()
            {
                Text = $"项目主页: {urtl}",
                AutoSize = true,
                Location = new Point(20, 180),
                ForeColor = Color.Blue,
                Cursor = Cursors.Hand
            };
            websiteLabel.Click += (s, e) => {
                try
                {
                    System.Diagnostics.Process.Start($"{urtl}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"无法打开网站: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            
            // 关闭按钮
            var closeButton = new Button()
            {
                Text = "关闭",
                Size = new Size(75, 29),
                Location = new Point(300, 220),
                DialogResult = DialogResult.OK
            };
            closeButton.Click += (s, e) => this.Close();
            
            // 添加控件到窗口
            this.Controls.AddRange(new Control[] {
                productNameLabel,
                versionLabel,
                authorLabel,
                descriptionLabel,
                websiteLabel,
                closeButton
            });
            
            // 设置默认按钮
            this.AcceptButton = closeButton;
        }
    }
}