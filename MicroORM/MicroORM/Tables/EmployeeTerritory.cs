using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MicroORM
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [Column, PrimaryKey, Identity]
        public int EmployeeID { get; set; }

        [Column, PrimaryKey, NotNull]
        public string TerritoryID { get; set; }
    }
}
