using System;
using LinqToDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicroORM;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class Task2
    {
        public Northwind connection { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var connection = new Northwind("Northwind");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            connection.Dispose();
        }

        [TestMethod]
        public void Task2_1()
        {
            var products = connection.Products.LoadWith(x => x.Category).LoadWith(x => x.Supplier).ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"Product name: {product.ProductName}; Category: {product.Category?.CategoryName}; Supplier: {product.Supplier?.ContactName}");
            }
        }

        [TestMethod]
        public void Task2_2()
        {
            var employees = connection.Employees;

            foreach (var record in employees.ToList())
            {
                Console.WriteLine($"Name: {record.FirstName} {record.LastName}; Region: {record.Region}");
            }
        }

        [TestMethod]
        public void Task2_3()
        {
            var employees = connection.Employees.ToList();

            var list = from e in employees
                        group e by e.Region into groupTable
                        select new { RegionDescription = groupTable.Key, EmployeesCount = groupTable.Count() };

            foreach (var record in list.ToList())
            {
                Console.WriteLine($"Region: {record.RegionDescription}, number of employees: {record.EmployeesCount}");
            }
        }

        [TestMethod]
        public void Task2_4()
        {
            var employees = connection.Employees;
            var order = connection.Orders;
            var shippers = connection.Shippers;

            var query = from e in employees
                         join o in order on e.EmployeeID equals o.EmployeeID into newTable
                         from nt in newTable
                         join s in shippers on nt.ShipVia equals s.ShipperID into newTable2
                         from nt2 in newTable2
                         select new { e.EmployeeID, e.FirstName, e.LastName, nt2.CompanyName };

            foreach (var record in query.ToList())
            {
                Console.WriteLine($"Employee: {record.FirstName} {record.LastName}, shipper: {record.CompanyName}");
            }
        }
    }
}
