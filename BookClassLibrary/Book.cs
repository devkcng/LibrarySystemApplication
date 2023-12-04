
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClassLibrary
{
    public class Book
    {
        private string id;
        private string title;
        private string author;
        private string status;
        private string category;
        public Book(string id, string title, string author, string category , string status)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.category = category;
            this.status = status;
        }

        public string ID { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Category { get { return category; } set { category = value; } }
    }
}
