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
            Account account0 = null;
            Account account1 = new Account();
            Account account2 = new Account(100);
            Account account3 = new Account(200, AccountType.Brokerage);

            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.WriteLine(account3);

            Console.WriteLine(account1 == account2);
            Console.WriteLine(account1 == account0);

            Console.ReadKey();
        }
    }
}
