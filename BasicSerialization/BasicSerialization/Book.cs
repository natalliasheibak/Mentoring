using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicSerialization
{
    public class Book
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlElement("isbn")]
        public string ISBN { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public Genre Genre { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlIgnore]
        public DateTime Publish_Date { get; set; }

        [XmlElement("publish_date")]
        public string PublisDateString
        {
            get
            {
                return Publish_Date.ToString("yyyy-mm-dd");
            }

            set
            {
                Publish_Date = DateTime.Parse(value);
            }
        }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlIgnore]
        public DateTime Registration_Date { get; set; }

        [XmlElement("registration_date")]
        public string RegistrationDateString
        {
            get
            {
                return Registration_Date.ToString("yyyy-mm-dd");
            }

            set
            {
                Registration_Date = DateTime.Parse(value);
            }
        }
    }

    public enum Genre
    {
        [XmlEnum]
        Computer,

        [XmlEnum]
        Fantasy,

        [XmlEnum]
        Romance,

        [XmlEnum]
        Horror,

        [XmlEnum("Science Fiction")]
        SciFi
    }
}
