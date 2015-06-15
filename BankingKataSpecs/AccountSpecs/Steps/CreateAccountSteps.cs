using System;
using BankingKata;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs.Steps
{
    [Binding]
    public sealed class CreateAccountSteps
    {
        private readonly AccountData accountData;

        public CreateAccountSteps(AccountData accountData)
        {
            this.accountData = accountData;
        }
        
        [Given(@"I want to create an account")]
        public void GivenIWantToCreateAnAccount()
        {
            //TODO is anything needed here?
        }

        [When(@"I create a new account")]
        public void WhenICreateANewAccount()
        {
            //Act
            accountData.Account = new Account();
        }

        [Then(@"Creating an account should throw an argument null exception\.")]
        public void ThenCreatingAnAccountShouldThrowAnArgumentNullException_()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Account(accountData.Cash));
        }

        [Given(@"I create an account with (.*) cash")]
        public void GivenICreateAnAccountWithCash(int p0)
        {
            //Act
            accountData.Account = new Account(new Cash(p0));
        }
    }
}
