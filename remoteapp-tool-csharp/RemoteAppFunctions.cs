using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RemoteApp_Tool
{
    public static class RemoteAppFunctions
    {
        public static void ValidateInteger(TextBox TheTextBox)
        {
            int cloc = TheTextBox.SelectionStart;
            TheTextBox.Text = Val(TheTextBox.Text).ToString();
            TheTextBox.Select(TheTextBox.Text.Length, 0);
            TheTextBox.Select(cloc, 0);
        }

        public static void ValidatePort(TextBox TheTextBox)
        {
            int cloc = TheTextBox.SelectionStart;
            if (Val(TheTextBox.Text) > 65535)
            {
                TheTextBox.Text = "65535";
                cloc = TheTextBox.Text.Length;
            }

            TheTextBox.Text = Val(TheTextBox.Text).ToString();
            TheTextBox.Select(TheTextBox.Text.Length, 0);
            TheTextBox.Select(cloc, 0);
        }

        public static void ValidateSeconds(TextBox TheTextBox)
        {
            int cloc = TheTextBox.SelectionStart;
            if (Val(TheTextBox.Text) > 2147483)
            {
                TheTextBox.Text = "2147483";
                cloc = TheTextBox.Text.Length;
            }

            TheTextBox.Text = Val(TheTextBox.Text).ToString();
            TheTextBox.Select(TheTextBox.Text.Length, 0);
            TheTextBox.Select(cloc, 0);
        }

        public static void ValidateAppName(TextBox TheTextBox)
        {
            ValidateTextBoxR(TheTextBox, @"[^\p{L}0-9\-_"" ""]");
        }

        private static void ValidateTextBoxR(TextBox TheTextBox, string regex)
        {
            int cloc = TheTextBox.SelectionStart;
            var rx = new Regex(regex);
            if (rx.IsMatch(TheTextBox.Text))
            {
                TheTextBox.Text = rx.Replace(TheTextBox.Text, "");
                TheTextBox.Select(cloc - 1, 0);
            }
            else
            {
                TheTextBox.Select(cloc, 0);
            }
        }

        public static string FixShortAppName(string TheText)
        {
            if (TheText != "")
            {
                var rx = new Regex(@"[^\p{L}0-9\-_"" ""]");
                if (rx.IsMatch(TheText))
                {
                    TheText = rx.Replace(TheText, "");
                }
            }
            TheText = TheText.Trim();
            return TheText;
        }

        public static void ValidateDNSname(TextBox TheTextBox)
        {
            // pattern matches any character that is NOT A-Z (allows upper and lower case alphabets)
            var rx = new Regex(@"[^\p{L}LlUu0-9\-\._:]");
            if (rx.IsMatch(TheTextBox.Text))
            {
                TheTextBox.Text = rx.Replace(TheTextBox.Text, "");
                TheTextBox.Select(TheTextBox.Text.Length, 0);
            }
        }

        public static void ValidateFileType(TextBox TheTextBox)
        {
            // pattern matches any character that is NOT A-Z (allows upper and lower case alphabets)
            var rx = new Regex(@"[^\p{L}0-9\-_\!\@\#\$\%\^\&\(\)\{\}\[\]\+\=\;\,\']");
            if (rx.IsMatch(TheTextBox.Text))
            {
                TheTextBox.Text = rx.Replace(TheTextBox.Text, "");
                TheTextBox.Select(TheTextBox.Text.Length, 0);
            }
        }

        public static Bitmap GetAppBitmap(string RemoteAppShortName)
        {
            try
            {
                string AppKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Terminal Server\\TSAppAllowList\\Applications\\" + RemoteAppShortName;
                var TheRegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(AppKey);
                var TheIcon = IconModule.ReturnIcon("", 0).ToBitmap();
                if (TheRegKey != null)
                {
                    // 修复类型转换错误
                    object iconPathObj = TheRegKey.GetValue("IconPath", "");
                    string IconPath = iconPathObj?.ToString() ?? "";
                    
                    object iconIndexObj = TheRegKey.GetValue("IconIndex", "");
                    string IconIndex = iconIndexObj?.ToString() ?? "";
                    
                    TheIcon = IconModule.ReturnIcon(IconPath, int.Parse(IconIndex)).ToBitmap();
                }
                return TheIcon;
            }
            catch
            {
                // Return a default bitmap if any error occurs
                return new Bitmap(16, 16);
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern long GetSystemDirectory(string lpBuffer, long nSize);

        public static string GetSysDir()
        {
            return Environment.SystemDirectory.ToString();
        }

        public static void DeleteFiles(List<string> FilesArray)
        {
            foreach (string dFile in FilesArray)
            {
                var LockCheck = new LockChecker.LockChecker();
                string FileLocked = string.Empty; // 明确初始化
                bool SkipFile = false;
                // 修复类型转换错误
                object fileLockedObj = LockCheck.CheckLock(dFile);
                FileLocked = fileLockedObj?.ToString() ?? string.Empty;
                
                while (!(FileLocked == "No locks"))
                {
                    // 修复类型转换错误
                    string message = "文件 " + dFile + " 当前被锁定。锁定信息：" + FileLocked + "\n" + "是否要重试？";
                    if (MessageBox.Show(message, "文件已锁定", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // 修复类型转换错误
                        object newFileLockedObj = LockCheck.CheckLock(dFile);
                        FileLocked = newFileLockedObj?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        string skipMessage = "不会删除以下文件：" + "\n" + dFile;
                        MessageBox.Show(skipMessage);
                        SkipFile = true;
                        FileLocked = "No locks";
                    }
                }
                if (!SkipFile)
                {
                    if (File.Exists(dFile)) File.Delete(dFile);
                }
            }
        }

        public static string GetEXETitle(string exePath)
        {
            string pname = System.Diagnostics.FileVersionInfo.GetVersionInfo(exePath).FileDescription;
            if (pname == "") pname = Path.GetFileNameWithoutExtension(exePath);

            return pname;
        }

        private static double Val(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return 0;

            // Try to parse as double
            if (double.TryParse(expression, out double result))
                return result;

            // If parsing fails, try to extract numeric part
            var regex = new Regex(@"-?\d+(\.\d+)?");
            var match = regex.Match(expression);
            if (match.Success)
            {
                if (double.TryParse(match.Value, out result))
                    return result;
            }

            return 0;
        }
    }
}