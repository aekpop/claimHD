namespace TIS
{
    partial class PopupReport
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
            this.cry_View = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cry_View
            // 
            this.cry_View.ActiveViewIndex = -1;
            this.cry_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cry_View.Cursor = System.Windows.Forms.Cursors.Default;
            this.cry_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cry_View.Location = new System.Drawing.Point(0, 0);
            this.cry_View.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cry_View.Name = "cry_View";
            this.cry_View.ShowCloseButton = false;
            this.cry_View.ShowCopyButton = false;
            this.cry_View.ShowGotoPageButton = false;
            this.cry_View.ShowGroupTreeButton = false;
            this.cry_View.ShowLogo = false;
            this.cry_View.ShowParameterPanelButton = false;
            this.cry_View.ShowRefreshButton = false;
            this.cry_View.ShowTextSearchButton = false;
            this.cry_View.Size = new System.Drawing.Size(933, 881);
            this.cry_View.TabIndex = 7;
            this.cry_View.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PopupReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 881);
            this.Controls.Add(this.cry_View);
            this.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.Name = "PopupReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopupReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cry_View;
    }
}