namespace Baitaplop.Báo_cáo
{
    partial class HDNcrt
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
            this.crthdn = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crthdn
            // 
            this.crthdn.ActiveViewIndex = -1;
            this.crthdn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crthdn.Cursor = System.Windows.Forms.Cursors.Default;
            this.crthdn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crthdn.Location = new System.Drawing.Point(0, 0);
            this.crthdn.Name = "crthdn";
            this.crthdn.Size = new System.Drawing.Size(862, 428);
            this.crthdn.TabIndex = 0;
            // 
            // HDNcrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 428);
            this.Controls.Add(this.crthdn);
            this.Name = "HDNcrt";
            this.Text = "HDNcrt";
            this.Load += new System.EventHandler(this.HDNcrt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crthdn;
    }
}