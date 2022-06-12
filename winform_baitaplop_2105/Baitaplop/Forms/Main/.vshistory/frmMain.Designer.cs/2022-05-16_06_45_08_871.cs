
namespace Baitaplop.Forms
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mipQL = new System.Windows.Forms.ToolStripMenuItem();
            this.miQLNV = new System.Windows.Forms.ToolStripMenuItem();
            this.miQLKH = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miQLSP = new System.Windows.Forms.ToolStripMenuItem();
            this.mipHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.miHoaDonBan = new System.Windows.Forms.ToolStripMenuItem();
            this.miHoaDonNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mipBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.miBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.miThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mipTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.miThongTinTK = new System.Windows.Forms.ToolStripMenuItem();
            this.miDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.menuItemSP_DSSP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_LSP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_HSX = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_NCC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Roboto", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mipQL,
            this.mipHoaDon,
            this.mipBaoCao,
            this.mipTaiKhoan});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mipQL
            // 
            this.mipQL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miQLNV,
            this.miQLKH,
            this.toolStripSeparator1,
            this.miQLSP});
            this.mipQL.Name = "mipQL";
            this.mipQL.Size = new System.Drawing.Size(60, 20);
            this.mipQL.Text = "Quản lý";
            // 
            // miQLNV
            // 
            this.miQLNV.Name = "miQLNV";
            this.miQLNV.Size = new System.Drawing.Size(180, 22);
            this.miQLNV.Text = "Nhân viên";
            this.miQLNV.Click += new System.EventHandler(this.menuItemNhanVien_Click);
            // 
            // miQLKH
            // 
            this.miQLKH.Name = "miQLKH";
            this.miQLKH.Size = new System.Drawing.Size(180, 22);
            this.miQLKH.Text = "Khách hàng";
            this.miQLKH.Click += new System.EventHandler(this.menuItemKhachHang_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // miQLSP
            // 
            this.miQLSP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSP_DSSP,
            this.menuItemSP_LSP,
            this.menuItemSP_HSX,
            this.menuItemSP_NCC});
            this.miQLSP.Name = "miQLSP";
            this.miQLSP.Size = new System.Drawing.Size(180, 22);
            this.miQLSP.Text = "Sản phẩm";
            // 
            // mipHoaDon
            // 
            this.mipHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHoaDonBan,
            this.miHoaDonNhap});
            this.mipHoaDon.Name = "mipHoaDon";
            this.mipHoaDon.Size = new System.Drawing.Size(66, 20);
            this.mipHoaDon.Text = "Hóa đơn";
            // 
            // miHoaDonBan
            // 
            this.miHoaDonBan.Name = "miHoaDonBan";
            this.miHoaDonBan.Size = new System.Drawing.Size(152, 22);
            this.miHoaDonBan.Text = "Hóa đơn bán";
            this.miHoaDonBan.Click += new System.EventHandler(this.menuItemHD_Ban_Click);
            // 
            // miHoaDonNhap
            // 
            this.miHoaDonNhap.Name = "miHoaDonNhap";
            this.miHoaDonNhap.Size = new System.Drawing.Size(152, 22);
            this.miHoaDonNhap.Text = "Hóa đơn nhập";
            this.miHoaDonNhap.Click += new System.EventHandler(this.menuItemHD_Nhap_Click);
            // 
            // mipBaoCao
            // 
            this.mipBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBaoCao,
            this.miThongKe});
            this.mipBaoCao.Name = "mipBaoCao";
            this.mipBaoCao.Size = new System.Drawing.Size(63, 20);
            this.mipBaoCao.Text = "Báo cáo";
            // 
            // miBaoCao
            // 
            this.miBaoCao.Name = "miBaoCao";
            this.miBaoCao.Size = new System.Drawing.Size(124, 22);
            this.miBaoCao.Text = "Báo cáo";
            this.miBaoCao.Click += new System.EventHandler(this.menuItemBaoCao_Click);
            // 
            // miThongKe
            // 
            this.miThongKe.Name = "miThongKe";
            this.miThongKe.Size = new System.Drawing.Size(124, 22);
            this.miThongKe.Text = "Thống kê";
            // 
            // mipTaiKhoan
            // 
            this.mipTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miThongTinTK,
            this.miDangXuat});
            this.mipTaiKhoan.Name = "mipTaiKhoan";
            this.mipTaiKhoan.Size = new System.Drawing.Size(72, 20);
            this.mipTaiKhoan.Text = "Tài khoản";
            // 
            // miThongTinTK
            // 
            this.miThongTinTK.Name = "miThongTinTK";
            this.miThongTinTK.Size = new System.Drawing.Size(130, 22);
            this.miThongTinTK.Text = "Thông tin";
            // 
            // miDangXuat
            // 
            this.miDangXuat.Name = "miDangXuat";
            this.miDangXuat.Size = new System.Drawing.Size(130, 22);
            this.miDangXuat.Text = "Đăng xuất";
            this.miDangXuat.Click += new System.EventHandler(this.menuItemThoat_Click);
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(0, 24);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(784, 437);
            this.pnlChildForm.TabIndex = 1;
            // 
            // menuItemSP_DSSP
            // 
            this.menuItemSP_DSSP.Name = "menuItemSP_DSSP";
            this.menuItemSP_DSSP.Size = new System.Drawing.Size(190, 22);
            this.menuItemSP_DSSP.Text = "Danh sách sản phẩm";
            this.menuItemSP_DSSP.Click += new System.EventHandler(this.menuItemSP_DSSP_Click);
            // 
            // menuItemSP_LSP
            // 
            this.menuItemSP_LSP.Name = "menuItemSP_LSP";
            this.menuItemSP_LSP.Size = new System.Drawing.Size(190, 22);
            this.menuItemSP_LSP.Text = "Loại sản phẩm";
            this.menuItemSP_LSP.Click += new System.EventHandler(this.menuItemSP_LSP_Click);
            // 
            // menuItemSP_HSX
            // 
            this.menuItemSP_HSX.Name = "menuItemSP_HSX";
            this.menuItemSP_HSX.Size = new System.Drawing.Size(190, 22);
            this.menuItemSP_HSX.Text = "Hãng sản xuất";
            this.menuItemSP_HSX.Click += new System.EventHandler(this.menuItemSP_HSX_Click);
            // 
            // menuItemSP_NCC
            // 
            this.menuItemSP_NCC.Name = "menuItemSP_NCC";
            this.menuItemSP_NCC.Size = new System.Drawing.Size(190, 22);
            this.menuItemSP_NCC.Text = "Nhà cung cấp";
            this.menuItemSP_NCC.Click += new System.EventHandler(this.menuItemSP_NCC_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng - Màn hình chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mipQL;
        private System.Windows.Forms.ToolStripMenuItem miQLNV;
        private System.Windows.Forms.ToolStripMenuItem miQLKH;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miQLSP;
        private System.Windows.Forms.ToolStripMenuItem mipHoaDon;
        private System.Windows.Forms.ToolStripMenuItem miHoaDonBan;
        private System.Windows.Forms.ToolStripMenuItem miHoaDonNhap;
        private System.Windows.Forms.ToolStripMenuItem mipBaoCao;
        private System.Windows.Forms.ToolStripMenuItem miBaoCao;
        private System.Windows.Forms.ToolStripMenuItem miThongKe;
        private System.Windows.Forms.ToolStripMenuItem mipTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem miThongTinTK;
        private System.Windows.Forms.ToolStripMenuItem miDangXuat;
        private System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_DSSP;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_LSP;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_HSX;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_NCC;
    }
}