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
            Hide();
            Form frm = new BorrowerLoginUI();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form frm = new DashBoardLibrarian();
            frm.Show();
        }
    }
}