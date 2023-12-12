using System;
using System.Data;
using System.Windows.Forms;


namespace LibrarianUI
{
    public partial class frmReturned : Form
    {
       

        public frmReturned()
        {
            InitializeComponent();
        }

        private void frmReturned_Load(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            

            txtrbooksSearch_TextChanged(sender, e);
        }

        private void txtrbooksSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearchPborrower_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dtg_RlistReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Rsave_Click(object sender, EventArgs e)
        {
            

            btnNew_Click(sender, e);
        }
    }
}