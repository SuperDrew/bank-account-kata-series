using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankingKata;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs
{
    [Binding]
    public sealed class AccountCashHandlingSteps
    {
        private AccountData accountData;

        public AccountCashHandlingSteps(AccountData accountData)
        {
            this.accountData = accountData;
        }

        [When(@"I deposit my cash")]
        public void WhenIDepositMyCash()
        {
            //Arrange
            accountData.Account.Deposit(accountData.Cash);
        }

        [Then(@"My account should have the same Cash as my cash")]
        public void ThenMyAccountShouldHaveTheSameCashAsMyCash()
        {
            //Arrange
            var expectedAccount = new Account(accountData.Cash);

            //Assert
            Assert.That(accountData.Account, Is.EqualTo(expectedAccount));
        }

        [When(@"I withdraw my cash")]
        public void WhenIWithdrawMyCash()
        {
            //Arrange
            accountData.Account.Withdraw(accountData.Cash);
        }

    }
}
