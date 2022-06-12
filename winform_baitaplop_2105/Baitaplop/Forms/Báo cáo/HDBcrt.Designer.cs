namespace Baitaplop.Forms
{
    partial class HDBcrt
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
            this.crthdb = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crthoadonban1 = new Baitaplop.crthoadonban();
            this.SuspendLayout();
            // 
            // crthdb
            // 
            this.crthdb.ActiveViewIndex = -1;
            this.crthdb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crthdb.Cursor = System.Windows.Forms.Cursors.Default;
            this.crthdb.Location = new System.Drawing.Point(0, 0);
            this.crthdb.Name = "crthdb";
            this.crthdb.Size = new System.Drawing.Size(803, 456);
            this.crthdb.TabIndex = 0;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv.Location = new System.Drawing.Point(0, 0);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(803, 456);
            this.crv.TabIndex = 0;
            this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // HDBcrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 456);
            this.Controls.Add(this.crv);
            this.Name = "HDBcrt";
            this.Text = "HDBcrt";
            this.Load += new System.EventHandler(this.HDBcrt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crthdb;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private crthoadonban crthoadonban1;
    }
}