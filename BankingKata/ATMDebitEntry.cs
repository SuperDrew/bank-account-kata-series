using System;

namespace BankingKata
{
    public class ATMDebitEntry : ITransaction
    {
        private readonly DateTime transactionDate;
        private readonly Money transactionAmount;

        public ATMDebitEntry(DateTime transactionDate, Money transactionAmount)
        {
            this.transactionDate = transactionDate;
            this.transactionAmount = transactionAmount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as ATMDebitEntry);
            return transaction != null && transactionAmount.Equals(transaction.transactionAmount);
        }

        public override string ToString()
        {
            return string.Format("ATM {0} ({1})", transactionDate.ToString("dd MMM yyyy"), transactionAmount);
        }
    }
}