using System;

namespace BankingKata
{
    public class Account
    {
        private static readonly Money DefaultHardLimit = new Money(0);
        private static readonly Money InitialAccountBalance = new Money(0m);

        private readonly ILedger _ledger;
        private readonly Money _hardLimit;

        public Account(ILedger ledger, Money hardLimit)
        {
            _ledger = ledger;
            _hardLimit = hardLimit;
        }
        
        public Account(ILedger ledger)
            : this(ledger, DefaultHardLimit)
        {
        }
        
        public Account()
            : this(new Ledger())
        {
        }

        public void Deposit(DateTime transactionDate, Money money)
        {
            var depositTransaction = new CreditEntry(transactionDate, money);
            _ledger.Record(depositTransaction);
        }

        public Money CalculateBalance()
        {
            return _ledger.Accept(new BalanceCalculatingVisitor(), InitialAccountBalance);
        }

        public TransactionResult Withdraw(DebitEntry debitEntry)
        {
            _ledger.Record(debitEntry);
            return new TransactionResult(true);
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