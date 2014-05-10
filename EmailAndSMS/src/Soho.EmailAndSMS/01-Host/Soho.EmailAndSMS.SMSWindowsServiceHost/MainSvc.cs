using System;
using System.Threading;
using System.Configuration;

using Soho.EmailAndSMS.Send.SMS;

namespace Soho.EmailAndSMS.SMSWindowsServiceHost
{
    public class MainSvc
    {
        /// <summary>
        /// 启动线程
        /// </summary>
        public void Run()
        {
            SyncRunDelegate _SyncRun = new SyncRunDelegate(SyncRun);
            IAsyncResult ar = _SyncRun.BeginInvoke(new AsyncCallback(RunCompleted), _SyncRun);
        }

        #region 异步运行
        public delegate void SyncRunDelegate();
        public void SyncRun()
        {
            while (true)
            {
                int interval = int.Parse(ConfigurationManager.AppSettings["SMSSvcIntervalSeconds"].ToString());
                (new SMSSendService()).StartSendSMS();
                Thread.Sleep(interval * 60 * 1000);
            }
        }
        private void RunCompleted(IAsyncResult ar)
        { }
        #endregion
    }
}
