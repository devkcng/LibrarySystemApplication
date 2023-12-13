
using System.Windows.Forms;

namespace LibrarySystemApplication
{
    public partial class ShowBooks : Form
    {
        private string borrowerID;
        List<Book> myBooks= new List<Book>();
        List<Book> listAllBook = new List<Book>();
        dataLoaderBook dataLoader = new dataLoaderBook();
        dataLoaderTransactionsBorrow dataLoaderTransactions = new dataLoaderTransactionsBorrow();
        public string BorrowerID { get { return borrowerID; } set { borrowerID = value; } }
        public ShowBooks(string id)
        {
            InitializeComponent();
            this.BorrowerID = id;
            //read list all of books
            dataLoader.Loader(listAllBook);
            List<string> Books= new List<string>();
            //check the book has been borrowed
            dataLoaderTransactions.Loader(Books, BorrowerID);
            //load transaction Return
            List<string> BookReturned = new List<string>();
            new dataLoaderTransactionsReturn().Loader(BookReturned, borrowerID);
            //check the book has been returned
            foreach (string  rbook in BookReturned)
                foreach (string book in Books)
                {
                    if (book.Split(',')[0] == rbook.Split(',')[0])
                    {
                        Books.Remove(book);
                        break;
                    }
                }
            //fill data
            DateTime date;
            foreach (var mBook in Books)
            {
                foreach (Book book in listAllBook)
                    if (mBook.Split(',')[0] == book.ID)
                    {
                        date = DateTime.ParseExact(mBook.Split(',')[1], "dd/MM/yyyy", null).AddDays(28);

                        myBooks.Add(book);
                        dataGridView1.Rows.Add(new string[] { book.ID, book.Title, book.Author,
                            book.Category, date.ToString("dd/MM/yyyy") });
                        if (date.ToString("dd/MM/yyyy") == DateTime.Now.Date.ToString("dd/MM/yyyy"))
                            MessageBox.Show("There are expired books!!!");
                    }
            }
        }

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
            foreach (var book in books)
            {
                dataGridView1.Rows.Add(new string[] {book.ID,book.Title,book.Author,book.Category});
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (MessageBox.Show("Are you Sure You want to Return? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //append new transactions Return
                    var item = myBooks.ElementAt(e.RowIndex);
                    new dataLoaderTransactionsReturn().Append(item, this.borrowerID);



                    //update file book.
                    dataLoader.UpdaterReturned(listAllBook, item, myBooks);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var mBook in myBooks)
            {
                foreach (Book book in listAllBook)
                    if (mBook.ID == book.ID)
                    {

                        dataGridView1.Rows.Add(new string[] { book.ID, book.Title, book.Author, book.Category });
                    }
            }
        }
    }
}