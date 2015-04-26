using EnterpriseLibConfig.UnityIntercetpion;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseLibConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //LogManagement.TestLog();
            //ExceptionManagement.TestException();
            //UnitiyIoCManagement.TestUnity();
            InterceptionManagement.TestInterception();
            Console.ReadLine();
        }

    }
}
