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

namespace Baitaplop.Hóa_đơn
{
    public partial class Chi_tiết_hóa_đơn_bán : Form
    {
        bool themmoi;
        bool ktsp;
        public Chi_tiết_hóa_đơn_bán()
        {
            InitializeComponent();
        }
        public void showcombobox1()
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
                using (SqlCommand cmd = new SqlCommand("select ChiTietHDB.smahdb,SanPham.stensp,ChiTietHDB.isoluong,ChiTietHDB.fgiamgia,SanPham.fgiaban,ChiTietHDB.fthanhtien from ChiTietHDB, SanPham where ChiTietHDB.smasp = SanPham.smasp and ChiTietHDB.smahdb='"+Hóa_đơn_bán.shdb+"'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgcthdb.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }

        public bool kiemtratensp()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                ktsp = false;
                SqlDataAdapter da = new SqlDataAdapter("select * from ChiTietHDB where smasp='" + cbotensp.SelectedValue + "' and smahdb='" + Hóa_đơn_bán.shdb + "'", cnn);
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
        private void Chi_tiết_hóa_đơn_bán_Load(object sender, EventArgs e)
        {
            showcombobox1();
            refresh();
            //showcombobox();
            //cbomhd.SelectedValue = "";
            cbotensp.SelectedValue = "";
            txtmhd.Text = Hóa_đơn_bán.shdb;
        }

        private void dtgcthdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgcthdb.CurrentRow.Index;
                        string mahd = dtgcthdb.Rows[cri].Cells[0].Value.ToString();
                        string tsp = dtgcthdb.Rows[cri].Cells[1].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdcthdb";
                        cmd.Parameters.AddWithValue("@mhdb", mahd);
                        cmd.Parameters.AddWithValue("@tsp", tsp);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmhd.Text = rd[0].ToString();
                            cbotensp.Text = rd[1].ToString();
                            txtsl.Text = rd[2].ToString();
                            txtgg.Text = rd[3].ToString();
                            txtdg.Text = rd[4].ToString();
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
            txtsl.Enabled = true;
            //txtdg.Enabled = true;
            txtgg.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            cbotensp.Enabled = false;
            txtsl.Enabled = false;
            txtdg.Enabled = false;
            txtgg.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            cbotensp.SelectedValue = "";
            txtsl.Text = "";
            txtdg.Text = "";
            txtgg.Text = "";
            txtthanhtien.Text = "";
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            cbotensp.Enabled = true;
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
                    string sql = "delete from ChitietHDB where smasp = '" + cbotensp.SelectedValue + "'and smahdb = '"+Hóa_đơn_bán.shdb+"'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    string tongtien = "update HoaDonBan set ftongtien = (select sum(fdongian*isoluong-fgiamgia) from ChiTietHDB where smahdb='" + txtmhd.Text + "') where smahdb='" + Hóa_đơn_bán.shdb + "'";
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
                }
            }
            else
                return;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (cbotensp.Text == "" || txtsl.Text == "" || txtdg.Text == ""|| txtgg.Text == "")
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
                if (txtdg.Text == "")
                {
                    label5.ForeColor = Color.Red;
                }
                if (txtgg.Text == "")
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
                        MessageBox.Show("Tên Sản phẩm đã tồn tại trong hóa đơn có mã: "+Hóa_đơn_bán.shdb+"!");
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
                                cmd.CommandText = "pcdthemcthdb";
                                try
                                {
                                    float tt = Convert.ToInt32(txtsl.Text) * float.Parse(txtdg.Text) - float.Parse(txtgg.Text);
                                    txtthanhtien.Text = tt.ToString();
                                    cmd.Parameters.AddWithValue("@smhd", Hóa_đơn_bán.shdb);
                                    cmd.Parameters.AddWithValue("@smsp", cbotensp.SelectedValue);
                                    cmd.Parameters.AddWithValue("@isl", Convert.ToInt32(txtsl.Text));
                                    cmd.Parameters.AddWithValue("@fgg", Math.Round(float.Parse(txtgg.Text), 2));
                                    cmd.Parameters.AddWithValue("@fdg", Math.Round(float.Parse(txtdg.Text), 2));
                                    cmd.Parameters.AddWithValue("@ftt", Math.Round(float.Parse(txtthanhtien.Text), 2));

                                    cmd.ExecuteNonQuery();

                                    string soluong = "update SanPham set isoluong = isoluong - '" + txtsl.Text + "' where smasp='" + cbotensp.SelectedValue + "'";
                                    SqlCommand sl = new SqlCommand(soluong, cnn);
                                    sl.CommandText = soluong;
                                    sl.ExecuteNonQuery();

                                    label2.ForeColor = Color.Black;
                                    label3.ForeColor = Color.Black;
                                    label4.ForeColor = Color.Black;
                                    label5.ForeColor = Color.Black;
                                    label6.ForeColor = Color.Black;
                                    btnhdb.Enabled = true;

                                    clean();
                                    close();
                                    refresh();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lối định dạng dữ liệu!");
                                }
                            }
                            string tongtien = "update HoaDonBan set ftongtien = (select sum(fdongian*isoluong-fgiamgia) from ChiTietHDB where smahdb='"+txtmhd.Text+"') where smahdb='" + Hóa_đơn_bán.shdb + "'";
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
                            string soluong = "update SanPham set isoluong = isoluong + (select isoluong from ChiTietHDB where smahdb ='" + txtmhd.Text + "' and smasp='" + cbotensp.SelectedValue + "') - '" + txtsl.Text + "' where smasp='" + cbotensp.SelectedValue + "'";
                            SqlCommand sl = new SqlCommand(soluong, conn);
                            sl.CommandText = soluong;
                            sl.ExecuteNonQuery();

