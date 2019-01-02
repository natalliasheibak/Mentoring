using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL
{
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderDetail> Details { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string CustomerID { get; set; }

        public DateTime ShippedDate { get; set; }
    }

    public enum OrderStatus
    {
        New,
        InProgress,
        Shipped
    }
}
