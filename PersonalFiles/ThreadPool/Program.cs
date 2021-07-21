using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            Employee employee = new Employee();
            employee.Name = "Pig Cap";
            employee.CompanyName = "Cazton";


            System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);


            

            

            int workerThreads = 0;
            int completioPortThreads = 0;
            System.Threading.ThreadPool.GetMinThreads(out workerThreads, out completioPortThreads);

            System.Threading.ThreadPool.SetMaxThreads(workerThreads, completioPortThreads);

            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

            Console.ReadLine();
        }

        private static void DisplayEmployeeInfo(object employee)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            //employee equals the object type casted as an employee
            Employee emp = employee as Employee;
            Console.WriteLine("Persone name is {0} and company name is {1}", emp.Name, emp.CompanyName);


        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
}
