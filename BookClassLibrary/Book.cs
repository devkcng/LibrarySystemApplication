namespace BookClassLibrary
{
    public class Book
    {
        public Book()
        {
        }

        public Book(string isbn, string title, string author, string category, string status)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Category = category;
            Status = status;
        }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }
    }
}