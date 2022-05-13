namespace TIS
{
    partial class ReportIncomForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.date_start_r1 = new System.Windows.Forms.DateTimePicker();
            this.btn_report1 = new System.Windows.Forms.Button();
            this.rd_p3 = new System.Windows.Forms.RadioButton();
            this.rd_p2 = new System.Windows.Forms.RadioButton();
            this.rd_p1 = new System.Windows.Forms.RadioButton();
            this.btn_report2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.date_start_r1);
            this.groupBox1.Controls.Add(this.btn_report1);
            this.groupBox1.Controls.Add(this.rd_p3);
            this.groupBox1.Controls.Add(this.rd_p2);
            this.groupBox1.Controls.Add(this.rd_p1);
            this.groupBox1.Controls.Add(this.btn_report2);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 211);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายงานประจำผลัด";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(269, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(369, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "พิมพ์ใบท้าย ธร.3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "วันที่ : ";
            // 
            // date_start_r1
            // 
            this.date_start_r1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start_r1.Location = new System.Drawing.Point(95, 43);
            this.date_start_r1.Name = "date_start_r1";
            this.date_start_r1.Size = new System.Drawing.Size(141, 39);
            this.date_start_r1.TabIndex = 1;
            this.date_start_r1.ValueChanged += new System.EventHandler(this.date_start_r1_ValueChanged);
            // 
            // btn_report1
            // 
            this.btn_report1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_report1.Location = new System.Drawing.Point(269, 99);
            this.btn_report1.Name = "btn_report1";
            this.btn_report1.Size = new System.Drawing.Size(369, 38);
            this.btn_report1.TabIndex = 5;
            this.btn_report1.Text = "พิมพ์รายงาน ด่านฯ";
            this.btn_report1.UseVisualStyleBackColor = true;
            this.btn_report1.Click += new System.EventHandler(this.btn_report1_Click);
            // 
            // rd_p3
            // 
            this.rd_p3.AutoSize = true;
            this.rd_p3.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rd_p3.Location = new System.Drawing.Point(37, 155);
            this.rd_p3.Name = "rd_p3";
            this.rd_p3.Size = new System.Drawing.Size(216, 37);
            this.rd_p3.TabIndex = 4;
            this.rd_p3.TabStop = true;
            this.rd_p3.Text = "ผลัดที่ 3 (บ่าย 14:00-22:00)";
            this.rd_p3.UseVisualStyleBackColor = true;
            // 
            // rd_p2
            // 
            this.rd_p2.AutoSize = true;
            this.rd_p2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rd_p2.Location = new System.Drawing.Point(37, 126);
            this.rd_p2.Name = "rd_p2";
            this.rd_p2.Size = new System.Drawing.Size(211, 37);
            this.rd_p2.TabIndex = 3;
            this.rd_p2.TabStop = true;
            this.rd_p2.Text = "ผลัดที่ 2 (เช้า 06:00-14:00)";
            this.rd_p2.UseVisualStyleBackColor = true;
            // 
            // rd_p1
            // 
            this.rd_p1.AutoSize = true;
            this.rd_p1.Checked = true;
            this.rd_p1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rd_p1.Location = new System.Drawing.Point(37, 99);
            this.rd_p1.Name = "rd_p1";
            this.rd_p1.Size = new System.Drawing.Size(207, 37);
            this.rd_p1.TabIndex = 2;
            this.rd_p1.TabStop = true;
            this.rd_p1.Text = "ผลัดที่ 1 (ดึก 22:00-06:00)";
            this.rd_p1.UseVisualStyleBackColor = true;
            // 
            // btn_report2
            // 
            this.btn_report2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_report2.Location = new System.Drawing.Point(269, 143);
            this.btn_report2.Name = "btn_report2";
            this.btn_report2.Size = new System.Drawing.Size(369, 38);
            this.btn_report2.TabIndex = 6;
            this.btn_report2.Text = "พิมพ์รายงานรวม ด่านฯ";
            this.btn_report2.UseVisualStyleBackColor = true;
            this.btn_report2.Click += new System.EventHandler(this.btn_report2_Click);
            // 
            // ReportIncomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 235);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ReportIncomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายงานการนำส่งรายได้ค่าธรรมเนียมผ่านทาง";
            this.Load += new System.EventHandler(this.ReportIncomForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker date_start_r1;
        private System.Windows.Forms.Button btn_report1;
        private System.Windows.Forms.RadioButton rd_p3;
        private System.Windows.Forms.RadioButton rd_p2;
        private System.Windows.Forms.RadioButton rd_p1;
        private System.Windows.Forms.Button btn_report2;
        private System.Windows.Forms.Button button1;
    }
}