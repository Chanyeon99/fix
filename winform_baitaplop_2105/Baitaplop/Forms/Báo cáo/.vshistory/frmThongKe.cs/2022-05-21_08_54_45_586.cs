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
            string choose = cbohdb.SelectedItem.ToString();
            if (!choose.Equals(""))
            {

            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xuất danh sách sản phẩm ra excel?", "Thông Báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DBAccess.XuatFileExcel(dgvThongKe, "ThongKeSoLuongSP.xlsx");
        }
    }
}
