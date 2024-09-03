using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class StudentTerminate : UserControl
    {
        public StudentTerminate()
        {
            InitializeComponent();
        }

        DataGridView dataGridView = new DataGridView();
        void LoadData()
        {
            try
            {
                dataGridView1.Visible = false;
                WControls.DBConOpen();

                SqlDataAdapter adapter = new SqlDataAdapter("select * from Student", WControls.connection);
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    DelLastStd_btn.Visible = false;
                    LastStudPic_pb.Visible = false;
                    LastStudN_lbl.Visible = false;
                    LastStudId_lbl.Visible = false;
                    LastStudN_lbl.Visible = false;
                    Phone_lbl.Visible = false;
                    label5.Visible = false;
                }
                else
                {

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

                        BackPanel.Controls.Remove(dataGridView);

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
                        WControls.DBConClose();
                    }
                    catch (Exception ex)
                    {
                        WControls.ShowToasterMsg("ERROR", "Error Loading Data", ex.Message);

                        WControls.DBConClose();
                    }



                }


            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR","Error Loading Data",ex.Message);
            }
            finally
            {
                WControls.DBConClose();
            }
        }

        private void StudentTerminate_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch(Exception ex)
            {
                WControls.ShowToasterMsg("ERROR","Something Went Wrong",ex.Message.ToString());
            }
        }

        SqlCommand cmd;
        private void DelLastStd_btn_Click(object sender, EventArgs e)
        {
            try
            {
                WControls.DBConOpen();
                cmd = new SqlCommand("Delete from Student Where Student_id='"+LastStudId_lbl.Text+"' and Phone='"+Phone_lbl.Text+"'",WControls.connection);
                cmd.ExecuteNonQuery();
                WControls.DBConClose();
                LoadData();                
                WControls.ShowToasterMsg("SUCCESS","Record Deleted","Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR","Something Went Wrong",ex.Message.ToString());
                WControls.DBConClose();
            }
            finally
            {
                WControls.DBConClose();
            }
        }

        private void DelOthStd_btn_Click(object sender, EventArgs e)
        {
            try
            {
                WControls.DBConOpen();
                cmd = new SqlCommand("Delete from Student Where Student_id='" + SearchDel_tbx.Text + "'", WControls.connection);
                cmd.ExecuteNonQuery();
                SearchDel_tbx.Text = null;
                WControls.DBConClose();
                LoadData();
                WControls.ShowToasterMsg("SUCCESS", "Record Deleted", "Student Record Deleted");
            }
            catch(Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Something Went Wrong", ex.Message.ToString());
                WControls.DBConClose();
            }
            finally
            {
                WControls.DBConClose();
            }            
        }
    }
}
