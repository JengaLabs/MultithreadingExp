using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //simple task
            Task task = new Task(SimpleMethod);
            task.Start();

            //Specifiy that it returns a string
            Task<string> taskThatReturns = new Task<string>(MethodThatReturns);
            //Declare task to start
            taskThatReturns.Start();

            //Waits for comcpletion
            taskThatReturns.Wait();

            Console.WriteLine(taskThatReturns.Result);

        }

        private static string MethodThatReturns()
        {
            Thread.Sleep(2000);
            return "Hello";
        }

        private static void SimpleMethod() 
        {
            Console.WriteLine("Hello World");   
        }
    }
}
