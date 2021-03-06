﻿using System;
using System.Net.Mail;
using System.Runtime.Serialization;

namespace Soho.EmailAndSMS.Service.Entity
{
    /// <summary>
    /// 电子邮件对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class EmailEntity
    {
        /// <summary>
        /// 邮件编号
        /// </summary>
        [DataMember]
        public long? SysNo { get; set; }
        /// <summary>
        /// 业务系统的用户编号，可不指定
        /// </summary>
        [DataMember]
        public int? UserSysNo { get; set; }
        /// <summary>
        /// 收件人名称
        /// </summary>
        [DataMember]
        public string ReceiveName { get; set; }
        /// <summary>
        /// 收件人地址，以;分隔
        /// </summary>
        [DataMember]
        public string ReceiveAddress { get; set; }
        /// <summary>
        /// 抄送地址，以;分隔
        /// </summary>
        [DataMember]
        public string CCAddress { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        [DataMember]
        public string EmailTitle { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        [DataMember]
        public string EmailBody { get; set; }
        /// <summary>
        /// 邮件内容是否是HTML格式
        /// </summary>
        [DataMember]
        public bool IsBodyHtml { get; set; }
        /// <summary>
        /// 邮件的发送级别
        /// </summary>
        [DataMember]
        public MailPriority EmailPriority { get; set; }
        /// <summary>
        /// 该封邮件当前状态
        /// </summary>
        [DataMember]
        public EmailStatus Status { get; set; }
        [DataMember]
        public string StatusText
        {
            get
            {
                string result = "";
                switch (this.Status)
                {
                    case EmailStatus.Voided:
                        result = "已作废";
                        break;
                    case EmailStatus.Initial:
                        result = "初始态";
                        break;
                    case EmailStatus.AuditRejected:
                        result = "审核拒绝";
                        break;
                    case EmailStatus.AuditPassed:
                        result = "审核通过";
                        break;
                    case EmailStatus.DelaySend:
                        result = "延迟发送";
                        break;
                    case EmailStatus.Sending:
                        result = "发送中";
                        break;
                    case EmailStatus.SendSuccess:
                        result = "发送成功";
                        break;
                    case EmailStatus.SendFailure:
                        result = "发送失败";
                        break;
                }
                return result;
            }
        }
        /// <summary>
        /// 发送时间，为null则不指定发送时间，审核通过即可发送
        /// </summary>
        [DataMember]
        public string SendTime { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        [DataMember]
        public string InDate { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        public string LastUpdateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Note { get; set; }
    }
}
