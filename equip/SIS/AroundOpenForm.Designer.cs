namespace TIS
{
    partial class AroundOpenForm
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
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_date_show = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_group = new System.Windows.Forms.Label();
            this.txt_emp_name = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_straps_start = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อผู้เปิดกะ : ";
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rb_2.Location = new System.Drawing.Point(47, 59);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(265, 37);
            this.rb_2.TabIndex = 3;
            this.rb_2.TabStop = true;
            this.rb_2.Text = "ผลัด 2 (เช้า)   เวลา 06:00-14:00 น.";
            this.rb_2.UseVisualStyleBackColor = true;
            // 
            // rb_3
            // 
            this.rb_3.AutoSize = true;
            this.rb_3.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rb_3.Location = new System.Drawing.Point(47, 89);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(265, 37);
            this.rb_3.TabIndex = 4;
            this.rb_3.TabStop = true;
            this.rb_3.Text = "ผลัด 3 (บ่าย)  เวลา 14:00-22:00 น.";
            this.rb_3.UseVisualStyleBackColor = true;
            // 
            // rb_1
            // 
            this.rb_1.AutoSize = true;
            this.rb_1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rb_1.Location = new System.Drawing.Point(47, 119);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(261, 37);
            this.rb_1.TabIndex = 5;
            this.rb_1.TabStop = true;
            this.rb_1.Text = "ผลัด 1 (ดึก)   เวลา 22:00-06:00 น.";
            this.rb_1.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_next.Location = new System.Drawing.Point(790, 396);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(84, 34);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "เสร็จสิ้น";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_back.Location = new System.Drawing.Point(12, 396);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(88, 34);
            this.btn_back.TabIndex = 60;
            this.btn_back.Text = "ย้อนกลับ";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_date_show);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lb_group);
            this.groupBox1.Controls.Add(this.txt_emp_name);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 378);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เปิดกะ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_date_show
            // 
            this.lb_date_show.AutoSize = true;
            this.lb_date_show.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_date_show.Location = new System.Drawing.Point(127, 146);
            this.lb_date_show.Name = "lb_date_show";
            this.lb_date_show.Size = new System.Drawing.Size(61, 33);
            this.lb_date_show.TabIndex = 15;
            this.lb_date_show.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(64, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 33);
            this.label5.TabIndex = 14;
            this.label5.Text = "วันที่ : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(39, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 33);
            this.label4.TabIndex = 13;
            this.label4.Text = "ตำแหน่ง : ";
            // 
            // lb_group
            // 
            this.lb_group.AutoSize = true;
            this.lb_group.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_group.Location = new System.Drawing.Point(127, 97);
            this.lb_group.Name = "lb_group";
            this.lb_group.Size = new System.Drawing.Size(79, 33);
            this.lb_group.TabIndex = 12;
            this.lb_group.Text = "lb_group";
            // 
            // txt_emp_name
            // 
            this.txt_emp_name.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_emp_name.Location = new System.Drawing.Point(122, 51);
            this.txt_emp_name.Name = "txt_emp_name";
            this.txt_emp_name.ReadOnly = true;
            this.txt_emp_name.Size = new System.Drawing.Size(310, 39);
            this.txt_emp_name.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_straps_start);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(449, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 176);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "สายรัด";
            // 
            // txt_straps_start
            // 
            this.txt_straps_start.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_straps_start.Location = new System.Drawing.Point(205, 54);
            this.txt_straps_start.MaxLength = 8;
            this.txt_straps_start.Name = "txt_straps_start";
            this.txt_straps_start.Size = new System.Drawing.Size(154, 39);
            this.txt_straps_start.TabIndex = 0;
            this.txt_straps_start.TextChanged += new System.EventHandler(this.txt_straps_start_TextChanged);
            this.txt_straps_start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_straps_start_KeyPress);
            this.txt_straps_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_straps_start_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "หมายเลขสายรัดเริ่มต้น : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_2);
            this.groupBox2.Controls.Add(this.rb_3);
            this.groupBox2.Controls.Add(this.rb_1);
            this.groupBox2.Location = new System.Drawing.Point(6, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 176);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ผลัด";
            // 
            // AroundOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(887, 443);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "AroundOpenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AroundOpenForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_3;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_straps_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_emp_name;
        private System.Windows.Forms.Label lb_group;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_date_show;
        private System.Windows.Forms.Label label5;
    }
}