using System;

namespace BankingKata
{
    public class Cheque : ITransaction
    {
        private readonly int _chequeNumber;
        private readonly Money _amount;

        public Cheque(int chequeNumber, Money amount)
        {
            _chequeNumber = chequeNumber;
            _amount = amount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - _amount;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", DateTime.Now.ToString("dd MMM yyyy"), _amount);
        }
    }
}