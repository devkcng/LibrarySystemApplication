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
using static System.Windows.Forms.LinkLabel;

namespace LibrarySystemApplication
{
    public partial class SearchBooks : Form
    {
        List<Book> listBook = new List<Book>();
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
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Book.csv"))
            {
               
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {
                        
                        listBook.Add(new Book(values[0], values[1], values[2], values[3], values[4]));
                        dataGridView1.Rows.Add(values);
                    }
                }
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
                    string newFileName = @"D:\code\c#\Git\LibrarySystemApplication\DATABASE\transactionsBorrow.csv";
                    var item = listBook.ElementAt(e.RowIndex);
                    List<String> lines = new List<String>();

                    string clientDetails =item.ID + "," + borrowerID + "," + DateTime.Now.ToString("dd/MM/yyyy");
                    if (File.Exists(newFileName))
                    {
                        using (StreamReader reader = new StreamReader(newFileName))
                        {
                            String line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                var a =line.Split(',');
                                line = string.Format("{0},{1},{2}", a[0], a[1], a[2]);
                                if(line !=",,")
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
                        foreach (Book book in listBook)
                        {
                            if (book.ID == item.ID)
                                book.Status = "1";
                            string line = string.Format("{0},{1},{2},{3},{4}",book.ID,book.Title,book.Author,book.Category,book.Status);
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            else { MessageBox.Show("books have been borrowed"); }
        }

        //search books
        private void button1_Click(object sender, EventArgs e)
        {
            string query = txtDescribe.Text;
            List<string> saveTopkID = new List<string>();   
            
            //search//


            //sasdas



            


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
