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
            // ReSharper disable once ObjectCreationAsStatement
            Assert.DoesNotThrow(() => new Cash(1));
        }

        [Test]
        public void CashesWithSameValueAreEqual()
        {
            //Arrange
            const int cashValue = 1;
            var cash1 = new Cash(cashValue);
            var cash2 = new Cash(cashValue);

            //Assert
            Assert.That(cash1, Is.EqualTo(cash2));
        }

        [Test]
        public void CanAddCashes()
        {
            //Arrange
            const int cashValue = 1;

            var cash1 = new Cash(cashValue);
            var cash2 = new Cash(cashValue);
            var expectedCash = new Cash(cashValue + cashValue);

            //Act
            var actualCash = cash1 + cash2;

            //Assert
            Assert.That(actualCash, Is.EqualTo(expectedCash));
        }

        [Test]
        public void CanSubtractCashes()
        {
            //Arrange
            const int cashValue = 1;

            var cash1 = new Cash(cashValue);
            var cash2 = new Cash(cashValue);
            var expectedCash = new Cash(cashValue - cashValue);

            //Act
            var actualCash = cash1 - cash2;

            //Assert
            Assert.That(actualCash, Is.EqualTo(expectedCash));
        }
    }
}