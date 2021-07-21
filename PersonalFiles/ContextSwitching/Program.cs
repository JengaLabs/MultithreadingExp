using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContextSwitching
{
    class Program
    {

        private static bool isCompleted;

        static readonly object lockCompleted = new object();

        static void Main(string[] args)
        {

            #region Shared Resources

            Thread thread = new Thread(HelloWorld);


            //Worker thread
            thread.Start();

            //Main thread
            HelloWorld();

            Console.ReadLine();









        }

        private static void HelloWorld()
        {
            //Every other thread that would come here, has to wait till the current thread is 
            //done with this section
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    isCompleted = true;
                    Console.WriteLine("Hello World should print only once");

                }
            }


        }

        #endregion


        #region Context Switching
        /*
        //What method this thread will run
        Thread thread = new Thread(WriteUsingNewThread);
        //Name the thread
        thread.Name = "Pig Worker";



        //Worker thread
        thread.Start();


        //Main thread
        //Name the thread
        Thread.CurrentThread.Name = "Pig Main";
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("A" + i + " ");
        }


        Console.ReadLine();

    }

    private static void WriteUsingNewThread()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write("Z" + i + " ");
        }
    }

    */
        #endregion

    }
}
