
using System.Windows.Forms;
using UsersClassLibrary;

namespace LibrarySystemApplication
{
    public partial class BorrowerLoginUI : Form
    {
        List<UsersClassLibrary.Borrower> listBorrower = new List<UsersClassLibrary.Borrower>();
        public BorrowerLoginUI()
        {
            InitializeComponent();
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\Borrower.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] != "ISBN")
                    {

                        listBorrower.Add(new UsersClassLibrary.Borrower(values[0], values[1], values[2], values[3]));
                    }
                }
            }
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
            List<string> listKey = new List<string>();
            using (var reader = new StreamReader(@"D:\code\c#\Git\LibrarySystemApplication\DATABASE\BorrowerKey.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    
                    if (line.Split(',')[0] != "username")
                    {
                        listKey.Add(line);
                    }
                }
            }
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
        }
    }
}