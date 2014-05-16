﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SohoWeb.Entity
{
    [DataContract]
    public class EntityBase
    {
        [DataMember]
        public DateTime? InDate { get; set; }
        [DataMember]
        public string InUserName { get; set; }
        [DataMember]
        public int? InUserSysNo { get; set; }
        [DataMember]
        public DateTime? EditDate { get; set; }
        [DataMember]
        public string EditUserName { get; set; }
        [DataMember]
        public int? EditUserSysNo { get; set; }
    }
}