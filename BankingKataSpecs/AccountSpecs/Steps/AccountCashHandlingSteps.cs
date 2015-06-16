using BankingKata;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs.Steps
{
    [Binding]
    public sealed class AccountCashHandlingSteps
    {
        private readonly AccountData _accountData;

        public AccountCashHandlingSteps(AccountData accountData)
        {
            _accountData = accountData;
        }

        [When(@"I deposit (.*) cash")]
        public void WhenIDepositCash(int p0)
        {
            //Arrange
            _accountData.Account.Deposit(new Cash(p0));
        }

        [Then(@"the account should have (.*) cash")]
        public void ThenTheAccountShouldHaveCash(int p0)
        {
            //Arrange
            var expectedAccount = new Account(new Cash(p0));

            //Assert
            Assert.That(_accountData.Account, Is.EqualTo(expectedAccount));
        }
        
        [When(@"I withdraw (.*) cash")]
        public void WhenIWithdrawCash(int p0)
        {
            //Arrange
            _accountData.Account.Withdraw(new Cash(p0));
        }
    }
}
