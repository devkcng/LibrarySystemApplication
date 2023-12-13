﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarianUI
{
    public partial class frmViewBook : Form
    {
        public frmViewBook()
        {
            InitializeComponent();
        }
        private readonly pathToEntity _path = new pathToEntity();
        private string checkStatus(string status)
        {
            if (status == "0")
                return "Available";
            return "Borrowed";
        }


        private void frmViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            var listBook = new List<Book>();
            var dataLoader = new dataLoaderBook();
            dataLoader.Loader(listBook);
            dgvBooks.Rows.Clear();
            dgvBooks.Columns.Clear();
            dgvBooks.Columns.Add("ISBN", "ISBN");
            dgvBooks.Columns.Add("Title", "Title");
            dgvBooks.Columns.Add("Author", "Author");
            dgvBooks.Columns.Add("Category", "Category");
            dgvBooks.Columns.Add("Status", "Status");
            foreach (var book in listBook)
                dgvBooks.Rows.Add(book.ISBN, book.Title, book.Author, book.Category, checkStatus(book.Status));
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                panel2.Visible = true;
                txtISBN.Text = dgvBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = dgvBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAuthor.Text = dgvBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCategory.Text = dgvBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtStatus.Text = dgvBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var listBook = new List<Book>();
            var dataLoader = new dataLoaderBook();
            dataLoader.Loader(listBook);
            foreach (var book in listBook)
                if (txtISBN.Text == book.ISBN)
                {
                    book.Title = txtTitle.Text;
                    book.Author = txtAuthor.Text;
                    book.Category = txtCategory.Text;
                    book.Status = txtStatus.Text;
                    break;
                }

            using (var writer = new StreamWriter(_path.PathBook, false))
            {
                writer.WriteLine("ISBN,Title,Author,Category,Status");
                foreach (var book in listBook)
                {
                    var line = string.Format("{0},{1},{2},{3},{4}", book.ISBN, book.Title, book.Author, book.Category,
                        book.Status);
                    writer.WriteLine(line);
                }
            }

            frmViewBook_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var listBook = new List<Book>();
            var dataLoader = new dataLoaderBook();
            dataLoader.Loader(listBook);
            foreach (var book in listBook)
                if (txtISBN.Text == book.ISBN)
                {
                    listBook.Remove(book);
                    break;
                }

            using (var writer = new StreamWriter(_path.PathBook, false))
            {
                writer.WriteLine("ISBN,Title,Author,Category,Status");
                foreach (var book in listBook)
                {
                    var line = string.Format("{0},{1},{2},{3},{4}", book.ISBN, book.Title, book.Author, book.Category,
                        book.Status);
                    writer.WriteLine(line);
                }
            }

            frmViewBook_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmViewBook_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var listBook = new List<Book>();
            var dataLoader = new dataLoaderBook();
            dataLoader.Loader(listBook);
            dgvBooks.Rows.Clear();
            dgvBooks.Columns.Clear();
            dgvBooks.Columns.Add("ISBN", "ISBN");
            dgvBooks.Columns.Add("Title", "Title");
            dgvBooks.Columns.Add("Author", "Author");
            dgvBooks.Columns.Add("Category", "Category");
            dgvBooks.Columns.Add("Status", "Status");
            var books = from a in listBook where a.Title.ToLower().Contains(textBox1.Text.ToLower()) select a;
            foreach (var book in books)
                dgvBooks.Rows.Add(book.ISBN, book.Title, book.Author, book.Category, checkStatus(book.Status));
        }
    }
}