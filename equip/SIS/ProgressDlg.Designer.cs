namespace TIS
{
    partial class ProgressDlg
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
            this.progressStatus = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressStatus
            // 
            this.progressStatus.Location = new System.Drawing.Point(12, 41);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(403, 32);
            this.progressStatus.Step = 50;
            this.progressStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(155, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "กำลังประมวลผล";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProgressDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 87);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressDlg";
            this.Load += new System.EventHandler(this.ProgressDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressStatus;
        private System.Windows.Forms.Label label1;
    }
}