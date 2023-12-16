using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarianUI
{
    public partial class frmAddBook : Form
    {
        private readonly pathToEntity _path = new pathToEntity();

        public frmAddBook()
        {
            InitializeComponent();
        }

        private void clear()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtCategory.Text = "";
            txtSummary.Text = "";
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                var bisbn = txtISBN.Text;
                var btitle = txtTitle.Text;
                var bauthor = txtAuthor.Text;
                var bcategory = txtCategory.Text;
                var bsummary = txtSummary.Text;

                var listBook = new List<Book>();
                var dataLoader = new dataLoaderBook();
                dataLoader.Loader(listBook);
                foreach (var book in listBook)
                    if (bisbn == book.ISBN)
                    {
                        MessageBox.Show("This ISBN already exists in the file.");
                        return; // Exit the function without adding a new entry
                    }

                // Append the data to the CSV file
                using (var sw = new StreamWriter(_path.PathBook, true))
                {
                    // Format the data as a CSV line
                    var csvLine = $"{bisbn},{btitle},{bauthor},{bcategory},0";

                    // Write the CSV line to the file
                    sw.WriteLine(csvLine);
                }
                
                using (StreamWriter writer = new StreamWriter(_path.PathSummary +"/" + bisbn + ".txt" , true))
                {
                    // Write book details to the file
                    writer.WriteLine($"ISBN: {bisbn}");
                    writer.WriteLine($"Title: {btitle}");
                    writer.WriteLine($"Author: {bauthor}");
                    writer.WriteLine($"Category: {bcategory}");
                    writer.WriteLine("\nSummary: \n");
                    writer.WriteLine(bsummary);
                }

                MessageBox.Show("Book added successfully!");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                clear();
        }
    }
}