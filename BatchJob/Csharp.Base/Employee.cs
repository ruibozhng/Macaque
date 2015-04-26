using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static List<Employee> GetEmployeeList()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { ID = 101, Name = "Sam", Salary = 5000, Experience = 5 });
            list.Add(new Employee() { ID = 102, Name = "Jerry", Salary = 6000, Experience = 6 });
            list.Add(new Employee() { ID = 103, Name = "Jack", Salary = 7000, Experience = 7 });
            list.Add(new Employee() { ID = 104, Name = "Peter", Salary = 8000, Experience = 8 });
            list.Add(new Employee() { ID = 105, Name = "Alex", Salary = 9000, Experience = 9 });
            return list;
        }

        public static Dictionary<int,Employee> GetEmployeeDictionary()
        {
            Dictionary<int, Employee> dict = new Dictionary<int, Employee>();
            List<Employee> list = GetEmployeeList();
            foreach (var item in list)
            {
                dict.Add(item.ID, item);
            }            
            return dict;
        }
    }   
}
