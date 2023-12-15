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
using BookClassLibrary;
using UsersClassLibrary;

namespace LibrarianUI
{
    public partial class frmInforBorrower : Form
    {
        List<Borrower> borrowers= new List<Borrower>();
        string borrowerID;
        List<Book> book= new List<Book>();
        string bookISBN;
        public frmInforBorrower(string id, string bookISBN)
        {
            InitializeComponent();
            borrowerID = id;
            this.bookISBN = bookISBN;
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
            new dataLoaderBook().Loader(book);
            foreach (var b in book)
            {
                if (b.ISBN == bookISBN)
                {
                    txt_ISBN.Text = b.ISBN;
                    txt_Title.Text = b.Title;
                    txt_Author.Text = b.Author;
                    txt_Category.Text = b.Category;
                    
                }
            }
        }
    }
}
