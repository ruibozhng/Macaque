using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class ReflectionDemo
    {
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int ID, string Name)
        {
            this.Id = ID;
            this.Name = Name;
        }
        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public void Print()
        {
            Console.WriteLine("Print Method");
        }

        public string GetFullName(string firstName, string lastName)
        {
            return firstName + " " +  lastName;
        }
    }
}
