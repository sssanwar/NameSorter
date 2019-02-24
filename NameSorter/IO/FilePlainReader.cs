using System;
using System.Collections.Generic;
using System.IO;
using NameSorter.Data;

namespace NameSorter.IO
{
    /// <summary>
    /// A reader that reads plain text and returns a List of T.
    /// </summary>
    public class FilePlainReader<T> : IReader<T> where T : INameAssignable, new()
    {
        private readonly String path;
        private readonly IDataConverter<T> converter;

        public FilePlainReader(String path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            this.path = path;
            this.converter = new PlainDataConverter<T>();
        }

        public T[] Read()
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                return converter.ConvertToList(fs);
            }
        }
    }
}
