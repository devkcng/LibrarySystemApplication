﻿using System;
using System.Windows.Forms;
using LibrarySystem.Includes;

namespace LibrarySystem
{
    public partial class frmCategories : Form
    {
        private readonly SQLConfig config = new SQLConfig();
        private readonly usableFunction funct = new usableFunction();
        private string sql, categoryid;

        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            btnnew_Click(sender, e);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            categoryid = "0";
            txtCategory.Clear();
            txtDeweyDecimal.Clear();
            sql = "Select CategoryId,`Category`,`DDecimal` as 'DeweyDecimal' From tblcategory WHERE Category !='ALL'";
            config.Load_DTG(sql, dtglist);
            btndelete.Enabled = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == "") funct.emptymessage();

            sql = "Select * From tblcategory WHERE CategoryId = '" + categoryid + "'";
            config.singleResult(sql);
            if (config.dt.Rows.Count > 0)
            {
                sql = "UPDATE `tblcategory` SET `Category`='" + txtCategory.Text + "',`DDecimal`='" +
                      txtDeweyDecimal.Text + "' WHERE CategoryId='" + categoryid + "'";
                config.Execute_CUD(sql, "error to execute the query.", "Category has been updated in the database.");
            }
            else
            {
                sql = "INSERT INTO `tblcategory` (`Category`,`DDecimal`) VALUES ('" + txtCategory.Text + "','" +
                      txtDeweyDecimal.Text + "')";
                config.Execute_CUD(sql, "error to execute the query.", "New category has been saved in the database.");
            }

            btnnew_Click(sender, e);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sql = "Delete From tblcategory WHERE CategoryId = " + dtglist.CurrentRow.Cells[0].Value;
            config.Execute_Query(sql);
            MessageBox.Show("Data has been deleted.");
            btnnew_Click(sender, e);
        }

        private void dtglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            categoryid = dtglist.CurrentRow.Cells[0].Value.ToString();
            txtCategory.Text = dtglist.CurrentRow.Cells[1].Value.ToString();
            txtDeweyDecimal.Text = dtglist.CurrentRow.Cells[2].Value.ToString();
            btndelete.Enabled = true;
        }
    }
}