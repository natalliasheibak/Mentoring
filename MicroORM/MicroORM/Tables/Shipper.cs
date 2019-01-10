using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("Shippers")]
    public class Shipper
    {
        [Column, PrimaryKey, Identity]
        public int ShipperID { get; set; }

        [Column, NotNull]
        public string CompanyName { get; set; }

        [Column]
        public string Phone { get; set; }
    }
}
