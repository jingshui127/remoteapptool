using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RemoteAppLib;
using RemoteApp_Tool;  // 添加命名空间引用

namespace RemoteAppTool
{
    public partial class RemoteAppFileTypeAssociation : Form
    {
        private RemoteApp RemoteApp = new RemoteApp();

        public RemoteAppFileTypeAssociation()
        {
            InitializeComponent();
            
            // 初始化ImageList，使用系统图标作为临时解决方案
            InitializeImageLists();
            
            // 初始化Tooltip，使用用户偏好的浅黄色背景
            SetToolTips();
        }
        
        /// <summary>
        /// 初始化ImageList，仅在需要时补充图标
        /// </summary>
        private void InitializeImageLists()
        {
            try
            {
                // 检查SmallerIcons是否为空，只有为空时才添加系统图标
                if (this.SmallerIcons.Images.Count == 0)
                {
                    // 为SmallerIcons添加基础图标
                    // 0: properties.ico - 编辑图标
                    this.SmallerIcons.Images.Add("properties.ico", SystemIcons.Information.ToBitmap());
                    // 1: plus.ico - 创建图标
                    this.SmallerIcons.Images.Add("plus.ico", SystemIcons.Information.ToBitmap());
                    // 2: minus.ico - 删除图标
                    this.SmallerIcons.Images.Add("minus.ico", SystemIcons.Warning.ToBitmap());
                    // 3: tick.ico - 确定图标
                    this.SmallerIcons.Images.Add("tick.ico", SystemIcons.Information.ToBitmap());
                    // 4: flag2-add.ico - 设置关联图标
                    this.SmallerIcons.Images.Add("flag2-add.ico", SystemIcons.Information.ToBitmap());
                    // 5: settings-16.ico - 设置图标
                    this.SmallerIcons.Images.Add("settings-16.ico", SystemIcons.Information.ToBitmap());
                }
                
                // 检查SmallerIcons2是否为空，只有为空时才添加系统图标
                if (this.SmallerIcons2.Images.Count == 0)
                {
                    // 为SmallerIcons2添加图标
                    // 0: cross.ico - 关闭图标
                    this.SmallerIcons2.Images.Add("cross.ico", SystemIcons.Error.ToBitmap());
                }
                
                System.Diagnostics.Debug.WriteLine($"RemoteAppFileTypeAssociation ImageList初始化完成");
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

            // 文件类型关联列表
            toolTip.SetToolTip(this.FTAListView, "文件类型关联列表\n显示当前RemoteApp对应的所有文件类型关联\n可以双击某一项进行编辑");
            
            // 操作按钮
            toolTip.SetToolTip(this.CreateButton, "创建新的文件类型关联\n为RemoteApp添加新的文件类型支持");
            toolTip.SetToolTip(this.EditButton, "编辑选中的文件类型关联\n修改选中文件类型的图标和属性");
            toolTip.SetToolTip(this.DeleteButton, "删除选中的文件类型关联\n从RemoteApp中移除选中的文件类型支持");
            toolTip.SetToolTip(this.SetAssociationButton, "在本地计算机上设置文件关联\n在本地系统中创建或移除文件类型关联");
            toolTip.SetToolTip(this.CloseButton, "关闭文件类型关联管理窗口\n保存更改并返回RemoteApp编辑窗口");
        }

        public RemoteApp EditFileTypes(RemoteApp selectedRemoteApp)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("EditFileTypes 开始");
                
                RemoteApp = selectedRemoteApp;
                System.Diagnostics.Debug.WriteLine($"RemoteApp: {RemoteApp?.Name}");
                
                this.Text = "File type associations for " + RemoteApp.Name;
                System.Diagnostics.Debug.WriteLine($"Window title set: {this.Text}");
                
                // HelpSystem.SetupTips(this);
                
                System.Diagnostics.Debug.WriteLine("准备调用LoadFTAs");
                LoadFTAs();
                System.Diagnostics.Debug.WriteLine("LoadFTAs 完成");
                
                this.ShowDialog();
                System.Diagnostics.Debug.WriteLine("ShowDialog 完成");
                
                this.Dispose();
                return RemoteApp;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EditFileTypes 错误: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"打开文件类型关联窗口失败:\n\n{ex.Message}\n\n堆栈跟踪:\n{ex.StackTrace}", 
                              "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return selectedRemoteApp;
            }
        }

