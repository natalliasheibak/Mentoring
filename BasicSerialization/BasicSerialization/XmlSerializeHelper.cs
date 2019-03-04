using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BasicSerialization
{
    public static class XmlSerializeHelper
    {
        public static string Serialize(Catalog catalog)
        {
            var serializer = new XmlSerializer(catalog.GetType());

            var sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, catalog);
            }

            return sb.ToString();
        }

        public static Catalog DeSerialize(string xml)
        {
            var serializer = new XmlSerializer(typeof(Catalog));
            Catalog catalog = null;

            using (TextReader reader = new StringReader(xml))
            {
                catalog = (Catalog)serializer.Deserialize(reader);
            }

            return catalog;
        }
    }
}
