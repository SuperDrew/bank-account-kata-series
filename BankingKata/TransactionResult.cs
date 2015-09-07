namespace BankingKata
{
    public class TransactionResult
    {
        private readonly bool _success;

        public TransactionResult(bool success)
        {
            _success = success;
        }

        protected bool Equals(TransactionResult other)
        {
            return _success.Equals(other._success);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TransactionResult) obj);
        }

        public override int GetHashCode()
        {
            return _success.GetHashCode();
        }

        public static bool operator ==(TransactionResult left, TransactionResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TransactionResult left, TransactionResult right)
        {
            return !Equals(left, right);
        }
    }
}