namespace TIS
{
    partial class EmpOverMoneyForm
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
            this.txt_emp_name = new System.Windows.Forms.TextBox();
            this.txt_over = new System.Windows.Forms.TextBox();
            this.txt_emp_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_emp_name
            // 
            this.txt_emp_name.Enabled = false;
            this.txt_emp_name.Location = new System.Drawing.Point(188, 87);
            this.txt_emp_name.MaxLength = 6;
            this.txt_emp_name.Name = "txt_emp_name";
            this.txt_emp_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_emp_name.Size = new System.Drawing.Size(333, 39);
            this.txt_emp_name.TabIndex = 2;
            // 
            // txt_over
            // 
            this.txt_over.Location = new System.Drawing.Point(188, 132);
            this.txt_over.MaxLength = 11;
            this.txt_over.Name = "txt_over";
            this.txt_over.Size = new System.Drawing.Size(117, 39);
            this.txt_over.TabIndex = 3;
            this.txt_over.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_over.Leave += new System.EventHandler(this.txt_over_Leave);
            // 
            // txt_emp_id
            // 
            this.txt_emp_id.Enabled = false;
            this.txt_emp_id.Location = new System.Drawing.Point(188, 42);
            this.txt_emp_id.MaxLength = 6;
            this.txt_emp_id.Name = "txt_emp_id";
            this.txt_emp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_emp_id.Size = new System.Drawing.Size(117, 39);
            this.txt_emp_id.TabIndex = 1;
            this.txt_emp_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "บาท";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "ยอดเงินเกินบัญชี : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อ-สกุล : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสพนักงาน : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_emp_name);
            this.groupBox1.Controls.Add(this.txt_over);
            this.groupBox1.Controls.Add(this.txt_emp_id);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 196);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงินเกินบัญชี";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_submit.Location = new System.Drawing.Point(472, 214);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(96, 37);
            this.btn_submit.TabIndex = 9;
            this.btn_submit.Text = "เสร็จสิ้น";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_back.Location = new System.Drawing.Point(12, 214);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(96, 37);
            this.btn_back.TabIndex = 7;
            this.btn_back.Text = "ย้อนกลับ";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // EmpOverMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 263);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_back);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EmpOverMoneyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmpOverMoneyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_emp_name;
        private System.Windows.Forms.TextBox txt_over;
        private System.Windows.Forms.TextBox txt_emp_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_back;
    }
}