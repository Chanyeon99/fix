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

namespace Baitaplop.Báo_cáo
{
    public partial class HDNcrt : Form
    {
        public HDNcrt()
        {
            InitializeComponent();
        }

        private void HDNcrt_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            SqlConnection cnn = new SqlConnection(constr);
            string sql = @"SELECT        HoaDonNhap.smahdn, HoaDonNhap.dngaynhap, NhanVien.shotennv, Nhacungcap.stenncc, SanPham.stensp, ChiTietHDN.isoluong, ChiTietHDN.fdongian, 
                         Hangsx.shangsx, ChiTietHDN.fthanhtien, HoaDonNhap.ftongtien
                        FROM            ChiTietHDN INNER JOIN
                         HoaDonNhap ON ChiTietHDN.smahdn = HoaDonNhap.smahdn AND ChiTietHDN.smahdn = HoaDonNhap.smahdn INNER JOIN
                         NhanVien ON HoaDonNhap.smanv = NhanVien.smanv INNER JOIN
                         SanPham ON ChiTietHDN.smasp = SanPham.smasp INNER JOIN
                         Nhacungcap ON HoaDonNhap.smancc = Nhacungcap.smancc INNER JOIN
                         Hangsx ON SanPham.smahangsx = Hangsx.smahangsx and HoaDonNhap.smahdn='"+Báo_cáo.shdn+"'";
            cnn.Open();
            try
            {
                SqlDataAdapter dn = new SqlDataAdapter(sql, cnn);
                DataSet dds = new DataSet();
                dn.Fill(dds, "hoadon");
                DataTable dtt = dds.Tables["hoadon"];
                crthoadonnhap hdn = new crthoadonnhap();
                hdn.SetDataSource(dtt);
                crthdn.ReportSource = hdn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống!");
            }
            cnn.Close();
        }
    }
}
