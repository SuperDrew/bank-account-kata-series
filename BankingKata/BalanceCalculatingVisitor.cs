namespace BankingKata
{
    public class BalanceCalculatingVisitor : ITransactionVisitor<Money>
    {
        public Money Visit(ITransaction currentTransaction, Money balance)
        {
            return currentTransaction.ApplyTo(balance);
        }
    }
}