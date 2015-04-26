using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class IndexerDemo
    {
    }

    public class Company
    {
        private List<Employee> list;

        public Company()
        {
            list = new List<Employee>();
            list.Add(new Employee() { ID = 1, Name = "Sam", Salary = 5000, Experience = 5 });
            list.Add(new Employee() { ID = 2, Name = "Jerry", Salary = 6000, Experience = 6 });
            list.Add(new Employee() { ID = 3, Name = "Jack", Salary = 7000, Experience = 7 });
            list.Add(new Employee() { ID = 4, Name = "Peter", Salary = 8000, Experience = 8 });
            list.Add(new Employee() { ID = 5, Name = "Alex", Salary = 9000, Experience = 9 });
        }

        public string this[int employId]
        {
            get
            {
                return list.FirstOrDefault(emp => emp.ID == employId).Name;
            }
            set
            {
                list.FirstOrDefault(emp => emp.ID == employId).Name = value;
            }
        }
    }
}
