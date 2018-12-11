using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_XML.CatalogElements
{
    public class Patent : Document
    {
        public string Inventor { get; set; }

        public string Country { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}
