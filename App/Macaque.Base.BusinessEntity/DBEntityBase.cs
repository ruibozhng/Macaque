using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    [Serializable]
    [DataContract]
    public abstract class DBEntityBase
    {
        [Column(Name = "CREATED_BY")]
        [DataMember]
        public virtual string CreatedBy { get; set; }

        [Column(Name = "CREATED_DATE")]
        [DataMember]
        public virtual DateTime CreatedDate { get; set; }

        [Column(Name = "UPDATED_BY")]
        [DataMember]
        public virtual string UpdatedBy { get; set; }

        [Column(Name = "UPDATED_DATE")]
        [DataMember]
        public virtual DateTime UpdatedDate { get; set; }

        [Column(Name = "IS_DELETED")]
        [DataMember]
        public virtual bool IsDeleted { get; set; }

        [Column(Name = "VERSION_NO")]
        [DataMember]
        public virtual long VersionNumber { get; set; }

        [Column(Name = "TIME_STAMP", AutoSync = AutoSync.Always, DbType = "rowversion NOT NULL", CanBeNull = false, IsDbGenerated = true, IsVersion = true)]
        [DataMember]
        public virtual byte[] TimeStamp { get; set; }
    }
}
