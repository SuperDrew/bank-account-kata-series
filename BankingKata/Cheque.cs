using System;

namespace BankingKata
{
    public class Cheque
    {
        private readonly int _chequeNumber;
        private readonly Money _amount;

        public Cheque(int chequeNumber, Money amount)
        {
            _chequeNumber = chequeNumber;
            _amount = amount;
        }
    }
}