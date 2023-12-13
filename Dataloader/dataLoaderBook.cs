using BookClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersClassLibrary;

namespace Dataloader
{
    public class dataLoaderBook : dataLoader<List<Book>>
    {
        public override void Loader(List<Book> listBook)
        {

            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Book.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {

                        listBook.Add(new Book(values[0], values[1], values[2], values[3], values[4]));
                    }
                }
            }
        }
        public void UpdaterBorrowed(List<Book> listBook, Book item)
        {
            using (StreamWriter writer = new StreamWriter(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Book.csv", false))
            {
                writer.WriteLine("ISBN,Title,Author,Category,Status");
                foreach (Book book in listBook)
                {
                    if (book.ID == item.ID)
                        book.Status = "1";
                    string line = string.Format("{0},{1},{2},{3},{4}", book.ID, book.Title, book.Author, book.Category, book.Status);
                    writer.WriteLine(line);
                }
            }
        }
        public void UpdaterReturned(List<Book> listAllBook, Book item, List<Book> myBooks)
        {
            using (StreamWriter writer = new StreamWriter(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Book.csv", false))
            {
                writer.WriteLine("ISBN,Title,Author,Category,Status");
                foreach (Book book in listAllBook)
                {
                    if (book.ID == item.ID)
                    {
                        book.Status = "0";
                        var idx = myBooks.IndexOf(book);
                        myBooks.RemoveAt(idx);
                    }
                    string line = string.Format("{0},{1},{2},{3},{4}", book.ID, book.Title, book.Author, book.Category, book.Status);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
