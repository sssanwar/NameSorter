using System;
using System.Collections.Generic;

namespace NameSorter.Data
{
    /// <summary>
    /// A comparer that prioritise last name first, and then given names.
    /// </summary>
    public class PersonLastNameFirstComparer : IComparer<Person>
    {
        private readonly bool isReverse = false;

        public PersonLastNameFirstComparer() { }

        public PersonLastNameFirstComparer(bool isReverse) => this.isReverse = isReverse;

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null && y != null)
                return -1;

            if (x != null && y == null)
                return 1;

            var lastNameResult = String.Compare(x.LastName, y.LastName);
            if (lastNameResult != 0)
            {
                return lastNameResult * (isReverse ? -1 : 1);
            }

            return String.Compare(x.GivenNames, y.GivenNames) * (isReverse ? -1 : 1);
        }
    }
}