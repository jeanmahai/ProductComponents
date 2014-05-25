using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SohoWeb.Entity.Enums
{
    [Serializable]
    [DataContract]
    public enum CommonStatus
    {
        [EnumMember]
        InValid = -100,
        [EnumMember]
        Init = 0,
        [EnumMember]
        Valid = 100
    }
}
