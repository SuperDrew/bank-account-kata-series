using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    class CashTests
    {
        [Test]
        public void CanConstructCash()
        {
            new Cash(1);
        }

        [Test]
        public void CashesWithSameValueAreEqual()
        {
            //Arrange
            var cashValue = 1;
            var cash1 = new Cash(cashValue);
            var cash2 = new Cash(cashValue);

            //Assert
            Assert.That(cash1, Is.EqualTo(cash2));
        }

        [Test]
        public void CanAddCashes()
        {
            //Arrange
            var cashValue = 1;

            var cash1 = new Cash(cashValue);
            var cash2 = new Cash(cashValue);
            var expectedCash = new Cash(cashValue + cashValue);

            //Act
            var actualCash = cash1 + cash2;

            //Assert
            Assert.That(actualCash, Is.EqualTo(expectedCash));
        }
    }
}