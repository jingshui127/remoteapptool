using System.Drawing;
using System;
using System.IO;
using System.Windows.Forms;
using RemoteAppLib;
using RemoteApp_Tool;  // 添加命名空间引用

namespace RemoteAppTool
{
    public partial class RemoteAppIconPicker : Form
    {
        private bool NoValidate = false;

        public RemoteAppIconPicker()
        {
            InitializeComponent();
            
            // 手动初始化ImageList，使用系统图标作为临时解决方案
            InitializeImageLists();
            
            // 初始化Tooltip，使用用户偏好的浅黄色背景
            SetToolTips();
        }
        
        private void InitializeImageLists()
        {
            try
            {
                // 检查SmallerIcons是否为空，只有为空时才添加系统图标
                if (this.SmallerIcons.Images.Count == 0)
                {
                    // 为SmallerIcons添加基础图标
                    // 0: folder
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                    // 1: tick
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                    // 2: cross
                    this.SmallerIcons.Images.Add(SystemIcons.Warning.ToBitmap());
                    // 3: settings
                    this.SmallerIcons.Images.Add(SystemIcons.Information.ToBitmap());
                }
                
                // 检查SmallIcons是否为空，只有为空时才添加默认图标
                if (this.SmallIcons.Images.Count == 0)
                {
                    // 为SmallIcons添加默认图标
                    this.SmallIcons.Images.Add(SystemIcons.Application.ToBitmap());
                }
                
                System.Diagnostics.Debug.WriteLine($"RemoteAppIconPicker ImageList初始化完成");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"初始化ImageList失败: {ex.Message}");
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

            // 文件路径和浏览
            toolTip.SetToolTip(this.IconPathTextBox, "输入图标文件的完整路径\n支持.exe、.dll、.ico等包含图标的文件");
            toolTip.SetToolTip(this.BrowseButton, "浏览选择图标文件\n打开文件选择对话框来选择包含图标的文件");
            
            // 图标选择
            toolTip.SetToolTip(this.IconList, "可用图标列表\n从选中的文件中加载的图标，点击选择要使用的图标");
            toolTip.SetToolTip(this.IconIndexTextBox, "图标索引号\n当前选中图标的索引位置，也可手动输入");
            
            // 文件类型关联（仅在文件类型管理模式显示）
            toolTip.SetToolTip(this.FileTypeTextBox, "文件类型扩展名\n输入要关联的文件类型（例如：.txt、.docx）");
            
            // 操作按钮
            // 注意：OKButton和CancelButton是特殊的按钮控件，需要转换为Control类型
            if (this.OKButton is Control okControl)
                toolTip.SetToolTip(okControl, "确认选择\n使用当前选中的图标和设置");
            if (this.CancelButton is Control cancelControl)
                toolTip.SetToolTip(cancelControl, "取消选择\n放弃更改，返回上一个窗口");
        }

        public IconSelection PickIcon(string defaultPath, int defaultIndex = 0)
        {
            // 设置纯图标选择模式，隐藏文件类型相关控件
            this.FileTypeLabel.Visible = false;
            this.FileTypeTextBox.Visible = false;
            // 纯图标选择模式下也显示索引控件
            this.IconIndexLabel.Visible = true;
            this.IconIndexTextBox.Visible = true;

            this.Text = "Select Icon";

            this.IconPathTextBox.Text = defaultPath;
            this.IconIndexTextBox.Text = defaultIndex.ToString();

            LoadIcons();
            var iconPick = new IconSelection();

            if (this.ShowDialog() == DialogResult.OK)
            {
                iconPick.IconPath = this.IconPathTextBox.Text;
                iconPick.IconIndex = this.IconIndexTextBox.Text;
            }

            this.Dispose();
            return iconPick;
        }

        public static FileTypeAssociation ManageFTA(string defaultPath, int defaultIndex = 0, string fileType = ".xyz", bool isEdit = false)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"ManageFTA 开始: defaultPath={defaultPath}, defaultIndex={defaultIndex}, fileType={fileType}, isEdit={isEdit}");
                
                // 验证defaultPath参数
                if (string.IsNullOrEmpty(defaultPath))
                {
                    System.Diagnostics.Debug.WriteLine("defaultPath为空，使用系统默认路径");
                    defaultPath = System.IO.Path.Combine(Environment.SystemDirectory, "shell32.dll");
                }
                
