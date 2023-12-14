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
            txtStatus.Text = book.Status;
        }
        
        private void clear()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtCategory.Text = "";
            txtStatus.Text = "";
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            bookToUpdate.ISBN = txtISBN.Text;
            bookToUpdate.Title = txtTitle.Text;
            bookToUpdate.Author = txtAuthor.Text;
            bookToUpdate.Category = txtCategory.Text;
            bookToUpdate.Status = txtStatus.Text;
            var listBook = new List<Book>();
            var dataLoader = new dataLoaderBook();
            dataLoader.Loader(listBook);
            
            foreach (var book in listBook)
                if (txtISBN.Text == book.ISBN)
                {   
                    book.Title = txtTitle.Text;
                    book.Author = txtAuthor.Text;
                    book.Category = txtCategory.Text;
                    book.Status = txtStatus.Text;
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