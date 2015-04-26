using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity.Common
{
    [Table(Name = "dbo.T_PARAMETER")]
    [Serializable]
    [DataContract]
    public class ParameterEntity
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, IsDbGenerated = true, Name = "ID")]
        [DataMember]
        public long ID { get; set; }

        [Column(Name = "CODE")]
        [DataMember]
        public string Code { get; set; }

        [Column(Name = "CODE_DESC")]
        [DataMember]
        public string CodeDesc { get; set; }

        [Column(Name = "CODE_VALUE")]
        [DataMember]
        public string CodeValue { get; set; }
    }
}
