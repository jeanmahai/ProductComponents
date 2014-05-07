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
        #region 电子邮件发送服务私有对象

        /// <summary>
        /// 服务配置
        /// </summary>
        private Dictionary<string, string> _SerivceConfig = null;
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
        private Queue<EmailEntity> _WaitSendEmailQueue = null;

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
            //所有线程发送完毕后结束本次发送任务
            while (_FinishThreadCounts != int.Parse(_SerivceConfig["SendThreadCounts"]))
            {
                Thread.Sleep(100);
            }
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
                string sendResult = GetSender().Send(_SerivceConfig, email);
                //更新电子邮件发送结果
                EmailStatus status = sendResult.Equals("OK") ? EmailStatus.SendSuccess : EmailStatus.SendFailure;
                EmailProcessor.Instance.UpdateEmailStatus(email.SysNo.Value, status, sendResult);
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
