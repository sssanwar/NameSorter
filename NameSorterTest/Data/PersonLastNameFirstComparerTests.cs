using System;
using Xunit;
using NameSorter.Data;

namespace NameSorterTest.Collections
{
    public class PersonLastNameFirstComparerTests : IClassFixture<PersonLastNameFirstComparerFixture>
    {
        private readonly PersonLastNameFirstComparerFixture fixture;

        public PersonLastNameFirstComparerTests(PersonLastNameFirstComparerFixture fixture)
        {
            // We may not need a fixture with a very simple class.
            // This is only for demonstrating its usage...
            this.fixture = fixture;
        }

        [Fact]
        public void Compare_NullValues_CorrectResultsReturned()
        {
            Assert.True(fixture.Comparer.Compare(null, new Person("a")) < 0);
            Assert.True(fixture.Comparer.Compare(new Person("a"), null) > 0);
            Assert.True(fixture.Comparer.Compare(null, null) == 0);
        }

        [Fact]
        public void Compare_PersonNames_CorrectResultsReturned()
        {
            Assert.True(fixture.Comparer.Compare(new Person("c"), new Person("b a")) > 0);
            Assert.True(fixture.Comparer.Compare(new Person("  a b c"), new Person("b a")) > 0);
            Assert.True(fixture.Comparer.Compare(new Person("a b c"), new Person("b c c")) < 0);
            Assert.True(fixture.Comparer.Compare(new Person("a bc"), new Person("a bb")) > 0);
            Assert.True(fixture.Comparer.Compare(new Person("a  a"), new Person("a a")) == 0);
        }
    }
}
