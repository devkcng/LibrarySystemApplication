using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BookClassLibrary;
using Dataloader;

namespace LibrarianUI
{
    public partial class frmTransaction : Form
    {
        private readonly pathToEntity _path = new pathToEntity();
        public frmTransaction()
        {
            InitializeComponent();
        }
        private DateTime ConvertStringToDateTime(string dateString)
        {
            
            string format = "dd/MM/yyyy";

            
            DateTime parsedDate = DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture);

            
            DateTime result = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day);

            return result;
        }
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                
                var historyBorrow = new List<Transaction>();
                var dataLoaderHistoryBorrow = new dataLoaderTransactions();
                dataLoaderHistoryBorrow.LoaderBorrow(historyBorrow);
                
                var historyReturn = new List<Transaction>();
                var dataLoaderHistoryReturn = new dataLoaderTransactions();
                dataLoaderHistoryReturn.LoaderReturn(historyReturn);
                
                dataGridView1.Rows.Clear();
                if (historyReturn.Count == historyBorrow.Count)
                {
                     var combine = from a in historyBorrow
                        join b in historyReturn on new { a.BorrowerID, a.ISBN } equals new { b.BorrowerID, b.ISBN }
                        select new { a.BorrowerID, a.ISBN, a.Time, SomeValue = ConvertStringToDateTime(a.Time).AddDays(28).ToString(("dd/MM/yyyy")), ReturnTime = b.Time };
                     foreach (var t in combine) dataGridView1.Rows.Add(t.BorrowerID, t.ISBN, t.Time,t.SomeValue, t.ReturnTime);
                }
                else
                {
                    var combine = historyBorrow
                        .GroupJoin(
                            historyReturn,
                            borrow => new { borrow.BorrowerID, borrow.ISBN },
                            @return => new { @return.BorrowerID, @return.ISBN },
                            (borrow, returns) => new
                            {
                                borrow.BorrowerID,
                                borrow.ISBN,
                                borrow.Time,
                                SomeValue = ConvertStringToDateTime(borrow.Time).AddDays(28).ToString("dd/MM/yyyy"),
                                ReturnTime = returns.FirstOrDefault()?.Time    // for null value
                            })
                        .ToList();
                    foreach (var t in combine) dataGridView1.Rows.Add(t.BorrowerID, t.ISBN, t.Time,t.SomeValue, t.ReturnTime);
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        if (DateTime.ParseExact(row.Cells[3].Value.ToString(), "dd/MM/yyyy", null).Date <= DateTime.Now.Date && row.Cells[4].Value==null)
                        {
                            row.DefaultCellStyle.BackColor = Color.Brown;
                        }
                    }
                }



            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            var historyBorrow = new List<Transaction>();
            var dataLoaderHistoryBorrow = new dataLoaderTransactions();
            dataLoaderHistoryBorrow.LoaderBorrow(historyBorrow);
                
            var historyReturn = new List<Transaction>();
            var dataLoaderHistoryReturn = new dataLoaderTransactions();
            dataLoaderHistoryReturn.LoaderReturn(historyReturn);
                
            dataGridView1.Rows.Clear();
            if (historyReturn.Count == historyBorrow.Count)
            {
                var combine = from a in historyBorrow
                    join b in historyReturn on new { a.BorrowerID, a.ISBN } equals new { b.BorrowerID, b.ISBN }
                    select new { a.BorrowerID, a.ISBN, a.Time, SomeValue = ConvertStringToDateTime(a.Time).AddDays(28).ToString(("dd/MM/yyyy")), ReturnTime = b.Time };
                foreach (var t in combine)
                    if (t.ISBN.ToLower().Contains(textBox1.Text.ToLower())) 
                        dataGridView1.Rows.Add(t.BorrowerID, t.ISBN, t.Time,t.SomeValue, t.ReturnTime);
            }
            else
            {
                var combine = historyBorrow
                    .GroupJoin(
                        historyReturn,
                        borrow => new { borrow.BorrowerID, borrow.ISBN },
                        @return => new { @return.BorrowerID, @return.ISBN },
                        (borrow, returns) => new
                        {
                            borrow.BorrowerID,
                            borrow.ISBN,
                            borrow.Time,
                            SomeValue = ConvertStringToDateTime(borrow.Time).AddDays(28).ToString("dd/MM/yyyy"),
                            ReturnTime = returns.FirstOrDefault()?.Time    // for null value
                        })
                    .ToList();
                
                foreach (var t in combine)
                    if (t.ISBN.ToLower().Contains(textBox1.Text.ToLower())) 
                        dataGridView1.Rows.Add(t.BorrowerID, t.ISBN, t.Time,t.SomeValue, t.ReturnTime);
            }
            
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex != dataGridView1.Rows.Count - 1)
            {
                Form frm = new frmInforBorrower(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                frm.ShowDialog();
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmTransaction_Load(sender, e);
        }

        
    }
}