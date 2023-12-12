using System;
using System.Windows.Forms;

namespace LibrarianUI
{
    public partial class BookManagement : Form
    {
        public BookManagement()
        {
            InitializeComponent();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;

            btnSave.Enabled = true;

            btnDelete.Enabled = false;
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmBooks_Load(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmBooks_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmBooks_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }
    }
}