                var picker = new RemoteAppIconPicker();
                System.Diagnostics.Debug.WriteLine("RemoteAppIconPicker 实例创建完成");
                
                var fta = new FileTypeAssociation();

                picker.FileTypeLabel.Visible = true;
                picker.FileTypeTextBox.Visible = true;
                picker.IconIndexLabel.Visible = true;
                picker.IconIndexTextBox.Visible = true;
                picker.IconIndexTextBox.ReadOnly = true;

                if (isEdit == true)
                {
                    picker.FileTypeTextBox.ReadOnly = true;
                }
                else
                {
                    picker.FileTypeTextBox.ReadOnly = false;
                }

                picker.Text = "File Type";

                picker.FileTypeTextBox.Text = fileType;
                picker.IconPathTextBox.Text = defaultPath;
                picker.IconIndexTextBox.Text = defaultIndex.ToString();
                
                System.Diagnostics.Debug.WriteLine("准备调用LoadIcons");
                picker.LoadIcons();
                System.Diagnostics.Debug.WriteLine("LoadIcons 调用完成");

                System.Diagnostics.Debug.WriteLine("准备显示ShowDialog");
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.Debug.WriteLine("用户点击了确定");
                    fta.Extension = picker.FileTypeTextBox.Text;
                    fta.IconPath = picker.IconPathTextBox.Text;
                    fta.IconIndex = picker.IconIndexTextBox.Text;
                    System.Diagnostics.Debug.WriteLine($"FTA: Extension={fta.Extension}, IconPath={fta.IconPath}, IconIndex={fta.IconIndex}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("用户取消了对话框");
                }

