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
        /// 关键字
        /// </summary>
        [DataMember]
        public string Keywords { get; set; }
        /// <summary>
        /// 该短信当前状态
        /// </summary>
        [DataMember]
        public SMSStatus? Status { get; set; }
        /// <summary>
        /// 插入时间起
        /// </summary>
        [DataMember]
        public DateTime? BeginInDate { get; set; }
        /// <summary>
        /// 插入时间止
        /// </summary>
        [DataMember]
        public DateTime? EndInDate { get; set; }
        /// <summary>
        /// 当前显示第几页数据
        /// </summary>
        [DataMember]
        public long PageIndex { get; set; }
        /// <summary>
        /// 每页显示几条数据
        /// </summary>
        [DataMember]
        public long PageSize { get; set; }
    }
}
