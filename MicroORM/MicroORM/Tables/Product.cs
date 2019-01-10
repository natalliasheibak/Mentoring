using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("Products")]
    public class Product
    {
        [Column, PrimaryKey, Identity]
        public int ProductID { get; set; }

        [Column, NotNull]
        public string ProductName { get; set; }

        [Column]
        public int SupplierID { get; set; }

        [Column]
        public int CategoryID { get; set; }

        [Column]
        public string QuantityPerUnit { get; set; }

        [Column]
        public decimal UnitPrice { get; set; }

        [Column]
        public int UnitsInStock { get; set; }

        [Column]
        public int UnitsOnOrder { get; set; }

        [Column]
        public int ReorderLevel { get; set; }

        [Column, NotNull]
        public bool Discontinued { get; set; }

        [Association(ThisKey = nameof(CategoryID), OtherKey = nameof(MicroORM.Category.CategoryID), CanBeNull = true)]
        public Category Category { get; set; }

        [Association(ThisKey = nameof(SupplierID), OtherKey = nameof(MicroORM.Supplier.SupplierID), CanBeNull = true)]
        public Supplier Supplier { get; set; }
    }
}
