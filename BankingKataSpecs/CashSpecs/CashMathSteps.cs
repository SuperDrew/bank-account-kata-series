using BankingKata;
using BankingKataSpecs.AccountSpecs;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.CashSpecs
{
    [Binding]
    public sealed class CashMathSteps
    {
        private AccountData accountData;

        public CashMathSteps(AccountData accountData)
        {
            this.accountData = accountData;
        }

        [Given(@"I have (.*) cash")]
        public void GivenIhaveCash(int p0)
        {
            accountData.Cash = new Cash(1.0);
        }

        [When(@"I add (.*) cash")]
        public void WhenIAddCash(int p0)
        {
            accountData.Cash += new Cash(p0);
        }
        
        [When(@"I subtract (.*) cash")]
        public void WhenISubtractCash(int p0)
        {
            accountData.Cash -= new Cash(p0);
        }

        [Then(@"I should have (.*) cash")]
        public void ThenIShouldHaveCash(int p0)
        {
            //Arrange
            var expectedCash = new Cash(p0);

            //Assert
            Assert.That(accountData.Cash, Is.EqualTo(expectedCash));
        }


    }
}
