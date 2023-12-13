using BookClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersClassLibrary;
using Dataloader;

namespace LibrarySystemApplication
{
    public partial class BorrowerLoginUI : Form
    {
        List<UsersClassLibrary.Borrower> listBorrower = new List<UsersClassLibrary.Borrower>();
        dataLoaderBorrrower dataLoader = new dataLoaderBorrrower();
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
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text == "UserName")
            {
                txtUserName.Clear();
            }
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
            if (txtUserName.Text == "UserName")
            {
                txtUserName.Clear();
            }
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
            List<string> listKey = new List<string>();
            dataLoader.LoaderBorrowerKey(listKey);
            string saveID="" ;
            foreach (var key in listKey)
            {
                var values = key.Split(',');
                if (values[0] == txtUserName.Text && values[1] == txtPassWord.Text)
                {
                    saveID = values[2];
                    break;
                }
            }

            if (saveID=="") MessageBox.Show("Wrong UserName OR PassWord", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.Hide();
                BorrowerUI brUI = new BorrowerUI(saveID);
                //brUI.BorrowerID = saveID;
                brUI.Show();
            }
            
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}
