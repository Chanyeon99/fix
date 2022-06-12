using Baitaplop.Model;
using Baitaplop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplop.Forms
{
    public partial class frmMain : Form
    {
        public UserInfo user;
        public bool isAdmin;

        public frmMain()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuItemNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frm = new frmQLNhanVien();
            openChildForm(frm);
        }

        private void menuItemSP_DSSP_Click(object sender, EventArgs e)
        {
            frmQLSP frm = new frmQLSP();
            openChildForm(frm);
        }

        private void menuItemSP_LSP_Click(object sender, EventArgs e)
        {
            frmQLSP_LSP frm = new frmQLSP_LSP();
            openChildForm(frm);
        }

        private void menuItemSP_HSX_Click(object sender, EventArgs e)
        {
            frmQLSP_HSX frm = new frmQLSP_HSX();
            openChildForm(frm);
        }

        private void menuItemSP_NCC_Click(object sender, EventArgs e)
        {
            frmQLSP_NCC frm = new frmQLSP_NCC();
            openChildForm(frm);
        }       

        private void menuItemKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            openChildForm(frm);
        }

        private void menuItemHD_Nhap_Click(object sender, EventArgs e)
        {
            frmHoaDonNhap frm = new frmHoaDonNhap();
            openChildForm(frm);
        }

        private void menuItemHD_Ban_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            openChildForm(frm);
        }

        private void menuItemBaoCao_Click(object sender, EventArgs e)
        {
            Báo_cáo frm = new Báo_cáo();
            openChildForm(frm);
        }

        private void menuItemDangNhap_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frm = new frmQLNhanVien();
            openChildForm(frm);
        }

        private void menuItemThoat_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frm = new frmQLNhanVien();
            openChildForm(frm);
        }

        
    }
}
