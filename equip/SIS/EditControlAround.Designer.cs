namespace TIS
{
    partial class EditControlAround
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.txt_emp_id = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(111, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 64);
            this.label1.TabIndex = 10;
            this.label1.Text = "กรุณาใส่รหัสรองฯ ที่ถูกต้อง";
            // 
            // btn_next
            // 
            this.btn_next.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_next.Location = new System.Drawing.Point(373, 153);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(84, 44);
            this.btn_next.TabIndex = 9;
            this.btn_next.Text = "ถัดไป";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click_1);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_back.Location = new System.Drawing.Point(145, 153);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(88, 44);
            this.btn_back.TabIndex = 8;
            this.btn_back.Text = "ย้อนกลับ";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
            // 
            // txt_emp_id
            // 
            this.txt_emp_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_emp_id.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_emp_id.Location = new System.Drawing.Point(145, 71);
            this.txt_emp_id.MaxLength = 6;
            this.txt_emp_id.Name = "txt_emp_id";
            this.txt_emp_id.PasswordChar = '*';
            this.txt_emp_id.Size = new System.Drawing.Size(312, 70);
            this.txt_emp_id.TabIndex = 7;
            this.txt_emp_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditControlAround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.txt_emp_id);
            this.Name = "EditControlAround";
            this.Text = "แก้ไขการเปิดผลัดผิด";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_back;
        public System.Windows.Forms.TextBox txt_emp_id;
    }
}