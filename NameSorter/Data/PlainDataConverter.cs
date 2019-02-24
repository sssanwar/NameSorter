using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.Data
{
    public class PlainDataConverter<T> : IDataConverter<T> where T : INameAssignable, new()
    {
        public T[] ConvertToList(Stream stream)
        {
            var list = new List<T>();

            using (var tr = new StreamReader(stream))
            {
                while (tr.Peek() >= 0)
                {
                    var t = new T();

                    try
                    {
                        t.AssignName(tr.ReadLine());
                        list.Add(t);
                    }
                    catch (ArgumentException)
                    {
                        // Skip and do nothing, just continue...
                    }
                }
            }

            return list.ToArray();
        }

        public byte[] ConvertToBytes(IEnumerable<T> sourceData)
        {
            var names = sourceData.Select(s => s.ToString()).ToArray();
            var joined = String.Join(Environment.NewLine, names);
            return System.Text.Encoding.UTF8.GetBytes(joined);
        }
    }
}
