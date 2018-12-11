using Module_XML.Attributes;
using Module_XML.CatalogElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Module_XML.XMLHelpers
{
    public static class XMLReadHelper
    {
        public static Catalog Read(string file)
        {
            var catalog = new Catalog();

            using (XmlReader reader = XmlReader.Create(file))
            {
                reader.MoveToContent();
                reader.ReadToFollowing("Catalog");

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "books":
                                catalog.Books = GetBooks(reader).ToList();
                                break;
                            case "newspapers":
                                catalog.Newspapers = GetNewspapers(reader).ToList();
                                break;
                            case "patents":
                                catalog.Patents = GetPatents(reader).ToList();
                                break;
                        }
                    }
                }
            }

            return catalog;
        }


        public static IEnumerable<Book> GetBooks(XmlReader reader)
        {
            while (reader.ReadToNextSibling("book"))
            {
                yield return GetBook(XElement.ReadFrom(reader) as XElement);
            }
        }

        public static IEnumerable<Newspaper> GetNewspapers(XmlReader reader)
        {
            while (reader.ReadToNextSibling("newspaper"))
            {
                yield return GetNewspaper(XElement.ReadFrom(reader) as XElement);
            }
        }

        public static IEnumerable<Patent> GetPatents(XmlReader reader)
        {
            while (reader.ReadToNextSibling("patent"))
            {
                yield return GetPatent(XElement.ReadFrom(reader) as XElement);
            }
        }

        public static Book GetBook(XElement bookElement)
        {
            var book = new Book();
            book.Name = bookElement.Element("name").Value;
            book.ISBN = bookElement.Element("isbn").Value;
            book.Author = bookElement.Element("author").Value;
            book.City = bookElement.Element("city").Value;
            book.AdditionalNotes = bookElement.Element("notes").Value;
            book.PageNumber = XmlConvert.ToInt16(bookElement.Element("city").Value);
            book.PublicationDate = XmlConvert.ToDateTime(bookElement.Element("publicationDate").Value, XmlDateTimeSerializationMode.Local);
            book.Publisher = bookElement.Element("publisher").Value;

            return book;
        }

        public static Newspaper GetNewspaper(XElement newspaperElement)
        {
            var newspaper = new Newspaper();
            newspaper.Name = newspaperElement.Element("name").Value;
            newspaper.ISSN = newspaperElement.Element("issn").Value;
            newspaper.Date = XmlConvert.ToDateTime(newspaperElement.Element("date").Value, XmlDateTimeSerializationMode.Local);
            newspaper.City = newspaperElement.Element("city").Value;
            newspaper.AdditionalNotes = newspaperElement.Element("notes").Value;
            newspaper.PageNumber = XmlConvert.ToInt16(newspaperElement.Element("city").Value);
            newspaper.PublicationDate = XmlConvert.ToDateTime(newspaperElement.Element("publicationDate").Value, XmlDateTimeSerializationMode.Local);
            newspaper.Publisher = newspaperElement.Element("publisher").Value;
            newspaper.Number = XmlConvert.ToInt32(newspaperElement.Element("number").Value);

            return newspaper;
        }

        public static Patent GetPatent(XElement patentElement)
        {
            var patent = new Patent();

            patent.Name = patentElement.Element("name").Value;
            patent.ApplicationDate = XmlConvert.ToDateTime(patentElement.Element("applicationDate").Value, XmlDateTimeSerializationMode.Local);
            patent.Country = patentElement.Element("country").Value;
            patent.Inventor = patentElement.Element("inventor").Value;
            patent.AdditionalNotes = patentElement.Element("notes").Value;
            patent.PageNumber = XmlConvert.ToInt16(patentElement.Element("city").Value);
            patent.PublicationDate = XmlConvert.ToDateTime(patentElement.Element("publicationDate").Value, XmlDateTimeSerializationMode.Local);
            patent.RegistrationNumber = patentElement.Element("publisher").Value;

            return patent;
        }
    }
}
