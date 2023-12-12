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
            ts_categories.Enabled = true;
            ts_users.Enabled = true;
            ts_reports.Enabled = true;
            ts_logs.Enabled = true;
            ts_login.Image = Resources.log_close;
        }

        public void disabled_menu()
        {
            ts_login.Text = "Login";
            ts_books.Enabled = false;
            ts_transaction.Enabled = false;
            ts_borrower.Enabled = false;
            ts_categories.Enabled = false;
            ts_users.Enabled = false;
            ts_reports.Enabled = false;
            ts_logs.Enabled = false;
            ts_login.Image = Resources.log_open;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disabled_menu();
        }

        private void ts_books_Click(object sender, EventArgs e)
        {
            Form frm = new BookManagement();
            frm.ShowDialog();
        }

        private void ts_BorrowItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmBorrow();
            frm.ShowDialog();
        }

        private void ts_returnItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReturned();
            frm.ShowDialog();
        }

        private void ts_overdueItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmOverdue();
            frm.ShowDialog();
        }

        private void ts_borrower_Click(object sender, EventArgs e)
        {
            Form frm = new frmBorrower();
            frm.ShowDialog();
        }

        private void ts_categories_Click(object sender, EventArgs e)
        {
            Form frm = new frmCategories();
            frm.ShowDialog();
        }

        private void ts_users_Click(object sender, EventArgs e)
        {
            Form frm = new frmUser();
            frm.ShowDialog();
        }

        private void ts_reports_Click(object sender, EventArgs e)
        {
            Form frm = new frmReport();
            frm.ShowDialog();
        }

        private void ts_logs_Click(object sender, EventArgs e)
        {
            Form frm = new frmLogs();
            frm.ShowDialog();
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
                ts_login.Text = "Login";
                disabled_menu();
            }
        }
    }
}