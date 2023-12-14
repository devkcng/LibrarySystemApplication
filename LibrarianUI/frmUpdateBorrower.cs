using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dataloader;
using UsersClassLibrary;

namespace LibrarianUI
{
    public partial class frmUpdateBorrower : Form
    {
        private readonly pathToEntity _path = new pathToEntity();
        private readonly Borrower bookBorrowerToUpdate;
        private Key keyToUpdate;

        // Constructor to initialize the form with the book information
        public frmUpdateBorrower(Borrower borrower, Key key)
        {
            InitializeComponent();
            bookBorrowerToUpdate = borrower;
            txtId.Text = borrower.Id;
            txtName.Text = borrower.Name;
            txtAddress.Text = borrower.Address;
            txtAge.Text = borrower.Age;
            txtUsername.Text = key.Username;
            txtPassword.Text = key.Password;
        }

        private void clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtAge.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bookBorrowerToUpdate.Id = txtId.Text;
            bookBorrowerToUpdate.Name = txtName.Text;
            bookBorrowerToUpdate.Address = txtAddress.Text;
            bookBorrowerToUpdate.Age = txtAge.Text;
            keyToUpdate.Username = txtUsername.Text;
            keyToUpdate.Password = txtPassword.Text;
            var listBorrower = new List<Borrower>();
            var dataLoader = new dataLoaderBorrrower();
            dataLoader.Loader(listBorrower);
            var listKey = new List<Key>();
            dataLoader.LoaderBorrowerKey(listKey);

            foreach (var t in listBorrower)
                if (t.Id == bookBorrowerToUpdate.Id)
                {
                    t.Id = bookBorrowerToUpdate.Id;
                    t.Name = bookBorrowerToUpdate.Name;
                    t.Address = bookBorrowerToUpdate.Address;
                    t.Age = bookBorrowerToUpdate.Age;
                }
        
            foreach (var t in listKey)
                if (t.UserID == bookBorrowerToUpdate.Id)
                {
                    t.Username = keyToUpdate.Username;
                    t.Password = keyToUpdate.Password;
                }
            using (var writer = new System.IO.StreamWriter(_path.PathBorrower))
            {
                writer.WriteLine("Id,Name,Address,Age");
                foreach (var t in listBorrower)
                {
                    var line = string.Format("{0},{1},{2},{3}", t.Id, t.Name, t.Address, t.Age);
                    writer.WriteLine(line);
                }
            }
            using (var writer = new System.IO.StreamWriter(_path.PathBorrowerKey))
            {
                writer.WriteLine("username,password,BorrowerID");
                foreach (var t in listKey)
                {
                    var line = string.Format("{0},{1},{2}",  t.Username, t.Password, t.UserID);
                    writer.WriteLine(line);
                }
            }
            
            MessageBox.Show("Book updated successfully!");
            clear();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}