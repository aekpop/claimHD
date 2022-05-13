namespace TIS
{
    partial class MenuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.lb_cpoint = new System.Windows.Forms.Label();
            this.timer_show = new System.Windows.Forms.Timer(this.components);
            this.lb_time = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_memo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_around = new System.Windows.Forms.Button();
            this.btn_refund = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_bag = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.group_around = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_edit_jon = new System.Windows.Forms.Button();
            this.label_date = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_group = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_emp_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.lb_around_id = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.group_around.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_cpoint
            // 
            this.lb_cpoint.AutoEllipsis = true;
            this.lb_cpoint.AutoSize = true;
            this.lb_cpoint.BackColor = System.Drawing.Color.Transparent;
            this.lb_cpoint.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_cpoint.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_cpoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_cpoint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_cpoint.Location = new System.Drawing.Point(898, 0);
            this.lb_cpoint.Name = "lb_cpoint";
            this.lb_cpoint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_cpoint.Size = new System.Drawing.Size(237, 64);
            this.lb_cpoint.TabIndex = 25;
            this.lb_cpoint.Text = "ไม่พบข้อมูลด่าน";
            this.lb_cpoint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer_show
            // 
            this.timer_show.Enabled = true;
            this.timer_show.Tick += new System.EventHandler(this.timer_show_Tick);
            // 
            // lb_time
            // 
            this.lb_time.AutoEllipsis = true;
            this.lb_time.AutoSize = true;
            this.lb_time.BackColor = System.Drawing.Color.Transparent;
            this.lb_time.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_time.Font = new System.Drawing.Font("TH SarabunPSK", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_time.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lb_time.Location = new System.Drawing.Point(0, 0);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(203, 85);
            this.lb_time.TabIndex = 27;
            this.lb_time.Text = "00:00:00";
            this.lb_time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.group_around);
            this.groupBox1.Controls.Add(this.btn_setting);
            this.groupBox1.Font = new System.Drawing.Font("TH SarabunPSK", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1108, 635);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toll of Income System (TIS)";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            this.groupBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_memo);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_edit);
            this.groupBox2.Controls.Add(this.btn_around);
            this.groupBox2.Controls.Add(this.btn_refund);
            this.groupBox2.Controls.Add(this.btn_report);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Controls.Add(this.btn_bag);
            this.groupBox2.Location = new System.Drawing.Point(193, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(814, 456);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btn_memo
            // 
            this.btn_memo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_memo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_memo.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_memo.ForeColor = System.Drawing.Color.Black;
            this.btn_memo.Image = global::TIS.Properties.Resources.note;
            this.btn_memo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_memo.Location = new System.Drawing.Point(637, 244);
            this.btn_memo.Name = "btn_memo";
            this.btn_memo.Size = new System.Drawing.Size(151, 189);
            this.btn_memo.TabIndex = 13;
            this.btn_memo.Text = "ทำบันทึก\r\n ";
            this.btn_memo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_memo.UseVisualStyleBackColor = false;
            this.btn_memo.Click += new System.EventHandler(this.btn_memo_Click);
            this.btn_memo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_memo_PreviewKeyDown);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = global::TIS.Properties.Resources.richNext;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(9, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 189);
            this.button3.TabIndex = 12;
            this.button3.Text = "เบิกถุงเงินผลัดต่อ\r\n ";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::TIS.Properties.Resources.straps;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(637, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 189);
            this.button2.TabIndex = 11;
            this.button2.Text = "สายรัด/ชำรุด\r\n ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::TIS.Properties.Resources.notes2;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(166, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 189);
            this.button1.TabIndex = 10;
            this.button1.Text = "ส่งเงินรายได้อื่นๆ\r\n ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_edit.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.Black;
            this.btn_edit.Image = global::TIS.Properties.Resources.get_money__1_;
            this.btn_edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_edit.Location = new System.Drawing.Point(480, 33);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(151, 189);
            this.btn_edit.TabIndex = 4;
            this.btn_edit.Text = "วิเคราะห์งาน\r\n ";
            this.btn_edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            this.btn_edit.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // btn_around
            // 
            this.btn_around.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_around.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_around.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_around.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_around.ForeColor = System.Drawing.Color.Black;
            this.btn_around.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_around.Location = new System.Drawing.Point(9, 33);
            this.btn_around.Name = "btn_around";
            this.btn_around.Size = new System.Drawing.Size(151, 189);
            this.btn_around.TabIndex = 1;
            this.btn_around.Text = "สถานะผลัด\r\n ";
            this.btn_around.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_around.UseVisualStyleBackColor = false;
            this.btn_around.Click += new System.EventHandler(this.btn_around_Click);
            this.btn_around.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // btn_refund
            // 
            this.btn_refund.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refund.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_refund.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refund.ForeColor = System.Drawing.Color.Black;
            this.btn_refund.Image = global::TIS.Properties.Resources.icon011;
            this.btn_refund.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_refund.Location = new System.Drawing.Point(323, 244);
            this.btn_refund.Name = "btn_refund";
            this.btn_refund.Size = new System.Drawing.Size(151, 189);
            this.btn_refund.TabIndex = 6;
            this.btn_refund.Text = "คืนเงินผู้ใช้ทาง\r\n ";
            this.btn_refund.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_refund.UseVisualStyleBackColor = false;
            this.btn_refund.Click += new System.EventHandler(this.btn_refund_Click);
            this.btn_refund.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // btn_report
            // 
            this.btn_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_report.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_report.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_report.ForeColor = System.Drawing.Color.Black;
            this.btn_report.Image = global::TIS.Properties.Resources.receipt;
            this.btn_report.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_report.Location = new System.Drawing.Point(480, 244);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(151, 189);
            this.btn_report.TabIndex = 5;
            this.btn_report.Text = "พิมพ์รายงาน\r\n ";
            this.btn_report.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_report.UseVisualStyleBackColor = false;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            this.btn_report.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // btn_send
            // 
            this.btn_send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_send.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.ForeColor = System.Drawing.Color.Black;
            this.btn_send.Image = global::TIS.Properties.Resources.change;
            this.btn_send.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_send.Location = new System.Drawing.Point(323, 33);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(151, 189);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "คืนเงินทอน / \r\nนำส่งเงินรายได้";
            this.btn_send.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            this.btn_send.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // btn_bag
            // 
            this.btn_bag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_bag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_bag.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bag.ForeColor = System.Drawing.Color.Black;
            this.btn_bag.Image = global::TIS.Properties.Resources.rich;
            this.btn_bag.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_bag.Location = new System.Drawing.Point(166, 33);
            this.btn_bag.Name = "btn_bag";
            this.btn_bag.Size = new System.Drawing.Size(151, 189);
            this.btn_bag.TabIndex = 2;
            this.btn_bag.Text = "เบิกถุงเงิน\r\nสถานะการปฏิบัติงาน\r\n";
            this.btn_bag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_bag.UseVisualStyleBackColor = false;
            this.btn_bag.Click += new System.EventHandler(this.btn_bag_Click);
            this.btn_bag.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(1013, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "V1.0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // group_around
            // 
            this.group_around.Controls.Add(this.button4);
            this.group_around.Controls.Add(this.linkLabel1);
            this.group_around.Controls.Add(this.btn_edit_jon);
            this.group_around.Controls.Add(this.label_date);
            this.group_around.Controls.Add(this.label4);
            this.group_around.Controls.Add(this.lb_group);
            this.group_around.Controls.Add(this.label3);
            this.group_around.Controls.Add(this.lb_emp_name);
            this.group_around.Controls.Add(this.label1);
            this.group_around.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.group_around.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.group_around.Location = new System.Drawing.Point(25, 48);
            this.group_around.Name = "group_around";
            this.group_around.Size = new System.Drawing.Size(722, 113);
            this.group_around.TabIndex = 8;
            this.group_around.TabStop = false;
            this.group_around.Text = "ข้อมูลผลัด";
            this.group_around.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(519, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 29);
            this.button4.TabIndex = 13;
            this.button4.Text = "แก้ไขเปิดกะผิด";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.linkLabel1.Location = new System.Drawing.Point(533, 49);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(162, 28);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ถาม-ตอบปัญหาการใช้งาน";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // btn_edit_jon
            // 
            this.btn_edit_jon.Location = new System.Drawing.Point(633, 78);
            this.btn_edit_jon.Name = "btn_edit_jon";
            this.btn_edit_jon.Size = new System.Drawing.Size(75, 29);
            this.btn_edit_jon.TabIndex = 7;
            this.btn_edit_jon.Text = "แก้ไขงาน";
            this.btn_edit_jon.UseVisualStyleBackColor = true;
            this.btn_edit_jon.Click += new System.EventHandler(this.btn_edit_jon_Click);
            this.btn_edit_jon.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_edit_jon_PreviewKeyDown);
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.BackColor = System.Drawing.Color.White;
            this.label_date.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label_date.Location = new System.Drawing.Point(163, 78);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(36, 28);
            this.label_date.TabIndex = 6;
            this.label_date.Text = "ผลัด";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(99, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "วันที่ : ";
            // 
            // lb_group
            // 
            this.lb_group.AutoSize = true;
            this.lb_group.BackColor = System.Drawing.Color.White;
            this.lb_group.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_group.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_group.Location = new System.Drawing.Point(163, 49);
            this.lb_group.Name = "lb_group";
            this.lb_group.Size = new System.Drawing.Size(72, 28);
            this.lb_group.TabIndex = 4;
            this.lb_group.Text = "lb_group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(71, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "ตำแหน่ง : ";
            // 
            // lb_emp_name
            // 
            this.lb_emp_name.AutoSize = true;
            this.lb_emp_name.BackColor = System.Drawing.Color.White;
            this.lb_emp_name.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_emp_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_emp_name.Location = new System.Drawing.Point(163, 20);
            this.lb_emp_name.Name = "lb_emp_name";
            this.lb_emp_name.Size = new System.Drawing.Size(58, 28);
            this.lb_emp_name.TabIndex = 2;
            this.lb_emp_name.Text = "ชื่อ-สกุล";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(69, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "ผู้ควบคุม : ";
            // 
            // btn_setting
            // 
            this.btn_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_setting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_setting.Enabled = false;
            this.btn_setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_setting.ForeColor = System.Drawing.Color.Black;
            this.btn_setting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_setting.Location = new System.Drawing.Point(38, 200);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(0, 0);
            this.btn_setting.TabIndex = 7;
            this.btn_setting.Text = "ตั้งค่า\r\n ";
            this.btn_setting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Visible = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            this.btn_setting.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            // 
            // lb_around_id
            // 
            this.lb_around_id.AutoSize = true;
            this.lb_around_id.Location = new System.Drawing.Point(672, 24);
            this.lb_around_id.Name = "lb_around_id";
            this.lb_around_id.Size = new System.Drawing.Size(35, 13);
            this.lb_around_id.TabIndex = 29;
            this.lb_around_id.Text = "label5";
            this.lb_around_id.Visible = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::TIS.Properties.Resources._01254154215415;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1135, 749);
            this.Controls.Add(this.lb_around_id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.lb_cpoint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toll of Income System (TIS)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_around_PreviewKeyDown_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.group_around.ResumeLayout(false);
            this.group_around.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_cpoint;
        private System.Windows.Forms.Timer timer_show;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox group_around;
        private System.Windows.Forms.Label lb_emp_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_memo;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_around;
        public System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_refund;
        private System.Windows.Forms.Button btn_report;
        public System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_bag;
        private System.Windows.Forms.Button btn_edit_jon;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lb_around_id;
    }
}