using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("CustomerDemographics")]
    public class CustomerDemographic
    {
        [Column, PrimaryKey, NotNull]
        public string CustomerTypeID { get; set; }

        [Column]
        public string CustomerDesc { get; set; }
    }
}
