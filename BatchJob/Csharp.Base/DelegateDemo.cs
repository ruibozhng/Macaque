using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class DelegateDemo
    {
    }

    public delegate bool IsPromotable(Employee emp);

    public partial class Employee
    {       
        public static void PromoteEmployee(List<Employee> list, IsPromotable isPromotable)
        {
            foreach (Employee emp in list)
            {
                if (isPromotable(emp))
                {
                    Console.WriteLine(emp.Name + " promoted");
                }
            }
        }
    }
}
