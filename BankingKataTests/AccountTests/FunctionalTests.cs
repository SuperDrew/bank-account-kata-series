using BankingKata;
using NUnit.Framework;

namespace BankingKataTests.AccountTests
{
    [TestFixture]
    class FunctionalTests
    {
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
        public void DoesWithdrawReduceTotalCorrectly()
        {
            //Arrange
            var cash = new Cash(1);
            var account = new Account(cash);
            var expectedAccount = new Account();

            //Act
            account.Withdraw(cash);

            //Assert
            Assert.That(account, Is.EqualTo(expectedAccount));
        }
    }
}
