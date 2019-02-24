using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using NameSorter.Data;

namespace NameSorterTest.Collections
{
    public class PlainDataConverterTests
    {
        [Fact]
        public void ConvertToList_Stream_CorrectPersonNameListReturned()
        {
            var content = string.Join(System.Environment.NewLine, new List<string>()
            {
                " a  b",
                "b c  ",
                "c d"
            });

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var list = new PlainDataConverter<Person>().ConvertToList(ms);
                Assert.Equal("a b", list[0].ToString());
                Assert.Equal("b c", list[1].ToString());
                Assert.Equal("c d", list[2].ToString());
            }
        }

        [Fact]
        public void ConvertToBytes_PersonNameList_CorrectBytesReturned()
        {
            var list = new List<Person>
            {
                new Person("a b "),
                new Person(" b c"),
                new Person("c   d")
            };

            byte[] bytes = new PlainDataConverter<Person>().ConvertToBytes(list);
            using (var sr = new StreamReader(new MemoryStream(bytes)))
            {
                Assert.Equal("a b", sr.ReadLine());
                Assert.Equal("b c", sr.ReadLine());
                Assert.Equal("c d", sr.ReadLine());
            }
        }
    }
}
