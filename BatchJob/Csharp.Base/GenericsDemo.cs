using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class GenericsDemo
    {
        public static bool Compare<T>(T v1, T v2)
        {
            return v1.Equals(v2);
        }
    }

    class GenericsClassDemo<T>
    {
        public static bool Compare(T v1, T v2)
        {
            return v1.Equals(v2);
        }
    }
}
