namespace TIS
{
    partial class BagNextTimeForm
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
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.txt_cabinet = new System.Windows.Forms.TextBox();
            this.txt_emp_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_emp_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_bag = new System.Windows.Forms.TextBox();
            this.txt_money = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.txt_cabinet);
            this.groupbox1.Controls.Add(this.txt_emp_id);
            this.groupbox1.Controls.Add(this.label7);
            this.groupbox1.Controls.Add(this.label1);
            this.groupbox1.Controls.Add(this.lb_emp_name);
            this.groupbox1.Controls.Add(this.label2);
            this.groupbox1.Controls.Add(this.label5);
            this.groupbox1.Controls.Add(this.label3);
            this.groupbox1.Controls.Add(this.label4);
            this.groupbox1.Controls.Add(this.txt_bag);
            this.groupbox1.Controls.Add(this.txt_money);
            this.groupbox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupbox1.Location = new System.Drawing.Point(7, 6);
            this.groupbox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupbox1.Size = new System.Drawing.Size(815, 291);
            this.groupbox1.TabIndex = 0;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "เบิกถุงเงินผลัดต่อ";
            // 
            // txt_cabinet
            // 
            this.txt_cabinet.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_cabinet.ForeColor = System.Drawing.Color.Red;
            this.txt_cabinet.Location = new System.Drawing.Point(428, 141);
            this.txt_cabinet.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cabinet.MaxLength = 2;
            this.txt_cabinet.Name = "txt_cabinet";
            this.txt_cabinet.Size = new System.Drawing.Size(76, 56);
            this.txt_cabinet.TabIndex = 3;
            this.txt_cabinet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_cabinet.Validating += new System.ComponentModel.CancelEventHandler(this.txt_cabinet_Validating);
            // 
            // txt_emp_id
            // 
            this.txt_emp_id.Location = new System.Drawing.Point(180, 36);
            this.txt_emp_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_emp_id.MaxLength = 6;
            this.txt_emp_id.Name = "txt_emp_id";
            this.txt_emp_id.Size = new System.Drawing.Size(166, 39);
            this.txt_emp_id.TabIndex = 1;
            this.txt_emp_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_emp_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_emp_id_KeyPress);
            this.txt_emp_id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_id_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 223);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 33);
            this.label7.TabIndex = 22;
            this.label7.Text = "บาท";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "รหัสพนักงาน : ";
            // 
            // lb_emp_name
            // 
            this.lb_emp_name.AutoSize = true;
            this.lb_emp_name.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_emp_name.ForeColor = System.Drawing.Color.Red;
            this.lb_emp_name.Location = new System.Drawing.Point(180, 89);
            this.lb_emp_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_emp_name.Name = "lb_emp_name";
            this.lb_emp_name.Size = new System.Drawing.Size(228, 50);
            this.lb_emp_name.TabIndex = 21;
            this.lb_emp_name.Text = "ไม่พบข้อมูลพนักงาน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(70, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 50);
            this.label2.TabIndex = 15;
            this.label2.Text = "ถุงเงิน : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(50, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 50);
            this.label5.TabIndex = 20;
            this.label5.Text = "ชื่อ-สกุล : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(349, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 50);
            this.label3.TabIndex = 17;
            this.label3.Text = "ตู้ที่ : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 33);
            this.label4.TabIndex = 19;
            this.label4.Text = "รับเงินทอนจำนวน : ";
            // 
            // txt_bag
            // 
            this.txt_bag.Font = new System.Drawing.Font("TH SarabunPSK", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_bag.ForeColor = System.Drawing.Color.Red;
            this.txt_bag.Location = new System.Drawing.Point(180, 141);
            this.txt_bag.Margin = new System.Windows.Forms.Padding(2);
            this.txt_bag.MaxLength = 4;
            this.txt_bag.Name = "txt_bag";
            this.txt_bag.Size = new System.Drawing.Size(165, 56);
            this.txt_bag.TabIndex = 2;
            this.txt_bag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_bag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bag_KeyUp);
            // 
            // txt_money
            // 
            this.txt_money.Location = new System.Drawing.Point(180, 220);
            this.txt_money.Margin = new System.Windows.Forms.Padding(2);
            this.txt_money.MaxLength = 10;
            this.txt_money.Name = "txt_money";
            this.txt_money.Size = new System.Drawing.Size(152, 39);
            this.txt_money.TabIndex = 4;
            this.txt_money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_money.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_money_KeyDown);
            this.txt_money.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_money_KeyPress);
            this.txt_money.Leave += new System.EventHandler(this.txt_money_Leave);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(187, 301);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "บันทึก";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_edit.Location = new System.Drawing.Point(412, 301);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(99, 34);
            this.btn_edit.TabIndex = 6;
            this.btn_edit.Text = "แก้ไข";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Visible = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 28;
            this.listBox1.Location = new System.Drawing.Point(6, 348);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(815, 312);
            this.listBox1.TabIndex = 7;
            // 
            // BagNextTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 668);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupbox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "BagNextTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BagNextTimeForm_Load);
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.TextBox txt_cabinet;
        private System.Windows.Forms.TextBox txt_emp_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_emp_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_bag;
        private System.Windows.Forms.TextBox txt_money;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.ListBox listBox1;
    }
}