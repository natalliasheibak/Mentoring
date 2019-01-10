using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Column, PrimaryKey, Identity]
        public int SupplierID { get; set; }

        [Column, NotNull]
        public string CompanyName { get; set; }

        [Column]
        public string ContactName { get; set; }

        [Column]
        public string ContactTitle { get; set; }

        [Column]
        public string Address { get; set; }

        [Column]
        public string City { get; set; }

        [Column]
        public string Region { get; set; }

        [Column]
        public string PostalCode { get; set; }

        [Column]
        public string Country { get; set; }

        [Column]
        public string Phone { get; set; }

        [Column]
        public string Fax { get; set; }

        [Column]
        public string HomePage { get; set; }

        [Association(ThisKey = nameof(SupplierID), OtherKey = nameof(Product.SupplierID), CanBeNull = true)]
        public IEnumerable<Product> Products { get; set; }
    }
}
