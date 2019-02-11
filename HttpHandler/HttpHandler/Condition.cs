using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpHandler
{
    public class Condition
    {
        public string CustomerID { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }
    }
}