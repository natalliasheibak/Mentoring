using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Module_XML.XMLHelpers;
using Module_XML;
using Module_XML.CatalogElements;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        public string FileName => Path.Combine(Environment.CurrentDirectory, "XmlExample.xml");
        public string WriteToFileName => Path.Combine(Environment.CurrentDirectory, "WriteToFileName.xml");

        public Catalog GetCatalog()
        {
            var catalog = new Catalog();
            var book = new Book();
            book.Name = "Stephen King";
            book.PageNumber = 100;
            book.PublicationDate
            catalog.AddBook();
        }

        [TestMethod]
        public void ReadFile()
        {
            var catalog = XMLReadHelper.Read(FileName);
        }

        [TestMethod]
        public void WriteFile()
        {
            XMLWriteHelper.Write(WriteToFileName, GetCatalog());
        }
    }
}
