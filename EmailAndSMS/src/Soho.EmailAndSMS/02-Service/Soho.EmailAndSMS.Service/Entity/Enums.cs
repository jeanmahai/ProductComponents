using System.ComponentModel;
using System.Runtime.Serialization;

namespace Soho.EmailAndSMS.Service.Entity
{
    /// <summary>
    /// 电子邮件状态
    /// </summary>
    [DataContract]
    public enum EmailStatus
    {
        /// <summary>
        /// 已作废
        /// </summary>
        [EnumMember]
        [Description("已作废")]
        Voided = -100,
        /// <summary>
        /// 初始态
        /// </summary>
        [EnumMember]
        [Description("初始态")]
        Initial = 0,
        /// <summary>
        /// 审核拒绝
        /// </summary>
        [EnumMember]
        [Description("审核拒绝")]
        AuditRejected = 100,
        /// <summary>
        /// 审核通过
        /// </summary>
        [EnumMember]
        [Description("审核通过")]
        AuditPassed = 200,
        /// <summary>
        /// 延迟发送
        /// </summary>
        [EnumMember]
        [Description("延迟发送")]
        DelaySend = 300,
        /// <summary>
        /// 发送中
        /// </summary>
        [EnumMember]
        [Description("发送中")]
        Sending = 301,
        /// <summary>
        /// 发送成功
        /// </summary>
        [EnumMember]
        [Description("发送成功")]
        SendSuccess = 400,
        /// <summary>
        /// 发送失败
        /// </summary>
        [EnumMember]
        [Description("发送失败")]
        SendFailure = 500
    }

    /// <summary>
    /// 短信状态
    /// </summary>
    [DataContract]
    public enum SMSStatus
    {
        /// <summary>
        /// 已作废
        /// </summary>
        [EnumMember]
        [Description("已作废")]
        Voided = -100,
        /// <summary>
        /// 初始态
        /// </summary>
        [EnumMember]
        [Description("初始态")]
        Initial = 0,
        /// <summary>
        /// 审核拒绝
        /// </summary>
        [EnumMember]
        [Description("审核拒绝")]
        AuditRejected = 100,
        /// <summary>
        /// 审核通过
        /// </summary>
        [EnumMember]
        [Description("审核通过")]
        AuditPassed = 200,
        /// <summary>
        /// 延迟发送
        /// </summary>
        [EnumMember]
        [Description("延迟发送")]
        DelaySend = 300,
        /// <summary>
        /// 发送中
        /// </summary>
        [EnumMember]
        [Description("发送中")]
        Sending = 301,
        /// <summary>
        /// 发送成功
        /// </summary>
        [EnumMember]
        [Description("发送成功")]
        SendSuccess = 400,
        /// <summary>
        /// 发送失败
        /// </summary>
        [EnumMember]
        [Description("发送失败")]
        SendFailure = 500
    }
}
