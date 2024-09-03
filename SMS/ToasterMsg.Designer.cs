namespace SMS
{
    partial class ToasterMsg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Close_btn = new System.Windows.Forms.Button();
            this.Statusbar_pnl = new System.Windows.Forms.Panel();
            this.MsgType_lbl = new System.Windows.Forms.Label();
            this.Msgbrief_lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.TypePic_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TypePic_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_btn
            // 
            this.Close_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Close_btn.FlatAppearance.BorderSize = 0;
            this.Close_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Close_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_btn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Close_btn.Location = new System.Drawing.Point(375, 12);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(32, 33);
            this.Close_btn.TabIndex = 4;
            this.Close_btn.Text = "X";
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // Statusbar_pnl
            // 
            this.Statusbar_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Statusbar_pnl.Location = new System.Drawing.Point(0, 70);
            this.Statusbar_pnl.Name = "Statusbar_pnl";
            this.Statusbar_pnl.Size = new System.Drawing.Size(411, 5);
            this.Statusbar_pnl.TabIndex = 5;
            // 
            // MsgType_lbl
            // 
            this.MsgType_lbl.AutoSize = true;
            this.MsgType_lbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgType_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MsgType_lbl.Location = new System.Drawing.Point(68, 10);
            this.MsgType_lbl.Name = "MsgType_lbl";
            this.MsgType_lbl.Size = new System.Drawing.Size(176, 22);
            this.MsgType_lbl.TabIndex = 7;
            this.MsgType_lbl.Text = "Saved Successfully";
            // 
            // Msgbrief_lbl
            // 
            this.Msgbrief_lbl.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msgbrief_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Msgbrief_lbl.Location = new System.Drawing.Point(71, 33);
            this.Msgbrief_lbl.Name = "Msgbrief_lbl";
            this.Msgbrief_lbl.Size = new System.Drawing.Size(298, 35);
            this.Msgbrief_lbl.TabIndex = 8;
            this.Msgbrief_lbl.Text = "Data Stored In The Database";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 18;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 18;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // TypePic_pb
            // 
            this.TypePic_pb.Location = new System.Drawing.Point(11, 14);
            this.TypePic_pb.Name = "TypePic_pb";
            this.TypePic_pb.Size = new System.Drawing.Size(40, 40);
            this.TypePic_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TypePic_pb.TabIndex = 6;
            this.TypePic_pb.TabStop = false;
            // 
            // ToasterMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 75);
            this.Controls.Add(this.Msgbrief_lbl);
            this.Controls.Add(this.MsgType_lbl);
            this.Controls.Add(this.TypePic_pb);
            this.Controls.Add(this.Statusbar_pnl);
            this.Controls.Add(this.Close_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToasterMsg";
            this.Text = "ToasterMsg";
            this.Load += new System.EventHandler(this.ToasterMsg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TypePic_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.Panel Statusbar_pnl;
        private System.Windows.Forms.PictureBox TypePic_pb;
        private System.Windows.Forms.Label MsgType_lbl;
        private System.Windows.Forms.Label Msgbrief_lbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}