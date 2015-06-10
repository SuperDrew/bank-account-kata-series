using System;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests.AccountTests
{
    class CanTests
    {
        [Test]
        public void CanConstructAccount()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.DoesNotThrow(() => new Account());
        }

        [Test]
        public void CanConstructAccountWithCash()
        {
            //Arrange
            var cash = new Cash(1);
            
            //Act/Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.DoesNotThrow(() => new Account(cash));
        }

        [Test]
        public void CantCreateAccountWithNullCash()
        {
            //Assert
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new Account(null));
        }

        [Test]
        public void CanDepositCash()
        {
            //Arrange
            var account = new Account();
            var cash = new Cash(1);
            
            //Act
            account.Deposit(cash);
        }

        [Test]
        public void CanWithdrawCash()
        {
            //Arrange
            var account = new Account();
            var cash = new Cash(1);

            //Act
            account.Withdraw(cash);
        }
    }
}