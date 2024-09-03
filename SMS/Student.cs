using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class Student : Form
    {
        // Making the Form Movable -----------------------------//
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Student_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        public Student(AdmissionUC admissionUC)
        {
            InitializeComponent();
        }
        public Student()
        {
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void Close_btn_MouseEnter(object sender, EventArgs e)
        {
            Close_btn.ForeColor = Color.White;
        }

        private void Close_btn_MouseLeave(object sender, EventArgs e)
        {
            Close_btn.ForeColor= Color.Black;
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }


        string Sql_Query,query;
        SqlCommand cmd;
        private void Browse_btn_Click(object sender, EventArgs e)
        {
            OFD_controler.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (OFD_controler.ShowDialog() == DialogResult.OK)
            {
                query = OFD_controler.FileName.ToString();
                Photo_pb.ImageLocation = query;
            }
        }
        private void Save_btn_Click(object sender, EventArgs e)
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
                else
                {
                    WControls.DBConOpen();
                    Sql_Query = "Insert into Student values(@S_ID, @S_Name, @F_Name, @Address, @Phone, @Voter, @Class, @Roll, @Sec, @Library, @Bus, @Photo)";

                    byte[] image = null;
                    FileStream stream = new FileStream(query, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    image = brs.ReadBytes((int)stream.Length);


                    cmd = new SqlCommand(Sql_Query, WControls.connection);
                    cmd.Parameters.AddWithValue("@S_ID", Student_id_tbx.Text);
                    cmd.Parameters.AddWithValue("@S_Name", StudentName_tbx.Text);
                    cmd.Parameters.AddWithValue("@F_Name", FatherName_tbx.Text);
                    cmd.Parameters.AddWithValue("@Address", Add_tbx.Text);
                    cmd.Parameters.AddWithValue("@Phone", Phone_tbx.Text);
                    cmd.Parameters.AddWithValue("@Voter", Voter_tbx.Text);
                    cmd.Parameters.AddWithValue("@Class", Class_tbx.Text);
                    cmd.Parameters.AddWithValue("@Roll", Roll_tbx.Text);
                    cmd.Parameters.AddWithValue("@Sec", Sec_tbx.Text);
                    cmd.Parameters.AddWithValue("@Library", Library_tbx.Text);
                    cmd.Parameters.AddWithValue("@Bus", Bus_tbx.Text);
                    cmd.Parameters.AddWithValue("@Photo", image);
                    cmd.ExecuteNonQuery();
                    ClearInputFields();
                    WControls.ShowToasterMsg("SUCCESS", "Saved Successfully ", "Data Stored in Database");
                    WControls.DBConClose();
                    insert();
                }
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Something Bad Happened", ex.Message.ToString());
            }
            finally
            {
                WControls.DBConClose();
            }
        }
        private void ClearInputFields()
        {
            Student_id_tbx.Text = string.Empty;
            StudentName_tbx.Text = string.Empty;
            FatherName_tbx.Text = string.Empty;
            Add_tbx.Text = string.Empty;
            Phone_tbx.Text = string.Empty;
            Voter_tbx.Text = string.Empty;
            Class_tbx.Text = string.Empty;
            Roll_tbx.Text = string.Empty;
            Sec_tbx.Text = string.Empty;
            Library_tbx.Text = string.Empty;
            Bus_tbx.Text = string.Empty;
            Photo_pb.Image = null;
        }
    }
}

