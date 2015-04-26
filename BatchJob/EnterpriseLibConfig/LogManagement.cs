using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnterpriseLibConfig
{
    class LogManagement
    {
        public static void TestLog()
        {
            Logger.SetLogWriter(new LogWriterFactory().Create());
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Logger.Write("Test", "MyLog", 0, 0, System.Diagnostics.TraceEventType.Information);
                        Dictionary<string, object> dic = new Dictionary<string, object>()
                                {
                                    { "Projec", "world" }, 
                                    { "Method", "hello" }, 
                                };
                        Logger.Write("test1", "MyLog", 0, 0, System.Diagnostics.TraceEventType.Error, "", dic);
                    }
                });
                thread.Start();
            }
            Console.ReadKey();
        }
    }
}
