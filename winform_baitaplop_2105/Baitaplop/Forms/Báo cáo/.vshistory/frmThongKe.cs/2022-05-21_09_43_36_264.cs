using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplop.Forms
{
    public partial class frmThongKe : Form
    {
        public bool isHasPermissionEdit;
        public frmThongKe()
        {
            InitializeComponent();
        }
        
        private void Báo_cáo_Load(object sender, EventArgs e)
        {
            cbohdb.SelectedValue = "";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string choose = cbohdb.Text.ToString();
            if (!choose.Equals(""))
            {
                dgvThongKe.DataSource = null;
                string sql = "SELECT SMASP as N'Mã SP', STENSP as N'Tên SP', isoluong as N'Số lượng', fgianhap as N'Giá nhập', (isoluong * fgianhap) AS N'Doanh thu' \nFROM SanPham";

                DBAccess.GanNguonDataGridView(dgvThongKe, sql);
                if (dgvThongKe.RowCount > 0)
                    lblDem.Text = dgvThongKe.RowCount + " sản phẩm.";
                else
                    lblDem.Text = "0";
            }
            else
            {
                MessageBox.Show("Chưa chọn loại thống kê", "Thông báo");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xuất danh sách sản phẩm ra excel?", "Thông Báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DBAccess.XuatFileExcel(dgvThongKe, "ThongKeSoLuongSP.xlsx");
        }

        private void pnlTopMenu_Paint(object sender, PaintEventArgs e)
        {
            dgvThongKe.AutoGenerateColumns = false;
        }
    }
}
