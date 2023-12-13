using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;
using static System.Windows.Forms.LinkLabel;

namespace LibrarySystemApplication
{
    public partial class SearchBooks : Form
    {
        List<Book> listBook = new List<Book>();

        dataLoaderBook dataLoader = new dataLoaderBook();

        dataLoaderTransactionsBorrow dataLoaderTransactions = new dataLoaderTransactionsBorrow();

        private string borrowerID;
        public string BorowerID { get { return borrowerID; } set { borrowerID = value; } }
        public SearchBooks(string id)
        {
            InitializeComponent();
            this.BorowerID = id;
        }

        //load books from database
        private void SearchBooks_Load(object sender, EventArgs e)
        {
            dataLoader.Loader(listBook);
            foreach (Book book in listBook)
            {
                dataGridView1.Rows.Add(new string[] {book.ID,book.Title,book.Author,book.Category});
            }    

        }

        //borrow books
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && listBook.ElementAt(e.RowIndex).Status !="1")
            {
                if (MessageBox.Show("Are you Sure You want to Borrow? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //append new transactions Borrow
                    var item = listBook.ElementAt(e.RowIndex);
                    dataLoaderTransactions.Append(item, this.BorowerID);


                    //update file book after book has been borrowed.
                    dataLoader.UpdaterBorrowed(listBook, item);
                }
            }
            else { MessageBox.Show("books have been borrowed"); }
        }

        //search books
        private void button1_Click(object sender, EventArgs e)
        {
            string query = txtDescribe.Text;
            var searchEngine = new TFIDF();
            //search//  
            
            listBook = searchEngine.TF_IDF(query.ToLower(), listBook);

            //fill dataGrid
            dataGridView1.Rows.Clear();
 
            foreach ( var item in listBook)
            {
                dataGridView1.Rows.Add(new string[] {item.ID,item.Title,item.Author,item.Category });
            }
        }
    }
}
