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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMS
{
    public partial class Register : Form
    {
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }
        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);
        // ----------------------------------------------------------

        // Minimize or Maximize from Taskbar Icon -----------------------//
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;
                var cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                return cp;
            }

        }
        // --------------------------------------------------------

        // Making the Form Movable -----------------------------//
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();               
        
        public Register()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // Rounded Corners ---------------------------------
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            // --------------------------------------------------
        }
        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            WControls.exit();
        }

        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    Pass_tbx.PasswordChar = '\0';
                }
                else
                {
                    Pass_tbx.PasswordChar = '*';
                }
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Something Went Wrong", ex.Message);
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            FName_tbx.Text = LName_tbx.Text = Phone_tbx.Text = UName_tbx.Text = UserType_cmb.Text = Pass_tbx.Text = null;
            DP_cpb.Image = null;
        }

        private void Login_lbl_Click(object sender, EventArgs e)
        {
            L_or_R lr = new L_or_R();
            lr.Show();
            this.Close();
        }

        string query;
        private void Browse_btn_Click(object sender, EventArgs e)
        {
            OFD_controler.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (OFD_controler.ShowDialog() == DialogResult.OK)
            {
                query = OFD_controler.FileName.ToString();
                DP_cpb.ImageLocation = query;
            }
        }

        private void Register_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd;
                byte[] image = null;
                FileStream stream = new FileStream(query, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                WControls.DBConOpen();
                string Sql_query = "Insert into Users Values('" + FName_tbx.Text + "','" + LName_tbx.Text + "','" + Phone_tbx.Text + "','" + UserType_cmb.Text + "','" + UName_tbx.Text +"','"+Pass_tbx.Text+ "',@image)";
                cmd = new SqlCommand(Sql_query, WControls.connection);
                cmd.Parameters.Add(new SqlParameter("@image", image));
                int n = cmd.ExecuteNonQuery();
                WControls.DBConClose();
                WControls.ShowToasterMsg("SUCCESS","Registration Successfull", "You Are SuccessFully Registerd ");
                FName_tbx.Text = LName_tbx.Text = Phone_tbx.Text = UName_tbx.Text = UserType_cmb.Text = Pass_tbx.Text = null;
                DP_cpb.Image = null;
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR","Error Saving",ex.Message.ToString());
            }
            finally
            {
                WControls.DBConClose();
            }
        }
    }
}
