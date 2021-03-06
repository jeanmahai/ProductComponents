﻿using System;
using System.Runtime.Serialization;

namespace Soho.EmailAndSMS.Service.Entity
{
    /// <summary>
    /// 短信对象
    /// </summary>
    [Serializable]
    [DataContract]
    public class SMSEntity
    {
        /// <summary>
        /// 短信编号
        /// </summary>
        [DataMember]
        public long? SysNo { get; set; }
        /// <summary>
        /// 业务系统的用户编号，可不指定
        /// </summary>
        [DataMember]
        public int? UserSysNo { get; set; }
        /// <summary>
        /// 接收人名称
        /// </summary>
        [DataMember]
        public string ReceiveName { get; set; }
        /// <summary>
        /// 接收手机号
        /// </summary>
        [DataMember]
        public string ReceivePhoneNumber { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        [DataMember]
        public string SMSBody { get; set; }
        /// <summary>
        /// 该短信当前状态
        /// </summary>
        [DataMember]
        public SMSStatus Status { get; set; }
        [DataMember]
        public string StatusText
        {
            get
            {
                string result = "";
                switch (this.Status)
                {
                    case SMSStatus.Voided:
                        result = "已作废";
                        break;
                    case SMSStatus.Initial:
                        result = "初始态";
                        break;
                    case SMSStatus.AuditRejected:
                        result = "审核拒绝";
                        break;
                    case SMSStatus.AuditPassed:
                        result = "审核通过";
                        break;
                    case SMSStatus.DelaySend:
                        result = "延迟发送";
                        break;
                    case SMSStatus.Sending:
                        result = "发送中";
                        break;
                    case SMSStatus.SendSuccess:
                        result = "发送成功";
                        break;
                    case SMSStatus.SendFailure:
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
