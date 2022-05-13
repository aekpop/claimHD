namespace TIS
{
    partial class EditStrapsEmpForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.combo_note = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txt_bag = new System.Windows.Forms.Label();
            this.txt_straps_id_old = new System.Windows.Forms.Label();
            this.txt_straps_id_new = new System.Windows.Forms.Label();
            this.lb_income_id = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_straps_note = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_straps_new = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_straps_old = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_emp_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_emp_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.combo_note);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txt_bag);
            this.groupBox1.Controls.Add(this.txt_straps_id_old);
            this.groupBox1.Controls.Add(this.txt_straps_id_new);
            this.groupBox1.Controls.Add(this.lb_income_id);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_straps_note);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_straps_new);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_straps_old);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_emp_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_emp_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เปลี่ยนสายรัด/ชำรุด";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 33);
            this.label6.TabIndex = 21;
            this.label6.Text = "สาเหตุที่เปลี่ยน : ";
            // 
            // combo_note
            // 
            this.combo_note.FormattingEnabled = true;
            this.combo_note.Items.AddRange(new object[] {
            "นำไปใช้รัดถุงเงินพิเศษ (ผจด)",
            "พนักงานเก็บเงินดึงสายรัดขาด",
            "ตัดสายรัด เนื่องจากยอดนำส่งรายได้ผิด",
            "สายรัดมีตำหนิ",
            "เปลี่ยนเพื่อเริ่มสายรัดเลขใหม่",
            "อื่นๆ (ระบุหมายเหตุ)"});
            this.combo_note.Location = new System.Drawing.Point(212, 190);
            this.combo_note.Name = "combo_note";
            this.combo_note.Size = new System.Drawing.Size(320, 41);
            this.combo_note.TabIndex = 20;
            this.combo_note.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_note_KeyPress);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(110, 36);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(178, 37);
            this.radioButton3.TabIndex = 19;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "ค้นหาจากรหัสพนักงาน";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(294, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(162, 37);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "ค้นหาจากเลขสายรัด";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(458, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 37);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.Text = "ถุงเงินพิเศษ";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txt_bag
            // 
            this.txt_bag.AutoSize = true;
            this.txt_bag.Location = new System.Drawing.Point(416, 157);
            this.txt_bag.Name = "txt_bag";
            this.txt_bag.Size = new System.Drawing.Size(61, 33);
            this.txt_bag.TabIndex = 14;
            this.txt_bag.Text = "label6";
            this.txt_bag.Visible = false;
            // 
            // txt_straps_id_old
            // 
            this.txt_straps_id_old.AutoSize = true;
            this.txt_straps_id_old.Location = new System.Drawing.Point(350, 157);
            this.txt_straps_id_old.Name = "txt_straps_id_old";
            this.txt_straps_id_old.Size = new System.Drawing.Size(61, 33);
            this.txt_straps_id_old.TabIndex = 13;
            this.txt_straps_id_old.Text = "label6";
            this.txt_straps_id_old.Visible = false;
            // 
            // txt_straps_id_new
            // 
            this.txt_straps_id_new.AutoSize = true;
            this.txt_straps_id_new.Location = new System.Drawing.Point(350, 303);
            this.txt_straps_id_new.Name = "txt_straps_id_new";
            this.txt_straps_id_new.Size = new System.Drawing.Size(61, 33);
            this.txt_straps_id_new.TabIndex = 12;
            this.txt_straps_id_new.Text = "label6";
            this.txt_straps_id_new.Visible = false;
            // 
            // lb_income_id
            // 
            this.lb_income_id.AutoSize = true;
            this.lb_income_id.Location = new System.Drawing.Point(63, 338);
            this.lb_income_id.Name = "lb_income_id";
            this.lb_income_id.Size = new System.Drawing.Size(112, 33);
            this.lb_income_id.TabIndex = 11;
            this.lb_income_id.Text = "lb_income_id";
            this.lb_income_id.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(212, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "บันทึก";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_straps_note
            // 
            this.txt_straps_note.Location = new System.Drawing.Point(212, 237);
            this.txt_straps_note.Multiline = true;
            this.txt_straps_note.Name = "txt_straps_note";
            this.txt_straps_note.Size = new System.Drawing.Size(320, 56);
            this.txt_straps_note.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "เหตุผลเพิ่มเติม : ";
            // 
            // txt_straps_new
            // 
            this.txt_straps_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_straps_new.Location = new System.Drawing.Point(212, 299);
            this.txt_straps_new.MaxLength = 6;
            this.txt_straps_new.Name = "txt_straps_new";
            this.txt_straps_new.Size = new System.Drawing.Size(132, 31);
            this.txt_straps_new.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "หมายเลขสายรัดใหม่ : ";
            // 
            // txt_straps_old
            // 
            this.txt_straps_old.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_straps_old.Location = new System.Drawing.Point(212, 153);
            this.txt_straps_old.MaxLength = 6;
            this.txt_straps_old.Name = "txt_straps_old";
            this.txt_straps_old.ReadOnly = true;
            this.txt_straps_old.Size = new System.Drawing.Size(132, 31);
            this.txt_straps_old.TabIndex = 5;
            this.txt_straps_old.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_straps_old_KeyPress);
            this.txt_straps_old.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_straps_old_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "หมายเลขสายรัดเดิม : ";
            // 
            // txt_emp_name
            // 
            this.txt_emp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_emp_name.Location = new System.Drawing.Point(212, 116);
            this.txt_emp_name.MaxLength = 6;
            this.txt_emp_name.Name = "txt_emp_name";
            this.txt_emp_name.ReadOnly = true;
            this.txt_emp_name.Size = new System.Drawing.Size(320, 31);
            this.txt_emp_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อ-สกุล : ";
            // 
            // txt_emp_id
            // 
            this.txt_emp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_emp_id.Location = new System.Drawing.Point(212, 79);
            this.txt_emp_id.MaxLength = 6;
            this.txt_emp_id.Name = "txt_emp_id";
            this.txt_emp_id.Size = new System.Drawing.Size(132, 31);
            this.txt_emp_id.TabIndex = 1;
            this.txt_emp_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_emp_id_KeyPress);
            this.txt_emp_id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_id_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสพนักงาน : ";
            // 
            // EditStrapsEmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 408);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EditStrapsEmpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เปลี่ยนสายรัด/ชำรุด";
            this.Load += new System.EventHandler(this.EditStrapsEmpForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_straps_new;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_straps_old;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_emp_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_emp_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_straps_note;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb_income_id;
        private System.Windows.Forms.Label txt_straps_id_old;
        private System.Windows.Forms.Label txt_straps_id_new;
        private System.Windows.Forms.Label txt_bag;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox combo_note;
        private System.Windows.Forms.Label label6;
    }
}