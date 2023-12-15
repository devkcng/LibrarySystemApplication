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
        private readonly pathToEntity _path = new pathToEntity();
        public frmTransaction()
        {
            InitializeComponent();
        }
        
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                var listBook = new List<Book>();
                var dataLoader = new dataLoaderBook();
                dataLoader.Loader(listBook);
                
                var historyBorrow = new List<Transaction>();
                var dataLoaderHistoryBorrow = new dataLoaderTransactions();
                dataLoaderHistoryBorrow.LoaderBorrow(historyBorrow);
                
                var historyReturn = new List<Transaction>();
                var dataLoaderHistoryReturn = new dataLoaderTransactions();
                dataLoaderHistoryReturn.LoaderReturn(historyReturn);
                
                dataGridView1.Rows.Clear();
                
                for(int i = 0; i < historyBorrow.Count; i++)
                {
                        dataGridView1.Rows.Add(historyBorrow[i].BorrowerID, historyBorrow[i].ISBN, historyBorrow[i].Time, historyReturn[i].Time);
                }
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
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