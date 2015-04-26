using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessContract
{
    public interface IServiceProxy : IDisposable
    {
        object Channel
        {
            get;
            set;
        }

        string EndpointName
        {
            get;
            set;
        }
    }
}
