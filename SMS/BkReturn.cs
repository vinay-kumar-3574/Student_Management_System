using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class BkReturn : UserControl
    {
        public BkReturn()
        {
            InitializeComponent();
        }

        private void BkReturn_Load(object sender, EventArgs e)
        {
            LoadIssuedBooks();
        }

        private void LoadIssuedBooks()
        {
            try
            {
                WControls.DBConOpen();
                SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT Student_id, Card_no, [Book Name], Issue_date, Submit_date, Total_fine, Report " +
                    "FROM Library WHERE Submit_date IS NULL OR Submit_date = ''", 
                    WControls.connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                dataGridView1.DataSource = table;
                
                // Set column headers
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "Student ID";
                    dataGridView1.Columns[1].HeaderText = "Card No";
                    dataGridView1.Columns[2].HeaderText = "Book Name";
                    dataGridView1.Columns[3].HeaderText = "Issue Date";
                    dataGridView1.Columns[4].HeaderText = "Return Date";
                    dataGridView1.Columns[5].HeaderText = "Fine";
                    dataGridView1.Columns[6].HeaderText = "Report";
                }

                WControls.DBConClose();
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Error Loading Data", ex.Message.ToString());
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Search_txb.Text))
                {
                    LoadIssuedBooks();
                    return;
                }

                WControls.DBConOpen();
                SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT Student_id, Card_no, [Book Name], Issue_date, Submit_date, Total_fine, Report " +
                    "FROM Library WHERE (Submit_date IS NULL OR Submit_date = '') AND " +
                    "(Student_id LIKE '%" + Search_txb.Text + "%' OR [Book Name] LIKE '%" + Search_txb.Text + "%')", 
                    WControls.connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                dataGridView1.DataSource = table;
                
                // Set column headers
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "Student ID";
                    dataGridView1.Columns[1].HeaderText = "Card No";
                    dataGridView1.Columns[2].HeaderText = "Book Name";
                    dataGridView1.Columns[3].HeaderText = "Issue Date";
                    dataGridView1.Columns[4].HeaderText = "Return Date";
                    dataGridView1.Columns[5].HeaderText = "Fine";
                    dataGridView1.Columns[6].HeaderText = "Report";
                }

                WControls.DBConClose();
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Error Searching", ex.Message.ToString());
            }
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    WControls.ShowToasterMsg("WARNING", "Selection Required", "Please select a book to return.");
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string studentId = selectedRow.Cells[0].Value.ToString();
                string bookName = selectedRow.Cells[2].Value.ToString();
                string issueDate = selectedRow.Cells[3].Value.ToString();

                // Validate that the book is actually issued
                if (string.IsNullOrEmpty(issueDate))
                {
                    WControls.ShowToasterMsg("ERROR", "Invalid Selection", "This book was not issued properly.");
                    return;
                }

                // Calculate late fee if applicable
                DateTime issueDateTime;
                if (DateTime.TryParse(issueDate, out issueDateTime))
                {
                    DateTime currentDate = DateTime.Now;
                    TimeSpan daysDifference = currentDate - issueDateTime;
                    int daysOverdue = daysDifference.Days - 7; // Assuming 7 days loan period

                    if (daysOverdue > 0)
                    {
                        decimal lateFee = daysOverdue * 5; // $5 per day late fee
                        Total_fine_tbx.Text = lateFee.ToString("F2");
                        
                        DialogResult result = MessageBox.Show(
                            $"This book is {daysOverdue} days overdue. Late fee: ${lateFee:F2}\n\nDo you want to proceed with the return?",
                            "Late Return",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        Total_fine_tbx.Text = "0.00";
                    }
                }
                else
                {
                    Total_fine_tbx.Text = "0.00";
                }

                // Update the database
                WControls.DBConOpen();
                string returnDate = DateTime.Now.ToString("yyyy-MM-dd");
                string fine = Total_fine_tbx.Text;
                string report = Report_tbx.Text;

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Library SET Submit_date = @Submit_date, Total_fine = @Total_fine, Report = @Report " +
                    "WHERE Student_id = @Student_id AND [Book Name] = @Book_Name AND (Submit_date IS NULL OR Submit_date = '')",
                    WControls.connection);

                cmd.Parameters.AddWithValue("@Submit_date", returnDate);
                cmd.Parameters.AddWithValue("@Total_fine", fine);
                cmd.Parameters.AddWithValue("@Report", report);
                cmd.Parameters.AddWithValue("@Student_id", studentId);
                cmd.Parameters.AddWithValue("@Book_Name", bookName);

                int rowsAffected = cmd.ExecuteNonQuery();
                WControls.DBConClose();

                if (rowsAffected > 0)
                {
                    WControls.ShowToasterMsg("SUCCESS", "Book Returned", "Book has been successfully returned.");
                    
                    // Clear form
                    Total_fine_tbx.Clear();
                    Report_tbx.Clear();
                    
                    // Refresh the list
                    LoadIssuedBooks();
                }
                else
                {
                    WControls.ShowToasterMsg("ERROR", "Return Failed", "Failed to return the book. It may have already been returned.");
                }
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Error Returning Book", ex.Message.ToString());
            }
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            LoadIssuedBooks();
            Search_txb.Clear();
            Total_fine_tbx.Clear();
            Report_tbx.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Student_id_tbx.Text = selectedRow.Cells[0].Value.ToString();
                Card_no_tbx.Text = selectedRow.Cells[1].Value.ToString();
                Book_name_tbx.Text = selectedRow.Cells[2].Value.ToString();
                Issue_date_tbx.Text = selectedRow.Cells[3].Value.ToString();
            }
        }
    }
}
