using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Predica.CostkillerLib.Model.Exceptions;

namespace Predica.CostkillerLib.Extensions
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
