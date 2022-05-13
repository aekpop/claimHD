namespace TIS
{
    partial class RefunForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_job = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_user = new System.Windows.Forms.Label();
            this.lb_fine = new System.Windows.Forms.Label();
            this.rdo_fine = new System.Windows.Forms.RadioButton();
            this.rdo_user = new System.Windows.Forms.RadioButton();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_fine = new System.Windows.Forms.TextBox();
            this.cb_emp_name = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_around = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date_value = new System.Windows.Forms.DateTimePicker();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_cb = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_cb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_note);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_job);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lb_user);
            this.groupBox1.Controls.Add(this.lb_fine);
            this.groupBox1.Controls.Add(this.rdo_fine);
            this.groupBox1.Controls.Add(this.rdo_user);
            this.groupBox1.Controls.Add(this.txt_user);
            this.groupBox1.Controls.Add(this.txt_fine);
            this.groupBox1.Controls.Add(this.cb_emp_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_around);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.date_value);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(580, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "คืนเงินผู้ใช้ทาง";
            // 
            // txt_note
            // 
            this.txt_note.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_note.Location = new System.Drawing.Point(202, 81);
            this.txt_note.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_note.Multiline = true;
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(350, 95);
            this.txt_note.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(13, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "อ้างอิง/เล่มใบเสร็จ/เลขที่ : ";
            // 
            // txt_job
            // 
            this.txt_job.Enabled = false;
            this.txt_job.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_job.FormattingEnabled = true;
            this.txt_job.Location = new System.Drawing.Point(360, 277);
            this.txt_job.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_job.Name = "txt_job";
            this.txt_job.Size = new System.Drawing.Size(81, 41);
            this.txt_job.TabIndex = 11;
            this.txt_job.SelectedIndexChanged += new System.EventHandler(this.txt_job_SelectedIndexChanged);
            this.txt_job.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_job_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(292, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 33);
            this.label6.TabIndex = 10;
            this.label6.Text = "งานที่ : ";
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_user.ForeColor = System.Drawing.Color.Blue;
            this.lb_user.Location = new System.Drawing.Point(355, 382);
            this.lb_user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(19, 26);
            this.lb_user.TabIndex = 9;
            this.lb_user.Text = "2";
            this.lb_user.Visible = false;
            // 
            // lb_fine
            // 
            this.lb_fine.AutoSize = true;
            this.lb_fine.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_fine.ForeColor = System.Drawing.Color.Blue;
            this.lb_fine.Location = new System.Drawing.Point(322, 337);
            this.lb_fine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_fine.Name = "lb_fine";
            this.lb_fine.Size = new System.Drawing.Size(19, 26);
            this.lb_fine.TabIndex = 8;
            this.lb_fine.Text = "1";
            this.lb_fine.Visible = false;
            // 
            // rdo_fine
            // 
            this.rdo_fine.AutoSize = true;
            this.rdo_fine.Enabled = false;
            this.rdo_fine.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_fine.Location = new System.Drawing.Point(30, 331);
            this.rdo_fine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdo_fine.Name = "rdo_fine";
            this.rdo_fine.Size = new System.Drawing.Size(163, 37);
            this.rdo_fine.TabIndex = 7;
            this.rdo_fine.Text = "เงินค่าปรับบัตรหาย :";
            this.rdo_fine.UseVisualStyleBackColor = true;
            this.rdo_fine.CheckedChanged += new System.EventHandler(this.rdo_fine_CheckedChanged);
            // 
            // rdo_user
            // 
            this.rdo_user.AutoSize = true;
            this.rdo_user.Enabled = false;
            this.rdo_user.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdo_user.Location = new System.Drawing.Point(30, 376);
            this.rdo_user.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdo_user.Name = "rdo_user";
            this.rdo_user.Size = new System.Drawing.Size(203, 37);
            this.rdo_user.TabIndex = 7;
            this.rdo_user.TabStop = true;
            this.rdo_user.Text = "เงินผู้ใช้ทางไม่รับเงินทอน : ";
            this.rdo_user.UseVisualStyleBackColor = true;
            this.rdo_user.CheckedChanged += new System.EventHandler(this.rdo_user_CheckedChanged);
            // 
            // txt_user
            // 
            this.txt_user.Enabled = false;
            this.txt_user.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_user.Location = new System.Drawing.Point(237, 375);
            this.txt_user.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_user.MaxLength = 11;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(68, 39);
            this.txt_user.TabIndex = 6;
            this.txt_user.Text = "0";
            this.txt_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            // 
            // txt_fine
            // 
            this.txt_fine.Enabled = false;
            this.txt_fine.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_fine.Location = new System.Drawing.Point(202, 330);
            this.txt_fine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_fine.MaxLength = 11;
            this.txt_fine.Name = "txt_fine";
            this.txt_fine.Size = new System.Drawing.Size(68, 39);
            this.txt_fine.TabIndex = 6;
            this.txt_fine.Text = "0";
            this.txt_fine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_fine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fine_KeyPress);
            this.txt_fine.Validating += new System.ComponentModel.CancelEventHandler(this.txt_fine_Validating);
            // 
            // cb_emp_name
            // 
            this.cb_emp_name.Enabled = false;
            this.cb_emp_name.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_emp_name.FormattingEnabled = true;
            this.cb_emp_name.Location = new System.Drawing.Point(202, 230);
            this.cb_emp_name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_emp_name.Name = "cb_emp_name";
            this.cb_emp_name.Size = new System.Drawing.Size(350, 41);
            this.cb_emp_name.TabIndex = 5;
            this.cb_emp_name.SelectedIndexChanged += new System.EventHandler(this.cb_emp_name_SelectedIndexChanged);
            this.cb_emp_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_emp_name_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(24, 233);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "พนักงานที่ปฎิบัติหน้าที่ : ";
            // 
            // cb_around
            // 
            this.cb_around.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_around.FormattingEnabled = true;
            this.cb_around.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cb_around.Location = new System.Drawing.Point(202, 182);
            this.cb_around.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_around.Name = "cb_around";
            this.cb_around.Size = new System.Drawing.Size(81, 41);
            this.cb_around.TabIndex = 2;
            this.cb_around.Text = "เลือก";
            this.cb_around.SelectedIndexChanged += new System.EventHandler(this.cb_around_SelectedIndexChanged);
            this.cb_around.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_around_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(275, 333);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 33);
            this.label5.TabIndex = 2;
            this.label5.Text = "บาท";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(308, 378);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 33);
            this.label4.TabIndex = 2;
            this.label4.Text = "บาท";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(129, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "ผลัดที่ : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(68, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "วันที่เกิดรายการ : ";
            // 
            // date_value
            // 
            this.date_value.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date_value.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_value.Location = new System.Drawing.Point(202, 36);
            this.date_value.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.date_value.Name = "date_value";
            this.date_value.Size = new System.Drawing.Size(109, 39);
            this.date_value.TabIndex = 1;
            this.date_value.ValueChanged += new System.EventHandler(this.date_value_ValueChanged);
            this.date_value.KeyDown += new System.Windows.Forms.KeyEventHandler(this.date_value_KeyDown);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_back.Location = new System.Drawing.Point(8, 449);
            this.btn_back.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(104, 39);
            this.btn_back.TabIndex = 1;
            this.btn_back.Text = "ย้อนกลับ";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_next
            // 
            this.btn_next.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_next.Location = new System.Drawing.Point(484, 449);
            this.btn_next.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(104, 39);
            this.btn_next.TabIndex = 0;
            this.btn_next.Text = "ถัดไป";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(145, 280);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 33);
            this.label8.TabIndex = 14;
            this.label8.Text = "ตู้ที่ : ";
            // 
            // cb_cb
            // 
            this.cb_cb.Enabled = false;
            this.cb_cb.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cb_cb.FormattingEnabled = true;
            this.cb_cb.Location = new System.Drawing.Point(202, 277);
            this.cb_cb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_cb.Name = "cb_cb";
            this.cb_cb.Size = new System.Drawing.Size(81, 41);
            this.cb_cb.TabIndex = 15;
            this.cb_cb.SelectedIndexChanged += new System.EventHandler(this.cb_cb_SelectedIndexChanged);
            this.cb_cb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_cb_KeyPress);
            // 
            // RefunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 500);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.Name = "RefunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.RefunForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date_value;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ComboBox cb_around;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.Label lb_fine;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_user;
        public System.Windows.Forms.TextBox txt_fine;
        public System.Windows.Forms.ComboBox txt_job;
        public System.Windows.Forms.ComboBox cb_emp_name;
        public System.Windows.Forms.RadioButton rdo_fine;
        public System.Windows.Forms.RadioButton rdo_user;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txt_note;
        public System.Windows.Forms.ComboBox cb_cb;
        private System.Windows.Forms.Label label8;
    }
}