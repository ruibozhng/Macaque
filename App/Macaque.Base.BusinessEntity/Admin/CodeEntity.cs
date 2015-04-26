using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    [Table(Name = "dbo.T_CODE")]
    [Serializable]
    [DataContract]
    public class CodeEntity
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, IsDbGenerated = true, Name = "ID")]
        [DataMember]
        public int ID { get; set; }

        [Column(Name = "CATEGORY")]
        [DataMember]
        public string Category { get; set; }

        [Column(Name = "CODE")]
        [DataMember]
        public string Code { get; set; }

        [Column(Name = "CODE_DESC")]
        [DataMember]
        public string CodeDesc { get; set; }
    }
}
