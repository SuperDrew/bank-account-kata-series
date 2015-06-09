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
    }
}