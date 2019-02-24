using System;
using System.Collections.Generic;
using System.IO;
using NameSorter.Data;

namespace NameSorter.IO
{
    public class ChannelWriter<T> : IWriter<T>
    {
        private readonly IDataConverter<T> converter;
        private readonly Stream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NameSorter.IO.ChannelWriter`1"/> class.
        /// </summary>
        /// <param name="converter">The converter type to use.</param>
        /// <param name="stream">The output stream to use.</param>
        public ChannelWriter(IDataConverter<T> converter, Stream stream)
        {
            this.converter = converter;
            this.stream = stream;
        }

        /// <summary>
        /// Write the specified sourceData to a stream that later can be output to any channel.
        /// </summary>
        /// <returns>The stream containing the names.</returns>
        /// <param name="sourceData">Source data.</param>
        public byte[] Write(IEnumerable<T> sourceData)
        {
            using (var sw = new StreamWriter(stream) { AutoFlush = true })
            {
                var bytes = converter.ConvertToBytes(sourceData);
                sw.Write(System.Text.Encoding.UTF8.GetString(bytes));
                return bytes;
            }
        }
    }
}
