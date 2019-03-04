using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSerialization
{
    [TestClass]
    public class Tests
    {
        private string filePath = @"C:\Users\Master\Desktop\books.xml";

        private Catalog Catalog 
        {
            get
            {
                var catalog = new Catalog();
                var book1 = new Book()
                {
                    Author = "Stephen King",
                    Title = "It",
                    Genre = Genre.Horror
                };

                var book2 = new Book()
                {
                    Author = "Chuck Palahniuk",
                    Title = "Fight Club",
                    Genre = Genre.Romance
                };

                catalog.Books = new List<Book>() { book1, book2 };
                catalog.Date = DateTime.Now;

                return catalog;
            }
        }

        [TestMethod]
        public void SerializeArrayTest()
        {
            var xmlString = XmlSerializeHelper.Serialize(Catalog);

            var xml = XDocument.Parse(xmlString);

            var actualCount = xml.Descendants().Where(x => x.Name.LocalName.Equals("book")).Count();

            Assert.AreEqual(Catalog.Books.Count, actualCount);
        }

        [TestMethod]
        public void DeSerializeArrayTest()
        {
            var xml = XDocument.Load(filePath);
            var expectedCount = xml.Descendants().Where(x => x.Name.LocalName.Equals("book")).Count();
            var catalog = XmlSerializeHelper.DeSerialize(xml.ToString());
            var actualCount = catalog.Books.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void SerializeDateTest()
        {
            var xmlString = XmlSerializeHelper.Serialize(Catalog);

            var xml = XDocument.Parse(xmlString);

            var actualDate = xml.Descendants().First(x => x.Name.LocalName.Equals("date")).Value;

            Assert.AreEqual(Catalog.Date, DateTime.Parse(actualDate));
        }

        [TestMethod]
        public void DeSerializeDateTest()
        {
            var xml = XDocument.Load(filePath);
            var expectedDate = DateTime.Parse(xml.Descendants().First(x => x.Name.LocalName.Equals("date")).Value);
            var catalog = XmlSerializeHelper.DeSerialize(xml.ToString());
            var actualDate = catalog.Date;

            Assert.AreEqual(expectedDate, actualDate);
        }

        [TestMethod]
        public void SerializeEnumTest()
        {
            var xmlString = XmlSerializeHelper.Serialize(Catalog);

            var xml = XDocument.Parse(xmlString);

            var dictionary = xml.Descendants().Where(x => x.Name.LocalName.Equals("book"))
                .ToDictionary(x => x.Elements().First(y => y.Name.LocalName.Equals("author")).Value,
                                z => z.Elements().First(y => y.Name.LocalName.Equals("genre")).Value);

            var correctGenres = dictionary.All(x => Catalog.Books.First(y => y.Author.Equals(x.Key)).Genre.ToString().Equals(x.Value));

            Assert.IsTrue(correctGenres);
        }

        [TestMethod]
        public void DeSerializeEnumTest()
        {
            var xml = XDocument.Load(filePath);
            var dictionary = xml.Descendants().Where(x => x.Name.LocalName.Equals("book"))
                .ToDictionary(x => x.Elements().First(y => y.Name.LocalName.Equals("author")).Value,
                                z => z.Elements().First(y => y.Name.LocalName.Equals("genre")).Value);

            var catalog = XmlSerializeHelper.DeSerialize(xml.ToString());

            var correctGenres = dictionary.All(x => Catalog.Books.First(y => y.Author.Equals(x.Key)).Genre.ToString().Equals(x.Value, StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(correctGenres);
        }
    }
}
