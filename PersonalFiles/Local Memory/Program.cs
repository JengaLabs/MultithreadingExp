﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Local_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Worker thread
            new Thread(PrintOneToThrity).Start();

            //Main thread
            PrintOneToThrity();



            Console.ReadLine();
        }

        private static void PrintOneToThrity()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + 1 + " ");
            }
        }
    }
}
