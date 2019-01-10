using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MicroORM
{
    [Table("Categories")]
    public class Category
    {
        [Column, PrimaryKey, Identity]
        public int CategoryID { get; set; }

        [Column, NotNull]
        public string CategoryName { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public byte[] Picture { get; set; }

        [Association(ThisKey = nameof(CategoryID), OtherKey = nameof (Product.CategoryID))]
        public IEnumerable<Product> Products { get; set; }
    }
}
