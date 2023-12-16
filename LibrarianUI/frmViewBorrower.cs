using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;
using UsersClassLibrary;

namespace LibrarianUI
{
    public partial class frmViewBorrower : Form
    {
        private readonly pathToEntity _path = new pathToEntity();

        public frmViewBorrower()
        {
            InitializeComponent();
        }


        private void frmViewBorrower_Load(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = false;
                textBox1.Text = "";
                var listBorrower = new List<Borrower>();
                var dataLoader = new dataLoaderBorrrower();
                dataLoader.Loader(listBorrower);
                dgvBorrower.Rows.Clear();
                var listKey = new List<Key>();
                dataLoader.LoaderBorrowerKey(listKey);

                var list = listKey;
                
                
                var combine = from a in listBorrower
                    join b in list on a.Id equals b.UserID
                    select new {a.Id, a.Name, a.Address, a.Age, b.Username, b.Password,a.Violations};
                foreach (var t in combine) dgvBorrower.Rows.Add(t.Id, t.Name, t.Address, t.Age, t.Username, t.Password,t.Violations);
                foreach (DataGridViewRow row in dgvBorrower.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (Int32.Parse(row.Cells[6].Value.ToString())>=3)
                        {
                           
                            
                            row.DefaultCellStyle.BackColor = Color.Brown;
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == dgvBorrower.Rows.Count - 1)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
                txtBorrowerID.Text = dgvBorrower.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvBorrower.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = dgvBorrower.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAge.Text = dgvBorrower.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUsername.Text = dgvBorrower.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPassword.Text = dgvBorrower.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var listBorrower = new List<Borrower>();
            var dataLoader = new dataLoaderBorrrower();
            dataLoader.Loader(listBorrower);

            var listKey = new List<Key>();
            dataLoader.LoaderBorrowerKey(listKey);

            foreach (var borrower in listBorrower)
            {
                if (txtBorrowerID.Text == borrower.Id)
                {
                    borrower.Name = txtName.Text;
                    borrower.Address = txtAddress.Text;
                    borrower.Age = txtAge.Text;
                    break;
                }
            }
            using (var writer = new StreamWriter(_path.PathBorrower, false))
            {
                writer.WriteLine("BorrowerID,Name,Address,Age,Violations");
                foreach (var borrower in listBorrower)
                {
                    var line = string.Format("{0},{1},{2},{3}", borrower.Id, borrower.Name, borrower.Address,
                        borrower.Age, borrower.Violations);
                    writer.WriteLine(line);
                }
            }

            foreach (var key in listKey)
            {
                if (txtBorrowerID.Text == key.UserID)
                {
                    key.Username = txtUsername.Text;
                    key.Password = txtPassword.Text;
                    break;
                }
            }
            using (var writer = new StreamWriter(_path.PathBorrowerKey, false))
            {
                writer.WriteLine("Username,Password,BorrowerID");
                foreach (var key in listKey)
                {
                    var line = string.Format("{0},{1},{2}" , key.Username, key.Password,key.UserID);
                    writer.WriteLine(line);
                }
            }
            MessageBox.Show("Update Successfully");
            frmViewBorrower_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var listBorrower = new List<Borrower>();
            var dataLoader = new dataLoaderBorrrower();
            dataLoader.Loader(listBorrower);
            
            var listKey = new List<Key>();
            dataLoader.LoaderBorrowerKey(listKey);
            
            foreach (var borrower in listBorrower)
            {
                if (txtBorrowerID.Text == borrower.Id)
                {
                    listBorrower.Remove(borrower);
                    break;
                }
            }
            using (var writer = new StreamWriter(_path.PathBorrower, false))
            {
                writer.WriteLine("BorrowerID,Name,Address,Age,Violations");
                foreach (var borrower in listBorrower)
                {
                    var line = string.Format("{0},{1},{2},{3}", borrower.Id, borrower.Name, borrower.Address,
                        borrower.Age,borrower.Violations);
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            
            foreach (var key in listKey)
            {
                if (txtBorrowerID.Text == key.UserID)
                {
                    listKey.Remove(key);
                    break;
                }
            }
            using (var writer = new StreamWriter(_path.PathBorrowerKey, false))
            {   
                
                writer.WriteLine("Username,Password,UserID");
                foreach (var key in listKey)
                {
                    var line = string.Format("{0},{1},{2}" , key.Username, key.Password,key.UserID);
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            
            MessageBox.Show("Delete Successfully");

            frmViewBorrower_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmViewBorrower_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            var listBorrower = new List<Borrower>();
            var dataLoader = new dataLoaderBorrrower();
            dataLoader.Loader(listBorrower);
            dgvBorrower.Rows.Clear();
            var listKey = new List<Key>();
            dataLoader.LoaderBorrowerKey(listKey);
            
            var list = listKey;
            
            var combine = from a in listBorrower
                join b in list on a.Id equals b.UserID
                select new {a.Id, a.Name, a.Address, a.Age, b.Username, b.Password,a.Violations};
            foreach (var t in combine)
                if (t.Id.ToLower().Contains(textBox1.Text.ToLower()))
                    dgvBorrower.Rows.Add(t.Id, t.Name, t.Address, t.Age, t.Username, t.Password,t.Violations);
        }
    }
}