        private void LoadFTAs()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("LoadFTAs 开始");
                FTAListView.Items.Clear();
                System.Diagnostics.Debug.WriteLine("ListView 已清空");

                if (RemoteApp.FileTypeAssociations != null)
                {
                    System.Diagnostics.Debug.WriteLine($"FileTypeAssociations count: {RemoteApp.FileTypeAssociations.Count}");
                    
                    int index = 0;
                    foreach (FileTypeAssociation fta in RemoteApp.FileTypeAssociations)
                    {
                        System.Diagnostics.Debug.WriteLine($"Processing FTA {index}: Extension={fta.Extension}, IconPath={fta.IconPath}, IconIndex={fta.IconIndex}");
                        
                        var ftItem = new ListViewItem(fta.Extension);

                        string ftaStatus;
                        if (LocalFtaModule.DoesFTAExist(fta.Extension))
                        {
                            // FTA exists - created by another app
                            ftaStatus = "Existing";
                            if (LocalFtaModule.IsFTAMine(fta.Extension))
                            {
                                // FTA exists - created by RemoteApp Tool
                                ftaStatus = "Yes";
                            }
                        }
                        else
                        {
                            // FTA does not exist
                            ftaStatus = "No";
                        }

                        ftItem.SubItems.Add(fta.IconPath);
                        ftItem.SubItems.Add(fta.IconIndex.ToString());
                        ftItem.SubItems.Add(ftaStatus);
                        FTAListView.Items.Add(ftItem);
                        
                        System.Diagnostics.Debug.WriteLine($"Added FTA {index} to ListView");
                        index++;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("FileTypeAssociations is null");
                }
                
                CheckSelection();
                System.Diagnostics.Debug.WriteLine("LoadFTAs 完成");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadFTAs 错误: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"LoadFTAs 错误: {ex.Message}\n\n{ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("CreateButton_Click 开始");
                
                if (RemoteApp.FileTypeAssociations == null)
                {
                    var ftaCol = new FileTypeAssociationCollection();
                    RemoteApp.FileTypeAssociations = ftaCol;
                    System.Diagnostics.Debug.WriteLine("创建了新的FileTypeAssociations集合");
                }

                System.Diagnostics.Debug.WriteLine($"准备调用ManageFTA，IconPath={RemoteApp.IconPath}");
                var fta = RemoteAppIconPicker.ManageFTA(RemoteApp.IconPath, 0);
                System.Diagnostics.Debug.WriteLine($"ManageFTA 返回，Extension={fta.Extension}");
                
                bool sameFTA = false;
                
                if (fta.Extension != null)
                {
                    foreach (FileTypeAssociation rafta in RemoteApp.FileTypeAssociations)
                    {
                        if (rafta.Extension == fta.Extension) 
                            sameFTA = true;
                    }
                    
                    if (!sameFTA)
                    {
                        RemoteApp.FileTypeAssociations.Add(fta);
                        System.Diagnostics.Debug.WriteLine($"添加了文件类型关联: {fta.Extension}");
                    }
                    else
                    {
                        MessageBox.Show("文件类型关联已存在：" + fta.Extension, 
                                      "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                LoadFTAs();
                System.Diagnostics.Debug.WriteLine("CreateButton_Click 完成");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateButton_Click 错误: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"创建文件类型关联失败: {ex.Message}\n\n{ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FTAListView_DoubleClick(object sender, EventArgs e)
        {
            EditFTA();
        }

        private void FTAListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelection();
        }

        private void CheckSelection()
        {
            if (FTAListView.SelectedItems.Count > 0)
            {
                this.EditButton.Enabled = true;
                this.DeleteButton.Enabled = true;
                this.SetAssociationButton.Enabled = true;
            }
            else
            {
                this.EditButton.Enabled = false;
                this.DeleteButton.Enabled = false;
                this.SetAssociationButton.Enabled = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string fileType = FTAListView.SelectedItems[0].Text;
            if (MessageBox.Show("确认要移除文件类型关联：" + Environment.NewLine + "." + fileType + " ?", 
                              "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                              MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string iconPath = FTAListView.SelectedItems[0].SubItems[0].Text;
                string iconIndex = FTAListView.SelectedItems[0].SubItems[1].Text;
                
                FileTypeAssociation ftaToRemove = null;
                foreach (FileTypeAssociation fta in RemoteApp.FileTypeAssociations)
                {
                    if (fta.Extension == fileType) 
                        ftaToRemove = fta;
                }
                
                if (ftaToRemove != null)
                    RemoteApp.FileTypeAssociations.Remove(ftaToRemove);
            }

            LoadFTAs();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditFTA();
        }

        private void EditFTA()
        {
            try
            {
                // ListView的结构：
                // [0] Text (Extension)
                // SubItems[0] (IconPath)
                // SubItems[1] (IconIndex)
                // SubItems[2] (Status)
                
                var fta = RemoteAppIconPicker.ManageFTA(
                    this.FTAListView.SelectedItems[0].SubItems[0].Text,  // IconPath
                    Convert.ToInt32(this.FTAListView.SelectedItems[0].SubItems[1].Text),  // IconIndex
                    this.FTAListView.SelectedItems[0].Text,  // Extension
                    true);

                if (fta.Extension != null)
                {
                    string fileType = FTAListView.SelectedItems[0].Text;
                    
                    FileTypeAssociation ftaToRemove = null;
                    foreach (FileTypeAssociation fta2 in RemoteApp.FileTypeAssociations)
                    {
                        if (fta2.Extension == fileType) 
                            ftaToRemove = fta2;
                    }
                    
                    if (ftaToRemove != null)
                    {
                        RemoteApp.FileTypeAssociations.Remove(ftaToRemove);
                        RemoteApp.FileTypeAssociations.Add(fta);
                    }
                    LoadFTAs();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EditFTA错误: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"编辑文件类型关联失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAssociationButton_Click(object sender, EventArgs e)
        {
            try
            {
                // ListView的结构：
                // [0] Text (Extension)
                // SubItems[0] (IconPath)
                // SubItems[1] (IconIndex)
                // SubItems[2] (Status)
                
                var fta = new FileTypeAssociation();
                fta.Extension = FTAListView.SelectedItems[0].Text;  // Extension
                fta.IconPath = FTAListView.SelectedItems[0].SubItems[0].Text;  // IconPath
                fta.IconIndex = FTAListView.SelectedItems[0].SubItems[1].Text;  // IconIndex

                DialogResult msgBoxResult = DialogResult.Cancel;

                if (LocalFtaModule.DoesFTAExist(fta.Extension))
                {
                    // An existing association was found
                    if (!LocalFtaModule.IsFTAMine(fta.Extension))
                    {
                        // FTA found and belongs to another application (replace?)
                        msgBoxResult = MessageBox.Show("本地计算机上已存在此文件类型的关联。" +
                                                     "是否要替换它？" + Environment.NewLine + Environment.NewLine +
                                                     "警告：此关联由另一个应用程序创建。" +
                                                     "替换它可能会导致问题。" +
                                                     "如果现有关联正常工作，则无需替换。",
                                                     "文件类型关联",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (msgBoxResult == DialogResult.Yes)
                            LocalFtaModule.CreateFTA(fta, RemoteApp.Path, RemoteApp.Name, true);
                    }
                    else
                    {
                        // FTA found and belongs to RemoteApp Tool (remove)
                        msgBoxResult = MessageBox.Show("确认要移除本地计算机上的此文件类型关联吗？",
                                                     "文件类型关联",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (msgBoxResult == DialogResult.Yes)
                            LocalFtaModule.DeleteFTA(fta.Extension);
                    }
                }
                else
                {
                    // FTA not found (create)
                    if (LocalFtaModule.CreateFTA(fta, RemoteApp.Path, RemoteApp.Name) == true)
                    {
                        MessageBox.Show("已为 " + fta.Extension + " 创建文件类型关联。", 
                                      "文件类型关联", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("未创建文件类型关联。发生错误。", 
                                      "文件类型关联", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.LoadFTAs();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SetAssociationButton_Click错误: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"设置文件关联失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}