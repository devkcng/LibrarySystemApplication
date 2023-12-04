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
        string status;
        public string ID {  get { return id; } }
        public string Title { get { return title; } }
        public string Author { get { return author; } }
        public string Category { get { return category; } }
        public string Status { get { return status; } set { status = value; } }
        public Book() 
        {
        }
        public Book(string id, string title, string author, string category, string status)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.category = category;
            this.status = status;
        }
    }
}
