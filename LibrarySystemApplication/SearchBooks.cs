using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarySystemApplication
{
    public partial class SearchBooks : Form
    {
        private readonly dataLoaderBook dataLoader = new dataLoaderBook();

        private readonly dataLoaderTransactionsBorrow dataLoaderTransactions = new dataLoaderTransactionsBorrow();
        private List<Book> listBook = new List<Book>();

        public SearchBooks(string id)
        {
            InitializeComponent();
            BorowerID = id;
        }

        public string BorowerID { get; set; }

        //load books from database
        private void SearchBooks_Load(object sender, EventArgs e)
        {
            dataLoader.Loader(listBook);
            var query = "";
            var searchEngine = new TFIDF();
            List<string> Summary = new List<string>();
            //search//  

            listBook = searchEngine.TF_IDF(query.ToLower(), listBook, Summary);

            //fill dataGrid
            dataGridView1.Rows.Clear();

            for (int i = 0; i < listBook.Count; i++) dataGridView1.Rows.Add(listBook[i].ISBN,
                listBook[i].Title, listBook[i].Author, listBook[i].Category, Summary[i]);
        }

        //borrow books
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && listBook.ElementAt(e.RowIndex).Status != "1")
            {
                if (MessageBox.Show("Are you Sure You want to Borrow? ", "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //append new transactions Borrow
                    var item = listBook.ElementAt(e.RowIndex);
                    dataLoaderTransactions.Append(item, BorowerID);


                    //update file book after book has been borrowed.
                    dataLoader.UpdaterBorrowed(listBook, item);
                }
            }
            else
            {
                MessageBox.Show("books have been borrowed");
            }
        }

        //search books
        private void button1_Click(object sender, EventArgs e)
        {
            var query = txtDescribe.Text;
            var searchEngine = new TFIDF();
            List<string> Summary = new List<string>();
            //search//  

            listBook = searchEngine.TF_IDF(query.ToLower(), listBook, Summary);

            //fill dataGrid
            dataGridView1.Rows.Clear();

            for (int i =0;i<listBook.Count;i++) dataGridView1.Rows.Add(listBook[i].ISBN,
                listBook[i].Title, listBook[i].Author, listBook[i].Category, Summary[i]);
        }
    }
}