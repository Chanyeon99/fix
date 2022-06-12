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
    public partial class frmCTHDNhap : Form
    {
        bool themmoi;
        bool ktsp;
        public frmCTHDNhap()
        {
            InitializeComponent();
        }
        public void showcombobox()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select smasp,stensp from SanPham", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbotensp.DataSource = tb;
                    cbotensp.DisplayMember = "stensp";
                    cbotensp.ValueMember = "smasp";
                }
            }
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select ChiTietHDN.smahdn,SanPham.stensp,ChiTietHDN.isoluong,ChiTietHDN.fdongian,Hangsx.shangsx,ChiTietHDN.fthanhtien from ChiTietHDN,SanPham,Hangsx where ChiTietHDN.smasp=SanPham.smasp and Sanpham.smahangsx=Hangsx.smahangsx and ChiTietHDN.smahdn='" + frmHoaDonNhap.shdn + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgchitiethdn.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        private void frmCTHDNhap_Load(object sender, EventArgs e)
        {
            showcombobox();
            refresh();
            cbotensp.SelectedValue="";
            txtmhd.Text = frmHoaDonNhap.shdn;
        }
        public bool kiemtratensp()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                ktsp = false;
                SqlDataAdapter da = new SqlDataAdapter("select * from ChiTietHDN where smasp='" + cbotensp.SelectedValue + "' and smahdn='" + frmHoaDonNhap.shdn + "'", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ktsp = true;
                }
                da.Dispose();
                return ktsp;
            }
        }

        private void dtgchitiethdn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgchitiethdn.CurrentRow.Index;
                        string mahd = dtgchitiethdn.Rows[cri].Cells[0].Value.ToString();
                        string tsp = dtgchitiethdn.Rows[cri].Cells[1].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdcthdn";
                        cmd.Parameters.AddWithValue("@hdn", mahd);
                        cmd.Parameters.AddWithValue("@tsp", tsp);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmhd.Text = rd[0].ToString();
                            cbotensp.Text = rd[1].ToString();
                            txtsl.Text = rd[2].ToString();
                            txtgianhap.Text = rd[3].ToString();
                            txthangsx.Text = rd[4].ToString();
                            txtthanhtien.Text = rd[5].ToString();
                        }
                        cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public void open()
        {
            cbotensp.Enabled = true;
            txtsl.Enabled = true;
            //txthangsx.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            cbotensp.Enabled = false;
            txtsl.Enabled = false;
            //txthangsx.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            cbotensp.SelectedValue = "";
            txtsl.Text = "";
            txtgianhap.Text = "";
            txthangsx.Text = "";
            txtthanhtien.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            open();
            clean();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            open();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                try
                {
                    string cnn = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
                    SqlConnection conn = new SqlConnection(cnn);
                    conn.Open();
                    string sql = "delete from ChitietHDN where smasp = '" + cbotensp.SelectedValue + "'and smahdn = '" + frmHoaDonNhap.shdn + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    string tongtien = "update HoaDonNhap set ftongtien = (select sum(fdongian*isoluong) from ChiTietHDN where smahdn='" + txtmhd.Text + "') where smahdn='" + frmHoaDonNhap.shdn + "'";
                    SqlCommand cnd = new SqlCommand(tongtien, conn);
                    cnd.CommandText = tongtien;
                    cnd.ExecuteNonQuery();

                    clean();
                    refresh();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không có dữ liệu!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
                return;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (cbotensp.Text == "" || txtsl.Text == ""||txthangsx.Text=="")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (cbotensp.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (txtsl.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                if (txthangsx.Text == "")
                {
                    label6.ForeColor = Color.Red;
                }
            }
            else
            {
                if (themmoi == true)
                {
                    if (kiemtratensp())
                    {
                        MessageBox.Show("Tên Sản phẩm đã tồn tại trong hóa đơn có mã: " + frmHoaDonNhap.shdn + "!");
                    }
                    else
                    {
                        string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
                        using (SqlConnection cnn = new SqlConnection(constr))
                        {
                            cnn.Open();
                            using (SqlCommand cmd = cnn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "pcdthemcthdn";
                                try
                                {
                                    float tt = Convert.ToInt32(txtsl.Text) * float.Parse(txtgianhap.Text);
                                    txtthanhtien.Text = tt.ToString();
                                    cmd.Parameters.AddWithValue("@mhdn", frmHoaDonNhap.shdn);
                                    cmd.Parameters.AddWithValue("@msp", cbotensp.SelectedValue);
                                    cmd.Parameters.AddWithValue("@sl", Convert.ToInt32(txtsl.Text));
                                    cmd.Parameters.AddWithValue("@dg", Math.Round(float.Parse(txtgianhap.Text), 2));
                                    cmd.Parameters.AddWithValue("@hsx", txthangsx.Text);
                                    cmd.Parameters.AddWithValue("@tt", Math.Round(float.Parse(txtthanhtien.Text), 2));

                                    cmd.ExecuteNonQuery();

                                    string soluong = "update SanPham set isoluong = isoluong +'" + txtsl.Text + "' where smasp='" + cbotensp.SelectedValue + "'";
                                    SqlCommand sl = new SqlCommand(soluong, cnn);
                                    sl.CommandText = soluong;
                                    sl.ExecuteNonQuery();

                                    label3.ForeColor = Color.Black;
                                    label4.ForeColor = Color.Black;
                                    label6.ForeColor = Color.Black;
                                    btnback.Enabled = true;

                                    clean();
                                    close();
                                    refresh();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    MessageBox.Show("Lối định dạng dữ liệu!");
                                }
                            }
                            string tongtien = "update HoaDonNhap set ftongtien = (select sum(fdongian*isoluong) from ChiTietHDN where smahdn='" + txtmhd.Text + "') where smahdn='" + frmHoaDonNhap.shdn + "'";
                            SqlCommand cnd = new SqlCommand(tongtien, cnn);
                            cnd.CommandText = tongtien;
                            cnd.ExecuteNonQuery();

                            cnn.Close();
                        }
                    }
                }
                else
                {
                    try
                    {
                        string cnn = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
                        SqlConnection conn = new SqlConnection(cnn);
                        conn.Open();
                        if (txtmhd.Text != "")
                        {
                            string soluong = "update SanPham set isoluong = isoluong - (select isoluong from ChiTietHDN where smahdn ='" + txtmhd.Text + "' and smasp='" + cbotensp.SelectedValue + "') + '" + txtsl.Text + "' where smasp='" + cbotensp.SelectedValue + "'";
                            SqlCommand sl = new SqlCommand(soluong, conn);
                            sl.CommandText = soluong;
                            sl.ExecuteNonQuery();

                            string sql = "update ChiTietHDN set isoluong='" + txtsl.Text + "', shangsx='"+txthangsx.Text+"' where smahdn ='" + frmHoaDonNhap.shdn + "' and smasp =N'" + cbotensp.SelectedValue + "'";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            string thanhtien = "update ChiTietHDN set fthanhtien = fdongian*isoluong where smahdn='" + txtmhd.Text + "'and smasp='" + cbotensp.SelectedValue + "'";
                            SqlCommand ctt = new SqlCommand(thanhtien, conn);
                            ctt.CommandText = thanhtien;
                            ctt.ExecuteNonQuery();

                            string tongtien = "update HoaDonNhap set ftongtien = (select sum(fdongian*isoluong) from ChiTietHDN where smahdn='" + txtmhd.Text + "') where smahdn='" + frmHoaDonNhap.shdn + "'";
                            SqlCommand cnd = new SqlCommand(tongtien, conn);
                            cnd.CommandText = tongtien;
                            cnd.ExecuteNonQuery();

                            btnback.Enabled = true;
                            clean();
                            close();
                            refresh();
                        }
                        conn.Close();
                        MessageBox.Show("Sửa dữ liệu thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập sai dữ liệu!");
                    }
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form hdn = new frmCTHDNhap();
            hdn.MdiParent = this.MdiParent;
            this.Close();
            hdn.Show();
        }

        private void cbotensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select SanPham.fgianhap,Hangsx.shangsx from SanPham,Hangsx where SanPham.smahangsx=Hangsx.smahangsx and smasp='" + cbotensp.SelectedValue + "'", cnn))
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        double value = rd.GetDouble(rd.GetOrdinal("fgianhap"));
                        txtgianhap.Text = value.ToString();

                        string hsx = (string)rd["shangsx"];
                        txthangsx.Text = hsx.ToString();
                    }
                    cnn.Close();
                }
            }
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ChiTietHDN.smahdn,SanPham.stensp,ChiTietHDN.isoluong,ChiTietHDN.fdongian,Hangsx.shangsx,ChiTietHDN.fthanhtien from ChiTietHDN,SanPham,Hangsx where ChiTietHDN.smasp=SanPham.smasp and Sanpham.smahangsx=Hangsx.smahangsx and ChiTietHDN.smahdn='" + frmHoaDonNhap.shdn + "' and SanPham.stensp like N'%" + txttk.Text.ToString() + "%'", cnn))
                {
                    cnn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("ncc");
                    da.Fill(dt);
                    da.Dispose();
                    dtgchitiethdn.DataSource = dt;
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        private void txttk_DoubleClick(object sender, EventArgs e)
        {
            txttk.Text = "";
        }
    }
}
