using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarySystemApplication
{
    public partial class ShowBooks : Form
    {
        private readonly dataLoaderBook dataLoader = new dataLoaderBook();
        private readonly dataLoaderTransactionsBorrow dataLoaderTransactions = new dataLoaderTransactionsBorrow();
        private readonly List<Book> listAllBook = new List<Book>();
        private readonly List<Book> myBooks = new List<Book>();

        public ShowBooks(string id)
        {
            InitializeComponent();
            BorrowerID = id;
            //read list all of books
            dataLoader.Loader(listAllBook);
            var Books = new List<string>();
            //check the book has been borrowed
            dataLoaderTransactions.Loader(Books, BorrowerID);
            //load transaction Return
            var BookReturned = new List<string>();
            new dataLoaderTransactionsReturn().Loader(BookReturned, BorrowerID);
            //check the book has been returned
            foreach (var rbook in BookReturned)
            foreach (var book in Books)
                if (book.Split(',')[0] == rbook.Split(',')[0])
                {
                    Books.Remove(book);
                    break;
                }

            //fill data
            DateTime date;
            foreach (var mBook in Books)
            foreach (var book in listAllBook)
                if (mBook.Split(',')[0] == book.ISBN)
                {
                    date = DateTime.ParseExact(mBook.Split(',')[1], "dd/MM/yyyy", null).AddDays(28);

                    myBooks.Add(book);
                    dataGridView1.Rows.Add(book.ISBN, book.Title, book.Author, book.Category,
                        date.ToString("dd/MM/yyyy"));
                    if (date.ToString("dd/MM/yyyy") == DateTime.Now.Date.ToString("dd/MM/yyyy"))
                        MessageBox.Show("There are expired books!!!");
                }
        }

        public string BorrowerID { get; set; }

        private void ShowBooks_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //List<Book> books = new List<Book>();
            var books = from a in myBooks where a.Title.ToLower().Contains(textBox1.Text.ToLower()) select a;
            foreach (var book in books) dataGridView1.Rows.Add(book.ISBN, book.Title, book.Author, book.Category);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                if (MessageBox.Show("Are you Sure You want to Return? ", "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //append new transactions Return
                    var item = myBooks.ElementAt(e.RowIndex);
                    new dataLoaderTransactionsReturn().Append(item, BorrowerID);


                    //update file book.
                    dataLoader.UpdaterReturned(listAllBook, item, myBooks);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var mBook in myBooks)
            foreach (var book in listAllBook)
                if (mBook.ISBN == book.ISBN)
                    dataGridView1.Rows.Add(book.ISBN, book.Title, book.Author, book.Category);
        }
    }
}