﻿using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig.UnityIntercetpion
{
    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class SemanticLogCallHandler : ICallHandler
    {
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "attributes")]
        public SemanticLogCallHandler(NameValueCollection attributes)
        {
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            // Before invoking the method on the original target
            WriteLog(String.Format("Invoking method {0} at {1}", input.MethodBase, DateTime.Now.ToLongTimeString()));
            // Invoke the next handler in the chain
            var result = getNext().Invoke(input, getNext);
            // After invoking the method on the original target
            if (result.Exception != null)
            {
                WriteLog(String.Format("Method {0} threw exception {1} at {2}",
                input.MethodBase, result.Exception.Message,
                DateTime.Now.ToLongTimeString()));
            }
            else
            {
                WriteLog(String.Format("Method {0} returned {1} at {2}",
                input.MethodBase, result.ReturnValue,
                DateTime.Now.ToLongTimeString()));
            }
            return result;
        }

        public int Order { get; set; }

        private void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
