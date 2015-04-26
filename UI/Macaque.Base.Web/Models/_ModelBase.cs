using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Models
{
    [Serializable]
    public class _ModelBase
    {
        public bool IsDeleted { get; set; }
        public string CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }
        public byte[] TimeStamp { set; get; }
        public long VersionNumber { set; get; }

        public string CreatedByName { set; get; }
        public string UpdatedByName { set; get; }

        public _ModelBase()
        {
            IsDeleted = false;
        }
    }
}