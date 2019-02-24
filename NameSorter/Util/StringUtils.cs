using System;
using System.Linq;

namespace NameSorter.Data.Util
{
    public static class StringUtils
    {
        public const char SPACE = ' ';

        /// <summary>
        /// Normalises the white space. That is removing all extraneous white spaces.
        /// </summary>
        /// <returns>Normalised string.</returns>
        /// <param name="aString">A string.</param>
        public static String NormaliseWhiteSpace(String aString)
        {
            return String.Join(SPACE, aString.Split(SPACE).Where(s => !String.IsNullOrWhiteSpace(s)));
        }
    }
}
