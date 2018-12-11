using Module_XML.CatalogElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Module_XML.XMLHelpers
{
    public static class XMLWriteHelper
    {
        public static void Write(string file, Catalog catalog)
        {
            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("catalog");

                WriteBooks(writer, catalog.Books);
                WriteNewspapers(writer, catalog.Newspapers);
                WritePatents(writer, catalog.Patents);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }


        public static void WriteBooks(XmlWriter writer, List<Book> books)
        {
            writer.WriteStartElement("books");

            foreach(var book in books)
            {
                WriteBook(writer, book);
            }

            writer.WriteEndElement();
        }

        public static void WriteNewspapers(XmlWriter writer, List<Newspaper> newspapers)
        {
            writer.WriteStartElement("newspapers");

            foreach (var newspaper in newspapers)
            {
                WriteNewspaper(writer, newspaper);
            }

            writer.WriteEndElement();
        }

        public static void WritePatents(XmlWriter writer, List<Patent> patents)
        {
            writer.WriteStartElement("patents");

            foreach (var patent in patents)
            {
                WritePatent(writer, patent);
            }

            writer.WriteEndElement();
        }

        public static void WriteBook(XmlWriter writer, Book book)
        {
            writer.WriteElementString("name", book.Name);
            writer.WriteElementString("isbn", book.ISBN);
            writer.WriteElementString("author", book.Author);
            writer.WriteElementString("city", book.City);
            writer.WriteElementString("notes", book.AdditionalNotes);
            writer.WriteElementString("pageNumber", book.PageNumber.ToString());
            writer.WriteElementString("publicationDate", book.PublicationDate.ToString());
            writer.WriteElementString("publisher", book.Publisher);
        }

        public static void WriteNewspaper(XmlWriter writer, Newspaper newspaper)
        {
            writer.WriteElementString("name", newspaper.Name);
            writer.WriteElementString("issn", newspaper.ISSN);
            writer.WriteElementString("date", newspaper.Date.ToString());
            writer.WriteElementString("city", newspaper.City);
            writer.WriteElementString("notes", newspaper.AdditionalNotes);
            writer.WriteElementString("pageNumber", newspaper.PageNumber.ToString());
            writer.WriteElementString("publicationDate", newspaper.PublicationDate.ToString());
            writer.WriteElementString("publisher", newspaper.Publisher);
        }

        public static void WritePatent(XmlWriter writer, Patent patent)
        {
            writer.WriteElementString("name", patent.Name);
            writer.WriteElementString("applicationDate", patent.ApplicationDate.ToString());
            writer.WriteElementString("country", patent.Country);
            writer.WriteElementString("inventor", patent.Inventor);
            writer.WriteElementString("notes", patent.AdditionalNotes);
            writer.WriteElementString("pageNumber", patent.PageNumber.ToString());
            writer.WriteElementString("publicationDate", patent.PublicationDate.ToString());
            writer.WriteElementString("registrationNumber", patent.RegistrationNumber);
        }
    }
}
