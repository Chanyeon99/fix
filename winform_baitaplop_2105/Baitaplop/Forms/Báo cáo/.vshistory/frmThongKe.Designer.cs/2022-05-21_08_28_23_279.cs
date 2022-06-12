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
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDayEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDayStart = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbohdb = new System.Windows.Forms.ComboBox();
            this.pnlBaoCaoChildForm = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTopMenu.SuspendLayout();
            this.pnlBaoCaoChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.Controls.Add(this.btnXuatExcel);
            this.pnlTopMenu.Controls.Add(this.label3);
            this.pnlTopMenu.Controls.Add(this.label2);
            this.pnlTopMenu.Controls.Add(this.dtpDayEnd);
            this.pnlTopMenu.Controls.Add(this.dtpDayStart);
            this.pnlTopMenu.Controls.Add(this.btnThongKe);
            this.pnlTopMenu.Controls.Add(this.label1);
            this.pnlTopMenu.Controls.Add(this.cbohdb);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(884, 58);
            this.pnlTopMenu.TabIndex = 6;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.AutoSize = true;
            this.btnXuatExcel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(731, 17);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(123, 31);
            this.btnXuatExcel.TabIndex = 13;
            this.btnXuatExcel.Text = "Xuất file excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(423, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Chọn ngày kết thúc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Chọn ngày bắt đầu:";
            // 
            // dtpDayEnd
            // 
            this.dtpDayEnd.CalendarFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpDayEnd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayEnd.Location = new System.Drawing.Point(426, 27);
            this.dtpDayEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDayEnd.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDayEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDayEnd.Name = "dtpDayEnd";
            this.dtpDayEnd.Size = new System.Drawing.Size(142, 23);
            this.dtpDayEnd.TabIndex = 10;
            // 
            // dtpDayStart
            // 
            this.dtpDayStart.CalendarFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayStart.CustomFormat = "dd/MM/yyyy";
            this.dtpDayStart.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayStart.Location = new System.Drawing.Point(264, 27);
            this.dtpDayStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDayStart.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDayStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDayStart.Name = "dtpDayStart";
            this.dtpDayStart.Size = new System.Drawing.Size(142, 23);
            this.dtpDayStart.TabIndex = 9;
            // 
            // btnThongKe
            // 
            this.btnThongKe.AutoSize = true;
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(590, 17);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(123, 31);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 9);
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
            this.cbohdb.Location = new System.Drawing.Point(73, 27);
            this.cbohdb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbohdb.Name = "cbohdb";
            this.cbohdb.Size = new System.Drawing.Size(159, 23);
            this.cbohdb.TabIndex = 6;
            // 
            // pnlBaoCaoChildForm
            // 
            this.pnlBaoCaoChildForm.Controls.Add(this.dataGridView1);
            this.pnlBaoCaoChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaoCaoChildForm.Location = new System.Drawing.Point(0, 58);
            this.pnlBaoCaoChildForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBaoCaoChildForm.Name = "pnlBaoCaoChildForm";
            this.pnlBaoCaoChildForm.Size = new System.Drawing.Size(884, 443);
            this.pnlBaoCaoChildForm.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.SoLuongCon,
            this.GiaNhap,
            this.SoLuongDaBan,
            this.DoanhThu});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(884, 443);
            this.dataGridView1.TabIndex = 0;
            // 
            // MaSP
            // 
            this.MaSP.FillWeight = 80F;
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên SP";
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // SoLuongCon
            // 
            this.SoLuongCon.HeaderText = "Số lượng còn";
            this.SoLuongCon.Name = "SoLuongCon";
            this.SoLuongCon.ReadOnly = true;
            // 
            // GiaNhap
            // 
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.Name = "GiaNhap";
            this.GiaNhap.ReadOnly = true;
            // 
            // SoLuongDaBan
            // 
            this.SoLuongDaBan.HeaderText = "Số lượng đã bán";
            this.SoLuongDaBan.Name = "SoLuongDaBan";
            this.SoLuongDaBan.ReadOnly = true;
            // 
            // DoanhThu
            // 
            this.DoanhThu.HeaderText = "Doanh thu";
            this.DoanhThu.Name = "DoanhThu";
            this.DoanhThu.ReadOnly = true;
            // 
            // frmThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 501);
            this.Controls.Add(this.pnlBaoCaoChildForm);
            this.Controls.Add(this.pnlTopMenu);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.Báo_cáo_Load);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            this.pnlBaoCaoChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbohdb;
        private System.Windows.Forms.Panel pnlBaoCaoChildForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDayEnd;
        private System.Windows.Forms.DateTimePicker dtpDayStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoanhThu;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}