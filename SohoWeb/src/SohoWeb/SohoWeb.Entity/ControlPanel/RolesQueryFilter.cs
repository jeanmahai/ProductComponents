﻿using System.Runtime.Serialization;

namespace SohoWeb.Entity.ControlPanel
{
    [DataContract]
    public class RolesQueryFilter : FilterBase
    {
        [DataMember]
        public int? SysNo { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public int? Status { get; set; }
    }
}
