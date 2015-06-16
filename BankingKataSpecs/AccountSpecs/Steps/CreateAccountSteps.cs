﻿using System;
using BankingKata;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs.Steps
{
    [Binding]
    public sealed class CreateAccountSteps
    {
        private readonly AccountData _accountData;

        public CreateAccountSteps(AccountData accountData)
        {
            _accountData = accountData;
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
            _accountData.Account = new Account();
        }

        [Then(@"Creating an account should throw an argument null exception")]
        public void ThenCreatingAnAccountShouldThrowAnArgumentNullException()
        {
            // Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new Account(_accountData.Cash));
        }

        [Given(@"I create an account with (.*) cash")]
        public void GivenICreateAnAccountWithCash(int p0)
        {
            //Act
            _accountData.Account = new Account(new Cash(p0));
        }
    }
}
