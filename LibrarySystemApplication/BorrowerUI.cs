using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystemApplication
{
    public partial class BorrowerUI : Form
    {
        private string borrowerID;
        public string BorrowerID {  get { return borrowerID; } set { borrowerID = value; } }
        public BorrowerUI(string value)
        {
            InitializeComponent();
            this.BorrowerID = value;
        }
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBooks sBooks = new ShowBooks(this.BorrowerID);
            //sBooks.BorrowerID= this.BorrowerID;
            sBooks.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Logout? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();

            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Exit? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SearchBooks searchBooks = new SearchBooks(this.BorrowerID);
            //searchBooks.BorowerID= this.BorrowerID;
            searchBooks.Show();
        }
    }
}
