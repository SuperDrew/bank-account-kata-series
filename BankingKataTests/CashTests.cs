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
            new Cash(8);
        }

        [Test]
        public void CashesWithSameValueAreEqual()
        {
            //Arrange
            var cashValue = 3.4;
            var cash1 = new Cash(cashValue);
            var cash2 = new Cash(cashValue);

            //Assert
            Assert.That(cash1, Is.EqualTo(cash2));
        }
    }
}