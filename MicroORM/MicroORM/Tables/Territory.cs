using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    [Table("Territories")]
    public class Territory
    {
        [Column, PrimaryKey, NotNull]
        public string TerritoryID { get; set; }

        [Column, NotNull]
        public string TerritoryDescription { get; set; }

        [Column, NotNull]
        public int RegionID { get; set; }
    }
}
