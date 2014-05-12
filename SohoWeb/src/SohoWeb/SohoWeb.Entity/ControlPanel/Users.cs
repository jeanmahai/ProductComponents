using System.Runtime.Serialization;

namespace SohoWeb.Entity.ControlPanel
{
    [DataContract]
    public class Users
    {
        [DataMember]
        public int? SysNo { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string UserAuthCode { get; set; }
    }
}
