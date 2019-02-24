using System;
using System.IO;
using Xunit;
using NameSorter.Data;
using NameSorter.IO;

namespace NameSorterTest.IO
{
    public class FilePlainReaderTests
    {
        [Fact]
        public void Read_Stream_CorrectList()
        {
            // Get path of output dir
            var unsortedFilePath = Path.Combine(AppContext.BaseDirectory, "unsorted-names-list.txt");

            // Create reader and read to list
            var reader = new FilePlainReader<Person>(unsortedFilePath);
            var list = reader.Read();

            // Verify list, this is unsorted yet
            Assert.Equal("Parsons", list[0].LastName);
            Assert.Equal("Lewis",   list[1].LastName);
            Assert.Equal("Archer",  list[2].LastName);
            Assert.Equal("Ritter",  list[10].LastName);
        }

        [Fact]
        public void New_NonExistentFile_ThrowFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => new FilePlainReader<Person>("this.file.doesnt.exist"));
        }
    }
}