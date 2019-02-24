using System;
using System.IO;
using NameSorter.Data;

namespace NameSorter.IO
{
    public class FilePlainWriter<T> : ChannelWriter<T> where T : INameAssignable, new ()
    {
        public FilePlainWriter(String filePath)
             : base(new PlainDataConverter<T>(), new FileStream(filePath, FileMode.Create))
        {
            // Nothing needed here.
        }
    }
}
