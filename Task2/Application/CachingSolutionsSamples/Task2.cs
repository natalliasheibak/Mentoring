using CachingSolutionsSamples;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class Task2
    {
        [TestMethod]
        public void CategoryMemoryCache()
        {
            var categoryManager = new DatabaseManager(new DBMemoryCache("Cache_Category"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCategories().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void EmployeeMemoryCache()
        {
            var categoryManager = new DatabaseManager(new DBMemoryCache("Cache_Employee"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEmployees().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CustomerMemoryCache()
        {
            var categoryManager = new DatabaseManager(new DBMemoryCache("Cache_Customer"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCustomers().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CategoryRedisCache()
        {
            var categoryManager = new DatabaseManager(new RedisCache("localhost", "Cache_Category"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCategories().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void EmployeeRedisCache()
        {
            var categoryManager = new DatabaseManager(new RedisCache("localhost", "Cache_Employee"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEmployees().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CustomerRedisCache()
        {
            var categoryManager = new DatabaseManager(new RedisCache("localhost", "Cache_Customer"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCustomers().Count());
                Thread.Sleep(100);
            }
        }
    }
}
