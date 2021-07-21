using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReaderWriter
{
    class Program
    {

        static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        static Dictionary<int, string> persons = new Dictionary<int, string>();
        static Random random = new Random();

        static void Main(string[] args)
        {

            var task1 = Task.Factory.StartNew(Read);
            var task2 = Task.Factory.StartNew(Write, "PIG");
            var task3 = Task.Factory.StartNew(Write, "Dog");
            var task4 = Task.Factory.StartNew(Read);
            Task.WaitAll(task1, task2, task3, task4);

            Console.ReadLine();
        }
    
        static void Read()
        {
            for (int i = 0; i < 10; i++)
            {
                //Read, lock and exit
                readerWriterLockSlim.EnterReadLock();
                Thread.Sleep(50);
                readerWriterLockSlim.ExitReadLock();
            }
        }

        static void Write(object name)
        {
            for (int i = 0; i < 10; i++)
            {
                //create a random id synchronized
                int id = GetRandom();
                readerWriterLockSlim.EnterWriteLock();
                var person = "Perons " + i;
                persons.Add(id, person);
                readerWriterLockSlim.ExitWriteLock();
                Console.WriteLine(name + " added " + person);
                Thread.Sleep(200);
                
            }
        }

        static int GetRandom()
        {
            lock (random)
            {
                return random.Next(2000, 5000);
            }
        }
    
    }
}
