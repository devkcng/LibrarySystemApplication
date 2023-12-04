namespace BookClassLibrary
{
    public class Book
    {
        public Book(string id, string title, string author, string category, string status)
        {
            this.ID = id;
            this.Title = title;
            this.Author = author;
            this.Category = category;
            this.Status = status;
        }

        public string ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Status { get; set; }

        public string Category { get; set; }
    }
}