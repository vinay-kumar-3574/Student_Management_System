using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class ToasterMsg : Form
    {
        int X, Y;
        public ToasterMsg(string type, string TypeMsg,string message)
        {
            InitializeComponent();
            this.TopMost = true;
            Msgbrief_lbl.Text = message;
            if (type.ToString() == "SUCCESS")
            {
                MsgType_lbl.Text = TypeMsg.ToString();
                Statusbar_pnl.BackColor = Color.Green;
                TypePic_pb.Image = global::SMS.Properties.Resources.Success;
            }
            else if (type.ToString() == "ACTION NEEDED")
            {
                MsgType_lbl.Text = TypeMsg.ToString();
                Statusbar_pnl.BackColor = Color.Orange;
                TypePic_pb.Image = global::SMS.Properties.Resources.Warning;
            }
            else if (type.ToString() == "ERROR")
            {
                MsgType_lbl.Text = TypeMsg.ToString();
                Statusbar_pnl.BackColor = Color.Red;
                TypePic_pb.Image = global::SMS.Properties.Resources.Error;
            }

        }

        private void ToasterMsg_Load(object sender, EventArgs e)
        {
            Position();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Y -= 10;
            this.Location = new Point(X, Y);
            if (Y <= 760)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        int dy = 100;
        private void timer2_Tick(object sender, EventArgs e)
        {
            dy--;
            if (dy <= 0)
            {
                Y += 1;
                this.Location = new Point(X, Y += 10);
                if (Y > 800)
                {
                    timer2.Stop();
                    dy = 100;
                    this.Close();
                }
            }
        }

        private void Position()
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            X = ScreenWidth - this.Width - 5;
            Y = ScreenHeight - this.Height - 10;

            this.Location = new Point(X, Y);
        }

    }
}
