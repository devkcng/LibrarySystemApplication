using System;
using System.Windows.Forms;

namespace LibrarySystemApplication
{
    public partial class BorrowerUI : Form
    {

        }

        public string BorrowerID { get; set; }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            searchBooks.Show();
        }
    }
}