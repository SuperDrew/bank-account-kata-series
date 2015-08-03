using System;

namespace BankingKata
{
    public class Cheque : DebitEntry
    {
        private readonly int _chequeNumber;

        public Cheque(DateTime transactionDate, Money amount, int chequeNumber)
            : base(transactionDate, amount)
        {
            _chequeNumber = chequeNumber;
        }
        
        public override string ToString()
        {
            return string.Format("CHQ {0} {1}", _chequeNumber, base.ToString());
        }
    }
}