using System;
using System.Collections;
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
    public partial class StudentRectify : UserControl
    {
        public StudentRectify()
        {
            InitializeComponent();
        }
        byte[] Photo_array;

        private void Search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                WControls.DBConOpen();
                int n = Int16.Parse(Search_txb.Text);
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Student where Student_id='"+Search_txb.Text+"'", WControls.connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table!= null)
                {
                    Student_id_tbx.Text = table.Rows[0][0].ToString();
                    StudentName_tbx.Text = table.Rows[0][1].ToString();
                    FatherName_tbx.Text = table.Rows[0][2].ToString();
                    Add_tbx.Text = table.Rows[0][3].ToString();
                    Phone_tbx.Text = table.Rows[0][4].ToString();
                    Voter_tbx.Text = table.Rows[0][5].ToString();
                    Class_tbx.Text = table.Rows[0][6].ToString();
                    Roll_tbx.Text = table.Rows[0][7].ToString();
                    Sec_tbx.Text = table.Rows[0][8].ToString();
                    Library_tbx.Text = table.Rows[0][9].ToString();
                    Bus_tbx.Text = table.Rows[0][10].ToString();
                    if (table.Rows[0][11] != null)
                    {
                        Photo_array = (byte[])table.Rows[0][11];
                        MemoryStream ms = new MemoryStream(Photo_array);
                        Photo_pb.Image = Image.FromStream(ms);
                    }
                    else 
                    {
                        WControls.ShowToasterMsg("ERROR", "Photo Error!!","Can't Read or Display Photo");
                    }
                }
                else
                {
                    WControls.ShowToasterMsg("ACTION NEEDED","Action Needed ", "Something Went Wrong!!");
                }

                WControls.DBConClose();
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR","Error on Loading",ex.Message.ToString());
            }
        }
        string query;
        Boolean picChanged = false;
        private void Browse_btn_Click(object sender, EventArgs e)
        {
            OFD_controler.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (OFD_controler.ShowDialog() == DialogResult.OK)
            {
                query = OFD_controler.FileName.ToString();
                Photo_pb.ImageLocation = query;
                picChanged = true;
            }
        }
        string Sql_Query;
        SqlCommand cmd;
        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {

                string[] inputs = new string[]
                {
                    Student_id_tbx.Text,
                    StudentName_tbx.Text,
                    FatherName_tbx.Text,
                    Add_tbx.Text,
                    Phone_tbx.Text,
                    Voter_tbx.Text,
                    Class_tbx.Text,
                    Roll_tbx.Text,
                    Sec_tbx.Text,
                    Library_tbx.Text,
                    Bus_tbx.Text
                };

                if (inputs.Any(input => string.IsNullOrWhiteSpace(input)))
                {
                    WControls.ShowToasterMsg("ACTION NEEDED", "Missing Data", "Fill all Details Carefully!!");
                }
                else if (picChanged == false)
                {                    
                    WControls.DBConOpen();

                    Sql_Query = "UPDATE Student SET [Student_id] = @Student_id, [Name] = @Name, [Father's_Name] = @Fathers_Name, [Address] = @Address, [Phone] = @Phone, [Voter_id] = @Voter_id, [Class] = @Class, [Roll_no] = @Roll_no, [Sec] = @Sec, [Library_Card] = @Library_Card, [Bus] = @Bus, [Photo] = @Photo WHERE [Student_id] = @Search_Student_id";

                    cmd = new SqlCommand(Sql_Query, WControls.connection);

                    cmd.Parameters.AddWithValue("@Student_id", Student_id_tbx.Text);
                    cmd.Parameters.AddWithValue("@Name", StudentName_tbx.Text);
                    cmd.Parameters.AddWithValue("@Fathers_Name", FatherName_tbx.Text);
                    cmd.Parameters.AddWithValue("@Address", Add_tbx.Text);
                    cmd.Parameters.AddWithValue("@Phone", Phone_tbx.Text);
                    cmd.Parameters.AddWithValue("@Voter_id", Voter_tbx.Text);
                    cmd.Parameters.AddWithValue("@Class", Class_tbx.Text);
                    cmd.Parameters.AddWithValue("@Roll_no", Roll_tbx.Text);
                    cmd.Parameters.AddWithValue("@Sec", Sec_tbx.Text);
                    cmd.Parameters.AddWithValue("@Library_Card", Library_tbx.Text);
                    cmd.Parameters.AddWithValue("@Bus", Bus_tbx.Text);
                    cmd.Parameters.AddWithValue("@Photo", Photo_array);
                    cmd.Parameters.AddWithValue("@Search_Student_id", Search_txb.Text);

                    cmd.ExecuteNonQuery();

                    Student_id_tbx.Text = StudentName_tbx.Text = FatherName_tbx.Text = Add_tbx.Text = Phone_tbx.Text = Voter_tbx.Text = Class_tbx.Text = Roll_tbx.Text = Sec_tbx.Text = Library_tbx.Text = Bus_tbx.Text = Search_txb.Text = "";
                    Photo_pb.Image = null;

                    WControls.ShowToasterMsg("SUCCESS", "Saved Successfully", "Data Stored in Database");
                    WControls.DBConClose();

                }
                else if(picChanged == true)
                {

                    WControls.DBConOpen();

                    string Sql_Query = "UPDATE Student SET [Student_id] = @Student_id, [Name] = @Name, [Father's_Name] = @Fathers_Name, [Address] = @Address, [Phone] = @Phone, [Voter_id] = @Voter_id, [Class] = @Class, [Roll_no] = @Roll_no, [Sec] = @Sec, [Library_Card] = @Library_Card, [Bus] = @Bus, [Photo] = @Photo WHERE [Student_id] = @Search_Student_id";
                    
                    
                    byte[] image;
                    FileStream stream = new FileStream(query, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    image = brs.ReadBytes((int)stream.Length);
                    

                    cmd = new SqlCommand(Sql_Query, WControls.connection);

                    cmd.Parameters.AddWithValue("@Student_id", Student_id_tbx.Text);
                    cmd.Parameters.AddWithValue("@Name", StudentName_tbx.Text);
                    cmd.Parameters.AddWithValue("@Fathers_Name", FatherName_tbx.Text);
                    cmd.Parameters.AddWithValue("@Address", Add_tbx.Text);
                    cmd.Parameters.AddWithValue("@Phone", Phone_tbx.Text);
                    cmd.Parameters.AddWithValue("@Voter_id", Voter_tbx.Text);
                    cmd.Parameters.AddWithValue("@Class", Class_tbx.Text);
                    cmd.Parameters.AddWithValue("@Roll_no", Roll_tbx.Text);
                    cmd.Parameters.AddWithValue("@Sec", Sec_tbx.Text);
                    cmd.Parameters.AddWithValue("@Library_Card", Library_tbx.Text);
                    cmd.Parameters.AddWithValue("@Bus", Bus_tbx.Text);
                    cmd.Parameters.AddWithValue("@Photo", image);
                    cmd.Parameters.AddWithValue("@Search_Student_id", Search_txb.Text);

                    cmd.ExecuteNonQuery();
                    Student_id_tbx.Text = StudentName_tbx.Text = FatherName_tbx.Text = Add_tbx.Text = Phone_tbx.Text = Voter_tbx.Text = Class_tbx.Text = Roll_tbx.Text = Sec_tbx.Text = Library_tbx.Text = Bus_tbx.Text = Search_txb.Text = "";
                    Photo_pb.Image = null;
                    WControls.ShowToasterMsg("SUCCESS", "Saved Successfully", "Data Stored in Database");
                    WControls.DBConClose();
                }
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Something Went Wrong", ex.Message.ToString());
            }
            finally
            {
                WControls.DBConClose();
            }
        }
    }
}

