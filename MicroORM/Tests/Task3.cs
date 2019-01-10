using LinqToDB;
using LinqToDB.Data;
using MicroORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class Task3
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
        public void Task3_1()
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = "SomeName";
            newEmployee.LastName = "SomeLastName";

            try
            {
                connection.BeginTransaction();
                newEmployee.EmployeeID = Convert.ToInt32(connection.InsertWithIdentity(newEmployee));
                connection.Territories.Where(t => t.TerritoryDescription.Length <= 5)
                    .Insert(connection.EmployeeTerritories, t => new EmployeeTerritory { EmployeeID = newEmployee.EmployeeID, TerritoryID = t.TerritoryID });
                connection.CommitTransaction();
            }
            catch
            {
                connection.RollbackTransaction();
            }
        }

        [TestMethod]
        public void Task3_2()
        {
            var product = new Product();
            product.CategoryID = 999;
            int updatedCount = connection.Products.Update(p => p.CategoryID == 2, pr => product);

            Console.WriteLine(updatedCount);
        }

        [TestMethod]
        public void Task3_3()
        {
            var products = new List<Product>();
            var product1 = new Product();
            product1.ProductName = "New Car";
            product1.Category = new Category { CategoryName = "NewCategory" };
            product1.Supplier = new Supplier { CompanyName = "New Company Name" };
            var product2 = new Product();
            product2.ProductName = "New Car 1";
            product2.Category = new Category { CategoryName = "NewCategory" };
            product2.Supplier = new Supplier { CompanyName = "New Company Name" };

            products.Add(product1);
            products.Add(product2);

            try
            {
                connection.BeginTransaction();
                foreach (var product in products)
                {
                    var category = connection.Categories.FirstOrDefault(c => c.CategoryName == product.Category.CategoryName);
                    product.CategoryID = category?.CategoryID ?? Convert.ToInt32(connection.InsertWithIdentity(new Category { CategoryName = product.Category.CategoryName }));
                    var supplier = connection.Suppliers.FirstOrDefault(s => s.CompanyName == product.Supplier.CompanyName);
                    product.SupplierID = supplier?.SupplierID ?? Convert.ToInt32(connection.InsertWithIdentity(new Supplier{ CompanyName = product.Supplier.CompanyName }));
                }

                connection.CommitTransaction();
            }
            catch
            {
                connection.RollbackTransaction();
            }
        }
        
        [TestMethod]
        public void Task3_4()
        {
            var updatedRows = connection.OrderDetails.LoadWith(x => x.Order).LoadWith(x => x.Product)
                .Where(x => x.Order.ShippedDate == null).Update(
                     o => new OrderDetail
                     {
                         ProductID = connection.Products.First(x => x.CategoryID == o.Product.CategoryID && x.ProductID > o.ProductID) != null
                             ? connection.Products.First(x => x.CategoryID == o.Product.CategoryID && x.ProductID > o.ProductID).ProductID
                             : connection.Products.First(x => x.CategoryID == o.Product.CategoryID).ProductID
                     });
            Console.WriteLine($"{updatedRows} rows updated");
        }
    }
}
