using System;
using NameSorter.Data;

namespace NameSorterTest.Collections
{
    public class PersonLastNameFirstComparerFixture
    {
        public PersonLastNameFirstComparer Comparer { get; private set; }

        public PersonLastNameFirstComparerFixture()
        {
            Comparer = new PersonLastNameFirstComparer();
        }
    }
}
