using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_XML.CatalogElements
{
    public class Book : Document
    {
        public string Author { get; set; }

        public string City { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }
    }
}
