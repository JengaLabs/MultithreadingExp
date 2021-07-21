using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskChaining
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> antecedent = Task.Run(() => DateTime.Today.ToShortDateString());

            Task<string> continuation = antecedent.ContinueWith(x => "Today is " + antecedent.Result);

            Console.WriteLine(continuation.Result);

            Console.ReadLine();
        }
    }
}
