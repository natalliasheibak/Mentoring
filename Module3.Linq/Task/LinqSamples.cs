// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;
using System.Text.RegularExpressions;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

        [Category("Aggregation Operators")]
        [Title("Sum - Task1")]
        [Description("This sample returns all customers whose order summ exceeds a specified value")]

        public void Linq1()
        {
            var customers =
                from c in dataSource.Customers
                let sum = c.Orders.Select(x => x.Total).Sum()
                where sum > 500
                select c;


            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Projection Operators")]
        [Title("Select - Task2")]
        [Description("This sample returns all Suppliers for Customers which located in the same country and city")]

        public void Linq21()
        {
            var customers =
                from c in dataSource.Customers
                select new { Customer = c.CompanyName, Suppliers = dataSource.Suppliers.Where(x => x.City.Equals(c.City) && x.Country.Equals(c.Country)).Select(y => y.SupplierName), City = c.City, Country = c.Country};

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Grouping Operators")]
        [Title("Group - Task2")]
        [Description("This sample returns all Suppliers for Customers which located in the same country and city")]

        public void Linq22()
        {
            var customers =
                from c in dataSource.Customers
                join s in dataSource.Suppliers on c.City equals s.City
                group s by new { c.City, c.Country };

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Element Operators")]
        [Title("Any - Task3")]
        [Description("This sample returns all cutomers who has at least one order which total exceeds a specified value")]

        public void Linq3()
        {
            var sum = 100;

            var customers =
                from c in dataSource.Customers
                where c.Orders.Any(x => x.Total > sum)
                select c;

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Set Operators")]
        [Title("Let - Task4")]
        [Description("This sample returns list of customers and the date of their first order")]

        public void Linq4()
        {
            var customers =
                from c in dataSource.Customers
                let d = c.Orders.Select(x => x.OrderDate).OrderBy(x => x).FirstOrDefault()
                where d != default(DateTime)
                select new { Customer = c.CompanyName, FirstOrder = d}; 

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Sorting Operators")]
        [Title("Order - Task5")]
        [Description("This sample returns ordered list of customers and the date of their first order ")]

        public void Linq5()
        {
            var customers =
                from c in dataSource.Customers
                let date = c.Orders.Select(x => x.OrderDate).FirstOrDefault()
                let orderSum = c.Orders.Sum(x => x.Total)
                where date != default(DateTime)
                orderby orderSum
                orderby date.Month
                orderby date.Year
                select new { Customer = c.CompanyName, FirstOrder = date, OrderSumm = orderSum };

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task6")]
        [Description("This sample returns all customers who has not digital postcode, no region or phone code")]

        public void Linq6()
        {
            var customers =
                from c in dataSource.Customers
                where (c.PostalCode != null && !Regex.IsMatch(c.PostalCode, @"^\d+$")) ||
                    string.IsNullOrEmpty(c.Region) ||
                    !c.Phone.StartsWith("(")
                select new { c.CompanyName, c.Phone, c.PostalCode, c.Region};

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Grouping Operators")]
        [Title("Group - Task7")]
        [Description("This sample return group products")]

        public void Linq7()
        {
            var summ = 150;

            var products =
                from group1 in
                (from p in dataSource.Products
                 group p by p.Category)
                select new
                {
                    Category = group1.Key,
                    Group =
                                    from group2 in
                                    (from p in group1
                                     group p by p.UnitsInStock > 0)
                                    select new
                                    {
                                        Category = group2.Key ? "In Stock" : "Out of Stock",
                                        Group =
                                                    from group3 in
                                                    (from p in group2
                                                    group p by p.UnitPrice > summ)
                                                    select new { Category = group2.Key ? "Expensive" : "Cheap", Group = group3}
                                    }
                };

            foreach (var productsByCategory in products)
            {
                ObjectDumper.Write(productsByCategory.Category);
                foreach (var productsByStock in productsByCategory.Group)
                {
                    ObjectDumper.Write(productsByStock.Category);
                    foreach( var productsByPrice in productsByStock.Group)
                    {
                        ObjectDumper.Write(productsByPrice.Category);
                        ObjectDumper.Write(productsByPrice);
                    }
                }
            }
        }

        [Category("Grouping Operators")]
        [Title("Group - Task8")]
        [Description("This sample returns products grouped by their price category")]

        public void Linq8()
        {
            var customers =
                from p in dataSource.Products
                let priceCategory = p.UnitPrice < 50 ? "cheap" : p.UnitPrice > 150 ? "expensive" : "middle"
                group p by priceCategory;

            foreach (var c in customers)
            {
                ObjectDumper.Write(c.Key);
                ObjectDumper.Write(c);
            }
        }

        [Category("Grouping Operators")]
        [Title("Group - Task9")]
        [Description("This sample returns average and summarized income of each city")]

        public void Linq9()
        {
            var citiesSum =
                from p in dataSource.Customers
                from o in p.Orders
                group o by p.City into cityOrders
                select new { City = cityOrders.Key, CitySum = cityOrders.Sum(x => x.Total) };

            var citiesAvg = 
                from p in dataSource.Customers
                group p by p.City into cityOrders
                select new { City = cityOrders.Key, CityAvg = cityOrders.Average(x => x.Orders.Count()) };

            var cityStatistic =
                from sum in citiesSum
                join avg in citiesAvg on sum.City equals avg.City
                select new { City = sum.City, OrderSumm = sum.CitySum, OrderAverage = avg.CityAvg };

            foreach (var c in cityStatistic)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Grouping Operators")]
        [Title("Group - Task10")]
        [Description("This sample returns monthly and annual statistic of customers' activities")]

        public void Linq10()
        {
            var format = new System.Globalization.DateTimeFormatInfo();

            var monthStatistics =
                from p in dataSource.Customers
                from o in p.Orders
                group o by o.OrderDate.Month into monthStatistic
                orderby monthStatistic.Key
                select new { Month = format.GetMonthName(monthStatistic.Key).ToString(), OrderNumber = monthStatistic.Count() };

            var yearStatistics =
                from p in dataSource.Customers
                from o in p.Orders
                group o by o.OrderDate.Year into yearStatistic
                orderby yearStatistic.Key
                select new { Year = yearStatistic.Key, OrderNumber = yearStatistic.Count() };

            var monthYearStatistics =
                from p in dataSource.Customers
                from o in p.Orders
                group o by new { o.OrderDate.Year, o.OrderDate.Month } into yearStatistic
                orderby yearStatistic.Key.Month
                orderby yearStatistic.Key.Year
                select new { Year = yearStatistic.Key.Year, Month = format.GetMonthName(yearStatistic.Key.Month).ToString(), OrderNumber = yearStatistic.Count() };

            foreach (var c in monthStatistics)
            {
                ObjectDumper.Write(c);
            }

            foreach (var c in yearStatistics)
            {
                ObjectDumper.Write(c);
            }

            foreach (var c in monthYearStatistics)
            {
                ObjectDumper.Write(c);
            }
        }
    }
}
