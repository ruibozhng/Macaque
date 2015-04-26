using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp.Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************Hide Method Test*********************************");
            HideMethodTest();
            Console.WriteLine("****************Delegate Test************************************");
            DelegateTest();
            Console.WriteLine("****************Delegate Multicase Test**************************");
            DelegateMulticaseTest();
            Console.WriteLine("****************Reflection Test**********************************");
            ReflectionTest();
            Console.WriteLine("****************Late Binding Reflection Test*********************");
            LateBindingReflectionTest();
            Console.WriteLine("***************Generics Test*************************************");
            GenericsTest();
            Console.WriteLine("***************Indexer Test**************************************");
            IndexerTest();
            Console.WriteLine("***************Optional Parameters Test**************************");
            OptionalParametersTest();
            Console.WriteLine("***************Dictionary Test***********************************");
            DictionaryTest();
            Console.WriteLine("***************Anonymous Test************************************");
            AnonymousTest();
            Console.WriteLine("***************Func Test*****************************************");
            FuncTest();
            Console.WriteLine("***************Queue Test****************************************");
            QueueTest();
            Console.WriteLine("***************Stack Test****************************************");
            StackTest();
            Console.WriteLine("***************Thread Test***************************************");
            ThreadTest();
            Console.ReadLine();
        }

        #region HideMethod Test
        static void HideMethodTest()
        {
            BaseClass c = new DerivedClass();
            c.Print();
            c.HidePrint();
        }
        #endregion

        //delegate is type safe function pointer
        #region Delegate Test
        public delegate void SampleDelegate();

        public static void SampleDelegateOne()
        {
            Console.WriteLine("SampleDelegateOne Invoked");
        }
        public static void SampleDelegateTwo()
        {
            Console.WriteLine("SampleDelegateTwo Invoked");
        }
        public static void SampleDelegateThree()
        {
            Console.WriteLine("SampleDelegateThree Invoked");
        }

        private static void DelegateMulticaseTest()
        {
            //Option 1
            Console.WriteLine("Option 1");
            SampleDelegate d1, d2, d3, d4;
            d1 = new SampleDelegate(SampleDelegateOne);
            d2 = new SampleDelegate(SampleDelegateTwo);
            d3 = new SampleDelegate(SampleDelegateThree);
            d4 = d1 + d2 + d3 - d2;
            d4();

            //Option 2
            Console.WriteLine("Option 2");
            SampleDelegate del = new SampleDelegate(SampleDelegateOne);
            del += SampleDelegateTwo;
            del += SampleDelegateThree;
            del -= SampleDelegateOne;
            del();
        }
        private static void DelegateTest()
        {
            List<Employee> list = Employee.GetEmployeeList();

            //Option 1
            Console.WriteLine("Option 1");
            IsPromotable isPromotable = new IsPromotable(Promote);
            Employee.PromoteEmployee(list, isPromotable);
            //Option 2
            Console.WriteLine("Option 2");
            Employee.PromoteEmployee(list, emp => emp.Experience >= 7);
        }

        public static bool Promote(Employee emp)
        {
            if (emp.Experience >= 7)
                return true;
            else
                return false;
        }
        #endregion

        #region Reflection Test
        private static void ReflectionTest()
        {
            //Option 1
            //Type T = Type.GetType("Csharp.Base.Customer");
            //Option 2
            //Customer c = new Customer();
            //Type T = c.GetType();
            //Option 3
            Type T = typeof(Customer);
            Console.WriteLine("Full Name = {0}", T.FullName);
            Console.WriteLine("Just the Name = {0}", T.Name);
            Console.WriteLine("Just the Namespace = {0}", T.Namespace);

            Console.WriteLine("Properites in Customer Class");
            PropertyInfo[] properites = T.GetProperties();
            foreach (PropertyInfo p in properites)
            {
                Console.WriteLine(p.PropertyType.Name + "" + p.Name);
            }
            Console.WriteLine("Methods in Customer Class");
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo m in methods)
            {
                Console.WriteLine(m.ReturnType.Name + "" + m.Name);
            }
        }

        private static void LateBindingReflectionTest()
        {
            Assembly a = Assembly.GetExecutingAssembly();
            Type t = a.GetType("Csharp.Base.Customer");
            object o = Activator.CreateInstance(t);

            MethodInfo m = t.GetMethod("GetFullName");
            string[] paras = new string[2];
            paras[0] = "Craig";
            paras[1] = "Lee";

            string fullName = (string)m.Invoke(o, paras);
            Console.WriteLine("Full name = {0}", fullName);
        }
        #endregion

        #region Generics Test
        private static void GenericsTest()
        {
            bool result = GenericsDemo.Compare<int>(10, 10);
            if (result)
                Console.WriteLine("Equal");
            else
                Console.WriteLine("Not Equal");

            bool result2 = GenericsClassDemo<int>.Compare(10, 10);
            if (result2)
                Console.WriteLine("Equal");
            else
                Console.WriteLine("Not Equal");
        }
        #endregion

        #region Indexer Test
        public static void IndexerTest()
        {
            Company c = new Company();
            Console.WriteLine(c[1]);
            Console.WriteLine("Change name to Test");
            c[1] = "Test";
            Console.WriteLine(c[1]);
        }
        #endregion

        #region Optional Parameters Test
        public static void OptionalParametersTest()
        {
            int result = OptionalParameters.Calculate(10, 20);
            Console.WriteLine("Sum overloading = " + result);
            result = OptionalParameters.Calculate(10, 20, new object[] { 30, 40, 50 });
            Console.WriteLine("Sum parameter array = " + result);
            result = OptionalParameters.Calculate(10, c: 30);
            Console.WriteLine("Sum parameter defaults = " + result);
            result = OptionalParameters.Calculate(10, new int[] { 30, 40, 50 });
            Console.WriteLine("Sum OptionalAttribute = " + result);
        }
        #endregion

        #region dictionary Test
        private static void DictionaryTest()
        {
            Dictionary<int, Employee> dict = Employee.GetEmployeeDictionary();
            Console.WriteLine("101: Name = {0}", dict[101].Name);
            Employee em;
            if (dict.TryGetValue(10, out em))
            {
                Console.WriteLine("10: Name = {0}", em.Name);
            }
            else
            {
                Console.WriteLine("10 is not found");
            }
            Console.WriteLine("Total Number (salary >1000) = {0} ", dict.Count(m => m.Value.Salary > 100));

            foreach (var item in dict)
            {
                Console.WriteLine("Key = {0} ", item.Key);
                Employee emp = item.Value;
                Console.WriteLine("{0} salary is {1}", emp.Name, emp.Salary);
                Console.WriteLine("-------------------------------------------");
            }
        }
        #endregion

        #region Anonymous and Lambda Test
        private static void AnonymousTest()
        {
            List<Employee> list = Employee.GetEmployeeList();
            //=> read as GOTO
            //Lambda cannot omit the parameters. Anonymous delegate can omit.
            Employee em1 = list.Find(x => x.ID == 101);
            Console.WriteLine("Key = {0}, Name = {1}", em1.ID, em1.Name);

            //Anonymous
            Employee em2 = list.Find(delegate(Employee x)
            {
                return x.ID == 102;
            });
            Console.WriteLine("Key = {0}, Name = {1}", em2.ID, em2.Name);

            Func<Employee, string> selector = emp => "Name " + emp.Name;
            IEnumerable<string> names = list.Select(selector);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
        #endregion

        #region Func Test
        private static void FuncTest()
        {
            List<Employee> list = Employee.GetEmployeeList();
            Func<Employee, string> selector = emp => "Name " + emp.Name;
            IEnumerable<string> names = list.Select(selector);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            //Lambda
            IEnumerable<string> names2 = list.Select(emp => "Name " + emp.Name);
            foreach (string name in names2)
            {
                Console.WriteLine(name);
            }
        }
        #endregion

        #region Queue Test - First In First Out

        private static void QueueTest()
        {
            Queue<Employee> q = new Queue<Employee>();
            List<Employee> list = Employee.GetEmployeeList();
            foreach (var item in list)
            {
                q.Enqueue(item);
            }
            Console.WriteLine("Total number of queue is {0}", q.Count);
            Employee m1 = q.Dequeue();
            Console.WriteLine("ID: {0} Name: {1}", m1.ID, m1.Name);
            Console.WriteLine("Total number of queue is {0}", q.Count);
            Employee m2 = q.Peek();
            Console.WriteLine("ID: {0} Name: {1}", m2.ID, m2.Name);
            Console.WriteLine("Total number of queue is {0}", q.Count);
        }

        #endregion

        #region Stack Test (stack of plates) - First In Last Out
        private static void StackTest()
        {
            Stack<Employee> s = new Stack<Employee>();
            List<Employee> list = Employee.GetEmployeeList();
            foreach (var item in list)
            {
                s.Push(item);
            }
            Console.WriteLine("Total number of stack is {0}", s.Count);
            Employee m1 = s.Pop();
            Console.WriteLine("ID: {0} Name: {1}", m1.ID, m1.Name);
            Console.WriteLine("Total number of stack is {0}", s.Count);
            Employee m2 = s.Peek();
            Console.WriteLine("ID: {0} Name: {1}", m2.ID, m2.Name);
            Console.WriteLine("Total number of stack is {0}", s.Count);
        }
        #endregion

        #region Thread Test with Parameter
        private static void ThreadTest()
        {
            Console.WriteLine("Please enter number");
            object target = Console.ReadLine();
            //Option 1: ParameterizedThreadStart - Not good practice
            Console.WriteLine("Option 1");
            Thread t1 = new Thread(PrintNumber);
            t1.Start(target);

            //Option 2
            Console.WriteLine("Option 2");
            int n = Convert.ToInt32(target);
            Number number = new Number(n);
            Thread t2 = new Thread(number.PrintNumber);
            t2.Start();
        }
        private static void PrintNumber(object max)
        {
            int count = 0;
            if (int.TryParse(max.ToString(), out count))
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        #endregion
    }
}
