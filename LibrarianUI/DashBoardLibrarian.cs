using System;
using System.Windows.Forms;
using LibrarianUI.Properties;
namespace LibrarianUI
{
    public partial class DashBoardLibrarian : Form
    {
        public DashBoardLibrarian()
        {
            InitializeComponent();
        }

        public void enabled_menu()
        {
            ts_login.Text = "Logout";
            ts_books.Enabled = true;
            ts_transaction.Enabled = true;
            ts_borrower.Enabled = true;
            ts_searchBook.Enabled = true;
            
            ts_exit.Enabled = true;
            ts_login.Image = Resources.log_close;
        }

        public void disabled_menu()
        {
            ts_login.Text = "Login";
            ts_books.Enabled = false;
            ts_transaction.Enabled = false;
            ts_borrower.Enabled = false;
            ts_searchBook.Enabled = false;
            
            ts_exit.Enabled = true;
            ts_login.Image = Resources.log_open;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disabled_menu();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddBook();
            frm.ShowDialog();
        }

        private void ts_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Exit? ", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes) Close();
            
        }

        private void ts_login_Click(object sender, EventArgs e)
        {
            Form frm = new frmLogin(this);

            if (ts_login.Text == "Login")
            {
                frm.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Are you Sure You want to Logout? ", "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ts_login.Text = "Login";
                    disabled_menu();
                }
            }
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmViewBook frm = new frmViewBook();
                frm.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void addBorrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddBorrower();
            frm.ShowDialog();
        }

        private void ts_searchBook_Click(object sender, EventArgs e)
        {
            Form frm = new frmSearchBooks();
            frm.ShowDialog();
        }

        private void viewBorrowerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = new frmViewBorrower();
                frm.ShowDialog();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ts_transaction_Click(object sender, EventArgs e)
        {
            Form frm = new frmTransaction();
            frm.ShowDialog();
        }
    }
}