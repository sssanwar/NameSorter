using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using NameSorter.IO;
using NameSorter.Data;

namespace NameSorterTest.IO
{
    public class ChannelWriterTests
    {
        [Fact]
        public void Write_NameList_NamesPrinted()
        {
            using (var ms = new MemoryStream())
            {
                var cw = new ChannelWriter<Person>(new PlainDataConverter<Person>(), ms);
                var bytes = cw.Write(new List<Person>
                {
                    new Person("a b"),
                    new Person(" bb cc"),
                    new Person(" dd e")
                });

                var written = System.Text.Encoding.UTF8.GetString(bytes).Split(Environment.NewLine);
                Assert.Equal("a b", written[0]);
                Assert.Equal("bb cc", written[1]);
                Assert.Equal("dd e", written[2]);
            }
        }
    }
}
