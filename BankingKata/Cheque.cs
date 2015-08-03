using System;

namespace BankingKata
{
    public class Cheque : ATMDebitEntry
    {
        private readonly int _chequeNumber;
        private readonly Money _amount;
        private readonly DateTime _transactionDate;

        public Cheque(DateTime transactionDate, Money amount, int chequeNumber)
            : base(transactionDate, amount)
        {
            _transactionDate = transactionDate;
            _chequeNumber = chequeNumber;
            _amount = amount;
        }
        
        public override string ToString()
        {
            return string.Format("CHQ {0} {1} ({2})", _chequeNumber, _transactionDate.ToString("dd MMM yyyy"), _amount);
        }
    }
}