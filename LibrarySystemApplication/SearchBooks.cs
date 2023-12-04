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


namespace LibrarySystemApplication
{
    public partial class SearchBooks : Form
    {
        List<Book> listBook = new List<Book>();
        private string borrowerID;
        public string BorowerID { get { return borrowerID; } set { borrowerID = value; } }
        public SearchBooks()
        {
            InitializeComponent();
        }

        //load books from database
        private void SearchBooks_Load(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(@"DATABASE/Book.csv"))
            {
               
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {
                        listBook.Add(new Book(values[0], values[1], values[2], values[3]));
                        dataGridView1.Rows.Add(values);
                    }
                }
            }

        }

        //borrow books
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (MessageBox.Show("Are you Sure You want to Borrow? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var a = listBook[e.RowIndex].ID;
                    
                }
            }

            
        }

        //search books
        private void button1_Click(object sender, EventArgs e)
        {
            string query = txtDescribe.Text;
            List<string> saveTopkID = new List<string>();   
            
            //search//






            


            //fill dataGrid
            dataGridView1.Rows.Clear();
            var listSearch = from a in listBook where a.ID == (from save in saveTopkID select save).ToString() select a ;
            foreach ( var item in listSearch )
            {
                dataGridView1.Rows.Add(new string[] {item.ID,item.Title,item.Author,item.Category });
            }
        }
    }
}
