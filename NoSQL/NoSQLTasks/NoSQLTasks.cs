using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;

namespace NoSQLTasks
{
    [TestClass]
    public class NoSQLTasks
    {
        public IMongoDatabase TestDataBase { get; set; }

        [ClassInitialize]
        public static void ClassInitialize()
        {
            MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017/?gssapiServiceName=mongodb");

            IMongoDatabase TestDataBase = dbClient.GetDatabase("test");
        }

        [TestMethod]
        public void Task1()
        {
            var things = TestDataBase.GetCollection<Book>("library");

            var books = new List<Book>();
            books.Add(new Book("Hobbit", "Tolkien", 5, new List<string> { "fantasy" }, 2014));
            books.Add(new Book("Lord of the rings", "Tolkien", 3, new List<string> { "fantasy" }, 2015));
            books.Add(new Book("Kolobok", null, 10, new List<string> { "kids" }, 2000));
            books.Add(new Book("Repka", null, 11, new List<string> { "kids" }, 2000));
            books.Add(new Book("Dyadya Stiopa", "Mihalkov", 1, new List<string> { "kids" }, 2001));

            things.InsertMany(books);

            var resultDoc = things.Find(new BsonDocument()).ToList();
            foreach (var item in resultDoc)
            {
                Console.WriteLine(item.Name);
            }
        }

        [TestMethod]
        public void Task2()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");


            var result = bookCollection.Find("{ Count: {'$gt': 1} }")
                .Project("{ Name: 1, _id: 0 }")
                .Sort("{ Name: 1 }")
                .Limit(3);

            foreach (var book in result.ToList())
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine($"Count = {result.CountDocuments()}");
        }

        [TestMethod]
        public void Task3()
        {
            var bookCollection = TestDataBase.GetCollection<Book>("library");

            var result = bookCollection.Find(new BsonDocument())
                .Sort("{ Count: -1 }")
                .First();


            Console.WriteLine($"Max = {result.Count}");

            result = bookCollection.Find(new BsonDocument())
                .Sort("{ Count: 1 }")
                .First();


            Console.WriteLine($"Min = {result.Count}");
        }

        [TestMethod]
        public void Task4()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");

            var result = bookCollection.Distinct<string>("Author", new BsonDocument()).ToList();

            foreach (var author in result.ToList())
            {
                Console.WriteLine(author.ToString());
            }
        }

        [TestMethod]
        public void Task5()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");
            var result = bookCollection.Find("{ Author: { $exists: false } }").ToList();

            foreach (var author in result)
            {
                Console.WriteLine(author.ToString());
            }
        }

        [TestMethod]
        public void Task6()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");

            bookCollection.UpdateMany(new BsonDocument(), "{ $inc: { Count: 1 }}") ;
            var resultDoc = bookCollection.Find(new BsonDocument()).ToList();

            foreach (var author in resultDoc)
            {
                Console.WriteLine(author.ToString());
            }
        }

        [TestMethod]
        public void Task7()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");

            bookCollection.UpdateMany("{ Genre: { $elemMatch : { $eq :'fantasy' } } }", "{ $addToSet: { Genre: 'favority' } }");

            var result = bookCollection.Find(new BsonDocument()).ToList();

            foreach (var book in result)
            {
                Console.WriteLine(book.ToString());
            }
        }

        [TestMethod]
        public void Task8()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");

            var result = bookCollection.DeleteMany("{ Count: {'$gt': 3} }");

            var resultDoc = bookCollection.Find(new BsonDocument()).ToList();

            foreach (var author in resultDoc)
            {
                Console.WriteLine(author.ToString());
            }
        }

        [TestMethod]
        public void Task9()
        {
            var bookCollection = TestDataBase.GetCollection<BsonDocument>("library");

            bookCollection.DeleteMany(new BsonDocument());

            var resultDoc = bookCollection.Find(new BsonDocument()).ToList();

            Console.WriteLine($"Document count: {resultDoc.Count}");
        }
    }
}
