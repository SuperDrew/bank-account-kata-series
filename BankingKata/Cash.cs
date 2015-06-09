namespace BankingKata
{
    public class Cash
    {
        private readonly double _cash;

        public Cash(double cash)
        {
            _cash = cash;
        }

        public static Cash operator+(Cash casha, Cash cashb)
        {
            return new Cash(casha._cash + cashb._cash);
        }

        public static Cash operator -(Cash casha, Cash cashb)
        {
            return new Cash(casha._cash - cashb._cash);
        }

        protected bool Equals(Cash other)
        {
            return _cash.Equals(other._cash);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cash) obj);
        }

        public override int GetHashCode()
        {
            return _cash.GetHashCode();
        }
    }
}