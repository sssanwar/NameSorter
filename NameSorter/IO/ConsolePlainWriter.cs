using System;
using NameSorter.Data;

namespace NameSorter.IO
{
    public class ConsolePlainWriter<T> : ChannelWriter<T> where T : INameAssignable, new ()
    {
        public ConsolePlainWriter() : base(new PlainDataConverter<T>(), Console.OpenStandardOutput())
        {
            // Nothing needed here.
        }
    }
}
