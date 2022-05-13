namespace TIS
{
    partial class EditStrapsForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.combo_note = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_straps_next = new System.Windows.Forms.TextBox();
            this.txt_straps_id = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_straps_note = new System.Windows.Forms.TextBox();
            this.txt_straps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.combo_note);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_straps_next);
            this.groupBox1.Controls.Add(this.txt_straps_id);
            this.groupBox1.Controls.Add(this.btn_confirm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_straps_note);
            this.groupBox1.Controls.Add(this.txt_straps);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เปลี่ยนสายรัด";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            this.groupBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 33);
            this.label5.TabIndex = 22;
            this.label5.Text = "เหตุผลเพิ่มเติม : ";
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
            this.combo_note.Location = new System.Drawing.Point(198, 79);
            this.combo_note.Name = "combo_note";
            this.combo_note.Size = new System.Drawing.Size(378, 41);
            this.combo_note.TabIndex = 21;
            this.combo_note.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_note_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 33);
            this.label3.TabIndex = 15;
            this.label3.Text = "หมายเลขสายรัดใหม่ : ";
            this.label3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // txt_straps_next
            // 
            this.txt_straps_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_straps_next.Location = new System.Drawing.Point(198, 207);
            this.txt_straps_next.Name = "txt_straps_next";
            this.txt_straps_next.Size = new System.Drawing.Size(150, 31);
            this.txt_straps_next.TabIndex = 14;
            this.txt_straps_next.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_straps_next_KeyUp);
            this.txt_straps_next.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // txt_straps_id
            // 
            this.txt_straps_id.AutoSize = true;
            this.txt_straps_id.Location = new System.Drawing.Point(354, 46);
            this.txt_straps_id.Name = "txt_straps_id";
            this.txt_straps_id.Size = new System.Drawing.Size(61, 33);
            this.txt_straps_id.TabIndex = 13;
            this.txt_straps_id.Text = "label3";
            this.txt_straps_id.Visible = false;
            this.txt_straps_id.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_confirm.Location = new System.Drawing.Point(483, 241);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(106, 37);
            this.btn_confirm.TabIndex = 12;
            this.btn_confirm.Text = "ยืนยัน";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            this.btn_confirm.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "สาเหตุที่เปลี่ยน : ";
            this.label2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // txt_straps_note
            // 
            this.txt_straps_note.Location = new System.Drawing.Point(198, 126);
            this.txt_straps_note.Multiline = true;
            this.txt_straps_note.Name = "txt_straps_note";
            this.txt_straps_note.Size = new System.Drawing.Size(378, 75);
            this.txt_straps_note.TabIndex = 2;
            this.txt_straps_note.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // txt_straps
            // 
            this.txt_straps.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_straps.Location = new System.Drawing.Point(198, 42);
            this.txt_straps.Name = "txt_straps";
            this.txt_straps.ReadOnly = true;
            this.txt_straps.Size = new System.Drawing.Size(150, 31);
            this.txt_straps.TabIndex = 1;
            this.txt_straps.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "หมายเลขสายรัดเดิม : ";
            this.label1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.groupBox1_PreviewKeyDown);
            // 
            // EditStrapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 307);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EditStrapsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เปลี่ยนสายรัด";
            this.Load += new System.EventHandler(this.EditStrapsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_straps_note;
        private System.Windows.Forms.TextBox txt_straps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_straps_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_straps_next;
        private System.Windows.Forms.ComboBox combo_note;
        private System.Windows.Forms.Label label5;
    }
}