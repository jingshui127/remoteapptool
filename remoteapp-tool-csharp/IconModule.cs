using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace RemoteApp_Tool
{
    public class IconExtractor
    {
        [DllImport("shell32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, ref int phiconLarge, ref int phiconSmall, int nIcons);

        [DllImport("shell32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("user32.dll")]
        private static extern int DrawIconEx(int hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyWidth, int istepIfAniCur, int hbrFlickerFreeDraw, int diFlags);

        [DllImport("user32.dll")]
        private static extern int DestroyIcon(int hIcon);

        private int[] m_hIcons = new int[0];

        ~IconExtractor()
        {
            int countIcons = m_hIcons.Length;

            if (countIcons > 0)
            {
                for (int iconIndex = 0; iconIndex < countIcons; iconIndex++)
                {
                    DestroyIcon(m_hIcons[iconIndex]);
                }
            }
        }

        public List<Icon> ExtractIcons(string filePath, IntPtr hInst)
        {
            var listIcons = new List<Icon>();

            try
            {
                int phiconLarge = 0;
                int phiconSmall = 0;
                int numIcons = ExtractIconEx(filePath, -1, ref phiconLarge, ref phiconSmall, 0);

                if (numIcons == 0)
                {
                    throw new Exception("No icons found in " + filePath);
                }

                numIcons -= 1;

                for (int currentIcon = 0; currentIcon < numIcons; currentIcon++)
                {
                    phiconLarge = 0;
                    phiconSmall = 0;
                    m_hIcons[currentIcon] = ExtractIcon(IntPtr.Zero, filePath, currentIcon);

                    IntPtr handleIcon = new IntPtr(m_hIcons[currentIcon]);

                    if (!handleIcon.Equals(IntPtr.Zero))
                    {
                        listIcons.Add(Icon.FromHandle(handleIcon));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return listIcons;
        }
    }

    public static class IconModule
    {

        public static bool ExtractToIco(string IconSourcePath, int IconSourceIndex, string IcoDestPath)
        {
            try
            {
                if (!File.Exists(IconSourcePath))
                    return false;

                // 如果源文件本身就是 .ico 文件，直接复制
                if (IconSourcePath.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                {
                    File.Copy(IconSourcePath, IcoDestPath, true);
                    return true;
                }

                // 使用 Windows API 从 .exe/.dll 提取图标
                IntPtr bigIcon = IntPtr.Zero;
                IntPtr smallIcon = IntPtr.Zero;

                try
                {
                    // ExtractIconEx 返回找到的图标数量
                    int iconCount = ExtractIconEx(IconSourcePath, IconSourceIndex, out bigIcon, out smallIcon, 1);

                    // 如果指定索引没有图标，尝试提取第一个图标
                    if (bigIcon == IntPtr.Zero && IconSourceIndex != 0)
                    {
                        ExtractIconEx(IconSourcePath, 0, out bigIcon, out smallIcon, 1);
                    }

                    if (bigIcon != IntPtr.Zero)
                    {
                        // 从句柄创建图标并保存
                        using (Icon icon = Icon.FromHandle(bigIcon))
                        {
                            using (var fs = new FileStream(IcoDestPath, FileMode.Create, FileAccess.Write))
                            {
                                icon.Save(fs);
                            }
                        }
                        return true;
                    }

                    // 如果提取失败，尝试使用 Icon.ExtractAssociatedIcon
                    var extractedIcon = Icon.ExtractAssociatedIcon(IconSourcePath);
                    if (extractedIcon != null)
                    {
                        using (var fs = new FileStream(IcoDestPath, FileMode.Create, FileAccess.Write))
                        {
                            extractedIcon.Save(fs);
                        }
                        return true;
                    }

                    return false;
                }
                finally
                {
                    // 释放图标句柄资源
                    if (bigIcon != IntPtr.Zero)
                        DestroyIcon(bigIcon);
                    if (smallIcon != IntPtr.Zero)
                        DestroyIcon(smallIcon);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ExtractToIco error: {ex.Message}");
                return false;
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, int nIcons);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public static Icon ReturnIcon(string Path, int Index, bool small = false)
        {
            try
            {
                IntPtr bigIcon = IntPtr.Zero;
                IntPtr smallIcon = IntPtr.Zero;

                try
                {
                    // 使用 ExtractIconEx 提取图标
                    ExtractIconEx(Path, Index, out bigIcon, out smallIcon, 1);

                    // 如果指定索引没有图标，尝试第一个图标
                    if (bigIcon == IntPtr.Zero && Index != 0)
                    {
                        ExtractIconEx(Path, 0, out bigIcon, out smallIcon, 1);
                    }

                    if (bigIcon != IntPtr.Zero || smallIcon != IntPtr.Zero)
                    {
                        IntPtr iconHandle = small ? smallIcon : bigIcon;
                        if (iconHandle != IntPtr.Zero)
                        {
                            Icon icon = Icon.FromHandle(iconHandle);
                            // 克隆图标以便可以释放原始句柄
                            Icon clonedIcon = (Icon)icon.Clone();

                            // 释放原始句柄
                            if (bigIcon != IntPtr.Zero)
                                DestroyIcon(bigIcon);
                            if (smallIcon != IntPtr.Zero)
                                DestroyIcon(smallIcon);

                            return clonedIcon;
                        }
                    }
                }
                catch
                {
                    // 如果 ExtractIconEx 失败，释放句柄
                    if (bigIcon != IntPtr.Zero)
                        DestroyIcon(bigIcon);
                    if (smallIcon != IntPtr.Zero)
                        DestroyIcon(smallIcon);
                }

                // 如果失败，返回默认系统图标
                return ReturnIcon(RemoteAppFunctions.GetSysDir() + "\\user32.dll", 0);
            }
            catch
            {
                // 最后的备用方案：返回系统默认图标
                return SystemIcons.Application;
            }
        }
    }
}