using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexProgram
{
    class Program
    {
        //false means ui thread will not have any locks, the name is a system wide reference
        static Mutex mutex = new Mutex(false, "MutexName");

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(AcquireMutex);
                thread.Name = string.Format("Thread{0}", i + 1);
                thread.Start();
            }
            
        }

        private static void AcquireMutex()
        {
            //Makes only one thread able to acess
            if(!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                Console.WriteLine("Mutex aquried by " + Thread.CurrentThread.Name);
                return;
            }
            //Blocks current thread till signal is received
            //mutex.WaitOne();
            //Do somthing
            DoSomthing();
            mutex.ReleaseMutex();
            Console.WriteLine("Mutex has benn released by " + Thread.CurrentThread.Name);
        }

        private static void DoSomthing()
        {
            Thread.Sleep(1500);
            Console.WriteLine("Mutex is used by " + Thread.CurrentThread.Name);
        }

    }
}
