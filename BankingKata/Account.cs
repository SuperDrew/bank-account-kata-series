using System;

namespace BankingKata
{
    public class Account
    {
        private static readonly Money DefaultHardLimit = new Money(0);

        private readonly ILedger _ledger;
        private readonly Money _hardLimit;

        public Account(ILedger ledger, Money hardLimit)
        {
            _ledger = ledger;
            _hardLimit = hardLimit;
        }

        public Account()
            : this(new Ledger(), DefaultHardLimit)
        {
        }

        public void Deposit(DateTime transactionDate, Money money)
        {
            var depositTransaction = new CreditEntry(transactionDate, money);
            _ledger.Record(depositTransaction);
        }

        public Money CalculateBalance()
        {
            return _ledger.Accept(new BalanceCalculatingVisitor(), new Money(0m));
        }

        public void Withdraw(DebitEntry debitEntry)
        {
            _ledger.Record(debitEntry);
        }

        public void PrintBalance(IPrinter printer)
        {
            var balance = CalculateBalance();
            printer.PrintBalance(balance);
        }

        public void PrintLastTransaction(IPrinter printer)
        {
            printer.PrintLastTransaction(_ledger);
        }
    }
}