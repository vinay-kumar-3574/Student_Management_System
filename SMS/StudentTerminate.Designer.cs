namespace SMS
{
    partial class StudentTerminate
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchDel_tbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DelOthStd_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Phone_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DelLastStd_btn = new System.Windows.Forms.Button();
            this.LastStudId_lbl = new System.Windows.Forms.Label();
            this.LastStudN_lbl = new System.Windows.Forms.Label();
            this.LastStudPic_pb = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BackPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastStudPic_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.White;
            this.BackPanel.Controls.Add(this.panel2);
            this.BackPanel.Controls.Add(this.groupBox1);
            this.BackPanel.Controls.Add(this.panel1);
            this.BackPanel.Controls.Add(this.Phone_lbl);
            this.BackPanel.Controls.Add(this.label5);
            this.BackPanel.Controls.Add(this.DelLastStd_btn);
            this.BackPanel.Controls.Add(this.LastStudId_lbl);
            this.BackPanel.Controls.Add(this.LastStudN_lbl);
            this.BackPanel.Controls.Add(this.LastStudPic_pb);
            this.BackPanel.Controls.Add(this.dataGridView1);
            this.BackPanel.Location = new System.Drawing.Point(20, 14);
            this.BackPanel.Margin = new System.Windows.Forms.Padding(30, 30, 30, 2);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(864, 678);
            this.BackPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(554, -7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 200);
            this.panel2.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.SearchDel_tbx);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DelOthStd_btn);
            this.groupBox1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(586, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 157);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete Other Student";
            // 
            // SearchDel_tbx
            // 
            this.SearchDel_tbx.Location = new System.Drawing.Point(40, 48);
            this.SearchDel_tbx.Multiline = true;
            this.SearchDel_tbx.Name = "SearchDel_tbx";
            this.SearchDel_tbx.Size = new System.Drawing.Size(166, 29);
            this.SearchDel_tbx.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Student Id";
            // 
            // DelOthStd_btn
            // 
            this.DelOthStd_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.DelOthStd_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.DelOthStd_btn.FlatAppearance.BorderSize = 2;
            this.DelOthStd_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(232)))));
            this.DelOthStd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelOthStd_btn.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelOthStd_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.DelOthStd_btn.Location = new System.Drawing.Point(40, 86);
            this.DelOthStd_btn.Name = "DelOthStd_btn";
            this.DelOthStd_btn.Size = new System.Drawing.Size(166, 62);
            this.DelOthStd_btn.TabIndex = 9;
            this.DelOthStd_btn.Text = "Delete Student";
            this.DelOthStd_btn.UseVisualStyleBackColor = false;
            this.DelOthStd_btn.Click += new System.EventHandler(this.DelOthStd_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 5);
            this.panel1.TabIndex = 10;
            // 
            // Phone_lbl
            // 
            this.Phone_lbl.AutoSize = true;
            this.Phone_lbl.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone_lbl.Location = new System.Drawing.Point(148, 106);
            this.Phone_lbl.Name = "Phone_lbl";
            this.Phone_lbl.Size = new System.Drawing.Size(59, 20);
            this.Phone_lbl.TabIndex = 8;
            this.Phone_lbl.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 32);
            this.label5.TabIndex = 7;
            this.label5.Text = "Last Student";
            // 
            // DelLastStd_btn
            // 
            this.DelLastStd_btn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.DelLastStd_btn.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.DelLastStd_btn.FlatAppearance.BorderSize = 2;
            this.DelLastStd_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(232)))));
            this.DelLastStd_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelLastStd_btn.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelLastStd_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.DelLastStd_btn.Location = new System.Drawing.Point(365, 64);
            this.DelLastStd_btn.Name = "DelLastStd_btn";
            this.DelLastStd_btn.Size = new System.Drawing.Size(166, 62);
            this.DelLastStd_btn.TabIndex = 6;
            this.DelLastStd_btn.Text = "Delete Last Student";
            this.DelLastStd_btn.UseVisualStyleBackColor = false;
            this.DelLastStd_btn.Click += new System.EventHandler(this.DelLastStd_btn_Click);
            // 
            // LastStudId_lbl
            // 
            this.LastStudId_lbl.AutoSize = true;
            this.LastStudId_lbl.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastStudId_lbl.Location = new System.Drawing.Point(148, 86);
            this.LastStudId_lbl.Name = "LastStudId_lbl";
            this.LastStudId_lbl.Size = new System.Drawing.Size(93, 20);
            this.LastStudId_lbl.TabIndex = 5;
            this.LastStudId_lbl.Text = "Student Id";
            // 
            // LastStudN_lbl
            // 
            this.LastStudN_lbl.AutoSize = true;
            this.LastStudN_lbl.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastStudN_lbl.Location = new System.Drawing.Point(148, 62);
            this.LastStudN_lbl.Name = "LastStudN_lbl";
            this.LastStudN_lbl.Size = new System.Drawing.Size(193, 24);
            this.LastStudN_lbl.TabIndex = 4;
            this.LastStudN_lbl.Text = "Name of Student";
            // 
            // LastStudPic_pb
            // 
            this.LastStudPic_pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastStudPic_pb.Location = new System.Drawing.Point(29, 53);
            this.LastStudPic_pb.Name = "LastStudPic_pb";
            this.LastStudPic_pb.Size = new System.Drawing.Size(104, 122);
            this.LastStudPic_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LastStudPic_pb.TabIndex = 3;
            this.LastStudPic_pb.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(11, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(840, 458);
            this.dataGridView1.TabIndex = 2;
            // 
            // StudentTerminate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BackPanel);
            this.Name = "StudentTerminate";
            this.Size = new System.Drawing.Size(905, 707);
            this.Load += new System.EventHandler(this.StudentTerminate_Load);
            this.BackPanel.ResumeLayout(false);
            this.BackPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastStudPic_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.Label Phone_lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DelLastStd_btn;
        private System.Windows.Forms.Label LastStudId_lbl;
        private System.Windows.Forms.Label LastStudN_lbl;
        private System.Windows.Forms.PictureBox LastStudPic_pb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DelOthStd_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchDel_tbx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
    }
}
