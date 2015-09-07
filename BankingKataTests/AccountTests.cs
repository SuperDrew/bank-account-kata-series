using System.Collections;
using BankingKata;
using NSubstitute;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        private ILedger _ledger;
        private readonly Money _ledgerCalculatedBalance = new Money(10m);


        [SetUp]
        public void SetUp()
        {
            _ledger = Substitute.For<ILedger>();
            _ledger.Accept(Arg.Any<BalanceCalculatingVisitor>(), Arg.Any<Money>()).Returns(_ledgerCalculatedBalance);
        }

        [Test]
        public void AccountRecordsDepositInTransactionLog()
        {
            var money = new Money(3m);
            var account = new Account(_ledger);

            account.Deposit(DateTime.Now, money);

            var deposit = new CreditEntry(DateTime.Now, money);
            _ledger.Received().Record(deposit);
        }

        [Test]
        public void AccountRecordsWithdrawalInTransactionLog()
        {
            var money = new Money(3m);
            var account = new Account(_ledger);

            var debitEntry = new ATMDebitEntry(DateTime.Now, money);
            account.Withdraw(debitEntry);

            _ledger.Received().Record(debitEntry);
        }

        [Test]
        public void AccountRecordsChequeWithdrawalInTransactionLog()
        {
            var money = new Money(3m);
            var account = new Account(_ledger);

            var myCheque = new ChequeDebitEntry(new DateTime(2015, 07, 13), money, 100001);
            account.Withdraw(myCheque);

            _ledger.Received().Record(myCheque);
        }

        [Test]
        public void CalculateBalanceTotalsAllDepositsMadeToTheAccount()
        {
            var account = new Account(_ledger);

            account.CalculateBalance();

            _ledger.Received().Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m));
        }

        [Test]
        public void LedgerTotalIsReturnedByCalculate()
        {
            var expectedBalance = new Money(13m);
            _ledger.Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m)).Returns(expectedBalance);
            var account = new Account(_ledger);

            var actualBalance = account.CalculateBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void CanAlwaysWithdraw()
        {
            var account = new Account(_ledger);

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(3m));
            var transactionResult = account.Withdraw(debitEntry);

            var expectedResult = new TransactionResult(true);
            Assert.That(transactionResult, Is.EqualTo(expectedResult));
        }


        [TestCase(20, false, TestName = "TransactionFailsWhenWithdrawIsOverLimit")]
        [TestCase(0, true, TestName = "TransactionSucceedsWhenWithdrawIsUnderLimit")]
        public void WithdrawResultIsCorrect(Decimal withdrawAmount, bool transactionSuccess)
        {
            var account = new Account(_ledger);

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(withdrawAmount));
            var transactionResult = account.Withdraw(debitEntry);

            var expectedResult = new TransactionResult(transactionSuccess);
            Assert.That(transactionResult, Is.EqualTo(expectedResult));
        }
    }
}