                            string sql = "update ChiTietHDB set isoluong='" + txtsl.Text + "',fgiamgia='" + txtgg.Text + "',fdongian='" + txtdg.Text + "' where smahdb ='" + Hóa_đơn_bán.shdb + "' and smasp =N'" + cbotensp.SelectedValue + "'";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                            string thanhtien = "update ChiTietHDB set fthanhtien = fdongian*isoluong-fgiamgia where smahdb='" + txtmhd.Text + "'and smasp='"+cbotensp.SelectedValue+"'";
                            SqlCommand ctt = new SqlCommand(thanhtien, conn);
                            ctt.CommandText = thanhtien;
                            ctt.ExecuteNonQuery();

                            string tongtien = "update HoaDonBan set ftongtien = (select sum(fdongian*isoluong-fgiamgia) from ChiTietHDB where smahdb='" + txtmhd.Text + "') where smahdb='" + Hóa_đơn_bán.shdb + "'";
                            SqlCommand cnd = new SqlCommand(tongtien, conn);
                            cnd.CommandText = tongtien;
                            cnd.ExecuteNonQuery();

                            btnhdb.Enabled = true;
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

        private void cbotensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select fgiaban from SanPham where smasp='"+cbotensp.SelectedValue+"'", cnn))
                {
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        double value = rd.GetDouble(rd.GetOrdinal("fgiaban"));
                        txtdg.Text = value.ToString();
                    }
                }
            }
        }

        private void btnhdb_Click(object sender, EventArgs e)
        {
            Form hdb = new Hóa_đơn_bán();
            hdb.MdiParent = this.MdiParent;
            this.Close();
            hdb.Show();
        }

        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            /*string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select fthanhtien,fdongian,fgiamgia,isoluong from ChiTietHDB where smahdb='" + Hóa_đơn_bán.shdb + "'", cnn))
                {
                    cnn.Open();

                    

                    cnn.Close();
                }
            }*/
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgg_KeyPress(object sender, KeyPressEventArgs e)
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
                using (SqlCommand cmd = new SqlCommand("SELECT ChiTietHDB.smahdb,SanPham.stensp,ChiTietHDB.isoluong,ChiTietHDB.fgiamgia,SanPham.fgiaban,ChiTietHDB.fthanhtien from ChiTietHDB, SanPham where ChiTietHDB.smasp = SanPham.smasp and ChiTietHDB.smahdb='" + Hóa_đơn_bán.shdb + "' and SanPham.stensp like N'%" + txttk.Text.ToString() + "%'", cnn))
                {
                    cnn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("ncc");
                    da.Fill(dt);
                    da.Dispose();
                    dtgcthdb.DataSource = dt;
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
