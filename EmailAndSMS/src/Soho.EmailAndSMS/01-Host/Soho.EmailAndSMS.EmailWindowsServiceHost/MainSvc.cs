using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Send.Email;
using System.Threading;

namespace Soho.EmailAndSMS.EmailWindowsServiceHost
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
                (new EmailSendService()).StartSendMail();
                Thread.Sleep(1 * 60 * 1000);
            }
        }
        private void RunCompleted(IAsyncResult ar)
        { }
        #endregion
    }
}
