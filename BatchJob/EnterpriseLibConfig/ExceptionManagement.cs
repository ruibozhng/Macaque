using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibConfig
{
    public class ExceptionManagement
    {

        public static void TestException()
        {
            bool hasFormatException = false;
            bool hasNullReferenceException = false;
            bool hasFileNotFoundException = false;
            bool hasTimeoutException = false;

            //Enterprise Lib 5.0
            //ExceptionManager em = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            //Enterprise Lib 6.0
            Logger.SetLogWriter(new LogWriterFactory().Create());
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);
            ExceptionManager em = factory.CreateManager();

            //FormatException异常捕获设置为None,将不会被抛出
            try
            {
                em.Process(NotThrowException, "Policy");
            }
            catch (FormatException)
            {
                hasFormatException = true;
                Console.WriteLine("捕获到FormatExceptio异常!");
            }
            if (hasFormatException == false)
            {
                Console.WriteLine("未捕获到FormatExceptio异常!");
            }

            //NullReferenceException异常捕获设置为NotifyThrow,将会被抛出
            try
            {
                em.Process(NotifyThrowException, "Policy");
            }
            catch (NullReferenceException)
            {
                hasNullReferenceException = true;
                Console.WriteLine("捕获到NullReferenceException异常!");
            }

            if (hasNullReferenceException == false)
            {
                Console.WriteLine("未捕获到NullReferenceException异常!");
            }

            //FileNotFoundException异常捕获设置为ThrowNewException,将会被抛出
            try
            {
                em.Process(ThrowNewException, "Policy");
            }
            catch (FileNotFoundException)
            {
                hasFileNotFoundException = true;
                Console.WriteLine("捕获到FileNotFoundException异常!");
            }
            catch (TimeoutException)
            {
                hasTimeoutException = true;
                Console.WriteLine("捕获到TimeoutException异常!");
            }

            if (hasFileNotFoundException == false)
            {
                Console.WriteLine("未捕获到FileNotFoundException异常!");
            }
            if (hasTimeoutException == false)
            {
                Console.WriteLine("未捕获到TimeoutException异常!");
            }
            Console.ReadLine();
        }

        private static void NotThrowException()
        {
            throw new FormatException();
        }

        private static void NotifyThrowException()
        {
            throw new NullReferenceException();
        }

        private static void ThrowNewException()
        {
            throw new FileNotFoundException();
        }
    }
}
