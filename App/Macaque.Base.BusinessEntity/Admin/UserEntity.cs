using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Base.BusinessEntity
{
    [Table(Name = "dbo.T_USER")]
    [Serializable]
    [DataContract]
    public class UserEntity : DBEntityBase
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, IsDbGenerated = true, Name = "ID")]
        [DataMember]
        public int ID { get; set; }

        [Column(Name = "USER_ID")]
        [DataMember]
        public string UserID { get; set; }

        [Column(Name = "USER_NAME")]
        [DataMember]
        public string UserName { get; set; }

        [Column(Name = "USER_PWD")]
        [DataMember]
        public string Password { get; set; }

        [Column(Name = "GENDER")]
        [DataMember]
        public string Gender { get; set; }

        [Column(Name = "MOBILE_NUMBER")]
        [DataMember]
        public string Mobile { get; set; }

        [Column(Name = "EMAIL_ADDRESS")]
        [DataMember]
        public string Email { get; set; }

        [Column(Name = "GRADE")]
        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public List<string> UserAllRoles
        {
            get;
            set;
        }

        [DataMember]
        public List<string> UserAllFunctions
        {
            get;
            set;
        }

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
