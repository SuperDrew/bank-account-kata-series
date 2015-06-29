using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BankingKataTests
{
    public class ConcatenateTests
    {
        [Test]
        public void AggregateSum()
        {
            var foo = new List<int> { 1, 2, 3, 4 };

            var total = foo.Aggregate(1, (sum, current) => sum + current);

            Assert.That(total, Is.EqualTo(11));
        }

        [Test]
        public void AggregateConcatenate()
        {
            var foo = new List<string> { "f", "o", "o" };

            var total = foo.Aggregate((sum, current) => sum + current);

            Assert.That(total, Is.EqualTo("foo"));
        }

        [Test]
        public void AggregateConcatenateWithSeed()
        {
            var foo = new List<string> { "b", "a", "r" };

            var total = foo.Aggregate("foo", (sum, current) => sum + current);

            Assert.That(total, Is.EqualTo("foobar"));
        }
    }
}
