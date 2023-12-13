using System.Collections.Generic;
using System.IO;
using BookClassLibrary;

namespace Dataloader
{
    public class dataLoaderBook : dataLoader<List<Book>>
    {
        private readonly pathToEntity _path = new pathToEntity();

        public override void Loader(List<Book> listBook)
        {
            using (var reader = new StreamReader(_path.PathBook))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                        listBook.Add(new Book(values[0], values[1], values[2], values[3], values[4]));
                }
            }
        }

        public void UpdaterBorrowed(List<Book> listBook, Book item)
        {
            try
            {
                using (var writer = new StreamWriter(_path.PathBook, false))
                {
                    writer.WriteLine("ISBN,Title,Author,Category,Status");
                    foreach (var book in listBook)
                    {
                        if (book.ISBN == item.ISBN)
                            book.Status = "1";
                        var line = string.Format("{0},{1},{2},{3},{4}", book.ISBN, book.Title, book.Author,
                            book.Category,
                            book.Status);
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
        }

        public void UpdaterReturned(List<Book> listAllBook, Book item, List<Book> myBooks)
        {
            try
            {
                using (var writer = new StreamWriter(_path.PathBook, false))
                {
                    writer.WriteLine("ISBN,Title,Author,Category,Status");
                    foreach (var book in listAllBook)
                    {
                        if (book.ISBN == item.ISBN)
                        {
                            book.Status = "0";
                            var idx = myBooks.IndexOf(book);
                            myBooks.RemoveAt(idx);
                        }

                        var line = string.Format("{0},{1},{2},{3},{4}", book.ISBN, book.Title, book.Author,
                            book.Category,
                            book.Status);
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
        }
    }
}