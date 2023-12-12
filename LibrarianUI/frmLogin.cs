using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarianUI
{
    public partial class frmLogin : Form
    {
        private readonly DashBoardLibrarian frm;

        public frmLogin(DashBoardLibrarian frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "admin" && PasswordTextBox.Text == "admin")
            {
                frm.enabled_menu();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}