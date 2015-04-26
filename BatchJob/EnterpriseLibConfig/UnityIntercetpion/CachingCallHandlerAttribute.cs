using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig.UnityIntercetpion
{
    class CachingCallHandlerAttribute: HandlerAttribute
    {
        private readonly int order;
        public CachingCallHandlerAttribute(int order)
        {
            this.order = order;
        }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CachingCallHandler() { Order = order };
        }
    }
}
