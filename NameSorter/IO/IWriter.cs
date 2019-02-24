using System;
using System.IO;
using System.Collections.Generic;

namespace NameSorter.IO
{
    public interface IWriter<T>
    {
        byte[] Write(IEnumerable<T> sourceData);
    }
}
