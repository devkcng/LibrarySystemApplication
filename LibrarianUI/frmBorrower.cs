using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace LibrarianUI
{
    public partial class frmBorrower : Form
    {
       

        public frmBorrower()
        {
            InitializeComponent();
        }

        private void navigate_records(int inc)
        {
          
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            
        }

        private void frmBorrower_Load(object sender, EventArgs e)
        {
            btn_New_Click(sender, e);
        }

        private void txt_bid_TextChanged(object sender, EventArgs e)
        {
            
                
            
        }

        private void clearme()
        {
            txt_fname.Clear();
            txt_lname.Clear();
            txt_mname.Clear();
            rch_address.Clear();
            txtContact.Clear();
            txtCourse.Clear();
            txtPhoto.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           
            btn_New_Click(sender, e);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            //With OpenFileDialog1

            //    'CHECK THE SELECTED FILE IF IT EXIST OTHERWISE THE DIALOG BOX WILL DISPLAY A WARNING.
            OpenFileDialog1.CheckFileExists = true;


            //    'CHECK THE SELECTED PATH IF IT EXIST OTHERWISE THE DIALOG BOX WILL DISPLAY A WARNING.
            OpenFileDialog1.CheckPathExists = true;


            //    'GET AND SET THE DEFAULT EXTENSION
            OpenFileDialog1.DefaultExt = "jpg";


            //    'RETURN THE FILE LINKED TO THE LNK FILE
            OpenFileDialog1.DereferenceLinks = true;

            //    'SET THE FILE NAME TO EMPTY 
            OpenFileDialog1.FileName = "";

            //    'FILTERING THE FILES
            OpenFileDialog1.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.jpg)|*.jpg|All files|*.*";

            //    'SET THIS FOR ONE FILE SELECTION ONLY.
            OpenFileDialog1.Multiselect = false;


            //    'SET THIS TO PUT THE CURRENT FOLDER BACK TO WHERE IT HAS STARTED.
            OpenFileDialog1.RestoreDirectory = true;

            //    'SET THE TITLE OF THE DIALOG BOX.
            OpenFileDialog1.Title = "Select a file to open";

            //    'ACCEPT ONLY THE VALID WIN32 FILE NAMES.
            OpenFileDialog1.ValidateNames = true;

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPhoto.Text = OpenFileDialog1.FileName;
                PictureBox1.ImageLocation = OpenFileDialog1.FileName;
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            
                btn_New_Click(sender, e);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
           
        }

        private void dtg_ABorrowLists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_bid.Text = dtg_ABorrowLists.CurrentRow.Cells[0].Value.ToString();
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            
        }
    }
}