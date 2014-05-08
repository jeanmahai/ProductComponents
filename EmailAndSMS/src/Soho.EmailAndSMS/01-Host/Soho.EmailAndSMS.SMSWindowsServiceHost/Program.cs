using System.ServiceProcess;

namespace Soho.EmailAndSMS.SMSWindowsServiceHost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            (new MainSvc()).Run();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new SMSSendSvc() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
