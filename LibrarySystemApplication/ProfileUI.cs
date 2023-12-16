using Dataloader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersClassLibrary;

namespace LibrarySystemApplication
{
    public partial class ProfileUI : Form
    {
        List<Borrower> borrowers= new List<Borrower>();
        string borrowerID;
        public ProfileUI(string id)
        {
            InitializeComponent();
            borrowerID = id;
        }

        private void ProfileUI_Load(object sender, EventArgs e)
        {
            new dataLoaderBorrrower().Loader(borrowers);
            foreach (Borrower b in borrowers)
            {
                if (b.Id == borrowerID)
                {
                    txt_Address.Text = b.Address;
                    txt_Age.Text = b.Age;
                    txt_ID.Text = b.Id;
                    txt_Name.Text = b.Name;
                }
            }    
        }
    }
}
