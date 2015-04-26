using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    [Table(Name = "dbo.T_USER_ROLE")]
    [Serializable]
    [DataContract]
    public class UserRoleEntity : DBEntityBase
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, IsDbGenerated = true, Name = "ID")]
        [DataMember]
        public int ID { get; set; }

        [Column(Name = "USER_ID")]
        [DataMember]
        public int UserID { get; set; }

        [Column(Name = "ROLE_CODE")]
        [DataMember]
        public string RoleCode { get; set; }

        #region //Common Fields
        [Column(Name = "CREATED_BY")]
        [DataMember]
        public override string CreatedBy { get; set; }

        [Column(Name = "CREATED_DATE")]
        [DataMember]
        public override DateTime CreatedDate { get; set; }

        [Column(Name = "UPDATED_BY")]
        [DataMember]
        public override string UpdatedBy { get; set; }

        [Column(Name = "UPDATED_DATE")]
        [DataMember]
        public override DateTime UpdatedDate { get; set; }

        [Column(Name = "IS_DELETED")]
        [DataMember]
        public override bool IsDeleted { get; set; }

        [Column(Name = "VERSION_NO")]
        [DataMember]
        public override long VersionNumber { get; set; }

        [Column(Name = "TIME_STAMP", AutoSync = AutoSync.Always, DbType = "rowversion NOT NULL", CanBeNull = false, IsDbGenerated = true, IsVersion = true)]
        [DataMember]
        public override byte[] TimeStamp { get; set; }
        #endregion        
    }
}
