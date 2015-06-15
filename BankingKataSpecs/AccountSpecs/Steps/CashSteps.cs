using BankingKata;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs.Steps
{
    [Binding]
    public sealed class CashSteps
    {
        private AccountData accountData;

        public CashSteps(AccountData accountData)
        {
            this.accountData = accountData;
        }

        [Given(@"I have zero cash")]
        public void GivenIHaveZeroCash()
        {
            //Arrange
            accountData.Cash = new Cash(0.0);
        }

        [Given(@"I have null cash")]
        public void GivenIHaveNullCash()
        {
            //Arrange
            accountData.Cash = null;
        }
    }
}