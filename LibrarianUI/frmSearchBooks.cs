using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarianUI
{
    public partial class frmSearchBooks : Form
    {
        private readonly dataLoaderBook dataLoader = new dataLoaderBook();

        private List<Book> listBook = new List<Book>();

        public frmSearchBooks()
        {
            InitializeComponent();
        }

        //load books from database
        private void frmSearchBooks_Load(object sender, EventArgs e)
        {
            dataLoader.Loader(listBook);
            var query = "";
            var searchEngine = new TFIDF();
            var Summary = new List<string>();
            //search//  

            listBook = searchEngine.TF_IDF(query.ToLower(), listBook, Summary);

            //fill dataGrid
            dataGridView1.Rows.Clear();

            for (var i = 0; i < listBook.Count; i++)
                dataGridView1.Rows.Add(listBook[i].ISBN,
                    listBook[i].Title, listBook[i].Author, listBook[i].Category, listBook[i].Status, Summary[i]);
        }

        //borrow books
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex != dataGridView1.Rows.Count - 1)
            {
                if (MessageBox.Show("Are you Sure You want to Update this book? ", "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Form frm = new frmUpdateBook(listBook.ElementAt(e.RowIndex));
                    frm.ShowDialog();
                    frmSearchBooks_Load(sender, e);
                }
            }
        }

        //search books
            private void button1_Click(object sender, EventArgs e)
            {
                var query = txtDescribe.Text;
                var searchEngine = new TFIDF();
                var Summary = new List<string>();
                //search//  

                listBook = searchEngine.TF_IDF(query.ToLower(), listBook, Summary);

                //fill dataGrid
                dataGridView1.Rows.Clear();

                for (var i = 0; i < listBook.Count; i++)
                    dataGridView1.Rows.Add(listBook[i].ISBN,
                        listBook[i].Title, listBook[i].Author, listBook[i].Category, Summary[i]);
            }
        }

    
}