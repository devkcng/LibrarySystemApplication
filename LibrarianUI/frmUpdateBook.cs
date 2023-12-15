using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarianUI
{
    public partial class frmUpdateBook : Form
    {   
        private readonly pathToEntity _path = new pathToEntity();
        private Book bookToUpdate;

        // Constructor to initialize the form with the book information
        public frmUpdateBook(Book book)
        {
            InitializeComponent();
            this.bookToUpdate = book;
            txtISBN.Text = book.ISBN;
            
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtCategory.Text = book.Category;
            cboStatus.Text = checkStatus(book.Status);
        }
        private static string checkStatus(string status)
        {
            if (status == "0")
                return "Available";
            return "Borrowed";
        }
        
        private static string convertStatus(string status)
        {
            if (status == "Borrowed" || status == "1" || status == "borrowed")
            {
                return "1";
            }
            return "0";
        }
        private void clear()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtCategory.Text = "";
            cboStatus.Text = "";
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            bookToUpdate.ISBN = txtISBN.Text;
            bookToUpdate.Title = txtTitle.Text;
            bookToUpdate.Author = txtAuthor.Text;
            bookToUpdate.Category = txtCategory.Text;
            bookToUpdate.Status = cboStatus.Text;
            var listBook = new List<Book>();
            var dataLoader = new dataLoaderBook();
            dataLoader.Loader(listBook);
            
            foreach (var book in listBook)
                if (book.ISBN == bookToUpdate.ISBN)
                {   
                    book.Title = bookToUpdate.Title;
                    book.Author = bookToUpdate.Author;
                    book.Category = bookToUpdate.Category;
                    book.Status = convertStatus(bookToUpdate.Status);
                    break;
                }
            using (var writer = new StreamWriter(_path.PathBook, false))
            {
                writer.WriteLine("ISBN,Title,Author,Category,Status");
                foreach (var book in listBook)
                {
                    var line = string.Format("{0},{1},{2},{3},{4}", book.ISBN, book.Title, book.Author, book.Category,
                        book.Status);
                    writer.WriteLine(line);
                }
            }
            MessageBox.Show("Book updated successfully!");
            this.clear();
            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
    }
}