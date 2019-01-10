using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Column, PrimaryKey, Identity]
        public int OrderID { get; set; }

        [Column, PrimaryKey, NotNull]
        public int ProductID { get; set; }

        [Column, NotNull]
        public decimal UnitPrice { get; set; }

        [Column, NotNull]
        public int Quantity { get; set; }

        [Column, NotNull]
        public decimal Discount { get; set; }

        [Association(ThisKey = nameof(ProductID), OtherKey = nameof(MicroORM.Product.ProductID))]
        public Product Product { get; set; }

        [Association(ThisKey = nameof(OrderID), OtherKey = nameof(MicroORM.Order.OrderID))]
        public Order Order { get; set; }
    }
}
