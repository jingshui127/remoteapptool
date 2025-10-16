using System.Diagnostics;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RemoteAppLib; // 现在可以使用C#版本的RemoteAppLib

namespace RemoteApp_Tool
{
    public partial class RemoteAppMainWindow : Form
    {
        // 添加P/Invoke声明用于创建圆角区域
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        
        // 辅助方法，用于在运行时设置控件的圆角效果
        // 在设计器模式下不会实际执行P/Invoke调用
        internal static IntPtr SafeCreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height)
        {
            // 检查是否在设计器模式下运行
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                // 在设计器模式下，返回null而不是调用P/Invoke函数
                return IntPtr.Zero;
            }
            
            // 在运行时，正常调用P/Invoke函数
            return CreateRoundRectRgn(left, top, right, bottom, width, height);
        }

        // 创建类级别的Tooltip对象，确保它不会被垃圾回收
        private ToolTip toolTip;
        // 为底部按钮创建专用的Tooltip组件
        private ToolTip createButtonToolTip;
        private ToolTip editButtonToolTip;
        private ToolTip deleteButtonToolTip;
        private ToolTip createClientConnectionToolTip;
        private ToolTip copyButtonToolTip;
        
        // 消息面板，用于承载NoAppsLabel标签
        private Panel messagePanel;
        
        public RemoteAppMainWindow()
        {
            InitializeComponent();
            
            // 初始化tooltip对象
            InitializeToolTips();
            
            // 初始化底部按钮专用的tooltip
            InitializeButtonToolTips();
            
            // 添加Shown事件处理程序，确保表单完全加载后再设置tooltip
            this.Shown += RemoteAppMainWindow_Shown;
        }
        
        private void InitializeButtonToolTips()
        {
            try
            {
                // 创建CreateButton专用的Tooltip组件
                createButtonToolTip = new ToolTip();
                ConfigureToolTip(createButtonToolTip);
                
                // 立即为CreateButton设置tooltip
                if (this.CreateButton != null)
                {
                    createButtonToolTip.SetToolTip(this.CreateButton, "创建新的 RemoteApp 应用程序\n点击此按钮添加新的远程应用程序到服务器");
                    System.Diagnostics.Debug.WriteLine("已初始化CreateButton专用tooltip");
                }
                
                // 创建EditButton专用的Tooltip组件
                editButtonToolTip = new ToolTip();
                ConfigureToolTip(editButtonToolTip);
                
                // 立即为EditButton设置tooltip
                if (this.EditButton != null)
                {
                    editButtonToolTip.SetToolTip(this.EditButton, "编辑选中的 RemoteApp\n修改当前选中应用程序的设置和属性");
                    System.Diagnostics.Debug.WriteLine("已初始化EditButton专用tooltip");
                }
                
                // 创建DeleteButton专用的Tooltip组件
                deleteButtonToolTip = new ToolTip();
                ConfigureToolTip(deleteButtonToolTip);
                
                // 立即为DeleteButton设置tooltip
                if (this.DeleteButton != null)
                {
                    deleteButtonToolTip.SetToolTip(this.DeleteButton, "删除选中的 RemoteApp\n从服务器上移除当前选中的远程应用程序");
                    System.Diagnostics.Debug.WriteLine("已初始化DeleteButton专用tooltip");
                }
                
                // 创建CreateClientConnection专用的Tooltip组件
                createClientConnectionToolTip = new ToolTip();
                ConfigureToolTip(createClientConnectionToolTip);
                
                // 立即为CreateClientConnection设置tooltip
                if (this.CreateClientConnection != null)
                {
                    createClientConnectionToolTip.SetToolTip(this.CreateClientConnection, "创建客户端连接\n为选中的 RemoteApp 生成 RDP 文件或 MSI 安装包");
                    System.Diagnostics.Debug.WriteLine("已初始化CreateClientConnection专用tooltip");
                }
                
                // 创建btnCopy专用的Tooltip组件
                copyButtonToolTip = new ToolTip();
                ConfigureToolTip(copyButtonToolTip);
                
                // 立即为btnCopy设置tooltip
                if (this.btnCopy != null)
                {
                    copyButtonToolTip.SetToolTip(this.btnCopy, "复制 RemoteApp\n创建选中 RemoteApp 的副本");
                    System.Diagnostics.Debug.WriteLine("已初始化btnCopy专用tooltip");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("初始化按钮专用tooltip失败: " + ex.Message);
            }
        }
        
        // 配置Tooltip属性的辅助方法
        private void ConfigureToolTip(ToolTip tooltip)
        {
            tooltip.BackColor = Color.Yellow;
            tooltip.ForeColor = Color.Black;
            tooltip.IsBalloon = false;
            tooltip.OwnerDraw = false;
            tooltip.UseAnimation = true;
            tooltip.UseFading = true;
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 200;
            tooltip.ReshowDelay = 100;
        }
        
        private void RemoteAppMainWindow_Shown(object sender, EventArgs e)
        {
            try
            {
                // 确保表单完全加载后，再次设置所有按钮的tooltip
                EnsureButtonTooltips();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RemoteAppMainWindow_Shown中设置tooltip出错: " + ex.Message);
            }
        }
        
        private void EnsureButtonTooltips()
        {
            try
            {
                // 确保CreateButton的tooltip
                if (this.CreateButton != null && createButtonToolTip != null)
                {
                    createButtonToolTip.SetToolTip(this.CreateButton, "创建新的 RemoteApp 应用程序\n点击此按钮添加新的远程应用程序到服务器");
                    System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中再次设置CreateButton的专用tooltip");
                    
                    string currentTooltip = createButtonToolTip.GetToolTip(this.CreateButton);
                    System.Diagnostics.Debug.WriteLine($"EnsureButtonTooltips中，CreateButton当前tooltip文本: {currentTooltip}");
                }
                
                // 确保EditButton的tooltip
                if (this.EditButton != null && editButtonToolTip != null)
                {
                    editButtonToolTip.SetToolTip(this.EditButton, "编辑选中的 RemoteApp\n修改当前选中应用程序的设置和属性");
                    System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中再次设置EditButton的专用tooltip");
                }
                
                // 确保DeleteButton的tooltip
                if (this.DeleteButton != null && deleteButtonToolTip != null)
                {
                    deleteButtonToolTip.SetToolTip(this.DeleteButton, "删除选中的 RemoteApp\n从服务器上移除当前选中的远程应用程序");
                    System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中再次设置DeleteButton的专用tooltip");
                }
                
                // 确保CreateClientConnection的tooltip
                if (this.CreateClientConnection != null && createClientConnectionToolTip != null)
                {
                    createClientConnectionToolTip.SetToolTip(this.CreateClientConnection, "创建客户端连接\n为选中的 RemoteApp 生成 RDP 文件或 MSI 安装包");
                    System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中再次设置CreateClientConnection的专用tooltip");
                }
                
                // 额外保障：如果专用tooltip有问题，尝试使用全局tooltip
                if (toolTip != null)
                {
                    // CreateButton的全局tooltip备选
                    if (this.CreateButton != null && string.IsNullOrEmpty(createButtonToolTip?.GetToolTip(this.CreateButton)))
                    {
                        toolTip.SetToolTip(this.CreateButton, "创建新的 RemoteApp 应用程序\n点击此按钮添加新的远程应用程序到服务器");
                        System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中使用全局tooltip作为CreateButton的备选");
                    }
                    
                    // EditButton的全局tooltip备选
                    if (this.EditButton != null && string.IsNullOrEmpty(editButtonToolTip?.GetToolTip(this.EditButton)))
                    {
                        toolTip.SetToolTip(this.EditButton, "编辑选中的 RemoteApp\n修改当前选中应用程序的设置和属性");
                        System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中使用全局tooltip作为EditButton的备选");
                    }
                    
                    // DeleteButton的全局tooltip备选
                    if (this.DeleteButton != null && string.IsNullOrEmpty(deleteButtonToolTip?.GetToolTip(this.DeleteButton)))
                    {
                        toolTip.SetToolTip(this.DeleteButton, "删除选中的 RemoteApp\n从服务器上移除当前选中的远程应用程序");
                        System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中使用全局tooltip作为DeleteButton的备选");
                    }
                    
                    // CreateClientConnection的全局tooltip备选
                    if (this.CreateClientConnection != null && string.IsNullOrEmpty(createClientConnectionToolTip?.GetToolTip(this.CreateClientConnection)))
                    {
                        toolTip.SetToolTip(this.CreateClientConnection, "创建客户端连接\n为选中的 RemoteApp 生成 RDP 文件或 MSI 安装包");
                        System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中使用全局tooltip作为CreateClientConnection的备选");
                    }
                    
                    // btnCopy的全局tooltip备选
                    if (this.btnCopy != null && string.IsNullOrEmpty(copyButtonToolTip?.GetToolTip(this.btnCopy)))
                    {
                        toolTip.SetToolTip(this.btnCopy, "复制 RemoteApp\n创建选中 RemoteApp 的副本");
                        System.Diagnostics.Debug.WriteLine("在EnsureButtonTooltips中使用全局tooltip作为btnCopy的备选");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureButtonTooltips方法出错: " + ex.Message);
            }
        }
        
        private void InitializeToolTips()
        {
            try
            {
                toolTip = new ToolTip();
                toolTip.BackColor = Color.Yellow; // 修改为黄色，使tooltip更加明显
                toolTip.ForeColor = Color.Black;
                toolTip.IsBalloon = false;
                toolTip.OwnerDraw = false;
                toolTip.UseAnimation = true;
                toolTip.UseFading = true;
                toolTip.AutoPopDelay = 5000;
                toolTip.InitialDelay = 200;
                toolTip.ReshowDelay = 100;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("初始化tooltip失败: " + ex.Message);
            }
        }

        private void RemoteAppMainWindow_Disposed(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                Properties.Settings.Default.MainWindowWidth = this.Width;
                Properties.Settings.Default.MainWindowHeight = this.Height;
            }
        }

        private void InitializeButtonIcons()
        {
            try
            {
                // 设置图标大小和颜色深度，无论是否已有图像
                this.SmallerIcons.ImageSize = new Size(16, 16);
                this.SmallerIcons.ColorDepth = ColorDepth.Depth32Bit;
                
                // 确保添加所有必要的图标，不检查Count是否为0
                if (this.SmallerIcons.Images.Count < 15) // 确保有足够的图标
                {
                    // 0: tools图标（工具菜单）- 齿轮图标
                    if (this.SmallerIcons.Images.Count <= 0) this.SmallerIcons.Images.Add(CreateModernIcon("⚙", Color.FromArgb(100, 100, 100), 12));
                    // 1: help图标（帮助菜单）- 问号图标
                    if (this.SmallerIcons.Images.Count <= 1) this.SmallerIcons.Images.Add(CreateModernIcon("?", Color.FromArgb(0, 120, 215), 13));
                    // 2: folder图标 - 文件夹符号
                    if (this.SmallerIcons.Images.Count <= 2) this.SmallerIcons.Images.Add(CreateModernIcon("■", Color.FromArgb(255, 185, 0), 12));
                    // 3: msi图标（创建客户端连接按钮）- 方块图标
                    if (this.SmallerIcons.Images.Count <= 3) this.SmallerIcons.Images.Add(CreateModernIcon("▣", Color.FromArgb(0, 120, 215), 12));
                    // 4: properties图标（编辑按钮）- 铅笔符号
                    if (this.SmallerIcons.Images.Count <= 4) this.SmallerIcons.Images.Add(CreateModernIcon("✎", Color.FromArgb(0, 120, 215), 13));
                    // 5: plus图标（创建按钮）- 加号图标
                    if (this.SmallerIcons.Images.Count <= 5) this.SmallerIcons.Images.Add(CreateModernIcon("+", Color.FromArgb(16, 137, 62), 14));
                    // 6: minus图标（删除按钮）- 减号图标  
                    if (this.SmallerIcons.Images.Count <= 6) this.SmallerIcons.Images.Add(CreateModernIcon("−", Color.FromArgb(232, 17, 35), 14));
                    // 7: file图标（文件菜单）- 文件符号
                    if (this.SmallerIcons.Images.Count <= 7) this.SmallerIcons.Images.Add(CreateModernIcon("□", Color.FromArgb(0, 120, 215), 12));
                    // 8: copy图标（复制菜单项）- 复制符号
                    if (this.SmallerIcons.Images.Count <= 8) this.SmallerIcons.Images.Add(CreateModernIcon("⧉", Color.FromArgb(100, 100, 100), 12));
                    // 9: exit图标（退出菜单项）- 退出符号
                    if (this.SmallerIcons.Images.Count <= 9) this.SmallerIcons.Images.Add(CreateModernIcon("×", Color.FromArgb(232, 17, 35), 12));
                    // 10: host图标（主机选项）- 主机符号
                    if (this.SmallerIcons.Images.Count <= 10) this.SmallerIcons.Images.Add(CreateModernIcon("⊞", Color.FromArgb(100, 100, 100), 12));
                    // 11: cleanup图标（清理功能）- 清理符号
                    if (this.SmallerIcons.Images.Count <= 11) this.SmallerIcons.Images.Add(CreateModernIcon("⟳", Color.FromArgb(100, 100, 100), 12));
                    // 12: backup图标（备份功能）- 备份符号
                    if (this.SmallerIcons.Images.Count <= 12) this.SmallerIcons.Images.Add(CreateModernIcon("⬇", Color.FromArgb(100, 100, 100), 12));
                    // 13: website图标（网站菜单项）- 网站符号
                    if (this.SmallerIcons.Images.Count <= 13) this.SmallerIcons.Images.Add(CreateModernIcon("☍", Color.FromArgb(0, 120, 215), 12));
                    // 14: about图标（关于菜单项）- 信息符号
                    if (this.SmallerIcons.Images.Count <= 14) this.SmallerIcons.Images.Add(CreateModernIcon("i", Color.FromArgb(100, 100, 100), 12));
                }
                
                System.Diagnostics.Debug.WriteLine("现代化按钮图标初始化完成，当前图标数量: " + this.SmallerIcons.Images.Count);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"初始化按钮图标失败: {ex.Message}");
                // 如果图标初始化失败，确保按钮文本可见
                this.CreateButton.Text = "新建";
                this.EditButton.Text = " 编辑";
                this.DeleteButton.Text = "删除";
            }
        }
        
        // 创建现代化图标的辅助方法
        private Bitmap CreateModernIcon(string symbol, Color color, float fontSize = 11)
        {
            var bitmap = new Bitmap(16, 16);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                g.Clear(Color.Transparent);
                
                // 使用 Segoe UI Symbol 字体以获得更好的图标效果
                using (var font = new Font("Segoe UI Symbol", fontSize, FontStyle.Bold))
                using (var brush = new SolidBrush(color))
                {
                    var format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(symbol, font, brush, new RectangleF(0, 0, 16, 16), format);
                }
            }
            return bitmap;
        }

        // Windows API for extracting icons
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, int nIcons);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        private Icon ReturnIcon(string path, int index, bool small = false)
        {
            try
            {
                IntPtr bigIcon = IntPtr.Zero;
                IntPtr smallIcon = IntPtr.Zero;
                
                ExtractIconEx(path, index, out bigIcon, out smallIcon, 1);
                
                if (bigIcon == IntPtr.Zero)
                {
                    ExtractIconEx(path, 0, out bigIcon, out smallIcon, 1);
                }
                
                if (bigIcon != IntPtr.Zero)
                {
                    Icon resultIcon = Icon.FromHandle(small ? smallIcon : bigIcon);
                    // 克隆图标以便可以释放原始句柄
                    Icon clonedIcon = (Icon)resultIcon.Clone();
                    
                    // 释放资源
                    if (bigIcon != IntPtr.Zero) DestroyIcon(bigIcon);
                    if (smallIcon != IntPtr.Zero) DestroyIcon(smallIcon);
                    
                    return clonedIcon;
                }
                else
                {
                    // 如果提取失败，返回默认图标
                    string sysDir = Environment.SystemDirectory;
                    return ReturnIcon(System.IO.Path.Combine(sysDir, "user32.dll"), 0);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ReturnIcon错误: {ex.Message}");
                // 返回应用程序默认图标
                return SystemIcons.Application;
            }
        }

        private Bitmap GetAppBitmap(string appName)
        {
            try
            {
                // 从注册表读取RemoteApp图标信息
                string appKey = $"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Terminal Server\\TSAppAllowList\\Applications\\{appName}";
                using (var regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(appKey))
                {
                    Icon theIcon = ReturnIcon("", 0);
                    
                    if (regKey != null)
                    {
                        string iconPath = regKey.GetValue("IconPath", "").ToString();
                        int iconIndex = 0;
                        object iconIndexObj = regKey.GetValue("IconIndex", 0);
                        if (iconIndexObj != null)
                        {
                            int.TryParse(iconIndexObj.ToString(), out iconIndex);
                        }
                        
                        if (!string.IsNullOrEmpty(iconPath))
                        {
                            theIcon = ReturnIcon(iconPath, iconIndex);
                        }
                    }
                    
                    return theIcon.ToBitmap();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAppBitmap错误 {appName}: {ex.Message}");
                // 返回默认图标的位图
                return SystemIcons.Application.ToBitmap();
            }
        }

        private void RemoteAppMainWindow_Load(object sender, EventArgs e)
        {
            // 设置窗口标题：显示版本和主机名（只显示主版本号，去掉 Git 哈希）
            var version = Application.ProductVersion.Split('+')[0];  // 提取 + 号前的版本号
            this.Text = $"RemoteApp工具 {version} ({System.Net.Dns.GetHostName()})";

            try
            {
                // 初始化按钮图标
                InitializeButtonIcons();
                
                // 加载设置（按住Shift键启动可以重置窗口大小）
                if (!Control.ModifierKeys.HasFlag(Keys.Shift))
                {
                    if (Properties.Settings.Default.MainWindowWidth >= this.MinimumSize.Width)
                        this.Width = Properties.Settings.Default.MainWindowWidth;
                    if (Properties.Settings.Default.MainWindowHeight >= this.MinimumSize.Height)
                        this.Height = Properties.Settings.Default.MainWindowHeight;
                }
                
                // 检查toolTip对象是否已初始化
                if (toolTip == null)
                {
                    System.Diagnostics.Debug.WriteLine("toolTip对象为null，重新初始化");
                    InitializeToolTips();
                }
                
                // 主界面按钮的完整Tooltip已由专用tooltip组件处理
                try
                {
                    // 仅保留对非底部按钮的tooltip设置
                    if (this.AppList != null)
                    {
                        toolTip.SetToolTip(this.AppList, "RemoteApp 应用程序列表\n显示服务器上所有已配置的远程应用程序\n双击可编辑应用程序");
                        System.Diagnostics.Debug.WriteLine("已设置AppList的tooltip");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("设置按钮tooltip时出错: " + ex.Message);
                }
                
                // 菜单项使用 ToolTipText 属性
                this.FileToolStripMenuItem.ToolTipText = "文件菜单\n包含新建、复制和退出选项";
                this.ToolsToolStripMenuItem.ToolTipText = "工具菜单\n包含主机选项、清理和备份功能";
                this.HelpToolStripMenuItem.ToolTipText = "帮助菜单\n包含网站链接和关于信息";
                this.NewRemoteAppadvancedToolStripMenuItem.ToolTipText = "创建新的 RemoteApp（高级模式）\n使用高级选项创建新的远程应用程序";
                this.DuplicateToolStripMenuItem.ToolTipText = "复制选中的 RemoteApp\n创建当前选中应用程序的副本";
                this.HostOptionsToolStripMenuItem.ToolTipText = "主机选项\n配置 RemoteApp 服务器的全局设置";
                this.RemoveUnusedFileTypeAssociationsToolStripMenuItem.ToolTipText = "清理未使用的文件类型关联\n删除不再使用的文件类型关联";
                this.BackupAllRemoteAppsToolStripMenuItem.ToolTipText = "备份所有 RemoteApp\n将所有 RemoteApp 配置导出为注册表文件";
                this.WebsiteToolStripMenuItem.ToolTipText = "访问项目网站\n在浏览器中打开 RemoteApp Tool 的 GitHub 主页";
                this.AboutToolStripMenuItem.ToolTipText = "关于 RemoteApp Tool\n显示软件版本和作者信息";
                this.ExitToolStripMenuItem.ToolTipText = "退出程序\n关闭 RemoteApp Tool 应用程序";
                
                // 为 NoAppsLabel 添加 tooltip
                if (this.NoAppsLabel != null)
                {
                    toolTip.SetToolTip(this.NoAppsLabel, "提示信息\n当前系统上没有配置任何 RemoteApp\n点击 [+创建] 按钮开始添加新的 RemoteApp 应用程序");
                    System.Diagnostics.Debug.WriteLine("已设置NoAppsLabel的tooltip");
                }
                else
                {
                    // 如果NoAppsLabel不存在，立即创建它
                    EnsureNoAppsLabelExists();
                    System.Diagnostics.Debug.WriteLine("在RemoteAppMainWindow_Load中创建了NoAppsLabel控件");
                    
                    // 为新创建的NoAppsLabel添加tooltip
                    if (this.NoAppsLabel != null && toolTip != null)
                    {
                        toolTip.SetToolTip(this.NoAppsLabel, "提示信息\n当前系统上没有配置任何 RemoteApp\n点击 [+创建] 按钮开始添加新的 RemoteApp 应用程序");
                        System.Diagnostics.Debug.WriteLine("已为新创建的NoAppsLabel设置tooltip");
                    }
                }
                
                // 设置菜单项图标
                try
                {
                    // 文件菜单
                    if (this.FileToolStripMenuItem != null && this.SmallerIcons.Images.Count > 7)
                    {
                        this.FileToolStripMenuItem.ImageIndex = 7; // file图标
                        System.Diagnostics.Debug.WriteLine("已设置File菜单图标");
                    }
                    
                    if (this.NewRemoteAppadvancedToolStripMenuItem != null && this.SmallerIcons.Images.Count > 5)
                    {
                        this.NewRemoteAppadvancedToolStripMenuItem.ImageIndex = 5; // plus图标
                        System.Diagnostics.Debug.WriteLine("已设置NewRemoteAppadvanced菜单项图标");
                    }
                    
                    if (this.DuplicateToolStripMenuItem != null && this.SmallerIcons.Images.Count > 8)
                    {
                        this.DuplicateToolStripMenuItem.ImageIndex = 8; // copy图标
                        System.Diagnostics.Debug.WriteLine("已设置Duplicate菜单项图标");
                    }
                    
                    if (this.ExitToolStripMenuItem != null && this.SmallerIcons.Images.Count > 9)
                    {
                        this.ExitToolStripMenuItem.ImageIndex = 9; // exit图标
                        System.Diagnostics.Debug.WriteLine("已设置Exit菜单项图标");
                    }
                    
                    // 工具菜单
                    if (this.ToolsToolStripMenuItem != null && this.SmallerIcons.Images.Count > 0)
                    {
                        this.ToolsToolStripMenuItem.ImageIndex = 0; // tools图标
                        System.Diagnostics.Debug.WriteLine("已设置Tools菜单图标");
                    }
                    
                    if (this.HostOptionsToolStripMenuItem != null && this.SmallerIcons.Images.Count > 10)
                    {
                        this.HostOptionsToolStripMenuItem.ImageIndex = 10; // host图标
                        System.Diagnostics.Debug.WriteLine("已设置HostOptions菜单项图标");
                    }
                    
                    if (this.RemoveUnusedFileTypeAssociationsToolStripMenuItem != null && this.SmallerIcons.Images.Count > 11)
                    {
                        this.RemoveUnusedFileTypeAssociationsToolStripMenuItem.ImageIndex = 11; // cleanup图标
                        System.Diagnostics.Debug.WriteLine("已设置RemoveUnusedFileTypeAssociations菜单项图标");
                    }
                    
                    if (this.BackupAllRemoteAppsToolStripMenuItem != null && this.SmallerIcons.Images.Count > 12)
                    {
                        this.BackupAllRemoteAppsToolStripMenuItem.ImageIndex = 12; // backup图标
                        System.Diagnostics.Debug.WriteLine("已设置BackupAllRemoteApps菜单项图标");
                    }
                    
                    // 帮助菜单
                    if (this.HelpToolStripMenuItem != null && this.SmallerIcons.Images.Count > 1)
                    {
                        this.HelpToolStripMenuItem.ImageIndex = 1; // help图标
                        System.Diagnostics.Debug.WriteLine("已设置Help菜单图标");
                    }
                    
                    if (this.WebsiteToolStripMenuItem != null && this.SmallerIcons.Images.Count > 13)
                    {
                        this.WebsiteToolStripMenuItem.ImageIndex = 13; // website图标
                        System.Diagnostics.Debug.WriteLine("已设置Website菜单项图标");
                    }
                    
                    if (this.AboutToolStripMenuItem != null && this.SmallerIcons.Images.Count > 14)
                    {
                        this.AboutToolStripMenuItem.ImageIndex = 14; // about图标
                        System.Diagnostics.Debug.WriteLine("已设置关于菜单项图标");
                    }
                    
                    // 设置底部按钮图标
                    if (this.CreateButton != null && this.SmallerIcons.Images.Count > 5)
                    {
                        this.CreateButton.ImageIndex = 5; // plus图标
                        System.Diagnostics.Debug.WriteLine("已设置CreateButton图标");
                    }
                    
                    if (this.EditButton != null && this.SmallerIcons.Images.Count > 4)
                    {
                        this.EditButton.ImageIndex = 4; // properties图标
                        System.Diagnostics.Debug.WriteLine("已设置EditButton图标");
                    }
                    
                    if (this.DeleteButton != null && this.SmallerIcons.Images.Count > 6)
                    {
                        this.DeleteButton.ImageIndex = 6; // minus图标
                        System.Diagnostics.Debug.WriteLine("已设置DeleteButton图标");
                    }
                    
                    if (this.CreateClientConnection != null && this.SmallerIcons.Images.Count > 3)
                    {
                        this.CreateClientConnection.ImageIndex = 3; // msi图标
                        System.Diagnostics.Debug.WriteLine("已设置CreateClientConnection图标");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("设置菜单项图标时出错: " + ex.Message);
                }
                
                // 强制创建消息面板和初始化NoAppsLabel
                EnsureMessagePanelExists();
                
                // 在加载应用列表前先显示NoAppsLabel
                if (NoAppsLabel != null)
                {
                    NoAppsLabel.Visible = true;
                    NoAppsLabel.BringToFront();
                    System.Diagnostics.Debug.WriteLine("在RemoteAppMainWindow_Load中强制显示了NoAppsLabel");
                }
                
                // 暂时隐藏AppList，直到加载完成
                AppList.Visible = false;
                
                // 加载应用列表
                ReloadApps();
                
                // 强制刷新UI，确保所有控件正确显示
                this.PerformLayout();
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Debug.WriteLine("RemoteAppMainWindow_Load错误: " + ex.Message);
            }
        }

        private void RemoteAppMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存窗口大小（仅当窗口不是最大化时）
            if (this.WindowState != FormWindowState.Maximized)
            {
                Properties.Settings.Default.MainWindowWidth = this.Width;
                Properties.Settings.Default.MainWindowHeight = this.Height;
                Properties.Settings.Default.Save();
            }
        }

        public void ReloadApps()
        {
            int selectedIndex = -1;
            string selectedName = "";
            int itemsCount = this.AppList.Items.Count;

            // Save the selection if there is one
            if (this.AppList.SelectedItems.Count > 0)
            {
                selectedIndex = this.AppList.SelectedItems[0].Index;
                selectedName = this.AppList.SelectedItems[0].Text;
            }

            this.AppList.Clear();

            try
            {
                var systemApps = new SystemRemoteApps();
                var apps = new RemoteAppCollection();
                apps = systemApps.GetAll();

                foreach (RemoteApp app in apps)
                {
                    // Check if the image is already present in SmallIcons before adding it
                    if (!this.SmallIcons.Images.ContainsKey(app.Name))
                    {
                        var theBitmap = GetAppBitmap(app.Name);
                        this.SmallIcons.Images.Add(app.Name, theBitmap);
                    }

                    // Create the ListView item
                    var appItem = new ListViewItem(app.Name);
                    appItem.ToolTipText = app.FullName;
                    appItem.ImageKey = app.Name;
                    AppList.Items.Add(appItem);
                }
            }
            catch (Exception ex)
            {
                // 如果无法加载RemoteApp，显示错误信息
                System.Diagnostics.Debug.WriteLine($"加载RemoteApp失败: {ex.Message}");
            }

            // If there was previously a selection
            if (selectedIndex > -1 && this.AppList.Items.Count > selectedIndex)
            {
                if (this.AppList.Items.Count >= itemsCount)
                {
                    if (this.AppList.Items[selectedIndex].Text == selectedName)
                    {
                        this.AppList.Items[selectedIndex].Selected = true;
                    }
                }
            }

            UpdateWindowStateBasedOnSelection();
        }

        // 暂时简化所有方法，只显示界面
        private void AppList_DoubleClick(object sender, EventArgs e)
        {
            if (this.AppList.SelectedItems.Count == 1)
            {
                EditRemoteApp(this.AppList.SelectedItems[0].Text);
            }
        }
        
        private void AppList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWindowStateBasedOnSelection();
        }
        
        private void UpdateWindowStateBasedOnSelection()
        {
            try
            {
                // 创建或更新消息显示容器
                EnsureMessagePanelExists();
                
                if (AppList.Items.Count == 0)
                {
                    // 显示NoAppsLabel
                    if (NoAppsLabel != null)
                    {
                        NoAppsLabel.Visible = true;
                        NoAppsLabel.BringToFront();
                    }
                    
                    // 隐藏AppList
                    AppList.Visible = false;
                    
                    EditButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    CreateClientConnection.Enabled = false;
                    DuplicateToolStripMenuItem.Enabled = false;
                    System.Diagnostics.Debug.WriteLine("AppList为空，显示NoAppsLabel");
                }
                else
                {
                    // 隐藏NoAppsLabel
                    if (NoAppsLabel != null)
                    {
                        NoAppsLabel.Visible = false;
                    }
                    
                    // 显示AppList
                    AppList.Visible = true;
                    
                    if (AppList.SelectedItems.Count == 1)
                    {
                        EditButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    CreateClientConnection.Enabled = true;
                    DuplicateToolStripMenuItem.Enabled = true;
                    btnCopy.Enabled = true;
                    }
                    else
                    {
                        EditButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    CreateClientConnection.Enabled = false;
                    DuplicateToolStripMenuItem.Enabled = false;
                    btnCopy.Enabled = false;
                    }
                }
                
                CreateButton.Enabled = true;
                
                // 强制布局更新，确保所有控件都正确绘制
                this.PerformLayout();
                this.Refresh();
                
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("UpdateWindowStateBasedOnSelection异常: " + ex.Message);
            }
        }
        
        private void EnsureMessagePanelExists()
        {
            if (messagePanel == null)
            {
                // 创建消息面板作为专门的容器
                messagePanel = new Panel();
                messagePanel.Name = "MessagePanel";
                messagePanel.BackColor = Color.WhiteSmoke; // 使用略微不同的背景色确保可见
                messagePanel.Dock = DockStyle.Fill;
                messagePanel.BringToFront();
                messagePanel.Visible = false;
                
                // 将面板添加到表单的最顶层
                if (!this.Controls.Contains(messagePanel))
                {
                    this.Controls.Add(messagePanel);
                }
                this.Controls.SetChildIndex(messagePanel, 0);
                
                System.Diagnostics.Debug.WriteLine("消息面板已创建并配置");
            }
            
            // 使用Designer.cs中已经存在的NoAppsLabel控件
            if (NoAppsLabel != null)
            {
                // 更新NoAppsLabel的属性
                NoAppsLabel.Text = "此计算机上没有托管 RemoteApp。\n点击 [+创建] 按钮添加一个。";
                NoAppsLabel.Font = new Font("Microsoft YaHei", 10, FontStyle.Bold);
                NoAppsLabel.ForeColor = Color.Black;
                NoAppsLabel.BackColor = Color.White;
                NoAppsLabel.TextAlign = ContentAlignment.MiddleCenter;
                NoAppsLabel.AutoSize = false;
                NoAppsLabel.Size = new Size(400, 60); // 固定大小确保文本完全显示
                NoAppsLabel.Visible = false; // 初始隐藏，由UpdateWindowStateBasedOnSelection控制
                
                // 将标签直接添加到主窗口，不放在messagePanel中
                // 我们只需要控制它的可见性
            }
        }
        
        // 统一使用EnsureMessagePanelExists，废弃原来的实现
        private void EnsureNoAppsLabelExists()
        {
            try
            {
                // 调用EnsureMessagePanelExists来创建消息面板和标签
                EnsureMessagePanelExists();
                
                // 确保标签设置正确
                if (NoAppsLabel != null)
                {
                    NoAppsLabel.Visible = true;
                    NoAppsLabel.BringToFront();
                    System.Diagnostics.Debug.WriteLine("通过EnsureMessagePanelExists确保了NoAppsLabel控件可见");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("确保NoAppsLabel可见时出错: " + ex.Message);
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.AppList.SelectedItems.Count == 1)
            {
                EditRemoteApp(this.AppList.SelectedItems[0].Text);
            }
        }
        private void EditRemoteApp(string appName)
        {
            try
            {
                var sra = new SystemRemoteApps();
                var editWindow = new RemoteAppEditWindow();
                editWindow.EditRemoteApp(sra.GetApp(appName));
                DeleteImage(appName);
                ReloadApps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法编辑RemoteApp: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteImage(string appName)
        {
            if (this.SmallIcons.Images.ContainsKey(appName))
            {
                this.SmallIcons.Images.RemoveByKey(appName);
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (this.AppList.SelectedItems.Count == 1)
            {
                DeleteRemoteApp(AppList.SelectedItems[0].Text);
                DeleteImage(AppList.SelectedItems[0].Text);
                ReloadApps();
            }
        }
        private void DeleteRemoteApp(string appName)
        {
            if (MessageBox.Show($"确实要删除 {appName} 吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var sra = new SystemRemoteApps();
                    sra.DeleteApp(appName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("CreateButton_Click 开始");
                var editWindow = new RemoteAppEditWindow();
                System.Diagnostics.Debug.WriteLine("RemoteAppEditWindow 创建成功");
                
                editWindow.CreateRemoteApp();
                System.Diagnostics.Debug.WriteLine("CreateRemoteApp 返回");
                
                ReloadApps();
                System.Diagnostics.Debug.WriteLine("ReloadApps 完成");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateButton_Click 错误: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"InnerException: {ex.InnerException?.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"无法创建RemoteApp:\n\n错误: {ex.Message}\n\n内部错误: {ex.InnerException?.Message}\n\n堆栈:\n{ex.StackTrace}", "详细错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddSysMenuItems() { }
        private void CreateClientConnection_Click(object sender, EventArgs e)
        {
            if (this.AppList.SelectedItems.Count == 1)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("CreateClientConnection_Click 开始");
                    
                    var selectedAppName = this.AppList.SelectedItems[0].Text;
                    System.Diagnostics.Debug.WriteLine($"选中的应用: {selectedAppName}");
                    
                    // 启用RemoteAppCreateClientConnection功能
                    var sra = new SystemRemoteApps();
                    var selectedApp = sra.GetApp(selectedAppName);
                    
                    if (selectedApp != null)
                    {
                        var createClientWindow = new RemoteAppCreateClientConnection();
                        createClientWindow.CreateClientConnection(selectedApp);
                    }
                    else
                    {
                        MessageBox.Show($"无法找到 RemoteApp: {selectedAppName}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"CreateClientConnection_Click 错误: {ex.Message}");
                    MessageBox.Show($"创建客户端连接时出错：\n{ex.Message}\n\n堆栈追踪：\n{ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HostOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var hostOptions = new RemoteAppHostOptions();
                hostOptions.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开主机选项: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var aboutWindow = new RemoteAppAboutWindow();
                aboutWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开关于窗口: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) { Environment.Exit(0); }
        private void WebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string urtl = "https://cloud.tencent.com/developer/user/8197675";

                System.Diagnostics.Process.Start(urtl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开网站: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RemoveUnusedFileTypeAssociationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LocalFtaModule.RemoveUnusedFTAs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"清理文件类型关联失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NewRemoteAppadvancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var editWindow = new RemoteAppEditWindow();
                editWindow.CreateRemoteApp(true);
                ReloadApps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法创建高级RemoteApp: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BackupAllRemoteAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "注册表文件|*.reg",
                    DefaultExt = "reg",
                    FileName = $"{System.Net.Dns.GetHostName()} RemoteApps Backup {DateTime.Now:yyyy-MM-dd}.reg"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var regPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications";
                    var startInfo = new ProcessStartInfo("reg.exe",
                        $"export \"{regPath}\" \"{saveDialog.FileName}\" /y")
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = Process.Start(startInfo);
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("备份成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("备份失败，请确保有足够的权限。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"备份失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRemoteAPP();
        }

        private void CopyRemoteAPP()
        {
            if (AppList.SelectedItems.Count == 1)
            {
                try
                {
                    DuplicateRemoteApp(AppList.SelectedItems[0].Text);
                    ReloadApps();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"复制失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DuplicateRemoteApp(string appName)
        {
            var sra = new SystemRemoteApps();
            sra.DuplicateApp(appName);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyRemoteAPP();
        }
    }
}