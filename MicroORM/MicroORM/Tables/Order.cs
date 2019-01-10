using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("Orders")]
    public class Order
    {
        [Column, PrimaryKey, Identity]
        public int OrderID { get; set; }

        [Column]
        public string CustomerID { get; set; }

        [Column]
        public int EmployeeID { get; set; }

        [Column]
        public DateTime OrderDate { get; set; }

        [Column]
        public DateTime RequiredDate { get; set; }

        [Column]
        public DateTime ShippedDate { get; set; }

        [Column]
        public int ShipVia { get; set; }

        [Column]
        public decimal Freight { get; set; }

        [Column]
        public string ShipName { get; set; }

        [Column]
        public string ShipAddress { get; set; }

        [Column]
        public string ShipCity { get; set; }

        [Column]
        public string ShipRegion { get; set; }

        [Column]
        public string ShipPostalCode { get; set; }

        [Column]
        public string ShipCountry { get; set; }

        [Association(ThisKey = nameof(EmployeeID), OtherKey = nameof(MicroORM.Employee.EmployeeID), CanBeNull = true)]
        public Employee Employee { get; set; }

        [Association(ThisKey = nameof(ShipVia), OtherKey = nameof(MicroORM.Shipper.ShipperID), CanBeNull = true)]
        public Shipper Shipper { get; set; }

        [Association(ThisKey = nameof(CustomerID), OtherKey = nameof(MicroORM.Customer.CustomerID), CanBeNull = true)]
        public Customer Customer { get; set; }
    }
}
