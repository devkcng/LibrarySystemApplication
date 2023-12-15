using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Dataloader;
using UsersClassLibrary;

namespace LibrarianUI
{
    public partial class frmLogin : Form
    {
        private readonly dataLoaderLibrarian dataLoader = new dataLoaderLibrarian();
        private readonly DashBoardLibrarian frm;
        private List<Librarian> listLibrarian = new List<Librarian>();

        public frmLogin(DashBoardLibrarian frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            var listKey = new List<Key>();
            dataLoader.LoaderLibrarianKey(listKey);
            var saveID = "";
            foreach (var key in listKey)
            {
               if(key.Username == UsernameTextBox.Text && key.Password == PasswordTextBox.Text)
                {
                    saveID = key.UserID;
                    break;
                }
            }

            if (saveID == "")
            {
                MessageBox.Show("Wrong UserName OR PassWord", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frm.enabled_menu();
                Close();
            }
        }
    }
}