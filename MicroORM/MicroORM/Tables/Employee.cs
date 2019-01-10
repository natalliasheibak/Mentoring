using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MicroORM
{
    [Table("Employees")]
    public class Employee
    {
        [Column, PrimaryKey, Identity]
        public int EmployeeID { get; set; }

        [Column, NotNull]
        public string LastName { get; set; }

        [Column, NotNull]
        public string FirstName { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string TitleOfCourtesy { get; set; }

        [Column]
        public DateTime BirthDate { get; set; }

        [Column]
        public DateTime HireDate { get; set; }

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
        public string HomePhone { get; set; }

        [Column]
        public string Extension { get; set; }

        [Column]
        public string Notes { get; set; }

        [Column]
        public string PhotoPath { get; set; }

        [Column]
        public int ReportsTo { get; set; }

        [Association(ThisKey = nameof(EmployeeID), OtherKey = nameof(Employee.ReportsTo), CanBeNull = true)]
        public IEnumerable<Employee> Employees { get; set; }
    }
}
