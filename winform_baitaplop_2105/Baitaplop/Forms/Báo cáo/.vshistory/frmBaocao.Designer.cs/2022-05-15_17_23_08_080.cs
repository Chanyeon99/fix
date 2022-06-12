namespace Baitaplop.Báo_cáo
{
    partial class Báo_cáo
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
            this.cbohdb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnhdb = new System.Windows.Forms.Button();
            this.btnhdn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbohdn = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbohdb
            // 
            this.cbohdb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbohdb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohdb.FormattingEnabled = true;
            this.cbohdb.Location = new System.Drawing.Point(129, 53);
            this.cbohdb.Name = "cbohdb";
            this.cbohdb.Size = new System.Drawing.Size(121, 23);
            this.cbohdb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hóa đơn bán";
            // 
            // btnhdb
            // 
            this.btnhdb.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhdb.Location = new System.Drawing.Point(272, 51);
            this.btnhdb.Name = "btnhdb";
            this.btnhdb.Size = new System.Drawing.Size(88, 23);
            this.btnhdb.TabIndex = 2;
            this.btnhdb.Text = "Xuất báo cáo";
            this.btnhdb.UseVisualStyleBackColor = true;
            this.btnhdb.Click += new System.EventHandler(this.btnhdb_Click);
            // 
            // btnhdn
            // 
            this.btnhdn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhdn.Location = new System.Drawing.Point(272, 80);
            this.btnhdn.Name = "btnhdn";
            this.btnhdn.Size = new System.Drawing.Size(88, 23);
            this.btnhdn.TabIndex = 5;
            this.btnhdn.Text = "Xuất báo cáo";
            this.btnhdn.UseVisualStyleBackColor = true;
            this.btnhdn.Click += new System.EventHandler(this.btnhdn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hóa đơn nhập";
            // 
            // cbohdn
            // 
            this.cbohdn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbohdn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbohdn.FormattingEnabled = true;
            this.cbohdn.Location = new System.Drawing.Point(129, 82);
            this.cbohdn.Name = "cbohdn";
            this.cbohdn.Size = new System.Drawing.Size(121, 23);
            this.cbohdn.TabIndex = 3;
            // 
            // Báo_cáo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 160);
            this.Controls.Add(this.btnhdn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbohdn);
            this.Controls.Add(this.btnhdb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbohdb);
            this.Name = "Báo_cáo";
            this.Text = "Báo_cáo";
            this.Load += new System.EventHandler(this.Báo_cáo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbohdb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnhdb;
        private System.Windows.Forms.Button btnhdn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbohdn;
    }
}