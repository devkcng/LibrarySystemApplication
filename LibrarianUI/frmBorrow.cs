using System;
using System.Data;
using System.Windows.Forms;


namespace LibrarianUI
{
    public partial class frmBorrow : Form
    {
        

        public frmBorrow()
        {
            InitializeComponent();
        }

        private void txtAccesionNumBorrow_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBorrowerId_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btn_Bsave_Click(object sender, EventArgs e)
        {
            

            btnNew_Click(sender, e);
        }

        private void check_due_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}