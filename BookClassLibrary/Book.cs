using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClassLibrary
{
    public class Book
    {
        string id;
        string title;
        string author;
        string category;
        public string ID {  get;}
        public string Title { get;}
        public string Author { get;}
        public string Category { get;}
        public Book() 
        {
        }
        public Book(string id, string title, string author, string category)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.category = category;
        }
    }
}
