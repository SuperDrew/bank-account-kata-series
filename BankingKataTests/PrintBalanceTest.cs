using System.Collections.Generic;
using BankingKata;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;

namespace BankingKataTests
{
    [TestFixture]
    public sealed class PrintBalanceTest
    {
        private static readonly Money _money = new Money(123m);
        private static readonly DateTime _nominalDateTime = new DateTime(2015, 07, 13);

        [Test]
        public void BalanceOfZeroIsPassedToThePrinter_ForANewAccount()
        {
            var account = new Account();

            IPrinter printer = Substitute.For<IPrinter>();
            account.PrintBalance(printer);

            printer.Received().PrintBalance(new Money(0m));
        }

        [Test]
        public void BalanceOfZeroIsPrinted_ForANewAccount()
        {
            var account = new Account();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintBalance(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Balance: £0.00";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void BalanceInThousandsIsPrinted()
        {
            var account = new Account();
            account.Deposit(DateTime.Now, new Money(1234.56m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintBalance(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Balance: £1,234.56";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void LastTransactionIsPrinted()
        {
            var account = new Account();
            account.Deposit(DateTime.Now, _money);
            account.Deposit(DateTime.Now, new Money(456m));
            account.Deposit(_nominalDateTime, new Money(789m));

            var actual = PrintLastTransaction(account);
            var expected = "Last transaction: DEP 13 Jul 2015 £789.00";
            Assert.That(actual, Is.EqualTo(expected));
        }

        private IEnumerable<TestCaseData> WithdrawalPrintedTestCases
        {
            get
            {
                yield return new TestCaseData(new ATMDebitEntry(_nominalDateTime, _money), "Last transaction: ATM 13 Jul 2015 (£123.00)");
                yield return new TestCaseData(new ChequeDebitEntry(_nominalDateTime, _money, 100001), "Last transaction: CHQ 100001 13 Jul 2015 (£123.00)");
                yield return new TestCaseData(new ChequeDebitEntry(_nominalDateTime, _money, -10), "Last transaction: CHQ -10 13 Jul 2015 (£123.00)");
            }
        }
            
        [TestCaseSource("WithdrawalPrintedTestCases")]
        public void WithDrawalIsPrinted(DebitEntry debitEntry, string expected)
        {
            var account = CreateAccountFromLedger(debitEntry);
            var actual = PrintLastTransaction(account);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CashWithdrawalIsPrinted()
        {
            var transaction = new ATMDebitEntry(_nominalDateTime, _money);
            var account = CreateAccountFromLedger(transaction);
            var actual = PrintLastTransaction(account);

            var expected = "Last transaction: ATM 13 Jul 2015 (£123.00)";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ChequeWithdrawalIsPrinted()
        {
            var transaction = new ChequeDebitEntry(_nominalDateTime, _money, 100001);
            var account = CreateAccountFromLedger(transaction);
            var actual = PrintLastTransaction(account);

            const string expected = "Last transaction: CHQ 100001 13 Jul 2015 (£123.00)";
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string PrintLastTransaction(Account account)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintLastTransaction(printer);

            var output = stringWriter.GetStringBuilder();
            var actual = output.ToString();
            return actual;
        }

        private static Account CreateAccountFromLedger(ITransaction transaction)
        {
            var ledger = new Ledger();
            ledger.Record(transaction);
            return new Account(ledger);
        }
    }
}
