using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarianUI
{
    public partial class frmTransaction : Form
    {
        private readonly dataLoaderBook dataBook = new dataLoaderBook();
        private readonly dataLoaderTransactions dataBorrow= new dataLoaderTransactions();
        private readonly dataLoaderTransactions dataReturn = new dataLoaderTransactions();
        private readonly List<Book> listAllBook = new List<Book>();
        private readonly List<Book> listBook = new List<Book>();
        private readonly List<Transaction> historyBorrow = new List<Transaction>();
        private readonly List<Transaction> historyReturn = new List<Transaction>();
        public frmTransaction()
        {
            InitializeComponent();
        }
        
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            dataBook.Loader(listAllBook);
            dataBorrow.LoaderBorrow(historyBorrow);
            dataReturn.LoaderReturn(historyReturn);
            
            var bookInBorrow = new List<Book>();
            
            foreach (var h in historyBorrow)
            {
                foreach (var b in listAllBook)
                {
                    if (h.ISBN == b.ISBN)
                    {
                        bookInBorrow.Add(b);
                    }
                }
            }
            dataGridView1.Rows.Clear();
            for (int i = 0; i < historyBorrow.Count; i++)
            {
                dataGridView1.Rows.Add(historyBorrow[i].BorrowerID, historyBorrow[i].ISBN, bookInBorrow[i].Title,
                    bookInBorrow[i].Author, bookInBorrow[i].Category, historyBorrow[i].Time,
                    "28", historyReturn[i].Time);
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }
    }
}