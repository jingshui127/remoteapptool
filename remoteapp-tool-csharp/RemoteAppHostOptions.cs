using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RemoteApp_Tool
{
    public partial class RemoteAppHostOptions : Form
    {
        public RemoteAppHostOptions()
        {
            InitializeComponent();
        }

        private void RemoteAppHostOptions_Load(object sender, EventArgs e)
        {
            SetValues();
        }

        public void SetValues()
        {
            try
            {
                const string policyKeyString = @"SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services";

                DisconnectTimeTextBox.Text = "0";
                IdleTimeTextBox.Text = "0";

                // 读取 fDisabledAllowList
                var fDisabledAllowList = Registry.GetValue(
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList",
                    "fDisabledAllowList", 0);
                DisableAllowListCheckBox.Checked = Convert.ToInt32(fDisabledAllowList) == 1;

                // 打开策略注册表键
                using (var policyKey = Registry.LocalMachine.OpenSubKey(policyKeyString, false))
                {
                    if (policyKey != null)
                    {
                        // 读取 MaxDisconnectionTime
                        var maxDisconnectionTime = policyKey.GetValue("MaxDisconnectionTime");
                        if (maxDisconnectionTime != null)
                        {
                            TimeoutDisconnectedCheckBox.Checked = true;
                            DisconnectTimeTextBox.Text = (Convert.ToInt32(maxDisconnectionTime) / 1000).ToString();
                        }
                        else
                        {
                            TimeoutDisconnectedCheckBox.Checked = false;
                        }

                        // 读取 MaxIdleTime
                        var maxIdleTime = policyKey.GetValue("MaxIdleTime");
                        if (maxIdleTime != null)
                        {
                            TimeoutIdleCheckBox.Checked = true;
                            IdleTimeTextBox.Text = (Convert.ToInt32(maxIdleTime) / 1000).ToString();
                        }
                        else
                        {
                            TimeoutIdleCheckBox.Checked = false;
                        }

                        // 读取 fResetBroken
                        var fResetBroken = policyKey.GetValue("fResetBroken");
                        LogoffWhenTimoutCheckBox.Checked = fResetBroken != null;

                        // 读取 fAllowUnlistedRemotePrograms
                        var fAllowUnlistedRemotePrograms = policyKey.GetValue("fAllowUnlistedRemotePrograms");
                        AllowUnlistedRemoteProgramsCheckBox.Checked = fAllowUnlistedRemotePrograms != null;
                    }
                }

                // 设置TextBox的启用状态
                DisconnectTimeTextBox.Enabled = TimeoutDisconnectedCheckBox.Checked;
                IdleTimeTextBox.Enabled = TimeoutIdleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取设置失败：{ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                const string policyKeyStringMS = @"SOFTWARE\Policies\Microsoft";
                const string policyKeyString = @"SOFTWARE\Policies\Microsoft\Windows NT\Terminal Services";

                // 创建策略注册表键
                using (var policyKeyMS = Registry.LocalMachine.OpenSubKey(policyKeyStringMS, true))
                {
                    if (policyKeyMS != null)
                    {
                        using (var policyKeyWNT = policyKeyMS.CreateSubKey("Windows NT"))
                        {
                            policyKeyWNT?.CreateSubKey("Terminal Services");
                        }
                    }
                }

                using (var policyKey = Registry.LocalMachine.OpenSubKey(policyKeyString, true))
                {
                    if (policyKey == null)
                    {
                        MessageBox.Show("无法打开策略注册表键。", "错误", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 保存 fDisabledAllowList
                    Registry.SetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList",
                        "fDisabledAllowList",
                        DisableAllowListCheckBox.Checked ? 1 : 0,
                        RegistryValueKind.DWord);

                    // 保存 fAllowUnlistedRemotePrograms
                    if (AllowUnlistedRemoteProgramsCheckBox.Checked)
                    {
                        policyKey.SetValue("fAllowUnlistedRemotePrograms", 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        try { policyKey.DeleteValue("fAllowUnlistedRemotePrograms", false); } catch { }
                    }

                    // 保存 MaxDisconnectionTime
                    if (TimeoutDisconnectedCheckBox.Checked)
                    {
                        int seconds = 0;
                        if (int.TryParse(DisconnectTimeTextBox.Text, out seconds))
                        {
                            policyKey.SetValue("MaxDisconnectionTime", seconds * 1000, RegistryValueKind.DWord);
                        }
                    }
                    else
                    {
                        try { policyKey.DeleteValue("MaxDisconnectionTime", false); } catch { }
                    }

                    // 保存 MaxIdleTime
                    if (TimeoutIdleCheckBox.Checked)
                    {
                        int seconds = 0;
                        if (int.TryParse(IdleTimeTextBox.Text, out seconds))
                        {
                            policyKey.SetValue("MaxIdleTime", seconds * 1000, RegistryValueKind.DWord);
                        }
                    }
                    else
                    {
                        try { policyKey.DeleteValue("MaxIdleTime", false); } catch { }
                    }

                    // 保存 fResetBroken
                    if (LogoffWhenTimoutCheckBox.Checked)
                    {
                        policyKey.SetValue("fResetBroken", 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        try { policyKey.DeleteValue("fResetBroken", false); } catch { }
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存设置失败：{ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimeoutDisconnectedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DisconnectTimeTextBox.Enabled = TimeoutDisconnectedCheckBox.Checked;
        }

        private void TimeoutIdleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IdleTimeTextBox.Enabled = TimeoutIdleCheckBox.Checked;
        }

        private void DisconnectTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateSeconds(DisconnectTimeTextBox);
        }

        private void IdleTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateSeconds(IdleTimeTextBox);
        }

        private void ValidateSeconds(TextBox textBox)
        {
            // 验证输入是否为有效的数字
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                int cursorPosition = textBox.SelectionStart;
                string text = textBox.Text;
                
                // 移除非数字字符
                string validText = new string(text.Where(char.IsDigit).ToArray());
                
                // 转换为数字并检查最大值（VB.NET 版本限制：2147483 秒）
                if (!string.IsNullOrEmpty(validText))
                {
                    long value;
                    if (long.TryParse(validText, out value))
                    {
                        if (value > 2147483)
                        {
                            validText = "2147483";
                            cursorPosition = validText.Length;
                        }
                    }
                }
                
                if (text != validText)
                {
                    textBox.Text = validText;
                    textBox.SelectionStart = Math.Min(cursorPosition, validText.Length);
                }
            }
        }
    }
}