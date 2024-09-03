using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class AdmissionUC : UserControl
    {
        public AdmissionUC()
        {
            InitializeComponent();
        }

        private DataTable table = new DataTable();
        DataGridView dataGridView = new DataGridView();

        public DataTable Source()
        {
            WControls.DBConOpen();
            table.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Student", WControls.connection);
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                label1.Visible = label2.Visible = true;
                panel1.Visible = AdmitNewStud_btn.Visible = ExCSV_btn.Visible = LastStudPic_pb.Visible = LastStudN_lbl.Visible = LastStudId_lbl.Visible = LastStudN_lbl.Visible = Phone_lbl.Visible = label5.Visible = false;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;

                try
                {
                    // Configuration of Last Student Details ---------------
                    int TotalRows = table.Rows.Count;
                    byte[] Photo_array;

                    LastStudN_lbl.Text = table.Rows[TotalRows - 1][1].ToString();
                    LastStudId_lbl.Text = table.Rows[TotalRows - 1][0].ToString();
                    Phone_lbl.Text = table.Rows[TotalRows - 1][4].ToString();
                    Photo_array = (byte[])table.Rows[TotalRows - 1][11];
                    MemoryStream ms = new MemoryStream(Photo_array);
                    LastStudPic_pb.Image = Image.FromStream(ms);

                    // Configuration of DataGridView ---------------
                    dataGridView.Size = new Size(840, 458);
                    dataGridView.Location = dataGridView1.Location;
                    dataGridView.BackgroundColor = SystemColors.ButtonFace;
                    dataGridView.BorderStyle = BorderStyle.None;
                    dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    dataGridView.RowHeadersBorderStyle = dataGridView1.RowHeadersBorderStyle;
                    dataGridView.ColumnHeadersBorderStyle = dataGridView1.ColumnHeadersBorderStyle;
                    dataGridView.ColumnHeadersDefaultCellStyle = dataGridView1.ColumnHeadersDefaultCellStyle;
                    dataGridView.RowsDefaultCellStyle = dataGridView1.RowsDefaultCellStyle;
                    dataGridView.DefaultCellStyle = dataGridView1.DefaultCellStyle;
                    dataGridView.DataSource = table;
                    BackPanel.Controls.Add(dataGridView);

                }
                catch (Exception ex)
                {
                    WControls.ShowToasterMsg("ERROR", "Error Loading Data", ex.Message);
                }
            }
            WControls.DBConClose();
            return table; 
        }

        private void Student_UpdateEventHandler(object sender, Student.UpdateEventArgs args)
        {
            dataGridView.DataSource = Source();
        }
        private void AdmissionUC_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = false;
                dataGridView.DataSource = Source();
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Error Loading Data", ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Student studentfrm = new Student(this);
            studentfrm.UpdateEventHandler += Student_UpdateEventHandler;
            studentfrm.ShowDialog();
        }

        private void AdmitNewStud_btn_Click(object sender, EventArgs e)
        {
            Student studentfrm = new Student(this);
            studentfrm.UpdateEventHandler += Student_UpdateEventHandler;
            studentfrm.ShowDialog();
        }

        private void ExCSV_btn_Click(object sender, EventArgs e)
        {
            GetCSV();            
        }


        private static void CreateCSV(IDataReader reader)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "comma-separated values (*.CSV)|*.csv";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Export Record as CSV..";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the specified file
                    string file = saveFileDialog.FileName;
                    List<string> lines = new List<string>();
                    string headerLine;

                    try
                    {
                        if (reader.Read())
                        {
                            // Create header line
                            string[] columns = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                columns[i] = reader.GetName(i);
                            }
                            headerLine = string.Join(",", columns);
                            lines.Add(headerLine);

                            // Read data rows
                            do
                            {
                                object[] values = new object[reader.FieldCount];
                                reader.GetValues(values);
                                // Convert each value to string to avoid issues with null or special characters
                                string line = string.Join(",", values.Select(value => value?.ToString() ?? string.Empty));
                                lines.Add(line);
                            } while (reader.Read());
                        }

                        // Write the collection to the file
                        File.WriteAllLines(file, lines);
                        WControls.ShowToasterMsg("SUCCESS", "Success", "File saved successfully.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        WControls.ShowToasterMsg("ERROR", "Data Not Saved", "You do not have permission to save to this location.");
                    }
                    catch (IOException ioEx)
                    {
                        WControls.ShowToasterMsg("ERROR", "Data Not Saved", $"I/O error: {ioEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        WControls.ShowToasterMsg("ERROR", "Data Not Saved", ex.Message);
                    }
                }

            }
        }

        void  GetCSV()
        {
            WControls.DBConOpen();
            CreateCSV(new SqlCommand("Select * from Student", WControls.connection).ExecuteReader());         
        }
    }
}
