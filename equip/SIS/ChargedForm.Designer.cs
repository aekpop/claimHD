namespace TIS
{
    partial class ChargedForm
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
            this.label14 = new System.Windows.Forms.Label();
            this.txt_t1_1 = new System.Windows.Forms.TextBox();
            this.txt_end = new System.Windows.Forms.MaskedTextBox();
            this.txt_start = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dpk_date1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_job = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_cb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_around = new System.Windows.Forms.ComboBox();
            this.txt_rs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_emp_name = new System.Windows.Forms.TextBox();
            this.txt_emp_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dpk_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_detail = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_line3 = new System.Windows.Forms.Label();
            this.lb_line2 = new System.Windows.Forms.Label();
            this.lb_line1 = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_t2_1 = new System.Windows.Forms.TextBox();
            this.txt_t2_4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_t2_3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_t2_2 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_t3_4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_t3_3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_t3_2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_t3_1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 33);
            this.label14.TabIndex = 88;
            this.label14.Text = "นำส่งรายได้ : ";
            // 
            // txt_t1_1
            // 
            this.txt_t1_1.Location = new System.Drawing.Point(161, 25);
            this.txt_t1_1.MaxLength = 60;
            this.txt_t1_1.Name = "txt_t1_1";
            this.txt_t1_1.Size = new System.Drawing.Size(256, 39);
            this.txt_t1_1.TabIndex = 87;
            this.txt_t1_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.txt_t1_1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
            // 
            // txt_end
            // 
            this.txt_end.Location = new System.Drawing.Point(592, 190);
            this.txt_end.Mask = "00:00";
            this.txt_end.Name = "txt_end";
            this.txt_end.Size = new System.Drawing.Size(64, 39);
            this.txt_end.TabIndex = 11;
            this.txt_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_end.ValidatingType = typeof(System.DateTime);
            this.txt_end.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_end_KeyUp);
            this.txt_end.Validating += new System.ComponentModel.CancelEventHandler(this.txt_end_Validating);
            // 
            // txt_start
            // 
            this.txt_start.Location = new System.Drawing.Point(491, 190);
            this.txt_start.Mask = "00:00";
            this.txt_start.Name = "txt_start";
            this.txt_start.Size = new System.Drawing.Size(62, 39);
            this.txt_start.TabIndex = 10;
            this.txt_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_start.ValidatingType = typeof(System.DateTime);
            this.txt_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_start_KeyUp);
            this.txt_start.Validating += new System.ComponentModel.CancelEventHandler(this.txt_start_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(559, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 33);
            this.label13.TabIndex = 24;
            this.label13.Text = "ถึง";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 33);
            this.label11.TabIndex = 19;
            this.label11.Text = "เวลาปฏิบัตงาน : ";
            // 
            // dpk_date1
            // 
            this.dpk_date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpk_date1.Location = new System.Drawing.Point(161, 143);
            this.dpk_date1.Name = "dpk_date1";
            this.dpk_date1.Size = new System.Drawing.Size(133, 39);
            this.dpk_date1.TabIndex = 6;
            this.dpk_date1.ValueChanged += new System.EventHandler(this.dpk_date1_ValueChanged);
            this.dpk_date1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpk_date1_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 33);
            this.label10.TabIndex = 18;
            this.label10.Text = "วันที่ที่ถูกเรียกเก็บ : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 33);
            this.label9.TabIndex = 17;
            this.label9.Text = "บาท";
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(161, 335);
            this.txt_amount.MaxLength = 11;
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(136, 39);
            this.txt_amount.TabIndex = 12;
            this.txt_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_amount_KeyPress);
            this.txt_amount.Leave += new System.EventHandler(this.txt_amount_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 33);
            this.label8.TabIndex = 15;
            this.label8.Text = "จำนวนเงิน : ";
            // 
            // txt_job
            // 
            this.txt_job.Location = new System.Drawing.Point(270, 190);
            this.txt_job.MaxLength = 10;
            this.txt_job.Name = "txt_job";
            this.txt_job.Size = new System.Drawing.Size(86, 39);
            this.txt_job.TabIndex = 9;
            this.txt_job.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_job_KeyPress);
            this.txt_job.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_job_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 33);
            this.label7.TabIndex = 13;
            this.label7.Text = "งานที่ : ";
            // 
            // txt_cb
            // 
            this.txt_cb.Location = new System.Drawing.Point(161, 190);
            this.txt_cb.MaxLength = 2;
            this.txt_cb.Name = "txt_cb";
            this.txt_cb.Size = new System.Drawing.Size(42, 39);
            this.txt_cb.TabIndex = 8;
            this.txt_cb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cb_KeyPress);
            this.txt_cb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_cb_KeyUp);
            this.txt_cb.Validating += new System.ComponentModel.CancelEventHandler(this.txt_cb_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 33);
            this.label6.TabIndex = 11;
            this.label6.Text = "ตู้ที่ : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "ผลัด : ";
            // 
            // cb_around
            // 
            this.cb_around.FormattingEnabled = true;
            this.cb_around.Location = new System.Drawing.Point(359, 143);
            this.cb_around.Name = "cb_around";
            this.cb_around.Size = new System.Drawing.Size(309, 41);
            this.cb_around.TabIndex = 7;
            this.cb_around.SelectedIndexChanged += new System.EventHandler(this.cb_around_SelectedIndexChanged);
            this.cb_around.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_around_KeyDown);
            // 
            // txt_rs
            // 
            this.txt_rs.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_rs.ForeColor = System.Drawing.Color.Red;
            this.txt_rs.Location = new System.Drawing.Point(423, 98);
            this.txt_rs.Name = "txt_rs";
            this.txt_rs.Size = new System.Drawing.Size(248, 39);
            this.txt_rs.TabIndex = 0;
            this.txt_rs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_rs_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "ชื่อ-สกุล : ";
            // 
            // txt_emp_name
            // 
            this.txt_emp_name.Location = new System.Drawing.Point(161, 290);
            this.txt_emp_name.MaxLength = 6;
            this.txt_emp_name.Name = "txt_emp_name";
            this.txt_emp_name.ReadOnly = true;
            this.txt_emp_name.Size = new System.Drawing.Size(407, 39);
            this.txt_emp_name.TabIndex = 0;
            // 
            // txt_emp_id
            // 
            this.txt_emp_id.Location = new System.Drawing.Point(212, 235);
            this.txt_emp_id.MaxLength = 6;
            this.txt_emp_id.Name = "txt_emp_id";
            this.txt_emp_id.Size = new System.Drawing.Size(100, 39);
            this.txt_emp_id.TabIndex = 3;
            this.txt_emp_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_emp_id_KeyPress);
            this.txt_emp_id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_id_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "รหัสพนักงานที่ถูกเรียกเก็บ : ";
            // 
            // dpk_date
            // 
            this.dpk_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpk_date.Location = new System.Drawing.Point(284, 98);
            this.dpk_date.Name = "dpk_date";
            this.dpk_date.Size = new System.Drawing.Size(133, 39);
            this.dpk_date.TabIndex = 2;
            this.dpk_date.ValueChanged += new System.EventHandler(this.dpk_date_ValueChanged);
            this.dpk_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpk_date_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "ลว.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "ตามบันทึกที่ : ";
            // 
            // txt_detail
            // 
            this.txt_detail.Location = new System.Drawing.Point(161, 98);
            this.txt_detail.Mask = "0000/00";
            this.txt_detail.Name = "txt_detail";
            this.txt_detail.Size = new System.Drawing.Size(79, 39);
            this.txt_detail.TabIndex = 1;
            this.txt_detail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_detail_KeyUp);
            this.txt_detail.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_detail_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(12, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 33);
            this.button1.TabIndex = 100;
            this.button1.Text = "ย้อนกลับ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(720, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 33);
            this.button2.TabIndex = 14;
            this.button2.Text = "บันทึก";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_line3);
            this.groupBox2.Controls.Add(this.lb_line2);
            this.groupBox2.Controls.Add(this.lb_line1);
            this.groupBox2.Controls.Add(this.lb_date);
            this.groupBox2.Controls.Add(this.lb_title);
            this.groupBox2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(778, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 231);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ตัวอย่างข้อความใน ธร.4";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lb_line3
            // 
            this.lb_line3.AutoSize = true;
            this.lb_line3.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_line3.Location = new System.Drawing.Point(16, 149);
            this.lb_line3.Name = "lb_line3";
            this.lb_line3.Size = new System.Drawing.Size(0, 26);
            this.lb_line3.TabIndex = 4;
            // 
            // lb_line2
            // 
            this.lb_line2.AutoSize = true;
            this.lb_line2.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_line2.Location = new System.Drawing.Point(16, 125);
            this.lb_line2.Name = "lb_line2";
            this.lb_line2.Size = new System.Drawing.Size(0, 26);
            this.lb_line2.TabIndex = 3;
            // 
            // lb_line1
            // 
            this.lb_line1.AutoSize = true;
            this.lb_line1.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_line1.Location = new System.Drawing.Point(38, 97);
            this.lb_line1.Name = "lb_line1";
            this.lb_line1.Size = new System.Drawing.Size(0, 26);
            this.lb_line1.TabIndex = 2;
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_date.Location = new System.Drawing.Point(16, 70);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(0, 26);
            this.lb_date.TabIndex = 1;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_title.Location = new System.Drawing.Point(16, 35);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(0, 26);
            this.lb_title.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 441);
            this.tabControl1.TabIndex = 102;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txt_job);
            this.tabPage1.Controls.Add(this.txt_amount);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txt_t1_1);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dpk_date1);
            this.tabPage1.Controls.Add(this.txt_cb);
            this.tabPage1.Controls.Add(this.txt_emp_id);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txt_detail);
            this.tabPage1.Controls.Add(this.txt_emp_name);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cb_around);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_start);
            this.tabPage1.Controls.Add(this.dpk_date);
            this.tabPage1.Controls.Add(this.txt_rs);
            this.tabPage1.Controls.Add(this.txt_end);
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ส่งเงินติดตามรายได้จากระบบ";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(279, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(299, 28);
            this.label12.TabIndex = 89;
            this.label12.Text = "*** ลว. ต้องเลือกวันที่ตามบันทึกจาก ผตท. เท่านั้น";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.txt_t2_1);
            this.tabPage2.Controls.Add(this.txt_t2_4);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txt_t2_3);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.txt_t2_2);
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ส่งเงินรายได้เพิ่มเติม";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(22, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(103, 33);
            this.label24.TabIndex = 99;
            this.label24.Text = "นำส่งรายได้ : ";
            this.label24.Visible = false;
            // 
            // txt_t2_1
            // 
            this.txt_t2_1.Location = new System.Drawing.Point(131, 21);
            this.txt_t2_1.MaxLength = 80;
            this.txt_t2_1.Name = "txt_t2_1";
            this.txt_t2_1.Size = new System.Drawing.Size(538, 39);
            this.txt_t2_1.TabIndex = 98;
            this.txt_t2_1.Visible = false;
            this.txt_t2_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_t2_1_KeyUp);
            // 
            // txt_t2_4
            // 
            this.txt_t2_4.Location = new System.Drawing.Point(131, 156);
            this.txt_t2_4.MaxLength = 11;
            this.txt_t2_4.Name = "txt_t2_4";
            this.txt_t2_4.Size = new System.Drawing.Size(136, 39);
            this.txt_t2_4.TabIndex = 93;
            this.txt_t2_4.Visible = false;
            this.txt_t2_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_t2_4_KeyPress);
            this.txt_t2_4.Leave += new System.EventHandler(this.txt_t2_4_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 159);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 33);
            this.label17.TabIndex = 94;
            this.label17.Text = "จำนวนเงิน : ";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(270, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 33);
            this.label18.TabIndex = 95;
            this.label18.Text = "บาท";
            this.label18.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(55, 114);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 33);
            this.label16.TabIndex = 92;
            this.label16.Text = "สาเหตุ : ";
            this.label16.Visible = false;
            // 
            // txt_t2_3
            // 
            this.txt_t2_3.Location = new System.Drawing.Point(131, 111);
            this.txt_t2_3.MaxLength = 60;
            this.txt_t2_3.Name = "txt_t2_3";
            this.txt_t2_3.Size = new System.Drawing.Size(538, 39);
            this.txt_t2_3.TabIndex = 91;
            this.txt_t2_3.Visible = false;
            this.txt_t2_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_t2_3_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 33);
            this.label15.TabIndex = 90;
            this.label15.Text = "รายละเอียด : ";
            this.label15.Visible = false;
            // 
            // txt_t2_2
            // 
            this.txt_t2_2.Location = new System.Drawing.Point(131, 66);
            this.txt_t2_2.MaxLength = 60;
            this.txt_t2_2.Name = "txt_t2_2";
            this.txt_t2_2.Size = new System.Drawing.Size(538, 39);
            this.txt_t2_2.TabIndex = 89;
            this.txt_t2_2.Visible = false;
            this.txt_t2_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_t2_2_KeyUp);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.txt_t3_4);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.txt_t3_3);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.txt_t3_2);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.txt_t3_1);
            this.tabPage3.Location = new System.Drawing.Point(4, 42);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(726, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ส่งเงินอื่นๆ";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // txt_t3_4
            // 
            this.txt_t3_4.Location = new System.Drawing.Point(131, 228);
            this.txt_t3_4.MaxLength = 11;
            this.txt_t3_4.Name = "txt_t3_4";
            this.txt_t3_4.Size = new System.Drawing.Size(136, 39);
            this.txt_t3_4.TabIndex = 102;
            this.txt_t3_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_t3_4_KeyPress);
            this.txt_t3_4.Leave += new System.EventHandler(this.txt_t3_4_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 231);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 33);
            this.label19.TabIndex = 103;
            this.label19.Text = "จำนวนเงิน : ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(270, 229);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 33);
            this.label20.TabIndex = 104;
            this.label20.Text = "บาท";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(55, 114);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 33);
            this.label21.TabIndex = 101;
            this.label21.Text = "สาเหตุ : ";
            // 
            // txt_t3_3
            // 
            this.txt_t3_3.Location = new System.Drawing.Point(131, 297);
            this.txt_t3_3.MaxLength = 60;
            this.txt_t3_3.Name = "txt_t3_3";
            this.txt_t3_3.Size = new System.Drawing.Size(538, 39);
            this.txt_t3_3.TabIndex = 100;
            this.txt_t3_3.Visible = false;
            this.txt_t3_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_t3_3_KeyUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(21, 69);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 33);
            this.label22.TabIndex = 99;
            this.label22.Text = "รายละเอียด : ";
            // 
            // txt_t3_2
            // 
            this.txt_t3_2.Location = new System.Drawing.Point(131, 66);
            this.txt_t3_2.MaxLength = 255;
            this.txt_t3_2.Multiline = true;
            this.txt_t3_2.Name = "txt_t3_2";
            this.txt_t3_2.Size = new System.Drawing.Size(589, 81);
            this.txt_t3_2.TabIndex = 98;
            this.txt_t3_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_t3_2_KeyUp);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(40, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 33);
            this.label23.TabIndex = 97;
            this.label23.Text = "นำส่งเงิน : ";
            // 
            // txt_t3_1
            // 
            this.txt_t3_1.Location = new System.Drawing.Point(131, 21);
            this.txt_t3_1.MaxLength = 80;
            this.txt_t3_1.Name = "txt_t3_1";
            this.txt_t3_1.Size = new System.Drawing.Size(538, 39);
            this.txt_t3_1.TabIndex = 96;
            this.txt_t3_1.TextChanged += new System.EventHandler(this.txt_t3_1_TextChanged);
            this.txt_t3_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_t3_1_KeyUp);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button3.Location = new System.Drawing.Point(113, 459);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 33);
            this.button3.TabIndex = 103;
            this.button3.Text = "แก้ไขข้อมูล";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // ChargedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 504);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ChargedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChargedForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txt_detail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpk_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_emp_name;
        private System.Windows.Forms.TextBox txt_emp_id;
        private System.Windows.Forms.TextBox txt_rs;
        private System.Windows.Forms.TextBox txt_job;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_cb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_around;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dpk_date1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txt_end;
        private System.Windows.Forms.MaskedTextBox txt_start;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_t1_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_line3;
        private System.Windows.Forms.Label lb_line2;
        private System.Windows.Forms.Label lb_line1;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_t2_3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_t2_2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_t2_4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_t3_4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_t3_3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_t3_2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_t3_1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt_t2_1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
    }
}