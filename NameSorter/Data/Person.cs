using System;
using NameSorter.Data.Util;

namespace NameSorter.Data
{
    public class Person : INameAssignable
    {
        public String LastName { get; private set; }
        public String GivenNames { get; private set; }
        public bool IsNameAssigned { get; private set; }

        public Person() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NameSorter.PersonName"/> class, and assign the name.
        /// </summary>
        /// <param name="fullName">Full name.</param>
        public Person(String fullName)
        {
            AssignName(fullName);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:NameSorter.Data.PersonName"/>.
        /// A null value is returned if name is not yet assigned.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:NameSorter.Data.PersonName"/>.</returns>
        public override string ToString() => !IsNameAssigned ? null : GivenNames + StringUtils.SPACE + LastName;

        /// <summary>
        /// Parse the full name and assign the names to properties.
        /// </summary>
        /// <param name="fullName">Raw full name.</param>
        public void AssignName(String fullName)
        {
            if (IsNameAssigned)
                throw new InvalidAssignmentException();

            if (String.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be null or whitespace only.", nameof(fullName));

            var normalisedName = StringUtils.NormaliseWhiteSpace(fullName);
            var lastSpaceIndex = normalisedName.LastIndexOf(StringUtils.SPACE);

            // If space is not found in the name,
            // then treat the whole fullname as last name.
            if (lastSpaceIndex < 0)
            {
                this.LastName = normalisedName;
                this.GivenNames = null;
            }
            else
            {
                this.LastName = normalisedName.Substring(lastSpaceIndex + 1);
                this.GivenNames = normalisedName.Substring(0, lastSpaceIndex);
            }

            this.IsNameAssigned = true;
        }
    }
}
