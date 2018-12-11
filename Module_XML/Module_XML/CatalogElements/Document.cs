using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_XML.CatalogElements
{
    public class Document
    {
        public string Name { get; set; }

        public DateTime PublicationDate { get; set; }

        public int PageNumber { get; set; }

        public string AdditionalNotes { get; set; }
    }
}
