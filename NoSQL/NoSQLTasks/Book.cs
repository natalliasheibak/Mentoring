using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLTasks
{
    public class Book
    {
        public Book(string name, string author, int count, List<string> genre, int year)
        {
            Name = name;
            Author = author;
            Count = count;
            Genre = genre;
            Year = year;
        }

        public ObjectId _id;

        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string Author { get; set; }

        public int Count { get; set; }

        public List<string> Genre { get; set; }

        public int Year { get; set; }
    }
}
