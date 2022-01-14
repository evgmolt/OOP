using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        private readonly int _number;
        private readonly AccountType _accountType;
        private decimal _balance;

        public int Number
        {
            get { return _number; }
        }

        public AccountType AccountType
        {
            get { return _accountType; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public Account() : this(0)
        {
        }

        public Account(decimal balance) : this(balance, 0)
        {
        }

        public Account(decimal balance, AccountType accountType)
        {
            _number = GetNumber();
            _balance = balance;
            _accountType = accountType;
        }

        public decimal Withdraw(decimal sum)
        {
            if (sum <= _balance)
            {
                _balance -= sum;
                return sum;
            }
            else
            {
                return -1;
            }
        }

        public void Deposit(decimal sum)
        {
            _balance += sum;
        }

        public decimal Transfer(Account accountFrom, decimal sum)
        {
            var result = accountFrom.Withdraw(sum);
            if (result >= 0)
            {
                Deposit(sum);
                return sum;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return (AccountType.ToString().PadRight(10) + " " + _number.ToString().PadLeft(10, '0') + " " + _balance.ToString());
        }

        private int GetNumber()
        {
            Properties.Settings1.Default.AccountNumber++;
            Properties.Settings1.Default.Save();
            return Properties.Settings1.Default.AccountNumber;
        }

        public static bool operator ==(Account account1, Account account2)
        {
            if (account1 is null && account2 is null) return true;
            if (account1 is null || account2 is null) return false;
            return account1._number == account2._number;
        }

        public static bool operator !=(Account account1, Account account2)
        {
            if (account1 is null && account2 is null) return true;
            if (account1 is null || account2 is null) return false;
            return !(account1 == account2);
        }

        public override bool Equals(object obj)
        {
            return this == (Account)obj;
        }

        public override int GetHashCode()
        {
            return _number ^ (int)_accountType;
        }
    }
}
