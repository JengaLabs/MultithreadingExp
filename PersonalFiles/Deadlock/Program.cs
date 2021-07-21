using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlock
{
    class Program
    {
        
        static void Main(string[] args)
        {
            object bradLock = new object();
            object frankLock = new object();


            new Thread(() =>
            {
                lock (bradLock)
                {
                    Console.WriteLine("Brad lock obtained");
                    Thread.Sleep(2000);
                    lock (frankLock)
                    {
                        Console.WriteLine("frank lock obtained");

                    }
                }
            }).Start();

            lock (frankLock)
            {
                Console.WriteLine("Main Thread obtained frank lock");
            }


        }
    }
}
