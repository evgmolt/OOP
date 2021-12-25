using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account();
            Account account2 = new Account(100);
            Account account3 = new Account(200, AccountType.Brokerage);

            Console.WriteLine("1 " + account1);
            Console.WriteLine("2 " + account2);
            Console.WriteLine("3 " + account3);

            Console.WriteLine("3 deposit 200"); 
            account3.Deposit(200);
            Console.WriteLine("3 Withdraw 50 --> " + account3.Withdraw(50));
            Console.WriteLine(account3);
            Console.WriteLine("3 Withdraw 1000 --> " + account3.Withdraw(1000));
            Console.WriteLine(account3);
            Console.WriteLine("Transfer from 3 to 2 30 --> " + account2.Transfer(account3, 30));
            Console.WriteLine("Transfer from 3 to 2 3000 --> " + account2.Transfer(account3, 3000));
            Console.WriteLine("2 " + account2);
            Console.WriteLine("3 " + account3);
            Console.ReadKey();
        }
    }
}
