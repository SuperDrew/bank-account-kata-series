using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingKata;
using NSpec;

namespace BankingKataNSpec
{
    public class Test : nspec
    {
        private void foo()
        {
            Account account = new Account();
            account.should_be_null();
            account.should_not_be_null();
        }
    }
}
