using System.Threading;
using System.Collections;
using System.Collections.Generic;

using Soho.EmailAndSMS.Service;
using Soho.EmailAndSMS.Service.Processor;
using Soho.EmailAndSMS.Service.Entity;
using Soho.EmailAndSMS.Send.Email.Sender;

namespace Soho.EmailAndSMS.Send.Email
{
    /// <summary>
    /// 电子邮件发送服务
    /// </summary>
    public class EmailSendService
    {
        #region 电子邮件发送服务私有对象

        /// <summary>
        /// 服务配置
        /// </summary>
        private Dictionary<string, string> _SerivceConfig = null;
        /// <summary>
        /// 待发送的电子邮件
        /// </summary>
        private Queue<EmailEntity> _WaitSendEmailQueue = null;
        /// <summary>
        /// 推送邮件数量
        /// </summary>
        private int _SendMailCounts = 0;

        #endregion

        #region 电子邮件发送服务委托事件
        /// <summary>
        /// 发送电子邮件委托
        /// </summary>
        private delegate void SendEmailDelegateHandler();
        /// <summary>
        /// 发送电子邮件事件
        /// </summary>
        private event SendEmailDelegateHandler SendEmailEventHandler;

        #endregion

        #region 电子邮件发送服务

        /// <summary>
        /// 开始发送电子邮件
        /// </summary>
        public void StartSendMail()
        {
            SendEmailEventHandler += LoadConfig;
            SendEmailEventHandler += LoadWaitSendMailList;
            SendEmailEventHandler += ThreadSendEmail;
            SendEmailEventHandler();
            Logger.WriteBizLogs(string.Format("本次推送电子邮件数量：{0}封。", _SendMailCounts));
        }
        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            _SerivceConfig = EmailProcessor.Instance.LoadConfig();
            _WaitSendEmailQueue = new Queue<EmailEntity>(int.Parse(_SerivceConfig["LoadEmailCounts"]));
        }
        /// <summary>
        /// 加载待发送的电子邮件
        /// </summary>
        private void LoadWaitSendMailList()
        {
            var emailList = EmailProcessor.Instance.GetWaitSendMailList(int.Parse(_SerivceConfig["LoadEmailCounts"]));
            if (emailList != null)
            {
                _SendMailCounts = emailList.Count;
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
            int sendThreadCounts = int.Parse(_SerivceConfig["SendThreadCounts"]);
            for (int i = 0; i < sendThreadCounts; i++)
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
                    if (_WaitSendEmailQueue.Count == 0)
                    {
                        isSendFinish = true;
                        break;
                    }
                    email = _WaitSendEmailQueue.Dequeue();
                }
                if (email == null)
                {
                    isSendFinish = true;
                    break;
                }
                //发送
                GetSender().Send(_SerivceConfig, email);
            }
        }
        /// <summary>
        /// 获取电子邮件的发送器
        /// </summary>
        /// <returns></returns>
        private ISenderInterface GetSender()
        {
            ISenderInterface sender = null;
            switch (_SerivceConfig["SendType"])
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
