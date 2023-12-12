using System;
using System.Windows.Forms;

namespace LibrarySystemApplication
{
    public partial class BorrowerLoginUI : Form
    {
        public BorrowerLoginUI()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text == "UserName") txtUserName.Clear();
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            if (txtPassWord.Text == "Password") txtPassWord.Clear();
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "UserName") txtUserName.Clear();
        }

        private void txtPassWord_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassWord.Text == "Password")
            {
                txtPassWord.Clear();
                txtPassWord.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*List<Borrower> list = new List<Borrower>();
            var BorrowerID = from a in list
                             where a.UserName == txtUserName.Text
                             where a.PassWord == txtPassWord.Text
                             select a.ID;

            if (BorrowerID == null) MessageBox.Show("Wrong UserName OR PassWord", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.Hide();
                BorrowerUI brUI = new BorrowerUI();
                brUI.Show();
            }*/
            Hide();
            var brUI = new BorrowerUI();
            brUI.ShowDialog();
            Show();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
        }
    }
}