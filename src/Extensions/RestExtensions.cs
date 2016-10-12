using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Predica.Costkiller.Core.Model.Exceptions;

namespace Predica.Costkiller.Core.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader stringReader = new StringReader(await content.ReadAsStringAsync());
                return (T)serializer.Deserialize(stringReader);
            }
            catch (InvalidOperationException ex)
            {
                throw new SerializerException(ex.Message, await content.ReadAsStringAsync());
            }
        }
    }
}
