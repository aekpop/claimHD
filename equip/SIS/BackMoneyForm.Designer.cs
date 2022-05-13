namespace TIS
{
    partial class BackMoneyForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.txt_emp_name = new System.Windows.Forms.TextBox();
            this.txt_bag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_money = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_emp_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_chang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_fine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txt_emp_name);
            this.groupBox1.Controls.Add(this.txt_bag);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_money);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_emp_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "คืนเงินทอน";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(447, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "ยืนยันคืนเงินยืม";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_emp_name
            // 
            this.txt_emp_name.Enabled = false;
            this.txt_emp_name.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_emp_name.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_emp_name.Location = new System.Drawing.Point(227, 96);
            this.txt_emp_name.MaxLength = 4;
            this.txt_emp_name.Name = "txt_emp_name";
            this.txt_emp_name.ReadOnly = true;
            this.txt_emp_name.Size = new System.Drawing.Size(358, 39);
            this.txt_emp_name.TabIndex = 9;
            // 
            // txt_bag
            // 
            this.txt_bag.Enabled = false;
            this.txt_bag.ForeColor = System.Drawing.Color.Blue;
            this.txt_bag.Location = new System.Drawing.Point(227, 144);
            this.txt_bag.MaxLength = 4;
            this.txt_bag.Name = "txt_bag";
            this.txt_bag.ReadOnly = true;
            this.txt_bag.Size = new System.Drawing.Size(100, 39);
            this.txt_bag.TabIndex = 8;
            this.txt_bag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 33);
            this.label5.TabIndex = 7;
            this.label5.Text = "ถุงเงิน : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(504, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 64);
            this.label4.TabIndex = 5;
            this.label4.Text = "บาท";
            // 
            // txt_money
            // 
            this.txt_money.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_money.ForeColor = System.Drawing.Color.Red;
            this.txt_money.Location = new System.Drawing.Point(255, 192);
            this.txt_money.MaxLength = 10;
            this.txt_money.Name = "txt_money";
            this.txt_money.ReadOnly = true;
            this.txt_money.Size = new System.Drawing.Size(243, 70);
            this.txt_money.TabIndex = 2;
            this.txt_money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_money.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(20, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 64);
            this.label3.TabIndex = 3;
            this.label3.Text = "จำนวนเงินที่ยืม : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อ-สกุล : ";
            // 
            // txt_emp_id
            // 
            this.txt_emp_id.Enabled = false;
            this.txt_emp_id.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_emp_id.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_emp_id.Location = new System.Drawing.Point(227, 48);
            this.txt_emp_id.MaxLength = 6;
            this.txt_emp_id.Name = "txt_emp_id";
            this.txt_emp_id.ReadOnly = true;
            this.txt_emp_id.Size = new System.Drawing.Size(143, 39);
            this.txt_emp_id.TabIndex = 1;
            this.txt_emp_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_emp_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_emp_id_KeyDown);
            this.txt_emp_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txt_emp_id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_id_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสพนักงาน : ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(12, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "ย้อนกลับ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_next
            // 
            this.btn_next.Enabled = false;
            this.btn_next.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_next.Location = new System.Drawing.Point(465, 538);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(151, 35);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "ยืนยันการรับเงิน";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_chang);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_fine);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(12, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 150);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 33);
            this.label10.TabIndex = 23;
            this.label10.Text = "ค่าปรับบัตรหาย : ";
            // 
            // txt_chang
            // 
            this.txt_chang.Location = new System.Drawing.Point(302, 38);
            this.txt_chang.MaxLength = 4;
            this.txt_chang.Name = "txt_chang";
            this.txt_chang.Size = new System.Drawing.Size(201, 39);
            this.txt_chang.TabIndex = 1;
            this.txt_chang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_chang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_chang_KeyDown);
            this.txt_chang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_chang_KeyPress);
            this.txt_chang.Leave += new System.EventHandler(this.txt_chang_Leave);
            this.txt_chang.Validating += new System.ComponentModel.CancelEventHandler(this.txt_chang_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 33);
            this.label9.TabIndex = 22;
            this.label9.Text = "บาท";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 33);
            this.label7.TabIndex = 20;
            this.label7.Text = "ผู้ใช้ทางไม่รับเงินทอน : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 33);
            this.label8.TabIndex = 21;
            this.label8.Text = "บาท";
            // 
            // txt_fine
            // 
            this.txt_fine.Location = new System.Drawing.Point(302, 79);
            this.txt_fine.MaxLength = 4;
            this.txt_fine.Name = "txt_fine";
            this.txt_fine.Size = new System.Drawing.Size(201, 39);
            this.txt_fine.TabIndex = 2;
            this.txt_fine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_fine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_chang_KeyDown);
            this.txt_fine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fine_KeyPress);
            this.txt_fine.Leave += new System.EventHandler(this.txt_fine_Leave);
            this.txt_fine.Validating += new System.ComponentModel.CancelEventHandler(this.txt_fine_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(311, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(304, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "***ต้องกดรับเงินยืมคืนก่อนถึงจะทำการบันทึกข้อมูลได้";
            // 
            // BackMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 586);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "BackMoneyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BackMoneyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_money;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_emp_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_emp_name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_chang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_fine;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
    }
}