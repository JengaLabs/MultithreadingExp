using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounts
{
    class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account(20000);

            Task task1 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task task2 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task task3 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task task4 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task.WaitAll(task1, task2, task3, task4);
            Console.WriteLine("Finished all task");




            Console.ReadLine();

        }
    }


    internal class Account
    {
        Object myLock = new Object();
        Random random = new Random();
        int balance;

        public Account(int initialBalance)
        {
            balance = initialBalance;
        }

        int Withdraw(int amount)
        {
            if (balance < 0)
            {
                throw new Exception("Not enough balance");

            }

            //Meaning lock
            Monitor.Enter(myLock);

            try
            {
                //perform logic
                if (balance >= amount)
                {
                    Console.WriteLine("Amount drawn " + amount);
                    balance = balance - amount;
                    return balance;
                }
            }
            finally
            {

                //Release the lock
                Monitor.Exit(myLock);
            }

            return 0;
        }

        public void WithdrawRandomly()
        {

            for(int i = 0; i < 100; i++)
            {
                balance = Withdraw(random.Next(2000, 5000));
                if (balance > 0)
                {
                    Console.WriteLine("Balance left " + balance);
                }
            }
            
        }

    }




}
