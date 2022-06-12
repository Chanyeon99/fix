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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nhậpDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_DSSP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_LSP = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_HSX = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSP_NCC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHD_Nhap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHD_Ban = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpDữLiệuToolStripMenuItem,
            this.menuItemHoaDon,
            this.menuItemBaoCao,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nhậpDữLiệuToolStripMenuItem
            // 
            this.nhậpDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNhanVien,
            this.menuItemSanPham,
            this.menuItemKhachHang});
            this.nhậpDữLiệuToolStripMenuItem.Name = "nhậpDữLiệuToolStripMenuItem";
            this.nhậpDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nhậpDữLiệuToolStripMenuItem.Text = "Quản lý";
            // 
            // menuItemNhanVien
            // 
            this.menuItemNhanVien.Name = "menuItemNhanVien";
            this.menuItemNhanVien.Size = new System.Drawing.Size(180, 22);
            this.menuItemNhanVien.Text = "Nhân viên";
            this.menuItemNhanVien.Click += new System.EventHandler(this.menuItemNhanVien_Click);
            // 
            // menuItemSanPham
            // 
            this.menuItemSanPham.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSP_DSSP,
            this.menuItemSP_LSP,
            this.menuItemSP_HSX,
            this.menuItemSP_NCC});
            this.menuItemSanPham.Name = "menuItemSanPham";
            this.menuItemSanPham.Size = new System.Drawing.Size(180, 22);
            this.menuItemSanPham.Text = "Sản phẩm";
            // 
            // menuItemSP_DSSP
            // 
            this.menuItemSP_DSSP.Name = "menuItemSP_DSSP";
            this.menuItemSP_DSSP.Size = new System.Drawing.Size(184, 22);
            this.menuItemSP_DSSP.Text = "Danh sách sản phẩm";
            this.menuItemSP_DSSP.Click += new System.EventHandler(this.menuItemSP_DSSP_Click);
            // 
            // menuItemSP_LSP
            // 
            this.menuItemSP_LSP.Name = "menuItemSP_LSP";
            this.menuItemSP_LSP.Size = new System.Drawing.Size(184, 22);
            this.menuItemSP_LSP.Text = "Loại sản phẩm";
            this.menuItemSP_LSP.Click += new System.EventHandler(this.menuItemSP_LSP_Click);
            // 
            // menuItemSP_HSX
            // 
            this.menuItemSP_HSX.Name = "menuItemSP_HSX";
            this.menuItemSP_HSX.Size = new System.Drawing.Size(184, 22);
            this.menuItemSP_HSX.Text = "Hãng sản xuất";
            this.menuItemSP_HSX.Click += new System.EventHandler(this.hãngSảnXuấtToolStripMenuItem_Click);
            // 
            // menuItemSP_NCC
            // 
            this.menuItemSP_NCC.Name = "menuItemSP_NCC";
            this.menuItemSP_NCC.Size = new System.Drawing.Size(184, 22);
            this.menuItemSP_NCC.Text = "Nhà cung cấp";
            this.menuItemSP_NCC.Click += new System.EventHandler(this.menuItemSP_NCC_Click);
            // 
            // menuItemKhachHang
            // 
            this.menuItemKhachHang.Name = "menuItemKhachHang";
            this.menuItemKhachHang.Size = new System.Drawing.Size(180, 22);
            this.menuItemKhachHang.Text = "Khách hàng";
            this.menuItemKhachHang.Click += new System.EventHandler(this.menuItemKhachHang_Click);
            // 
            // menuItemHoaDon
            // 
            this.menuItemHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHD_Nhap,
            this.menuItemHD_Ban});
            this.menuItemHoaDon.Name = "menuItemHoaDon";
            this.menuItemHoaDon.Size = new System.Drawing.Size(65, 20);
            this.menuItemHoaDon.Text = "Hóa đơn";
            // 
            // menuItemHD_Nhap
            // 
            this.menuItemHD_Nhap.Name = "menuItemHD_Nhap";
            this.menuItemHD_Nhap.Size = new System.Drawing.Size(180, 22);
            this.menuItemHD_Nhap.Text = "Hóa đơn nhập";
            this.menuItemHD_Nhap.Click += new System.EventHandler(this.menuItemHD_Nhap_Click);
            // 
            // menuItemHD_Ban
            // 
            this.menuItemHD_Ban.Name = "menuItemHD_Ban";
            this.menuItemHD_Ban.Size = new System.Drawing.Size(180, 22);
            this.menuItemHD_Ban.Text = "Hóa đơn bán";
            this.menuItemHD_Ban.Click += new System.EventHandler(this.menuItemHD_Ban_Click);
            // 
            // menuItemBaoCao
            // 
            this.menuItemBaoCao.Name = "menuItemBaoCao";
            this.menuItemBaoCao.Size = new System.Drawing.Size(61, 20);
            this.menuItemBaoCao.Text = "Báo cáo";
            this.menuItemBaoCao.Click += new System.EventHandler(this.menuItemBaoCao_Click);
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(0, 24);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(756, 322);
            this.pnlChildForm.TabIndex = 3;
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDangXuat});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // menuItemDangXuat
            // 
            this.menuItemDangXuat.Name = "menuItemDangXuat";
            this.menuItemDangXuat.Size = new System.Drawing.Size(180, 22);
            this.menuItemDangXuat.Text = "Đăng xuất";
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(756, 346);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
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
        private System.Windows.Forms.ToolStripMenuItem nhậpDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuItemSanPham;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_DSSP;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_LSP;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_HSX;
        private System.Windows.Forms.ToolStripMenuItem menuItemKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuItemHoaDon;
        private System.Windows.Forms.ToolStripMenuItem menuItemHD_Nhap;
        private System.Windows.Forms.ToolStripMenuItem menuItemHD_Ban;
        private System.Windows.Forms.ToolStripMenuItem menuItemBaoCao;
        private System.Windows.Forms.ToolStripMenuItem menuItemSP_NCC;
        private System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemDangXuat;
    }
}