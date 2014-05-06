using System;
using System.Runtime.Serialization;

namespace Soho.EmailAndSMS.Service.Entity
{
    /// <summary>
    /// 邮件查询条件
    /// </summary>
    [Serializable]
    [DataContract]
    public class SMSQueryFilter
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public int? UserSysNo { get; set; }
        /// <summary>
        /// 收件人名称
        /// </summary>
        [DataMember]
        public string ReceiveName { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string Keywords { get; set; }
    }
}
