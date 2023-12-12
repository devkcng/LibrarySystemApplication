using System;
using System.Data;
using System.Windows.Forms;


namespace LibrarianUI
{
    public partial class frmOverdue : Form
    {
        

        public frmOverdue()
        {
            InitializeComponent();
        }

        private void btnPenNew_Click(object sender, EventArgs e)
        {
            
        }

        private void frmOverdue_Load(object sender, EventArgs e)
        {
            btnPenNew_Click(sender, e);
        }

        private void txtSearchPborrower_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgPenalties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txthours_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txttenderedAmount_TextChanged(object sender, EventArgs e)
        {
            double change;
            change = double.Parse(txttenderedAmount.Text) - double.Parse(txtTotPay.Text);
            txtChange.Text = change.ToString();
        }

        private void btnPSave_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == "" || txthours.Text == "" || txttenderedAmount.Text == "" ||
                txtOverdueTime.Text == "")
            {
                MessageBox.Show("You must fill all the fields inorder to save.", "Invalid", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (int.Parse(txtChange.Text) < 0)
            {
                MessageBox.Show("The tendered amount is less than the total payments. Its not valid", "Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            
            btnPenNew_Click(sender, e);
        }

        private void btnPenClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}