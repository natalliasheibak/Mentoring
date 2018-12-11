using Module_XML.CatalogElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_XML
{
    public class Catalog
    {
        public List<Book> Books { get; set; }

        public List<Newspaper> Newspapers { get; set; }

        public List<Patent> Patents { get; set; }

        public Catalog()
        {
            Books = new List<Book>();
            Newspapers = new List<Newspaper>();
            Patents = new List<Patent>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddNewspaper(Newspaper newspaper)
        {
            Newspapers.Add(newspaper);
        }

        public void AddPatent(Patent patent)
        {
            Patents.Add(patent);
        }
    }
}
