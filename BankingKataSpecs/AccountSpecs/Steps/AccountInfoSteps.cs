using System.Globalization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BankingKataSpecs.AccountSpecs.Steps
{
    [Binding]
    public sealed class AccountInfoSteps
    {
        private readonly AccountData _accountData;

        public AccountInfoSteps(AccountData accountData)
        {
            _accountData = accountData;
        }

        [Then(@"The account information should contain (.*) cash")]
        public void ThenTheAccountInformationShouldContainCash(int p0)
        {
            //Assert
            Assert.That(_accountData.Account.ToString(), Is.StringContaining(p0.ToString(CultureInfo.CurrentCulture)));
        }
    }
}