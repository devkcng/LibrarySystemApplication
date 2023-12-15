using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dataloader;
using UsersClassLibrary;

namespace LibrarySystemApplication
{
    public partial class BorrowerLoginUI : Form
    {
        private readonly dataLoaderBorrrower dataLoader = new dataLoaderBorrrower();
        private readonly List<Borrower> listBorrower = new List<Borrower>();

        public BorrowerLoginUI()
        {
            InitializeComponent();
            dataLoader.Loader(listBorrower);
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
            if (txtPassWord.Text == "Password")
            {
                txtPassWord.Clear();
                txtPassWord.PasswordChar = '*';
            }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var listKey = new List<Key>();
            dataLoader.LoaderBorrowerKey(listKey);
            var saveID = "";
            foreach (var key in listKey)
            {
                // var values = key.Split(',');
                // if (values[0] == txtUserName.Text && values[1] == txtPassWord.Text)
                // {
                //     saveID = values[2];
                //     break;
                // }
                if (key.Username == txtUserName.Text && key.Password == txtPassWord.Text)
                {
                    saveID = key.UserID;
                    break;
                }
            }

            if (saveID == "")
            {
                MessageBox.Show("Wrong UserName OR PassWord", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
                var brUI = new BorrowerUI(saveID);
                //brUI.BorrowerID = saveID;
                brUI.ShowDialog();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
        }
    }
}