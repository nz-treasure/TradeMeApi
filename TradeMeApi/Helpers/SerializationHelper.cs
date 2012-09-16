using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace BadgerSoft.TradeMe.Api.Helpers
{
    public static class SerializationHelper
    {
        public static string Serialize<T>(T toSerialize)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var sw = new StringWriterWithEncoding(Encoding.UTF8))
                using (var writer = XmlWriter.Create(sw))
                {
                    serializer.Serialize(writer, toSerialize);
                    return sw.ToString();
                }
            }
            catch
            {
#if DEBUG
                throw;
#endif
                return string.Empty;
            }
        }

        public static T Deserialize<T>(string serialized)
        {
            try
            {
                var settings = new XmlReaderSettings { CheckCharacters = false };

                using (var sr = new StringReader(serialized))
                using (var reader = XmlReader.Create(sr, settings))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch
            {
#if DEBUG
                throw;
#endif
                return default(T);
            }
        }
    }
}
