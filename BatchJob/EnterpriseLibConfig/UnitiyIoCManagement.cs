using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace EnterpriseLibConfig
{
    public interface ILog
    {
        void Write(string message);
    }

    public class ConsoleLog: ILog
    { 
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class UnitiyIoCManagement
    {
        public static void TestUnity()
        {
            Console.WriteLine("测试一:");
            test1();

            Console.WriteLine("测试二:");
            test2();
            Console.ReadLine();
        }
        private static void test1()
        {
            //1.创建服务
            ILog logServer = new ConsoleLog();

            //2.使用服务
            logServer.Write("日志正文 - Normal");
        }

        private static void test2()
        {
            //1.注册了一个容器；
            IUnityContainer container = new UnityContainer();

            //2.向容器中注册ILog服务,并告诉容器用ConsoleLog实现这个服务
            container.RegisterType<ILog, ConsoleLog>();

            //3.向容器中注册ILogFormatter,并告知容器用TextFormatter实现它
            // 容器发现类的构造函数还需要另外一个参数Target,这里用InjectionProperty注入该参数
            //container
            //.RegisterType<ILogFormatter, TextFormatter>(new InjectionProperty("Target", "/"))
            //.RegisterInstance<string>(@"C:\test.log");

            //4.获取服务
            ILog log = container.Resolve<ILog>();

            //5.使用服务,到此为止我们都没有使用new关键字创建一个具体类的实例,
            // 完全屏蔽了组件和服务的实例化,而由Unity自动装配,使得程序更加的灵活.
            log.Write("日志正文 - Unitiy");
        }
    }
}
