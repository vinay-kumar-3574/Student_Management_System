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
    public partial class BkIssue : UserControl
    {
        public BkIssue()
        {
            InitializeComponent();
        }

        private void BkIssue_Load(object sender, EventArgs e)
        {

        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                WControls.DBConOpen();
                int n = Int16.Parse(Search_txb.Text);
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Student where Student_id='" + Search_txb.Text + "'", WControls.connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table != null)
                {
                    Student_id_tbx.Text = table.Rows[0][0].ToString();
                    StudentName_tbx.Text = table.Rows[0][1].ToString();
                    Sec_tbx.Text = table.Rows[0][8].ToString();
                    Library_tbx.Text = table.Rows[0][9].ToString();                    
                }
                else
                {
                    WControls.ShowToasterMsg("ACTION NEEDED", "Action Needed ", "Something Went Wrong!!");
                }

                WControls.DBConClose();
            }
            catch (Exception ex)
            {
                WControls.ShowToasterMsg("ERROR", "Error on Loading", ex.Message.ToString());
            }
        }
    }
}
