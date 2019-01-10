using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroORM
{
    public class Northwind : DataConnection
    {
        public Northwind(string connectionString) : base(connectionString)
        { }

        public ITable<Category> Categories => GetTable<Category>();

        public ITable<Customer> Customers => GetTable<Customer>();

        public ITable<CustomerCustomerDemo> CustomerCustomerDemos => GetTable<CustomerCustomerDemo>();

        public ITable<CustomerDemographic> CustomerDemographics => GetTable<CustomerDemographic>();

        public ITable<Employee> Employees => GetTable<Employee>();

        public ITable<EmployeeTerritory> EmployeeTerritories => GetTable<EmployeeTerritory>();

        public ITable<Order> Orders => GetTable<Order>();

        public ITable<OrderDetail> OrderDetails => GetTable<OrderDetail>();

        public ITable<Product> Products => GetTable<Product>();

        public ITable<Region> Regions => GetTable<Region>();

        public ITable<Shipper> Shippers => GetTable<Shipper>();

        public ITable<Supplier> Suppliers => GetTable<Supplier>();

        public ITable<Territory> Territories => GetTable<Territory>();
    }
}
