using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Dataloader;
using UsersClassLibrary;

namespace LibrarianUI
{
    public partial class frmAddBorrower : Form
    {
        private readonly pathToEntity _path = new pathToEntity();

        public frmAddBorrower()
        {
            InitializeComponent();
        }

        private void clear()
        {
            txtBorrowerID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var borrowerID = txtBorrowerID.Text;
                var name = txtName.Text;
                var address = txtAddress.Text;
                var age = txtAge.Text;
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                var listBorrower = new List<Borrower>();
                var dataLoaderInfo = new dataLoaderBorrrower();

                dataLoaderInfo.Loader(listBorrower);

                var listKey = new List<string>();
                var dataLoaderKey = new dataLoaderBorrrower();
                dataLoaderKey.LoaderBorrowerKey(listKey);
                foreach (var borrower in listBorrower)
                    if (borrowerID == borrower.Id)
                    {
                        MessageBox.Show("This BorrowerID already exists in the file.");
                        return; // Exit the function without adding a new entry
                    }

                foreach (var key in listKey)
                    if (username == key.Split(',')[0])
                    {
                        MessageBox.Show("This username already exists in the file.");
                        return; // Exit the function without adding a new entry
                    }


                using (var sw = new StreamWriter(_path.PathBorrower, true))
                {
                    // Format the data as a CSV line
                    var csvLine = $"{borrowerID},{name},{address},{age}";

                    // Write the CSV line to the file
                    sw.WriteLine(csvLine);
                }

                // Append the data to the CSV file

                using (var sw = new StreamWriter(_path.PathBorrowerKey, true))
                {
                    // Format the data as a CSV line
                    var csvLine = $"{username},{password},{borrowerID}";

                    // Write the CSV line to the file
                    sw.WriteLine(csvLine);
                }

                MessageBox.Show("Borrower added successfully.");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                clear();
        }
    }
}