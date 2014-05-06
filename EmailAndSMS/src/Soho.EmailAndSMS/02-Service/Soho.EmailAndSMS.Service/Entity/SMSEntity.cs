using System;
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
        [DataMember]
        public int? SysNo { get; set; }
    }
}
