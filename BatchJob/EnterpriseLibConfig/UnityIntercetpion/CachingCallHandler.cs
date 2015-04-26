using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig.UnityIntercetpion
{
    public class CachingCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //Before invoking the method on the original target
            if (input.MethodBase.Name == "GetTenant")
            {
                var tenantName = input.Arguments["tenant"].ToString();
                if (IsInCache(tenantName))
                {
                    return input.CreateMethodReturn(FetchFromCache(tenantName));
                }
            }
            IMethodReturn result = getNext()(input, getNext);
            //After invoking the method on the original target
            if (input.MethodBase.Name == "SaveTenant")
            {
                AddToCache(input.Arguments["tenant"]);
            }
            return result;
        }
        public int Order
        {
            get;
            set;
        }
        private bool IsInCache(string key)
        {
            Console.WriteLine("CachingCallHandler IsInCache");
            return true;
        }
        private object FetchFromCache(string key)
        {
            Console.WriteLine("CachingCallHandler FetchFromCache");
            return new object();
        }
        private void AddToCache(object item)
        {
            Console.WriteLine("CachingCallHandler AddToCache");
        }
    }
}
