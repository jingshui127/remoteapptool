using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace RemoteApp_Tool
{
    public partial class RemoteAppHostStatus : Form
    {
        public RemoteAppHostStatus()
        {
            InitializeComponent();
            LoadHostStatus();
        }

        private void LoadHostStatus()
        {
            try
            {
                // 获取主机名称
                labelHostName.Text = System.Net.Dns.GetHostName();
                
                // 获取处理器信息
                labelProcessor.Text = GetProcessorInfo();
                
                // 获取内存信息
                labelMemory.Text = GetMemoryInfo();
                
                // 获取OS信息
                OperatingSystem os = Environment.OSVersion;
                labelOSName.Text = GetOSFriendlyName(os);
                labelOSVersion.Text = os.Version.ToString();
                
                // 获取系统型号
                labelSystemModel.Text = GetSystemModel();
                
                // 获取系统区域设置
                labelSystemLocale.Text = System.Globalization.CultureInfo.CurrentCulture.Name;
                
                // 检查远程桌面服务状态
                bool rdpServiceRunning = CheckRDPServiceStatus();
                labelRDPStatus.Text = rdpServiceRunning ? "开启" : "关闭";
                labelRDPPort.Text = rdpServiceRunning ? GetRDPPort().ToString() : "未开启";
                
                // 获取系统启动时间
                labelSystemStartTime.Text = GetSystemStartTime();
                
            } catch (Exception ex)
            {
                MessageBox.Show($"获取主机状态信息时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetProcessorInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["Name"].ToString();
                    }
                }
            } catch {}
            return "未知";
        }

        private string GetMemoryInfo()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        ulong totalMemoryKB = Convert.ToUInt64(obj["TotalVisibleMemorySize"]);
                        int totalMemoryMB = (int)(totalMemoryKB / 1024);
                        return $"{totalMemoryMB} MB";
                    }
                }
            } catch {}
            return "未知";
        }

        private string GetOSFriendlyName(OperatingSystem os)
        {
            try
            {
                // 尝试通过注册表获取更友好的OS名称
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        string productName = key.GetValue("ProductName") as string;
                        string csdVersion = key.GetValue("CSDVersion") as string;
                        
                        if (!string.IsNullOrEmpty(productName))
                        {
                            return !string.IsNullOrEmpty(csdVersion) ? $"{productName} {csdVersion}" : productName;
                        }
                    }
                }
            } catch {}
            
            return os.VersionString;
        }

        private string GetSystemModel()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["Model"]?.ToString() ?? "未知";
                    }
                }
            } catch {}
            return "未知";
        }

        private bool CheckRDPServiceStatus()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT State FROM Win32_Service WHERE Name = 'TermService'"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["State"]?.ToString() == "Running";
                    }
                }
            } catch {}
            return false;
        }

        private int GetRDPPort()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp"))
                {
                    if (key != null)
                    {
                        object portObj = key.GetValue("PortNumber");
                        if (portObj != null)
                        {
                            return Convert.ToInt32(portObj);
                        }
                    }
                }
            } catch {}
            return 3389; // 默认端口
        }

        private string GetSystemStartTime()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        string lastBootUpTime = obj["LastBootUpTime"].ToString();
                        // WMI时间格式转换
                        DateTime bootTime = ManagementDateTimeConverter.ToDateTime(lastBootUpTime);
                        return bootTime.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            } catch {}
            return "未知";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAppHostStatus));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelHostNameLabel = new System.Windows.Forms.Label();
            this.labelHostName = new System.Windows.Forms.Label();
            this.labelProcessorLabel = new System.Windows.Forms.Label();
            this.labelProcessor = new System.Windows.Forms.Label();
            this.labelMemoryLabel = new System.Windows.Forms.Label();
            this.labelMemory = new System.Windows.Forms.Label();
            this.labelOSNameLabel = new System.Windows.Forms.Label();
            this.labelOSName = new System.Windows.Forms.Label();
            this.labelOSVersionLabel = new System.Windows.Forms.Label();
            this.labelOSVersion = new System.Windows.Forms.Label();
            this.labelSystemModelLabel = new System.Windows.Forms.Label();
            this.labelSystemModel = new System.Windows.Forms.Label();
            this.labelSystemLocaleLabel = new System.Windows.Forms.Label();
            this.labelSystemLocale = new System.Windows.Forms.Label();
            this.labelRDPStatusLabel = new System.Windows.Forms.Label();
            this.labelRDPStatus = new System.Windows.Forms.Label();
            this.labelRDPPortLabel = new System.Windows.Forms.Label();
            this.labelRDPPort = new System.Windows.Forms.Label();
            this.labelSystemStartTimeLabel = new System.Windows.Forms.Label();
            this.labelSystemStartTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(219, 64);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "主机状态";
            // 
            // labelHostNameLabel
            // 
            this.labelHostNameLabel.AutoSize = true;
            this.labelHostNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHostNameLabel.Location = new System.Drawing.Point(30, 50);
            this.labelHostNameLabel.Name = "labelHostNameLabel";
            this.labelHostNameLabel.Size = new System.Drawing.Size(167, 39);
            this.labelHostNameLabel.TabIndex = 1;
            this.labelHostNameLabel.Text = "主机名称：";
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHostName.Location = new System.Drawing.Point(130, 50);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(77, 39);
            this.labelHostName.TabIndex = 2;
            this.labelHostName.Text = "未知";
            // 
            // labelProcessorLabel
            // 
            this.labelProcessorLabel.AutoSize = true;
            this.labelProcessorLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProcessorLabel.Location = new System.Drawing.Point(30, 75);
            this.labelProcessorLabel.Name = "labelProcessorLabel";
            this.labelProcessorLabel.Size = new System.Drawing.Size(137, 39);
            this.labelProcessorLabel.TabIndex = 3;
            this.labelProcessorLabel.Text = "处理器：";
            // 
            // labelProcessor
            // 
            this.labelProcessor.AutoSize = true;
            this.labelProcessor.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProcessor.Location = new System.Drawing.Point(130, 75);
            this.labelProcessor.Name = "labelProcessor";
            this.labelProcessor.Size = new System.Drawing.Size(77, 39);
            this.labelProcessor.TabIndex = 4;
            this.labelProcessor.Text = "未知";
            // 
            // labelMemoryLabel
            // 
            this.labelMemoryLabel.AutoSize = true;
            this.labelMemoryLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemoryLabel.Location = new System.Drawing.Point(30, 100);
            this.labelMemoryLabel.Name = "labelMemoryLabel";
            this.labelMemoryLabel.Size = new System.Drawing.Size(116, 39);
            this.labelMemoryLabel.TabIndex = 5;
            this.labelMemoryLabel.Text = "内 存：";
            // 
            // labelMemory
            // 
            this.labelMemory.AutoSize = true;
            this.labelMemory.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMemory.Location = new System.Drawing.Point(130, 100);
            this.labelMemory.Name = "labelMemory";
            this.labelMemory.Size = new System.Drawing.Size(77, 39);
            this.labelMemory.TabIndex = 6;
            this.labelMemory.Text = "未知";
            // 
            // labelOSNameLabel
            // 
            this.labelOSNameLabel.AutoSize = true;
            this.labelOSNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOSNameLabel.Location = new System.Drawing.Point(30, 125);
            this.labelOSNameLabel.Name = "labelOSNameLabel";
            this.labelOSNameLabel.Size = new System.Drawing.Size(157, 39);
            this.labelOSNameLabel.TabIndex = 7;
            this.labelOSNameLabel.Text = "OS 名称：";
            // 
            // labelOSName
            // 
            this.labelOSName.AutoSize = true;
            this.labelOSName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOSName.Location = new System.Drawing.Point(130, 125);
            this.labelOSName.Name = "labelOSName";
            this.labelOSName.Size = new System.Drawing.Size(77, 39);
            this.labelOSName.TabIndex = 8;
            this.labelOSName.Text = "未知";
            // 
            // labelOSVersionLabel
            // 
            this.labelOSVersionLabel.AutoSize = true;
            this.labelOSVersionLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOSVersionLabel.Location = new System.Drawing.Point(30, 150);
            this.labelOSVersionLabel.Name = "labelOSVersionLabel";
            this.labelOSVersionLabel.Size = new System.Drawing.Size(157, 39);
            this.labelOSVersionLabel.TabIndex = 9;
            this.labelOSVersionLabel.Text = "OS 版本：";
            // 
            // labelOSVersion
            // 
            this.labelOSVersion.AutoSize = true;
            this.labelOSVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOSVersion.Location = new System.Drawing.Point(130, 150);
            this.labelOSVersion.Name = "labelOSVersion";
            this.labelOSVersion.Size = new System.Drawing.Size(77, 39);
            this.labelOSVersion.TabIndex = 10;
            this.labelOSVersion.Text = "未知";
            // 
            // labelSystemModelLabel
            // 
            this.labelSystemModelLabel.AutoSize = true;
            this.labelSystemModelLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemModelLabel.Location = new System.Drawing.Point(30, 175);
            this.labelSystemModelLabel.Name = "labelSystemModelLabel";
            this.labelSystemModelLabel.Size = new System.Drawing.Size(167, 39);
            this.labelSystemModelLabel.TabIndex = 11;
            this.labelSystemModelLabel.Text = "系统型号：";
            // 
            // labelSystemModel
            // 
            this.labelSystemModel.AutoSize = true;
            this.labelSystemModel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemModel.Location = new System.Drawing.Point(130, 175);
            this.labelSystemModel.Name = "labelSystemModel";
            this.labelSystemModel.Size = new System.Drawing.Size(77, 39);
            this.labelSystemModel.TabIndex = 12;
            this.labelSystemModel.Text = "未知";
            // 
            // labelSystemLocaleLabel
            // 
            this.labelSystemLocaleLabel.AutoSize = true;
            this.labelSystemLocaleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemLocaleLabel.Location = new System.Drawing.Point(30, 200);
            this.labelSystemLocaleLabel.Name = "labelSystemLocaleLabel";
            this.labelSystemLocaleLabel.Size = new System.Drawing.Size(227, 39);
            this.labelSystemLocaleLabel.TabIndex = 13;
            this.labelSystemLocaleLabel.Text = "系统区域设置：";
            // 
            // labelSystemLocale
            // 
            this.labelSystemLocale.AutoSize = true;
            this.labelSystemLocale.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemLocale.Location = new System.Drawing.Point(130, 200);
            this.labelSystemLocale.Name = "labelSystemLocale";
            this.labelSystemLocale.Size = new System.Drawing.Size(77, 39);
            this.labelSystemLocale.TabIndex = 14;
            this.labelSystemLocale.Text = "未知";
            // 
            // labelRDPStatusLabel
            // 
            this.labelRDPStatusLabel.AutoSize = true;
            this.labelRDPStatusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRDPStatusLabel.Location = new System.Drawing.Point(30, 225);
            this.labelRDPStatusLabel.Name = "labelRDPStatusLabel";
            this.labelRDPStatusLabel.Size = new System.Drawing.Size(287, 39);
            this.labelRDPStatusLabel.TabIndex = 15;
            this.labelRDPStatusLabel.Text = "远程桌面服务状态：";
            // 
            // labelRDPStatus
            // 
            this.labelRDPStatus.AutoSize = true;
            this.labelRDPStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRDPStatus.Location = new System.Drawing.Point(130, 225);
            this.labelRDPStatus.Name = "labelRDPStatus";
            this.labelRDPStatus.Size = new System.Drawing.Size(77, 39);
            this.labelRDPStatus.TabIndex = 16;
            this.labelRDPStatus.Text = "未知";
            // 
            // labelRDPPortLabel
            // 
            this.labelRDPPortLabel.AutoSize = true;
            this.labelRDPPortLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRDPPortLabel.Location = new System.Drawing.Point(30, 250);
            this.labelRDPPortLabel.Name = "labelRDPPortLabel";
            this.labelRDPPortLabel.Size = new System.Drawing.Size(287, 39);
            this.labelRDPPortLabel.TabIndex = 17;
            this.labelRDPPortLabel.Text = "远程桌面服务端口：";
            // 
            // labelRDPPort
            // 
            this.labelRDPPort.AutoSize = true;
            this.labelRDPPort.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRDPPort.Location = new System.Drawing.Point(130, 250);
            this.labelRDPPort.Name = "labelRDPPort";
            this.labelRDPPort.Size = new System.Drawing.Size(77, 39);
            this.labelRDPPort.TabIndex = 18;
            this.labelRDPPort.Text = "未知";
            // 
            // labelSystemStartTimeLabel
            // 
            this.labelSystemStartTimeLabel.AutoSize = true;
            this.labelSystemStartTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemStartTimeLabel.Location = new System.Drawing.Point(30, 275);
            this.labelSystemStartTimeLabel.Name = "labelSystemStartTimeLabel";
            this.labelSystemStartTimeLabel.Size = new System.Drawing.Size(227, 39);
            this.labelSystemStartTimeLabel.TabIndex = 19;
            this.labelSystemStartTimeLabel.Text = "系统启动时间：";
            // 
            // labelSystemStartTime
            // 
            this.labelSystemStartTime.AutoSize = true;
            this.labelSystemStartTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSystemStartTime.Location = new System.Drawing.Point(130, 275);
            this.labelSystemStartTime.Name = "labelSystemStartTime";
            this.labelSystemStartTime.Size = new System.Drawing.Size(77, 39);
            this.labelSystemStartTime.TabIndex = 20;
            this.labelSystemStartTime.Text = "未知";
            // 
            // RemoteAppHostStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(432, 315);
            this.Controls.Add(this.labelSystemStartTime);
            this.Controls.Add(this.labelSystemStartTimeLabel);
            this.Controls.Add(this.labelRDPPort);
            this.Controls.Add(this.labelRDPPortLabel);
            this.Controls.Add(this.labelRDPStatus);
            this.Controls.Add(this.labelRDPStatusLabel);
            this.Controls.Add(this.labelSystemLocale);
            this.Controls.Add(this.labelSystemLocaleLabel);
            this.Controls.Add(this.labelSystemModel);
            this.Controls.Add(this.labelSystemModelLabel);
            this.Controls.Add(this.labelOSVersion);
            this.Controls.Add(this.labelOSVersionLabel);
            this.Controls.Add(this.labelOSName);
            this.Controls.Add(this.labelOSNameLabel);
            this.Controls.Add(this.labelMemory);
            this.Controls.Add(this.labelMemoryLabel);
            this.Controls.Add(this.labelProcessor);
            this.Controls.Add(this.labelProcessorLabel);
            this.Controls.Add(this.labelHostName);
            this.Controls.Add(this.labelHostNameLabel);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteAppHostStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主机状态";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelHostNameLabel;
        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.Label labelProcessorLabel;
        private System.Windows.Forms.Label labelProcessor;
        private System.Windows.Forms.Label labelMemoryLabel;
        private System.Windows.Forms.Label labelMemory;
        private System.Windows.Forms.Label labelOSNameLabel;
        private System.Windows.Forms.Label labelOSName;
        private System.Windows.Forms.Label labelOSVersionLabel;
        private System.Windows.Forms.Label labelOSVersion;
        private System.Windows.Forms.Label labelSystemModelLabel;
        private System.Windows.Forms.Label labelSystemModel;
        private System.Windows.Forms.Label labelSystemLocaleLabel;
        private System.Windows.Forms.Label labelSystemLocale;
        private System.Windows.Forms.Label labelRDPStatusLabel;
        private System.Windows.Forms.Label labelRDPStatus;
        private System.Windows.Forms.Label labelRDPPortLabel;
        private System.Windows.Forms.Label labelRDPPort;
        private System.Windows.Forms.Label labelSystemStartTimeLabel;
        private System.Windows.Forms.Label labelSystemStartTime;
    }
}