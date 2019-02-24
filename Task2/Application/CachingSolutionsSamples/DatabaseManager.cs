using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public class DatabaseManager
    {
        private ICache cache;

        public DatabaseManager(ICache cache)
        {
            this.cache = cache;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            Console.WriteLine("Get Employees");

            var user = Thread.CurrentPrincipal.Identity.Name;
            var employees = cache.Get<Employee>(user);

            if (employees == null)
            {
                Console.WriteLine("From DB");

                using (var dbContext = new Northwind())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;
                    employees = dbContext.Employees.ToList();
                    cache.Set(user, employees);
                }
            }

            return employees;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            Console.WriteLine("Get Customers");

            var user = Thread.CurrentPrincipal.Identity.Name;
            var customers = cache.Get<Customer>(user);

            if (customers == null)
            {
                Console.WriteLine("From DB");

                using (var dbContext = new Northwind())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;
                    customers = dbContext.Customers.ToList();
                    cache.Set(user, customers);
                }
            }

            return customers;
        }

        public IEnumerable<Category> GetCategories()
        {
            Console.WriteLine("Get Categories");

            var user = Thread.CurrentPrincipal.Identity.Name;
            var categories = cache.Get<Category>(user);

            if (categories == null)
            {
                Console.WriteLine("From DB");

                using (var dbContext = new Northwind())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;
                    categories = dbContext.Categories.ToList();
                    cache.Set(user, categories);
                }
            }

            return categories;
        }
    }
}
