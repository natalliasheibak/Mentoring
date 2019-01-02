using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL
{
    public class Customer
    {
        public string CustomerID { get; set; }

        public List<Product> BoughtProducts { get; set; }
    }
}
