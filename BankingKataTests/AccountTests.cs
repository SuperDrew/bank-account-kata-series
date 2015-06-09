using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void CanDepositCash()
        {
            //Arrange
            var account = new Account();
            var cash = new Cash(10.45);
            
            //Act
            account.Deposit(cash);
        }
    }
}
