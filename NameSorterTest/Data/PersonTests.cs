using System;
using Xunit;
using NameSorter.Data;

namespace NameSorterTest
{
    public class PersonTests
    {
        [Fact]
        public void Person_NullValue_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Person(null));
            Assert.Throws<ArgumentException>(() => new Person("  "));
        }

        [Theory]
        [InlineData("a b", "a", "b")]
        [InlineData("b", null, "b")]
        [InlineData("  a b  ", "a", "b")]
        public void AssignName_FullName_NameAssigned(String fullName, String expectedGivenNames, String expectedLastName)
        {
            var person = new Person();
            person.AssignName(fullName);
            Assert.True(person.LastName == expectedLastName && person.GivenNames == expectedGivenNames && person.IsNameAssigned);
        }

        [Fact]
        public void AssignName_Twice_ThrowException()
        {
            var person = new Person();
            person.AssignName("a a");
            Assert.Throws<InvalidAssignmentException>(() => person.AssignName("b b"));
        }

        [Fact]
        public void ToString_RawFullName_NormalisedName()
        {
            Assert.Equal("a b", new Person("  a  b").ToString());
        }
    }
}