                picker.Dispose();
                System.Diagnostics.Debug.WriteLine("ManageFTA 完成");
                return fta;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ManageFTA 错误: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"ManageFTA 错误: {ex.Message}\n\n{ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new FileTypeAssociation();
            }
        }

        private bool LoadIcons()
        {
            this.IconList.Clear();
            this.SmallIcons.Images.Clear();
            bool iconError = false;

            this.IconIndexLabel.Visible = true;
            this.IconIndexTextBox.Visible = true;
            
            // 设置ListView为大图标模式，更适合图标选择
            this.IconList.View = View.LargeIcon;

            if (File.Exists(this.IconPathTextBox.Text))
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine($"LoadIcons 开始加载: {this.IconPathTextBox.Text}");
                    
                    // 处理不同类型的图标文件
                    string filePath = this.IconPathTextBox.Text;
                    string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
                    
                    if (fileExtension == ".ico")
                    {
                        // 处理 .ico 文件
                        try
                        {
                            var icon = new Icon(filePath);
                            this.SmallIcons.Images.Add("0", icon.ToBitmap());
                            var iconItem = new ListViewItem("图标 0");
                            iconItem.ImageKey = "0";
                            IconList.Items.Add(iconItem);
                            System.Diagnostics.Debug.WriteLine(".ico 文件加载成功");
                        }
                        catch (Exception icoEx)
                        {
                            System.Diagnostics.Debug.WriteLine($".ico 文件加载失败: {icoEx.Message}");
                            // 使用默认图标作为备用
                            this.SmallIcons.Images.Add("0", SystemIcons.Application.ToBitmap());
                            var iconItem = new ListViewItem("默认图标");
                            iconItem.ImageKey = "0";
                            IconList.Items.Add(iconItem);
                        }
                    }
                    else if (fileExtension == ".exe" || fileExtension == ".dll")
                    {
                        // 处理 .exe 和 .dll 文件中的图标
                        try
                        {
                            var icon = Icon.ExtractAssociatedIcon(filePath);
                            if (icon != null)
                            {
                                this.SmallIcons.Images.Add("0", icon.ToBitmap());
                                var iconItem = new ListViewItem("图标 0");
                                iconItem.ImageKey = "0";
                                IconList.Items.Add(iconItem);
                                System.Diagnostics.Debug.WriteLine(".exe/.dll 文件图标加载成功");
                            }
                            else
                            {
                                throw new Exception("无法提取图标");
                            }
                        }
                        catch (Exception exeEx)
                        {
                            System.Diagnostics.Debug.WriteLine($".exe/.dll 文件图标加载失败: {exeEx.Message}");
                            // 使用默认图标作为备用
                            this.SmallIcons.Images.Add("0", SystemIcons.Application.ToBitmap());
                            var iconItem = new ListViewItem("默认图标");
                            iconItem.ImageKey = "0";
                            IconList.Items.Add(iconItem);
                        }
                    }
                    else
                    {
                        // 不支持的文件类型，使用默认图标
                        this.SmallIcons.Images.Add("0", SystemIcons.Application.ToBitmap());
                        var iconItem = new ListViewItem("默认图标");
                        iconItem.ImageKey = "0";
                        IconList.Items.Add(iconItem);
                        System.Diagnostics.Debug.WriteLine($"不支持的文件类型: {fileExtension}");
                    }
                    
                    this.IconIndexTextBox.ReadOnly = true;
                    
                    // 改进的自动选中逻辑：使用BeginInvoke延迟执行，确保UI完全加载
                    this.BeginInvoke(new Action(() =>
                    {
                        if (IconList.Items.Count > 0)
                        {
                            IconList.Items[0].Selected = true;
                            IconList.Items[0].Focused = true; // 同时设置焦点
                            IconList.Focus(); // 确保列表有焦点
                            CheckSelection(); // 触发选择检查
                            
                            // 调试信息
                            System.Diagnostics.Debug.WriteLine($"自动选中图标，Selected={IconList.Items[0].Selected}, OKEnabled={OKButton.Enabled}");
                        }
                    }));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"LoadIcons异常: {ex.Message}");
                    iconError = true;
                    NoValidate = true;
                    this.OKButton.Enabled = true;
                    MessageBox.Show($"从以下路径加载图标时出错：\n{this.IconPathTextBox.Text}\n\n错误详情：{ex.Message}\n\n图标可能仍可使用，但您无法使用图标选择器选择图标。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.IconIndexTextBox.Text = "0";
                    this.IconIndexTextBox.ReadOnly = false;
                }

                if (!iconError)
                {
                    NoValidate = false;
                    // 不要在这里强制禁用OK按钮，让CheckSelection()来处理
                    // if (!NoValidate) 
                    //     this.OKButton.Enabled = false;
                }
            }
            return iconError;
        }

        private void IconList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelection();
        }

        private void CheckSelection()
        {
            // 调试信息
            System.Diagnostics.Debug.WriteLine($"CheckSelection: SelectedItems.Count={this.IconList.SelectedItems.Count}, FileTypeTextBox.Visible={this.FileTypeTextBox.Visible}");
            
            if (this.IconList.SelectedItems.Count > 0)
            {
                // something is selected
                // 如果FileTypeTextBox可见（文件类型关联模式），需要检查文件类型是否填写
                // 如果FileTypeTextBox不可见（纯图标选择模式），直接启用OK按钮
                if (this.FileTypeTextBox.Visible)
                {
                    if (!string.IsNullOrEmpty(FileTypeTextBox.Text)) 
                        this.OKButton.Enabled = true;
                    else
                        this.OKButton.Enabled = false;
                }
                else
                {
                    // 纯图标选择模式，选中图标即可确定
                    this.OKButton.Enabled = true;
                    System.Diagnostics.Debug.WriteLine("纯图标模式，启用OK按钮");
                }
                this.IconIndexTextBox.Text = this.IconList.SelectedItems[0].Text;
            }
            else
            {
                // nothing is selected
                if (!NoValidate) 
                    this.OKButton.Enabled = false;
                this.IconIndexTextBox.Text = "0";
                System.Diagnostics.Debug.WriteLine("未选中任何图标，禁用OK按钮");
            }
            
            System.Diagnostics.Debug.WriteLine($"CheckSelection 结果: OKButton.Enabled={this.OKButton.Enabled}");
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.IconPathTextBox.Text))
                this.FileBrowserIcon.InitialDirectory = System.IO.Path.GetDirectoryName(this.IconPathTextBox.Text);
            
            if (FileBrowserIcon.ShowDialog() == DialogResult.OK)
            {
                this.IconPathTextBox.Text = FileBrowserIcon.FileName;
                LoadIcons();
            }
        }

        private void FileTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoteAppFunctions.ValidateFileType(FileTypeTextBox);
            if (string.IsNullOrEmpty(this.FileTypeTextBox.Text))
                this.OKButton.Enabled = false;
            else if (this.IconList.SelectedItems.Count == 1)
                this.OKButton.Enabled = true;
        }

        private void IconIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            RemoteAppFunctions.ValidateInteger(IconIndexTextBox);
        }
    }
}