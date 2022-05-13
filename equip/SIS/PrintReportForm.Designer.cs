namespace TIS
{
    partial class PrintReportForm
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
            this.btn_r1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_r4 = new System.Windows.Forms.Button();
            this.btn_r3 = new System.Windows.Forms.Button();
            this.btn_r2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_r1
            // 
            this.btn_r1.Location = new System.Drawing.Point(6, 28);
            this.btn_r1.Name = "btn_r1";
            this.btn_r1.Size = new System.Drawing.Size(505, 36);
            this.btn_r1.TabIndex = 0;
            this.btn_r1.Text = "รายงานการนำส่งรายได้ค่าธรรมเนียมผ่านทาง/ผลัด";
            this.btn_r1.UseVisualStyleBackColor = true;
            this.btn_r1.Click += new System.EventHandler(this.btn_r1_Click);
            this.btn_r1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_r1_PreviewKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_r4);
            this.groupBox1.Controls.Add(this.btn_r3);
            this.groupBox1.Controls.Add(this.btn_r2);
            this.groupBox1.Controls.Add(this.btn_r1);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เลือกรายงาน";
            this.groupBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // btn_r4
            // 
            this.btn_r4.Location = new System.Drawing.Point(6, 154);
            this.btn_r4.Name = "btn_r4";
            this.btn_r4.Size = new System.Drawing.Size(505, 36);
            this.btn_r4.TabIndex = 3;
            this.btn_r4.Text = "รายงานถุงเงินพิเศษ";
            this.btn_r4.UseVisualStyleBackColor = true;
            this.btn_r4.Visible = false;
            this.btn_r4.Click += new System.EventHandler(this.btn_r4_Click);
            // 
            // btn_r3
            // 
            this.btn_r3.Location = new System.Drawing.Point(6, 112);
            this.btn_r3.Name = "btn_r3";
            this.btn_r3.Size = new System.Drawing.Size(505, 36);
            this.btn_r3.TabIndex = 2;
            this.btn_r3.Text = "นำเข้าข้อมูล ผู้ใช้ทางไม่รับเงินทอน และ ค่าปรับบัตร ย้อนหลัง";
            this.btn_r3.UseVisualStyleBackColor = true;
            this.btn_r3.Visible = false;
            this.btn_r3.Click += new System.EventHandler(this.btn_r3_Click);
            // 
            // btn_r2
            // 
            this.btn_r2.Location = new System.Drawing.Point(6, 70);
            this.btn_r2.Name = "btn_r2";
            this.btn_r2.Size = new System.Drawing.Size(505, 36);
            this.btn_r2.TabIndex = 1;
            this.btn_r2.Text = "รายงานการนำส่งรายได้ค่าธรรมเนียมผ่านทางประจำวัน";
            this.btn_r2.UseVisualStyleBackColor = true;
            this.btn_r2.Click += new System.EventHandler(this.btn_r2_Click);
            // 
            // PrintReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 221);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "PrintReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "พิมพ์รายงาน";
            this.Load += new System.EventHandler(this.PrintReportForm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PrintReportForm_PreviewKeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_r1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_r4;
        private System.Windows.Forms.Button btn_r2;
        private System.Windows.Forms.Button btn_r3;
    }
}