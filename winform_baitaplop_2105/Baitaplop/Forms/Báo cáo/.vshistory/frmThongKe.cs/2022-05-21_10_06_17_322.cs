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
                string sql = "SELECT SMASP, STENSP, isoluong, fgianhap, (isoluong * fgianhap) AS DOANHTHU \nFROM SanPham";

                DBAccess.GanNguonDataGridView(dgvThongKe, sql);
                dgvThongKe.Columns[0].HeaderText = "Mã SP";
                dgvThongKe.Columns[1].HeaderText = "Tên SP";
                dgvThongKe.Columns[2].HeaderText = "Số lượng";
                dgvThongKe.Columns[2].ValueType = typeof(int);
                dgvThongKe.Columns[3].HeaderText = "Giá nhập";
                dgvThongKe.Columns[3].ValueType = typeof(int);
                dgvThongKe.Columns[4].HeaderText = "Doanh thu dự kiến";
                dgvThongKe.Columns[4].ValueType = typeof(long);
                int row = dgvThongKe.RowCount;
                if (row > 0)
                {
                    lblDem.Text = dgvThongKe.RowCount + " sản phẩm.";
                    int rowAdd = dgvThongKe.Rows.Add();
                    dgvThongKe.Rows[rowAdd].Cells[3].Value = "Tổng doanh thu dự kiến:";
                    dgvThongKe.Rows[rowAdd].Cells[4].Value = dgvThongKe.Rows.Cast<DataGridViewRow>()
                                                                            .Sum(t => Convert.ToInt32(t.Cells[4].Value));
                }    
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
        }
    }
}
