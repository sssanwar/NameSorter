using System;
using Xunit;
using NameSorter.Data.Util;

namespace NameSorterTest.Util
{
    public class StringUtilsTests
    {
        [Fact]
        public void NormaliseWhiteSpace_StringWithWhiteSpace_NormalisedString()
        {
            Assert.Equal("a a a", StringUtils.NormaliseWhiteSpace("  a    a  a  "));
        }
    }
}
