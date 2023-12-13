using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;
using static System.Windows.Forms.LinkLabel;

namespace LibrarySystemApplication
{
    public partial class SearchBooks : Form
    {

        {
            InitializeComponent();
            this.BorowerID = id;
        }

        public string BorowerID { get; set; }

        //load books from database
        private void SearchBooks_Load(object sender, EventArgs e)
        {

        }

        //borrow books
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //search books
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}