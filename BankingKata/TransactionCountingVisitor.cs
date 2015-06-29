namespace BankingKata
{
    public class TransactionCountingVisitor : ITransactionVisitor<int>
    {
        public int Visit(ITransaction currentTransaction, int argument)
        {
            return argument + 1;
        }
    }
}