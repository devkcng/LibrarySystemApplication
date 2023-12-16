using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;
using UsersClassLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LibrarySystemApplication
{
    public partial class ShowBooks : Form
    {
        private readonly pathToEntity _path = new pathToEntity();
        private readonly dataLoaderBook dataLoader = new dataLoaderBook();
        private readonly dataLoaderTransactionsBorrow dataLoaderTransactions = new dataLoaderTransactionsBorrow();
        private readonly List<Book> listAllBook = new List<Book>();
        private readonly List<Book> myBooks = new List<Book>();
        private readonly List<string> BooksWithTime = new List<string>();

        public ShowBooks(string id)
        {
            InitializeComponent();
            BorrowerID = id;
            //read list all of books
            dataLoader.Loader(listAllBook);
            //check the book has been borrowed
            dataLoaderTransactions.Loader(BooksWithTime, BorrowerID);
            //load transaction Return
            var BookReturned = new List<string>();
            new dataLoaderTransactionsReturn().Loader(BookReturned, BorrowerID);
            //check the book has been returned
            foreach (var rbook in BookReturned)
            foreach (var book in BooksWithTime)
                if (book.Split(',')[0] == rbook.Split(',')[0])
                {
                    BooksWithTime.Remove(book);
                    break;
                }

            //fill data
            DateTime date;
            foreach (var mBook in BooksWithTime)
            foreach (var book in listAllBook)
                if (mBook.Split(',')[0] == book.ISBN)
                {
                    date = DateTime.ParseExact(mBook.Split(',')[1], "dd/MM/yyyy", null).AddDays(28);
                    
                    myBooks.Add(book);
                    dataGridView1.Rows.Add(book.ISBN, book.Title, book.Author, book.Category,
                        date.ToString("dd/MM/yyyy"));
                        /*if (date.ToString("dd/MM/yyyy") == DateTime.Now.Date.ToString("dd/MM/yyyy"))
                        {
                            MessageBox.Show("There are expired books!!!");
                        }*/
                }
            //change color and send notification to user if the deadline is due
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    if (DateTime.ParseExact(row.Cells[4].Value.ToString(), "dd/MM/yyyy", null).Date <= DateTime.Now.Date)
                    {
                        if(count <1) MessageBox.Show("There are expired books!!!");
                        count++;
                        row.DefaultCellStyle.BackColor = Color.Brown;
                    }
                }
            }

            //update Violations
            List<Borrower> listBorrower = new List<Borrower>(); 
            new dataLoaderBorrrower().Loader(listBorrower);
            foreach (Borrower b in listBorrower)
                if (b.Id == BorrowerID) { b.Violations = (Int32.Parse(b.Violations) + count).ToString(); break; }
            using (var writer = new StreamWriter(_path.PathBorrower, false))
            {
                writer.WriteLine("BorrowerID,Name,Address,Age,Violations");
                foreach (var borrower in listBorrower)
                {
                    var line = string.Format("{0},{1},{2},{3},{4}", borrower.Id, borrower.Name, borrower.Address,
                        borrower.Age, borrower.Violations);
                    writer.WriteLine(line);
                }
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
            if (e.RowIndex != -1 && e.RowIndex != dataGridView1.Rows.Count - 1)
            {
                if (MessageBox.Show("Are you Sure You want to Return? ", "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //append new transactions Return
                    var item = myBooks.ElementAt(e.RowIndex);
                    new dataLoaderTransactionsReturn().Append(item, BorrowerID);


                    //update file book.
                    dataLoader.UpdaterReturned(listAllBook, item, myBooks);
                }
                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();



            var combine=from mBook in myBooks 
                        join bookTime in BooksWithTime on
                        mBook.ISBN equals bookTime.Split(',')[0] 
                        select new { mBook.ISBN, mBook.Title, mBook.Author, mBook.Category, bookTime };
            
            foreach (var mBook in combine)
                foreach (var book in listAllBook)
                    if (mBook.ISBN == book.ISBN)
                    {
                        DateTime date = DateTime.ParseExact(mBook.bookTime.Split(',')[1], "dd/MM/yyyy", null).AddDays(28);
                        dataGridView1.Rows.Add(book.ISBN, book.Title, book.Author, book.Category,
                             date.ToString("dd/MM/yyyy"));
                    }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    if (DateTime.ParseExact(row.Cells[4].Value.ToString(), "dd/MM/yyyy", null).Date <= DateTime.Now.Date)
                    {
                        row.DefaultCellStyle.BackColor = Color.Brown;
                    }
                }
            }
        }
    }
}