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
        private string BorrowerID;
        public BorrowerUI()
        {
            InitializeComponent();
        }
        public BorrowerUI(string id)
        {
            this.BorrowerID = id;
        }
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBooks sBooks = new ShowBooks();
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
    }
}
