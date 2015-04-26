using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    [Table(Name = "dbo.T_FUNCTION")]
    [Serializable]
    [DataContract]
    public class FunctionEntity
    {
        [Column(Name = "FUNCTION_CODE")]
        [DataMember]
        public string FunctionName { get; set; }

        [Column(Name = "FUNCTION_DESC")]
        [DataMember]
        public string FunctionDesc { get; set; }
    }
}
