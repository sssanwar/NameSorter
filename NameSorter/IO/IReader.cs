using System.Collections.Generic;

namespace NameSorter.IO
{
    public interface IReader<T>
    {
        T[] Read();
    }
}
