using System;
using System.Windows.Forms;


namespace LibrarianUI
{
    public partial class frmCategories : Form
    {
       

        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            btnnew_Click(sender, e);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           

            btnnew_Click(sender, e);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
        }

        private void dtglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}