using System;
using System.Windows.Forms;
using LibrarianUI;

namespace LibrarySystemApplication
{
    public partial class CommonUI : Form
    {
        public CommonUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            Form frm = new BorrowerLoginUI();
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
            Form frm = new DashBoardLibrarian();
            frm.ShowDialog();
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}