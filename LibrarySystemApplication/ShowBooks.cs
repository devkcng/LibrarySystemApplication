
using System.Windows.Forms;

namespace LibrarySystemApplication
{
    public partial class ShowBooks : Form
    {
        private string borrowerID;
        List<Book> myBooks= new List<Book>();
        List<Book> listAllBook = new List<Book>();
        public string BorrowerID { get { return borrowerID; } set { borrowerID = value; } }
        public ShowBooks(string id)
        {
            InitializeComponent();
            this.BorrowerID = id;
            //read list all of books
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Book.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {

                        listAllBook.Add(new Book(values[0], values[1], values[2], values[3], values[4]));
                    }
                }
            }
            List<string> Books= new List<string>();
            //save my books id without return
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\transactionsBorrow.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {
                        if (values[1] == borrowerID)
                        {
                            Books.Add(string.Format("{0},{1}",values[0], values[2]));
                        }
                    }
                }
            }
            //save my books id
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\transactionsReturn.csv"))
            {

                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {
                        foreach (var book in Books)
                        {
                            if (values[0] == book.Split(',')[0])
                            {
                                Books.RemoveAt(Books.IndexOf(book));
                                break;
                            }
                        }
                    }
                    
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
                    string newFileName = @"D:\code\c#\Git\LibrarySystemApplication\DATABASE\transactionsReturn.csv";
                    var item = myBooks.ElementAt(e.RowIndex);
                    List<String> lines = new List<String>();

                    string clientDetails = item.ID + "," + borrowerID + "," + DateTime.Now.ToString("dd/MM/yyyy");
                    if (File.Exists(newFileName))
                    {
                        using (StreamReader reader = new StreamReader(newFileName))
                        {
                            String line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                var a = line.Split(',');
                                line = string.Format("{0},{1},{2}", a[0], a[1], a[2]);
                                if (line != ",,")
                                    lines.Add(line);
                            }
                        }

                        using (StreamWriter writer = new StreamWriter(newFileName, false))
                        {
                            foreach (String line in lines)
                                writer.WriteLine(line);
                            writer.WriteLine(clientDetails);
                        }

                    }



                    //update file book.
                    using (StreamWriter writer = new StreamWriter(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Book.csv", false))
                    {
                        writer.WriteLine("ISBN,Title,Author,Category,Status");
                        foreach (Book book in listAllBook)
                        {
                            if (book.ID == item.ID)
                            {
                                book.Status = "0";
                                var idx=myBooks.IndexOf(book);
                                myBooks.RemoveAt(idx);
                            }
                            string line = string.Format("{0},{1},{2},{3},{4}", book.ID, book.Title, book.Author, book.Category, book.Status);
                            writer.WriteLine(line);
                        }
                    }
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