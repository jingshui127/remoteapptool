using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using RemoteAppLib;
using RemoteAppTool; // 添加对RemoteAppTool命名空间的引用

namespace RemoteApp_Tool
{
    public partial class RemoteAppEditWindow : Form
    {
        private RemoteApp RemoteApp = new RemoteApp();
        // 创建类级别的Tooltip对象，确保它不会被垃圾回收
        private ToolTip toolTip;

        public RemoteAppEditWindow()
        {
            InitializeComponent();
            InitializeTooltips();
        }
        
        private void InitializeTooltips()
        {
            try
            {
                // 创建ToolTip组件
                toolTip = new ToolTip();
                // toolTip.Owner = this; // 这行代码错误，Windows Forms的ToolTip没有Owner属性
                toolTip.BackColor = Color.Yellow; // 修改为黄色，使tooltip更加明显
                toolTip.ForeColor = Color.Black;
                toolTip.IsBalloon = false;
                toolTip.OwnerDraw = false;
                toolTip.UseAnimation = true;
                toolTip.UseFading = true;
                toolTip.AutoPopDelay = 5000;
                toolTip.InitialDelay = 200;
                toolTip.ReshowDelay = 100;
                
                System.Diagnostics.Debug.WriteLine("初始化EditWindow的tooltip组件");
                
                try
                {
                    // 标题组
                    if (this.GroupBox1 != null)
                    {
                        toolTip.SetToolTip(this.GroupBox1, "应用程序的标题信息");
                        System.Diagnostics.Debug.WriteLine("已设置GroupBox1的tooltip");
                    }
                    if (this.ShortNameText != null)
                    {
                        toolTip.SetToolTip(this.ShortNameText, "应用程序的短名称\n在RemoteApp列表中显示");
                        System.Diagnostics.Debug.WriteLine("已设置ShortNameText的tooltip");
                    }
                    if (this.FullNameText != null)
                    {
                        toolTip.SetToolTip(this.FullNameText, "应用程序的完整名称\n在客户端显示给用户");
                        System.Diagnostics.Debug.WriteLine("已设置FullNameText的tooltip");
                    }
                    
                    // 文件组
                    if (this.GroupBox2 != null)
                    {
                        toolTip.SetToolTip(this.GroupBox2, "应用程序文件和图标信息");
                        System.Diagnostics.Debug.WriteLine("已设置GroupBox2的tooltip");
                    }
                    if (this.PathText != null)
                    {
                        toolTip.SetToolTip(this.PathText, "应用程序的完整路径\n指向可执行文件的位置");
                        System.Diagnostics.Debug.WriteLine("已设置PathText的tooltip");
                    }
                    if (this.BrowsePath != null)
                    {
                        toolTip.SetToolTip(this.BrowsePath, "浏览文件\n选择应用程序可执行文件");
                        System.Diagnostics.Debug.WriteLine("已设置BrowsePath的tooltip");
                    }
                    if (this.IconPathText != null)
                    {
                        toolTip.SetToolTip(this.IconPathText, "图标文件的路径\n指向包含图标的文件");
                        System.Diagnostics.Debug.WriteLine("已设置IconPathText的tooltip");
                    }
                    if (this.BrowseIconPath != null)
                    {
                        toolTip.SetToolTip(this.BrowseIconPath, "浏览图标\n选择自定义图标文件");
                        System.Diagnostics.Debug.WriteLine("已设置BrowseIconPath的tooltip");
                    }
                    if (this.IconIndexText != null)
                    {
                        toolTip.SetToolTip(this.IconIndexText, "图标索引\n指定文件中的图标位置，默认为0");
                        System.Diagnostics.Debug.WriteLine("已设置IconIndexText的tooltip");
                    }
                    if (this.IconResetButton != null)
                    {
                        toolTip.SetToolTip(this.IconResetButton, "重置图标\n将图标重置为应用程序默认图标");
                        System.Diagnostics.Debug.WriteLine("已设置IconResetButton的tooltip");
                    }
                    
                    // 选项组
                    if (this.GroupBox3 != null)
                    {
                        toolTip.SetToolTip(this.GroupBox3, "应用程序的高级选项");
                        System.Diagnostics.Debug.WriteLine("已设置GroupBox3的tooltip");
                    }
                    if (this.CommandLineOptionCombo != null)
                    {
                        toolTip.SetToolTip(this.CommandLineOptionCombo, "命令行选项\n控制命令行参数的使用方式");
                        System.Diagnostics.Debug.WriteLine("已设置CommandLineOptionCombo的tooltip");
                    }
                    if (this.CommandLineText != null)
                    {
                        toolTip.SetToolTip(this.CommandLineText, "命令行参数\n启动应用程序时传递的命令行参数");
                        System.Diagnostics.Debug.WriteLine("已设置CommandLineText的tooltip");
                    }
                    if (this.TSWAbox != null)
                    {
                        toolTip.SetToolTip(this.TSWAbox, "在TSWebAccess中显示\n控制应用程序是否在Web访问界面中显示");
                        System.Diagnostics.Debug.WriteLine("已设置TSWAbox的tooltip");
                    }
                    if (this.FTAButton != null)
                    {
                        toolTip.SetToolTip(this.FTAButton, "文件类型关联\n配置应用程序关联的文件类型");
                        System.Diagnostics.Debug.WriteLine("已设置FTAButton的tooltip");
                    }
                    
                    // 底部按钮
                    if (this.SaveButton != null)
                    {
                        toolTip.SetToolTip(this.SaveButton, "保存\n保存应用程序配置并关闭窗口");
                        System.Diagnostics.Debug.WriteLine("已设置SaveButton的tooltip");
                    }
                    if (this.CancelEditButton != null)
                    {
                        toolTip.SetToolTip(this.CancelEditButton, "取消\n放弃更改并关闭窗口");
                        System.Diagnostics.Debug.WriteLine("已设置CancelEditButton的tooltip");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("设置控件tooltip时出错: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("初始化tooltip时发生错误: " + ex.Message);
            }
        }

        public RemoteApp EditRemoteApp(RemoteApp SelectedRemoteApp)
        {
            RemoteApp = SelectedRemoteApp;
            this.Text = "Properties of " + RemoteApp.Name;  
            this.Size = this.MinimumSize;
            
            // 编辑现有RemoteApp时启用文件类型关联按钮
            this.FTAButton.Enabled = true;
            
            // 将RemoteApp对象的属性值填充到界面控件中
            if (RemoteApp != null)
            {
                try
                {
                    if (this.ShortNameText != null)
                        this.ShortNameText.Text = RemoteApp.Name;
                    
                    if (this.FullNameText != null)
                        this.FullNameText.Text = RemoteApp.FullName;
                    
                    if (this.PathText != null)
                        this.PathText.Text = RemoteApp.Path;
                    
                    if (this.IconPathText != null)
                        this.IconPathText.Text = RemoteApp.IconPath;
                    
                    if (this.IconIndexText != null)
                        this.IconIndexText.Text = RemoteApp.IconIndex.ToString();
                    
                    // 设置命令行选项
                    if (this.CommandLineOptionCombo != null)
                    {
                        // 设置命令行选项
                        if (this.CommandLineOptionCombo.Items.Count > RemoteApp.CommandLineOption)
                        {
                            this.CommandLineOptionCombo.SelectedIndex = RemoteApp.CommandLineOption;
                        }
                    }
                    
                    if (this.CommandLineText != null)
                        this.CommandLineText.Text = RemoteApp.CommandLine;
                    
                    // 设置TSWA选项
                    if (this.TSWAbox != null)
                    {
                        if (RemoteApp.TSWA)
                        {
                            if (this.TSWAbox.Items.Count > 0)
                                this.TSWAbox.SelectedIndex = 0;
                        }
                        else
                        {
                            if (this.TSWAbox.Items.Count > 1)
                                this.TSWAbox.SelectedIndex = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("填充编辑窗口控件时出错: " + ex.Message);
                }
            }
            
            DialogResult dlgResult = this.ShowDialog();
            return RemoteApp;
        }

        public RemoteApp CreateRemoteApp(bool Advanced = false)
        {
            try
            {
                this.Text = "新建 RemoteApp";
                this.Size = this.MinimumSize;
                
                // 安全设置ComboBox的选中索引，防止索引越界
                if (this.CommandLineOptionCombo.Items.Count > 1)
                    this.CommandLineOptionCombo.SelectedIndex = 1;
                else if (this.CommandLineOptionCombo.Items.Count > 0)
                    this.CommandLineOptionCombo.SelectedIndex = 0;
                    
                if (this.TSWAbox.Items.Count > 0)
                    this.TSWAbox.SelectedIndex = 0;
                    
                this.FTAButton.Enabled = false;

                DialogResult dlgResult = this.ShowDialog();
                return RemoteApp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建 RemoteApp 时发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return RemoteApp;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 验证必填字段
                if (string.IsNullOrEmpty(this.ShortNameText.Text))
                {
                    MessageBox.Show("名称不能为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(this.FullNameText.Text))
                {
                    MessageBox.Show("全名不能为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (string.IsNullOrEmpty(this.PathText.Text))
                {
                    MessageBox.Show("路径不能为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                // 检查是否已存在同名应用程序
                if (!this.ShortNameText.Text.Equals(RemoteApp.Name) && DoesAppExist(this.ShortNameText.Text))
                {
                    MessageBox.Show("已存在同名的RemoteApp。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (this.Text.Equals("新建 RemoteApp") && DoesAppExist(this.ShortNameText.Text))
                {
                    MessageBox.Show("已存在同名的RemoteApp。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                // 保存所有数据
                RemoteApp.FullName = this.FullNameText.Text;
                RemoteApp.Path = this.PathText.Text;
                RemoteApp.IconPath = this.IconPathText.Text;
                
                // 保存图标索引
                int iconIndex;
                if (int.TryParse(this.IconIndexText.Text, out iconIndex))
                {
                    RemoteApp.IconIndex = iconIndex;
                }
                else
                {
                    RemoteApp.IconIndex = 0;
                }
                
                // 保存命令行选项
                if (this.CommandLineOptionCombo != null)
                {
                    RemoteApp.CommandLineOption = this.CommandLineOptionCombo.SelectedIndex;
                }
                
                // 保存命令行参数
                RemoteApp.CommandLine = this.CommandLineText.Text;
                
                // 保存TSWA选项
                if (this.TSWAbox != null)
                {
                    RemoteApp.TSWA = (this.TSWAbox.SelectedIndex == 0);
                }
                
                // 实际保存到系统
                string newName = this.ShortNameText.Text.Trim();
                SaveRemoteApp(newName);
                
                // 设置对话框结果并关闭
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SaveRemoteApp(string newName)
        {
            SystemRemoteApps sysApps = new SystemRemoteApps();
            
            // 保存原始名称用于可能的重命名操作
            string originalName = RemoteApp.Name;
            
            // 如果是重命名应用程序，先重命名
            if (!string.IsNullOrEmpty(originalName) && !this.Text.Equals("新建 RemoteApp"))
            {
                if (!newName.Equals(originalName))
                {
                    sysApps.RenameApp(originalName, newName);
                }
            }
            
            // 更新RemoteApp的名称
            RemoteApp.Name = newName;
            
            // 保存RemoteApp到系统
            sysApps.SaveApp(RemoteApp);
        }
        
        private bool DoesAppExist(string appName)
        {
            bool appExists = false;
            
            SystemRemoteApps sra = new SystemRemoteApps();
            RemoteAppCollection appCol = sra.GetAll();
            
            foreach (RemoteApp app in appCol)
            {
                if (app.Name.Equals(appName))
                {
                    appExists = true;
                    break;
                }
            }
            
            return appExists;
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            // 取消逻辑
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FTAButton_Click(object sender, EventArgs e)
        {
            // 调用文件类型关联编辑窗口
            using (RemoteAppFileTypeAssociation ftaForm = new RemoteAppFileTypeAssociation())
            {
                RemoteApp = ftaForm.EditFileTypes(RemoteApp);
            }
        }

        private void ShortNameText_TextChanged(object sender, EventArgs e)
        {
            // 当短名称改变时的处理逻辑
            if (string.IsNullOrEmpty(this.FullNameText.Text))
            {
                this.FullNameText.Text = this.ShortNameText.Text;
            }
        }

        private void BrowsePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "可执行文件 (*.exe)|*.exe|所有文件 (*.*)|*.*";
                ofd.Title = "选择可执行文件";
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.PathText.Text = ofd.FileName;
                    // 自动设置短名称和全名
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                    if (string.IsNullOrEmpty(this.ShortNameText.Text))
                    {
                        this.ShortNameText.Text = fileName;
                    }
                    if (string.IsNullOrEmpty(this.FullNameText.Text))
                    {
                        this.FullNameText.Text = fileName;
                    }
                    // 自动设置图标路径
                    if (string.IsNullOrEmpty(this.IconPathText.Text))
                    {
                        this.IconPathText.Text = ofd.FileName;
                        this.IconIndexText.Text = "0";
                    }
                }
            }
        }

        private void BrowseIconPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "图标文件 (*.ico)|*.ico|可执行文件 (*.exe)|*.exe|DLL文件 (*.dll)|*.dll|所有文件 (*.*)|*.*";
                ofd.Title = "选择图标文件";
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.IconPathText.Text = ofd.FileName;
                }
            }
        }

        private void IconResetButton_Click(object sender, EventArgs e)
        {
            // 重置图标路径为应用程序路径
            if (!string.IsNullOrEmpty(this.PathText.Text))
            {
                this.IconPathText.Text = this.PathText.Text;
                this.IconIndexText.Text = "0";
            }
        }

        private void IconIndexText_TextChanged(object sender, EventArgs e)
        {
            // 验证图标索引是否为数字
            int index;
            if (!int.TryParse(this.IconIndexText.Text, out index))
            {
                this.IconIndexText.Text = "0";
            }
        }
    }
}