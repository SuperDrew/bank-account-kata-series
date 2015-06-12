using System;
using BankingKata;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs
{
    [Binding]
    public sealed class CreateAccountSteps
    {
        private readonly AccountData accountData;

        public CreateAccountSteps(AccountData accountData)
        {
            this.accountData = accountData;
        }

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I want to create an account")]
        public void GivenIWantToCreateAnAccount()
        {
            //TODO is anything needed here?
        }

        [Given(@"I create an account with my cash")]
        public void GivenICreateAnAccountWithMyCash()
        {
            accountData.Account = new Account(accountData.Cash);
        }

        [When(@"I create a new account")]
        public void WhenICreateANewAccount()
        {
            //Act
            accountData.Account = new Account();
        }
        
        [Then(@"the account should have zero cash")]
        public void ThenTheAccountShouldHaveZeroCash()
        {
            // Arrange
            var zeroCashAccount = new Account(new Cash(0.0));

            // Assert
            Assert.That(accountData.Account, Is.EqualTo(zeroCashAccount));
        }

        [Then(@"Creating an account should throw an argument null exception\.")]
        public void ThenCreatingAnAccountShouldThrowAnArgumentNullException_()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Account(accountData.Cash));
        }



        [Then(@"the account total should be the same as my cash\.")]
        public void ThenTheAccountTotalShouldBeTheSameAsMyCash_()
        {
            //TODO This is testing the new account vs deposit func => not great.
            var expectedAccount = new Account();
            expectedAccount.Deposit(accountData.Cash);

            Assert.That(accountData.Account, Is.EqualTo(expectedAccount));
        }

    }
}
