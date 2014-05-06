using Soho.EmailAndSMS.Service.Entity;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using Soho.EmailAndSMS.Service.Processor;
using Soho.EmailAndSMS.Send.Email.Sender;

namespace Soho.EmailAndSMS.Send.Email
{
    /// <summary>
    /// 电子邮件发送服务
    /// </summary>
    public class EmailSendService
    {
        #region 电子邮件发送服务实例
        private EmailSendService _Instance = null;
        public EmailSendService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new EmailSendService();
                return _Instance;
            }
        }
        #endregion

        #region 电子邮件发送服务

        /// <summary>
        /// 发送完成线程对象
        /// </summary>
        private static readonly object _FinishThreadObject = new object();
        /// <summary>
        /// 发送完成线程数
        /// </summary>
        private int _FinishThreadCounts = 0;
        /// <summary>
        /// 待发送的电子邮件
        /// </summary>
        private Queue<EmailEntity> _WaitSendEmailQueue = new Queue<EmailEntity>(ConfigHelper.Instance.Config.Email.LoadEmailCounts);

        /// <summary>
        /// 发送电子邮件委托
        /// </summary>
        public delegate void SendEmailDelegateHandler();
        /// <summary>
        /// 发送电子邮件事件
        /// </summary>
        public event SendEmailDelegateHandler SendEmailEventHandler;

        /// <summary>
        /// 开始发送电子邮件
        /// </summary>
        /// <param name="email">电子邮件对象</param>
        public void StartSendMail(EmailEntity email)
        {
            SendEmailEventHandler += LoadWaitSendMailList;
            SendEmailEventHandler += ThreadSendEmail;
            SendEmailEventHandler();
            //所有线程发送完毕后结束本次发送任务
            while (_FinishThreadCounts != ConfigHelper.Instance.Config.Email.SendThreadCounts)
            {
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 加载待发送的电子邮件
        /// </summary>
        private void LoadWaitSendMailList()
        {
            var emailList = EmailProcessor.Instance.GetWaitSendMailList();
            if (emailList != null)
            {
                emailList.ForEach(m =>
                {
                    lock (_WaitSendEmailQueue)
                    {
                        _WaitSendEmailQueue.Enqueue(m);
                    }
                });
            }
        }
        /// <summary>
        /// 线程发送电子邮件
        /// </summary>
        private void ThreadSendEmail()
        {
            for (int i = 0; i < ConfigHelper.Instance.Config.Email.SendThreadCounts; i++)
            {
                ThreadPool.QueueUserWorkItem(SendMail);
            }
        }
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        private void SendMail(object state)
        {
            bool isSendFinish = false;
            while (!isSendFinish)
            {
                EmailEntity email = null;
                lock (_WaitSendEmailQueue)
                {
                    email = _WaitSendEmailQueue.Dequeue();
                }
                if (email == null)
                {
                    isSendFinish = true;
                    break;
                }
                //发送
                bool sendResult = GetSender().Send(email);
                //更新电子邮件发送结果
                EmailStatus status = sendResult ? EmailStatus.SendSuccess : EmailStatus.SendFailure;
                EmailProcessor.Instance.UpdateEmailStatus(email.SysNo.Value, status);
            }
            IncreaseFinishThreadCounts();
        }
        /// <summary>
        /// 递增完成线程数
        /// </summary>
        private void IncreaseFinishThreadCounts()
        {
            lock (_FinishThreadObject)
            {
                _FinishThreadCounts++;
            }
        }
        /// <summary>
        /// 获取电子邮件的发送器
        /// </summary>
        /// <returns></returns>
        private ISenderInterface GetSender()
        {
            ISenderInterface sender = null;
            switch (ConfigHelper.Instance.Config.Email.SendType)
            {
                case "PersonalMailSender":
                    sender = new PersonalMailSender();
                    break;
                default:
                    sender = new PersonalMailSender();
                    break;
            }
            return sender;
        }

        #endregion
    }
}
