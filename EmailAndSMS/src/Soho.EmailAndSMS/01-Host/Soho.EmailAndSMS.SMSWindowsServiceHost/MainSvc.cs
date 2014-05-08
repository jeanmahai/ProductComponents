using System;
using System.Threading;

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
                (new SMSSendService()).StartSendSMS();
                Thread.Sleep(1 * 60 * 1000);
            }
        }
        private void RunCompleted(IAsyncResult ar)
        { }
        #endregion
    }
}
