using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table]
    public class CustomerCustomerDemo
    {
        [Column, PrimaryKey, NotNull]
        public string CustomerID { get; set; }

        [Column, PrimaryKey, NotNull]
        public string CustomerTypeID { get; set; }
    }
}
