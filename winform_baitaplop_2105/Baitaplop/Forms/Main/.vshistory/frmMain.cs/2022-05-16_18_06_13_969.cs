using Baitaplop.Model;
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
        private bool turnOnEditButton = false;

        public frmMain()
        {
            InitializeComponent();
            CheckUserLoginIsAdminOrNot();
        }

        //Khai báo Form hiện đang mở bằng rỗng
        private Form activeForm = null;
        //Hàm mở form trong panel thay vì mở 1 cửa sổ mới, thao tác ngay trong main form
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

        private void CheckUserLoginIsAdminOrNot()
        {
            this.turnOnEditButton = isAdmin ? true : false;
        }

        public bool getEditPermission()
        {
            return this.turnOnEditButton;
        }

        private void menuItemNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frm = new frmQLNhanVien();
            frm.isHasPermissionEdit = getEditPermission() ? true : false;
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
            frmBaoCao frm = new frmBaoCao();
            openChildForm(frm);
        }

        private void menuItemDangNhap_Click(object sender, EventArgs e)
        {
            frmlogin frm = new frmlogin();
            openChildForm(frm);
        }

        private void menuItemThoat_Click(object sender, EventArgs e)
        {
            frmlogin frm = new frmlogin();
            frm.Show();
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show("isAdmin: " + this.isAdmin.ToString());
        }
    }
}
