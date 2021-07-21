using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample
{
    class Program
    {
        static void Main(string[] args)
        {


            Thread thread = new Thread(PrintHelloWorld);
            thread.Start();

            //makes other thread wait to write
            thread.Join();

            Console.WriteLine("hello world pr");



            Console.Read();

        }

        private static void PrintHelloWorld()
        {
            Thread.Sleep(5000);
            Console.WriteLine("hello world");
            Thread.Sleep(5000);
        }
    }
}
