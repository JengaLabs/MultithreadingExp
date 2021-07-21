using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskIoOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            Task<string> task = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/todos"));

            //https://jsonplaceholder.typicode.com/todos

            //task.Start();

            SomethingElse();

            //task.Wait();

            //if task is still exccuting than result will normally just wait itse;f
            try
            {
                Console.WriteLine(task.Result);
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        private static void SomethingElse()
        {
            Console.WriteLine("nerd");
        }

        private static string GetPosts(string url)
        {

            //throw null;

            //lots of ways to do this
            using(var client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
