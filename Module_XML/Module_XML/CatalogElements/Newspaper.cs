using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_XML.CatalogElements
{
    public class Newspaper : Document
    {
        public string City { get; set; }

        public string Publisher { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public string ISSN { get; set; }
    }
}
