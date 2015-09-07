﻿using System.Collections;
using BankingKata;
using NSubstitute;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void AccountRecordsDepositInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger);

            account.Deposit(DateTime.Now, money);

            CreditEntry deposit = new CreditEntry(DateTime.Now, money);
            ledger.Received().Record(deposit);
        }

        [Test]
        public void AccountRecordsWithdrawalInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger);

            var debitEntry = new ATMDebitEntry(DateTime.Now, money);
            account.Withdraw(debitEntry);

            ledger.Received().Record(debitEntry);
        }

        [Test]
        public void AccountRecordsChequeWithdrawalInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger);

            var myCheque = new ChequeDebitEntry(new DateTime(2015, 07, 13), money, 100001);
            account.Withdraw(myCheque);

            ledger.Received().Record(myCheque);
        }

        [Test]
        public void CalculateBalanceTotalsAllDepositsMadeToTheAccount()
        {
            var ledger = Substitute.For<ILedger>();
            var account = new Account(ledger);

            account.CalculateBalance();

            ledger.Received().Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m));
        }

        [Test]
        public void LedgerTotalIsReturnedByCalculate()
        {
            var expectedBalance = new Money(13m);
            var ledger = Substitute.For<ILedger>();
            ledger.Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m)).Returns(expectedBalance);
            var account = new Account(ledger);

            var actualBalance = account.CalculateBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void CanAlwaysWithdraw()
        {
            var ledger = Substitute.For<ILedger>();
            var account = new Account(ledger);

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(3m));
            var transactionResult = account.Withdraw(debitEntry);

            var expectedResult = new TransactionResult(true);
            Assert.That(transactionResult, Is.EqualTo(expectedResult));
        }


        [TestCase(3, false, TestName = "TransactionFailsWhenWithdrawIsOverLimit")]
        [TestCase(0, true, TestName = "TransactionSucceedsWhenWithdrawIsUnderLimit")]
        public void WithdrawResultIsCorrect(Decimal withdrawAmount, bool transactionSuccess)
        {
            var ledger = Substitute.For<ILedger>();
            var account = new Account(ledger);

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(withdrawAmount));
            var transactionResult = account.Withdraw(debitEntry);

            var expectedResult = new TransactionResult(transactionSuccess);
            Assert.That(transactionResult, Is.EqualTo(expectedResult));
        }
    }
}
