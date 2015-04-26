using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ExceptionManagement.TestException();

                CacheManagement.TestCache();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
