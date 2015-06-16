using System;

namespace BankingKata
{
    public class Account
    {
        private Cash _cash = new Cash(0.0);

        public Account()
        {
        }

        public Account(Cash cash)
        {
            if (cash == null)
            {
                throw new ArgumentNullException(@"Cash can't be null.");
            }

            _cash = cash;
        }

        public void Deposit(Cash cash)
        {
            _cash += cash;
        }

        public void Withdraw(Cash cash)
        {
            _cash -= cash;
        }

        private bool Equals(Account other)
        {
            return _cash.Equals(other._cash);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Account) obj);
        }

        public override int GetHashCode()
        {
            return _cash.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Account Cash: {0}", _cash);
        }
    }
}