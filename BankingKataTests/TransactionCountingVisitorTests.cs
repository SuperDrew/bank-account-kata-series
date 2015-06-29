using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    class TransactionCountingVisitorTests
    {
        [Test]
        public void TotalIsInitiallyZero()
        {
            var actualTotal = new Ledger().Accept(new TransactionCountingVisitor(), 0);

            Assert.That(actualTotal, Is.EqualTo(0));
        }

        [Test]
        public void TotalEqualsSumOfAddedMoney()
        {
            var transactionLog = new Ledger();

            transactionLog.Record(new CreditEntry(new Money(1m)));
            transactionLog.Record(new CreditEntry(new Money(3m)));

            var actualTotal = transactionLog.Accept(new TransactionCountingVisitor(), 0);

            Assert.That(actualTotal, Is.EqualTo(2));
        }
    }
}
