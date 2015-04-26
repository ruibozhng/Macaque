using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessEntity
{
    //[DataContract]
    public class LogEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public Dictionary<string, string> EnvironmentVariable { get; set; }
    }
}
