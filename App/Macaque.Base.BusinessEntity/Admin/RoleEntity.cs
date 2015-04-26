using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    [Table(Name = "dbo.T_ROLE")]
    [Serializable]
    [DataContract]
    public class RoleEntity
    {
        [Column(Name = "ROLE_CODE")]
        [DataMember]
        public string RoleCode { get; set; }

        [Column(Name = "ROLE_DESC")]
        [DataMember]
        public string RoleDesc { get; set; }
    }
}
