using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessContract
{
    public interface IApplicationContext
    {
        // Methods
        void Clear();
        Hashtable GetContext();
        object GetKeyValue(string key);
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        void SetContext(Hashtable context);
        void SetKeyValue(string key, object state);

        string ClientHostName { get; set; }
        string ServerHostName { get; set; }
        string ApplicationId { get; set; }
        string PageObjectName { get; set; }
        string UserId { get; set; }
        string SessionId { get; set; }
    }
}
