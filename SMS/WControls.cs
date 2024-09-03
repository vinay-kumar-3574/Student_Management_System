using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS
{
    internal class WControls
    {
        static bool isMax = false;
        static Size old_size, default_size;
        static Point old_loc, default_loc;

        public static void SetInitial(Form form)
        {
            old_size = form.Size;
            default_size = form.Size;
            old_loc = form.Location;
            default_loc = form.Location;
        }
        public static void Maximize(Form form)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            form.WindowState = FormWindowState.Normal;
            form.Location = new Point(0, 0);
            form.Size = new Size(x, y);
        }
        public static void DoMax(Form form)
        {
            if (isMax == false)
            {
                old_loc = new Point(form.Location.X, form.Location.Y);
                old_size = new Size(form.Size.Width, form.Size.Height);
                Maximize(form);
                isMax = true;
            }
            else
            {
                form.Location = old_loc;
                form.Size = old_size;
                isMax = false;

            }
        }

        public static void Minimize(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            else if (form.WindowState == FormWindowState.Normal)
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }

        public static void exit()
        {
            Application.Exit();
        }
        public static SqlConnection connection = new SqlConnection("Data Source=RABINDRA\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;");
        public static void DBConOpen()
        {
            connection.Open();
        }
        public static void DBConClose()
        {
            connection.Close();
        }

        public static void ShowToasterMsg(string type, string TypeMsg,string message)
        {
            ToasterMsg toaster = new ToasterMsg(type, TypeMsg, message);
            toaster.Show();
        }
    }
}
