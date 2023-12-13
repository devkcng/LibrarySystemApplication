using System;
using System.Windows.Forms;

namespace LibrarySystemApplication
{
    public partial class BorrowerUI : Form
    {
        public BorrowerUI()
        {
            InitializeComponent();
        }

        public BorrowerUI(string id)
        {
            BorrowerID = id;
        }

        public string BorrowerID { get; set; }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sBooks = new ShowBooks();
            sBooks.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Logout? ", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes) Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Exit? ", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes) Application.Exit();
        }

        private void searchBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchBooks = new SearchBooks();
            searchBooks.BorowerID = BorrowerID;
            searchBooks.Show();
        }
    }
}