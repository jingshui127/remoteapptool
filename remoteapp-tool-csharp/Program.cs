using NewLife;
using NewLife.Log;
using NewLife.Model;
using NewLife.Remoting.Clients;
using Stardust;
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
            MachineInfo.RegisterAsync();

            StartClient();

            var set = ClientSetting.Current;

            // 启用语音提示
            StringHelper.EnableSpeechTip = set.SpeechTip;

            if (set.IsNew)
            {
                "新朋友您好！欢迎使用科控物联RDP远程服务！".SpeechTip();
            }
            else
            {
                "欢迎您再次使用科控物联远程桌面服务！".SpeechTip();
            }
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

        private static StarFactory _factory;
        private static StarClient _Client;

        private static void StartClient()
        {
            var set = ClientSetting.Current;
            var server = set.Server;
            if (NewLife.StringHelper.IsNullOrEmpty(server)) return;

            XTrace.WriteLine("初始化服务端地址：{0}", server);

            _factory = new StarFactory(server, null, null)
            {
                Log = XTrace.Log,
            };

            var client = new StarClient(server)
            {
                Code = set.Code,
                Secret = set.Secret,
                ProductCode = _factory.AppId,
                Setting = set,

                Tracer = _factory.Tracer,
                Log = XTrace.Log,
            };

            client.Open();

            Host.RegisterExit(() => client.Logout("ApplicationExit"));

            _Client = client;
        }
    }
}