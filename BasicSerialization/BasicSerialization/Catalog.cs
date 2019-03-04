using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicSerialization
{
    [XmlRoot("catalog", Namespace = "http://library.by/catalog", IsNullable = false)]
    public class Catalog
    {
        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlAttribute("date")]
        public string DateString
        {
            get
            {
                return Date.ToString("yyyy-mm-dd");
            }

            set
            {
                Date = DateTime.Parse(value);
            }
        }

        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}
