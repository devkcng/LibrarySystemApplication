using System;
using System.Windows.Forms;


namespace LibrarianUI
{
    public partial class frmUser : Form
    {
        

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            btn_New_Click(sender, e);
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_saveuser_Click(object sender, EventArgs e)
        {
            

            btn_New_Click(sender, e);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            

            btn_New_Click(sender, e);
        }

        private void dtg_listUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_id.Text = dtg_listUser.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = dtg_listUser.CurrentRow.Cells[1].Value.ToString();
            txt_username.Text = dtg_listUser.CurrentRow.Cells[2].Value.ToString();
            cbo_type.Text = dtg_listUser.CurrentRow.Cells[3].Value.ToString();

            btn_saveuser.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
            }

            btn_New_Click(sender, e);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}