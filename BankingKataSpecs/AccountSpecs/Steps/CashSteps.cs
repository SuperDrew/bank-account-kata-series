using BankingKata;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs.Steps
{
    [Binding]
    public sealed class CashSteps
    {
        private readonly AccountData _accountData;

        public CashSteps(AccountData accountData)
        {
            _accountData = accountData;
        }

        [Given(@"I have zero cash")]
        public void GivenIHaveZeroCash()
        {
            //Arrange
            _accountData.Cash = new Cash(0.0);
        }

        [Given(@"I have null cash")]
        public void GivenIHaveNullCash()
        {
            //Arrange
            _accountData.Cash = null;
        }
    }
}