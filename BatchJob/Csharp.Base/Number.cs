using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class Number
    {
        private int _target;
        public Number(int target)
        {
            this._target = target;
        }
        public void PrintNumber()
        {
            for (int i = 0; i < _target; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
