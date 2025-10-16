using System;
using System.Windows.Forms;

namespace RemoteApp_Tool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                // 使用实际的主窗体
                Application.Run(new RemoteAppMainWindow());
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序启动错误:\n" + ex.Message + "\n\n堆栈追踪:\n" + ex.StackTrace, 
                              "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}