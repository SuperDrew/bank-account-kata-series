using System;

namespace BankingKata
{
    public class Account
    {
        public Account()
        {
        }

        public Account(Cash cash)
        {
            if (cash == null)
            {
                throw new ArgumentNullException("Cash can't be null.");
            }
        }

        public void Deposit(Cash cash)
        {
        }
    }
}