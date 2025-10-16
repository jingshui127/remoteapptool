using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace RemoteApp_Tool
{
    public static class HelpSystem
    {
        public static void SetupTips(Form TheForm)
        {
            // 根据用户偏好，设置Tooltip背景色为浅黄色
            var toolTip1 = new ToolTip
            {
                AutoPopDelay = 10000,
                InitialDelay = 500,
                ReshowDelay = 500,
                BackColor = System.Drawing.Color.LightYellow  // 用户偏好：浅黄色背景
            };

            string HelpString;

            foreach (Control Control in TheForm.Controls)
            {
                foreach (Control SubControl in Control.Controls)
                {
                    foreach (Control SubSubControl in SubControl.Controls)
                    {
                        foreach (Control SubSubSubControl in SubSubControl.Controls)
                        {
                            HelpString = GetTipString(Control.Parent.Name, SubSubSubControl.Name);
                            if (HelpString != "") toolTip1.SetToolTip(SubSubSubControl, HelpString);
                        }
                        HelpString = GetTipString(Control.Parent.Name, SubSubControl.Name);
                        if (HelpString != "") toolTip1.SetToolTip(SubSubControl, HelpString);
                    }
                    HelpString = GetTipString(Control.Parent.Name, SubControl.Name);
                    if (HelpString != "") toolTip1.SetToolTip(SubControl, HelpString);
                }
                HelpString = GetTipString(Control.Parent.Name, Control.Name);
                if (HelpString != "") toolTip1.SetToolTip(Control, HelpString);
            }
        }

        private static string GetTipString(string FormName, string ControlName)
        {
            string TipString = "";

            string TipText = GetTipFile();
            string[] TipArray = TipText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string TipLine in TipArray)
            {
                string[] TipLineArray = TipLine.Split('|');
                if (TipLineArray.Length >= 3 && TipLineArray[0] == FormName && TipLineArray[1] == ControlName) 
                    TipString = TipLineArray[2];
            }

            TipString = TipString.Replace("\\r", "\r");
            TipString = TipString.Replace("\\n", "\n");

            return TipString;
        }

        private static string GetTipFile()
        {
            string TipFile = "";

            if (File.Exists("tips.txt"))
            {
                TipFile = File.ReadAllText("tips.txt");
            }
            else
            {
                TipFile = GetBuiltInTips();
            }

            return TipFile;
        }

        private static string GetBuiltInTips()
        {
            // 根据用户偏好，使用单一语言（中文）
            string Tips = "";

            // RemoteAppMainWindow - 主窗口
            Tips += "RemoteAppMainWindow|CreateButton|创建新的 RemoteApp。" + "\r\n";
            Tips += "RemoteAppMainWindow|DeleteButton|删除选中的 RemoteApp。" + "\r\n";
            Tips += "RemoteAppMainWindow|EditButton|编辑选中的 RemoteApp 属性。" + "\r\n";
            Tips += "RemoteAppMainWindow|CreateClientConnection|为选中的 RemoteApp 创建 RDP 文件或 MSI 安装程序。" + "\r\n";

            // RemoteAppEditWindow - 编辑窗口
            Tips += "RemoteAppEditWindow|SaveButton|保存更改并关闭。" + "\r\n";
            Tips += "RemoteAppEditWindow|FTAButton|设置此 RemoteApp 的文件类型关联。" + "\r\n";
            Tips += "RemoteAppEditWindow|CancelEditButton|放弃更改并关闭。" + "\r\n";
            Tips += "RemoteAppEditWindow|BrowseIconPath|为 RemoteApp 选择图标。" + "\r\n";
            Tips += "RemoteAppEditWindow|IconPathCopyButton|将“路径”字段的值复制到“图标路径”字段。" + "\r\n";
            Tips += "RemoteAppEditWindow|BrowsePath|浏览应用程序。" + "\r\n";
            Tips += "RemoteAppEditWindow|IconResetButton|将图标重置为此应用程序的默认图标。" + "\r\n";
            Tips += "RemoteAppEditWindow|NameTextBox|输入 RemoteApp 的短名称（用于注册表键名）。" + "\r\n";
            Tips += "RemoteAppEditWindow|FullNameTextBox|输入 RemoteApp 的完整名称（用户可见）。" + "\r\n";
            Tips += "RemoteAppEditWindow|PathTextBox|输入应用程序的完整路径。" + "\r\n";

            // RemoteAppCreateClientConnection - 创建客户端连接窗口
            Tips += "RemoteAppCreateClientConnection|RDPRadioButton|创建 RDP 文件。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|MSIRadioButton|创建 MSI 安装程序。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|EditAfterSave|编辑 RDP 连接文件。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|CreateRAWebIcon|为应用程序和任何文件类型关联生成图标。\r\n与 RAWeb 一起使用。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|FTAButton|设置此 RemoteApp 的文件类型关联。\r\n此处的更改仅影响此客户端连接，不会被保存。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|DisabledFTACheckBox|不在此客户端连接中包含文件类型关联。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|SaveButton|保存窗口设置以便下次使用。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|ResetButton|将窗口设置重置为默认值。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|CancelEditButton|关闭并返回主窗口。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|CreateButton|创建客户端连接并选择保存位置。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|UseRDGatewayCheckBox|使用远程桌面网关连接到主机。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|AttemptDirectCheckBox|先尝试直接连接，如果失败则使用远程桌面网关。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|ShortcutTagCheckBox|在每个快捷方式标题末尾附加一些文本。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|PerMachineRadioButton|快捷方式应该为所有用户安装（每计算机），还是仅为当前登录用户安装（每用户）？" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|PerUserRadioButton|快捷方式应该为所有用户安装（每计算机），还是仅为当前登录用户安装（每用户）？" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|CheckBoxSignRDPEnabled|对 RDP 文件进行数字签名。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|CheckBoxCreateSignedAndUnsigned|生成已签名和未签名的 RDP 文件副本。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|ServerAddress|输入远程桌面服务器的地址。" + "\r\n";
            Tips += "RemoteAppCreateClientConnection|ServerPort|输入远程桌面服务器的端口（默认 3389）。" + "\r\n";

            // RemoteAppFileTypeAssociation - 文件类型关联窗口
            Tips += "RemoteAppFileTypeAssociation|CreateButton|创建新的文件类型关联。" + "\r\n";
            Tips += "RemoteAppFileTypeAssociation|DeleteButton|删除选中的文件类型关联。" + "\r\n";
            Tips += "RemoteAppFileTypeAssociation|EditButton|更改选中的文件类型关联的图标。" + "\r\n";
            Tips += "RemoteAppFileTypeAssociation|SetAssociationButton|在当前系统上创建或删除选中的文件类型关联。" + "\r\n";
            Tips += "RemoteAppFileTypeAssociation|CloseButton|保存更改并关闭。" + "\r\n";

            // RemoteAppIconPicker - 图标选择器
            Tips += "RemoteAppIconPicker|BrowseButton|浏览包含图标的文件。" + "\r\n";
            Tips += "RemoteAppIconPicker|CancelEditButton|放弃更改并关闭。" + "\r\n";
            Tips += "RemoteAppIconPicker|OKButton|选择所选图标。" + "\r\n";

            // RDPOptionsWindow - RDP 选项窗口
            Tips += "RDPOptionsWindow|OptionsListBox|选择要配置的 RDP 选项。" + "\r\n";
            Tips += "RDPOptionsWindow|DescriptionTextBox|显示所选 RDP 选项的详细说明。" + "\r\n";
            Tips += "RDPOptionsWindow|ValueTextBox|输入所选 RDP 选项的值。" + "\r\n";
            Tips += "RDPOptionsWindow|ChangedOptionsListView|显示所有已修改的 RDP 选项。" + "\r\n";
            Tips += "RDPOptionsWindow|SaveButton|保存并关闭窗口。" + "\r\n";
            Tips += "RDPOptionsWindow|ResetButton|清除所有修改，恢复为默认值。" + "\r\n";
            Tips += "RDPOptionsWindow|DefaultsButton|应用推荐的默认配置。" + "\r\n";
            Tips += "RDPOptionsWindow|ResetValueButton|重置当前选项为默认值。" + "\r\n";

            // RemoteAppHostOptions - 主机选项窗口
            Tips += "RemoteAppHostOptions|DisableAllowListCheckBox|禁用应用程序允许列表（允许所有应用程序作为 RemoteApp 运行）。" + "\r\n";
            Tips += "RemoteAppHostOptions|AllowUnlistedRemoteProgramsCheckBox|允许未列入允许列表的远程程序运行。" + "\r\n";
            Tips += "RemoteAppHostOptions|TimeoutDisconnectedCheckBox|启用断开连接会话的超时时间。" + "\r\n";
            Tips += "RemoteAppHostOptions|DisconnectTimeTextBox|输入断开连接的超时时间（秒）。" + "\r\n";
            Tips += "RemoteAppHostOptions|TimeoutIdleCheckBox|启用空闲会话的超时时间。" + "\r\n";
            Tips += "RemoteAppHostOptions|IdleTimeTextBox|输入空闲的超时时间（秒）。" + "\r\n";
            Tips += "RemoteAppHostOptions|LogoffWhenTimoutCheckBox|达到时间限制时注销会话。" + "\r\n";
            Tips += "RemoteAppHostOptions|SaveButton|保存设置到注册表。" + "\r\n";
            Tips += "RemoteAppHostOptions|CancelEditButton|放弃更改并关闭。" + "\r\n";

            return Tips;
        }
    }
}