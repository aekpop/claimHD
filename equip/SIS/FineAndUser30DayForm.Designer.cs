namespace TIS
{
    partial class FineAndUser30DayForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txt_straps_id = new System.Windows.Forms.Label();
            this.lb_message = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_bag = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_straps = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.txt_straps_id);
            this.groupBox3.Controls.Add(this.lb_message);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txt_bag);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_straps);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 324);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "นำส่งเงินถุงเงินพิเศษ";
            this.groupBox3.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.linkLabel1.Location = new System.Drawing.Point(373, 219);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 20);
            this.linkLabel1.TabIndex = 85;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "เปลี่ยนสายรัด";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txt_straps_id
            // 
            this.txt_straps_id.AutoSize = true;
            this.txt_straps_id.Location = new System.Drawing.Point(350, 169);
            this.txt_straps_id.Name = "txt_straps_id";
            this.txt_straps_id.Size = new System.Drawing.Size(61, 33);
            this.txt_straps_id.TabIndex = 84;
            this.txt_straps_id.Text = "label8";
            this.txt_straps_id.Visible = false;
            // 
            // lb_message
            // 
            this.lb_message.AutoSize = true;
            this.lb_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_message.ForeColor = System.Drawing.Color.Blue;
            this.lb_message.Location = new System.Drawing.Point(40, 32);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(88, 18);
            this.lb_message.TabIndex = 13;
            this.lb_message.Text = "lb_message";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.Location = new System.Drawing.Point(278, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 12;
            this.button2.Text = "บันทึก";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_bag
            // 
            this.txt_bag.Location = new System.Drawing.Point(278, 166);
            this.txt_bag.MaxLength = 4;
            this.txt_bag.Name = "txt_bag";
            this.txt_bag.Size = new System.Drawing.Size(66, 39);
            this.txt_bag.TabIndex = 7;
            this.txt_bag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bag_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 33);
            this.label6.TabIndex = 11;
            this.label6.Text = "ถุงเงินพิเศษ : ";
            // 
            // txt_straps
            // 
            this.txt_straps.Location = new System.Drawing.Point(278, 211);
            this.txt_straps.MaxLength = 6;
            this.txt_straps.Name = "txt_straps";
            this.txt_straps.ReadOnly = true;
            this.txt_straps.Size = new System.Drawing.Size(89, 39);
            this.txt_straps.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 33);
            this.label10.TabIndex = 5;
            this.label10.Text = "หมายเลขสายรัด : ";
            // 
            // FineAndUser30DayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 348);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FineAndUser30DayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FineAndUser30DayForm_FormClosed);
            this.Load += new System.EventHandler(this.FineAndUser30DayForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txt_straps_id;
        private System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_bag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_straps;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}