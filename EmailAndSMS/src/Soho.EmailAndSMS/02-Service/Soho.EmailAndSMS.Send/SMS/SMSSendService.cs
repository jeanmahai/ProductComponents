using System.Threading;
using System.Collections;
using System.Collections.Generic;

using Soho.EmailAndSMS.Service;
using Soho.EmailAndSMS.Service.Processor;
using Soho.EmailAndSMS.Service.Entity;
using Soho.EmailAndSMS.Send.SMS.Sender;

namespace Soho.EmailAndSMS.Send.SMS
{
    /// <summary>
    /// 短信发送服务
    /// </summary>
    public class SMSSendService
    {
        #region 短信发送服务私有对象

        /// <summary>
        /// 服务配置
        /// </summary>
        private Dictionary<string, string> _SerivceConfig = null;
        /// <summary>
        /// 待发送的短信
        /// </summary>
        private Queue<SMSEntity> _WaitSendSMSlQueue = null;
        /// <summary>
        /// 推送短信数量
        /// </summary>
        private int _SendSMSCounts = 0;

        #endregion

        #region 短信发送服务委托事件
        /// <summary>
        /// 发送短信委托
        /// </summary>
        private delegate void SendSMSDelegateHandler();
        /// <summary>
        /// 发送短信事件
        /// </summary>
        private event SendSMSDelegateHandler SendSMSEventHandler;

        #endregion

        #region 短信发送服务

        /// <summary>
        /// 开始发送短信
        /// </summary>
        public void StartSendSMS()
        {
            SendSMSEventHandler += LoadConfig;
            SendSMSEventHandler += LoadWaitSendSMSList;
            SendSMSEventHandler += ThreadSendSMS;
            SendSMSEventHandler();
            Logger.WriteBizLogs(string.Format("本次推送短信数量：{0}封。", _SendSMSCounts));
        }
        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            _SerivceConfig = SMSProcessor.Instance.LoadConfig();
            _WaitSendSMSlQueue = new Queue<SMSEntity>(int.Parse(_SerivceConfig["LoadSMSCounts"]));
        }
        /// <summary>
        /// 加载待发送的短信
        /// </summary>
        private void LoadWaitSendSMSList()
        {
            var emailList = SMSProcessor.Instance.GetWaitSendSMSList(int.Parse(_SerivceConfig["LoadSMSCounts"]));
            if (emailList != null)
            {
                _SendSMSCounts = emailList.Count;
                emailList.ForEach(m =>
                {
                    lock (_WaitSendSMSlQueue)
                    {
                        _WaitSendSMSlQueue.Enqueue(m);
                    }
                });
            }
        }
        /// <summary>
        /// 线程发送短信
        /// </summary>
        private void ThreadSendSMS()
        {
            int sendThreadCounts = int.Parse(_SerivceConfig["SendThreadCounts"]);
            for (int i = 0; i < sendThreadCounts; i++)
            {
                ThreadPool.QueueUserWorkItem(SendSMS);
            }
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        private void SendSMS(object state)
        {
            bool isSendFinish = false;
            while (!isSendFinish)
            {
                SMSEntity sms = null;
                lock (_WaitSendSMSlQueue)
                {
                    if (_WaitSendSMSlQueue.Count == 0)
                    {
                        isSendFinish = true;
                        break;
                    }
                    sms = _WaitSendSMSlQueue.Dequeue();
                }
                if (sms == null)
                {
                    isSendFinish = true;
                    break;
                }
                //发送
                GetSender().Send(_SerivceConfig, sms);
            }
        }
        /// <summary>
        /// 获取短信的发送器
        /// </summary>
        /// <returns></returns>
        private ISenderInterface GetSender()
        {
            ISenderInterface sender = null;
            switch (_SerivceConfig["SendType"])
            {
                case "EmaySMSSender":
                    sender = new EmaySMSSender();
                    break;
                default:
                    sender = new EmaySMSSender();
                    break;
            }
            return sender;
        }

        #endregion
    }
}
