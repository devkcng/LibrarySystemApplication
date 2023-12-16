using Dataloader;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UsersClassLibrary;

namespace LibrarySystemApplication
{
    public partial class BorrowerUI : Form
    {
        public BorrowerUI(string value)
        {
            InitializeComponent();
            BorrowerID = value;
            var listBorrower = new List<Borrower>();
            new dataLoaderBorrrower().Loader(listBorrower);
            foreach (var item in listBorrower)
                if(item.Id == BorrowerID && Int32.Parse(item.Violations)>=3 )
                {
                    bookToolStripMenuItem.Enabled = false;
                    searchBookToolStripMenuItem.Enabled = false;
                    toolStripMenuItem1.Enabled = false;
                    MessageBox.Show("Your account has been BANNED !!!!");
                }

        }

        public string BorrowerID { get; set; }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sBooks = new ShowBooks(BorrowerID);
            //sBooks.BorrowerID= this.BorrowerID;
            sBooks.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Logout? ", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes) this.Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Exit? ", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes) Application.Exit();
        }

        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchBooks = new SearchBooks(BorrowerID);
            //searchBooks.BorowerID= this.BorrowerID;
            searchBooks.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var ProfileUI = new ProfileUI(BorrowerID);
            //searchBooks.BorowerID= this.BorrowerID;
            ProfileUI.Show();
        }
    }
}