namespace TIS
{
    partial class DefectiveFrom
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.date_start = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateSummary = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReportSummary = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.date_start);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายงานสายรัด";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(296, 39);
            this.button3.TabIndex = 8;
            this.button3.Text = "สายรัดชำรุด (พิมพ์ ทุกด่าน)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(296, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "การขอแก้งาน";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "สายรัดชำรุด";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "เดือน : ";
            // 
            // date_start
            // 
            this.date_start.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_start.Location = new System.Drawing.Point(99, 38);
            this.date_start.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.date_start.Name = "date_start";
            this.date_start.ShowUpDown = true;
            this.date_start.Size = new System.Drawing.Size(136, 39);
            this.date_start.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 84);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายงานการขอแก้ไขงาน";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReportSummary);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateSummary);
            this.groupBox3.Location = new System.Drawing.Point(12, 292);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 85);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "รายงานสรุปรายได้ประจำ เดือน/ปี";
            // 
            // dateSummary
            // 
            this.dateSummary.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dateSummary.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateSummary.Location = new System.Drawing.Point(53, 38);
            this.dateSummary.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateSummary.Name = "dateSummary";
            this.dateSummary.ShowUpDown = true;
            this.dateSummary.Size = new System.Drawing.Size(136, 39);
            this.dateSummary.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "ปี : ";
            // 
            // btnReportSummary
            // 
            this.btnReportSummary.Location = new System.Drawing.Point(194, 38);
            this.btnReportSummary.Name = "btnReportSummary";
            this.btnReportSummary.Size = new System.Drawing.Size(110, 39);
            this.btnReportSummary.TabIndex = 8;
            this.btnReportSummary.Text = "พิมพ์";
            this.btnReportSummary.UseVisualStyleBackColor = true;
            this.btnReportSummary.Click += new System.EventHandler(this.btnReportSummary_Click);
            // 
            // DefectiveFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 390);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "DefectiveFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สายรัดชำรุด";
            this.Load += new System.EventHandler(this.DefectiveFrom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_start;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateSummary;
        private System.Windows.Forms.Button btnReportSummary;
    }
}