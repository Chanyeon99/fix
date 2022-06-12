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
    public partial class HDBcrt : Form
    {
        public HDBcrt()
        {
            InitializeComponent();
        }

        private void HDBcrt_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            SqlConnection cnn = new SqlConnection(constr);
            string sql = @"SELECT        ChiTietHDB.isoluong, ChiTietHDB.fgiamgia, ChiTietHDB.fdongian, ChiTietHDB.fthanhtien, HoaDonBan.smahdb, HoaDonBan.dngayban, NhanVien.shotennv, 
                         SanPham.stensp, KhachHang.shotenkh, HoaDonBan.ftongtien
                         FROM            ChiTietHDB INNER JOIN
                         HoaDonBan ON ChiTietHDB.smahdb = HoaDonBan.smahdb AND ChiTietHDB.smahdb = HoaDonBan.smahdb INNER JOIN
                         NhanVien ON HoaDonBan.smanv = NhanVien.smanv AND HoaDonBan.smanv = NhanVien.smanv INNER JOIN
                         KhachHang ON HoaDonBan.smakh = KhachHang.smakh AND HoaDonBan.smakh = KhachHang.smakh INNER JOIN
                         SanPham ON ChiTietHDB.smasp = SanPham.smasp and HoaDonBan.smahdb = '" + frmBaoCao.shdb + "'";
            cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "hoadon");
                DataTable dt = ds.Tables["hoadon"];
                crthoadonban hdb = new crthoadonban();
                hdb.SetDataSource(dt);
                crthdb.ReportSource = hdb;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống!"+ ex.Message);
            }
            cnn.Close();
            //crthoadonban hdb = new crthoadonban();
            //crthdb.ReportSource = hdb;
        }
    }
}
