namespace Baitaplop.Forms
{
    partial class frmThongKe
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
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.btnhdb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbohdb = new System.Windows.Forms.ComboBox();
            this.pnlBaoCaoChildForm = new System.Windows.Forms.Panel();
            this.pnlTopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.Controls.Add(this.btnhdb);
            this.pnlTopMenu.Controls.Add(this.label1);
            this.pnlTopMenu.Controls.Add(this.cbohdb);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(994, 47);
            this.pnlTopMenu.TabIndex = 6;
            // 
            // btnhdb
            // 
            this.btnhdb.AutoSize = true;
            this.btnhdb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhdb.Location = new System.Drawing.Point(189, 12);
            this.btnhdb.Name = "btnhdb";
            this.btnhdb.Size = new System.Drawing.Size(93, 25);
            this.btnhdb.TabIndex = 8;
            this.btnhdb.Text = "Xuất thống kê";
            this.btnhdb.UseVisualStyleBackColor = true;
            this.btnhdb.Click += new System.EventHandler(this.btnhdb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn:";
            // 
            // cbohdb
            // 
            this.cbohdb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbohdb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohdb.FormattingEnabled = true;
            this.cbohdb.Items.AddRange(new object[] {
            "Doanh thu tháng",
            "Doanh thu ngày"});
            this.cbohdb.Location = new System.Drawing.Point(53, 12);
            this.cbohdb.Name = "cbohdb";
            this.cbohdb.Size = new System.Drawing.Size(121, 23);
            this.cbohdb.TabIndex = 6;
            // 
            // pnlBaoCaoChildForm
            // 
            this.pnlBaoCaoChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaoCaoChildForm.Location = new System.Drawing.Point(0, 47);
            this.pnlBaoCaoChildForm.Name = "pnlBaoCaoChildForm";
            this.pnlBaoCaoChildForm.Size = new System.Drawing.Size(994, 444);
            this.pnlBaoCaoChildForm.TabIndex = 7;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 491);
            this.Controls.Add(this.pnlBaoCaoChildForm);
            this.Controls.Add(this.pnlTopMenu);
            this.Name = "frmThongKe";
            this.Text = "Báo_cáo";
            this.Load += new System.EventHandler(this.Báo_cáo_Load);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Button btnhdb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbohdb;
        private System.Windows.Forms.Panel pnlBaoCaoChildForm;
    }
}