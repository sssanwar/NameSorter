using System.IO;
using System.Collections.Generic;

namespace NameSorter.Data
{
    /// <summary>
    /// Common converter interface so that we can write other converters to process any data format,
    /// for example: XmlDataConverter, JsonDataConverter, or CsvDataConverter.
    /// </summary>
    public interface IDataConverter<T>
    {
        T[] ConvertToList(Stream stream);

        byte[] ConvertToBytes(IEnumerable<T> sourceData);
    }
}
