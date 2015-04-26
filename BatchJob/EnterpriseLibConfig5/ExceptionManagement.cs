using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig5
{
    class ExceptionManagement
    {
        public static void TestException()
        {
            Exception ex = new Exception();
            string policy = "Global Policy";
            ExceptionPolicy.HandleException(ex, policy);
        }
    }
}
