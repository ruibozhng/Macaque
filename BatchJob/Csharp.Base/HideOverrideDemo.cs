using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class HideOverrideDemo
    {
    }

    public class BaseClass
    {
        public virtual void Print()
        {
            Console.WriteLine("I am a Base Class Print");
        }

        public virtual void HidePrint()
        {
            Console.WriteLine("I am a Base Class Hide Print");
        }

        public static void Hello(string strMessage)
        {
            Console.WriteLine(strMessage);
        }
    }

    public class DerivedClass : BaseClass
    {
        public override void Print()
        {
            Console.WriteLine("I am a Derived Class Print");
        }

        public new void HidePrint()
        {
            Console.WriteLine("I am a Derived Class Hide Print");
        }
    }
}
