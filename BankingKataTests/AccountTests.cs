using System;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    class AccountTests
    {
        [Test]
        public void CanConstructAccount()
        {
            new Account();
        }

        [Test]
        public void CanConstructAccountWithCash()
        {
            //Arrange
            var cash = new Cash(1);
            
            //Act
            new Account(cash);
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
        public void CantCreateAccountWithNullCash()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Account(null));
        }

        [Test]
        public void NewAccountHasZeroCash()
        {
            //Arrange/Act
            var zeroCash = new Cash(0.0);
            var account = new Account();
            var expectedAccount = new Account(zeroCash);
            
            //Assert
            Assert.That(account, Is.EqualTo(expectedAccount));
        }

        [Test]
        public void DoesDepositAddToTotalCorrectly()
        {
            //Arrange
            var cash = new Cash(1);
            var account = new Account();
            var expectedAccount = new Account(cash);

            //Act
            account.Deposit(cash);

            //Assert
            Assert.That(account, Is.EqualTo(expectedAccount));
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
