using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class OptionalParameters
    {
        //Making method parameters optional by overloading
        public static int Calculate(int firstNumber, int secondNumber)
        {
            return Calculate(firstNumber, secondNumber, null);
        }

        //Making method parameters optional by parameter array
        public static int Calculate(int firstNumber, int secondNumber, params object[] restOfNumbers)
        {
            int result = firstNumber + secondNumber;
            if (restOfNumbers != null)
            {
                foreach (int i in restOfNumbers)
                {
                    result += i;
                }
            }
            return result;
        }

        //Making method parameters optional by specifying parameter defaults
        public static int Calculate(int a, int b = 20, int c =30 , int[] restOfNumbers = null)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            int result = a + b + c;
            if (restOfNumbers != null)
            {
                foreach (int i in restOfNumbers)
                {
                    result += i;
                }
            }
            return result;
        }

        //Making method parameters optional by using OptionalAttribute
        public static int Calculate(int firstNumber, [Optional] int[] restOfNumbers)
        {
            int result = firstNumber;
            if (restOfNumbers != null)
            {
                foreach (int i in restOfNumbers)
                {
                    result += i;
                }
            }
            return result;
        }
    }
}
