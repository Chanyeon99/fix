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
    public partial class frmHoaDonBan : Form
    {
        bool themmoi;
        public static string shdb = null;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select HoaDonBan.smahdb,HoaDonBan.dngayban,KhachHang.shotenkh,NhanVien.shotennv,HoaDonBan.ftongtien from HoaDonBan, KhachHang, NhanVien where HoaDonBan.smakh = KhachHang.smakh and HoaDonBan.smanv = NhanVien.smanv", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtghdb.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        public void showcomboobox()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select smakh,shotenkh from KhachHang", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbokh.DataSource = tb;
                    cbokh.DisplayMember = "shotenkh";
                    cbokh.ValueMember = "smakh";
                }
            }
        }
        public void showcombobox1()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select smanv,shotennv from NhanVien", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbonv.DataSource = tb;
                    cbonv.DisplayMember = "shotennv";
                    cbonv.ValueMember = "smanv";
                }
            }
        }
        private void Hóa_đơn_bán_Load(object sender, EventArgs e)
        {
            refresh();
            showcomboobox();
            showcombobox1();
            cbokh.SelectedValue = "";
            cbonv.SelectedValue = "";
            clean();
        }
        public void open()
        {
            dtpngayban.Enabled = true;
            cbokh.Enabled = true;
            cbonv.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            dtpngayban.Enabled = false;
            cbokh.Enabled = false;
            cbonv.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtmahd.Text = "";
            dtpngayban.Text = "";
            cbokh.SelectedValue = "";
            cbonv.SelectedValue = "";
            txttt.Text = "0";
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtmahd.Enabled = true;
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
                    string sql = "delete from HoaDonBan where smahdb = '" + txtmahd.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
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
            if (txtmahd.Text == "" || dtpngayban.Text == "" || cbokh.Text == "" || cbonv.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmahd.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (dtpngayban.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (cbokh.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                if (cbonv.Text == "")
                {
                    label5.ForeColor = Color.Red;
                }
            }
            else
            {
                if (themmoi == true)
                {
                    string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cnn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "pcdthemhdb";
                            try
                            {
                                DateTime ngayhientai = DateTime.Parse(Convert.ToDateTime(dtpngayban.Text).ToShortDateString());
                                if (ngayhientai > DateTime.Now)
                                {
                                    MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại!");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@mhdb", txtmahd.Text);
                                    cmd.Parameters.AddWithValue("@dnb", ngayhientai);
                                    cmd.Parameters.AddWithValue("@smkh", cbokh.SelectedValue);
                                    cmd.Parameters.AddWithValue("@smnv", cbonv.SelectedValue);
                                    cmd.Parameters.AddWithValue("@tt", float.Parse(txttt.Text));

                                    cmd.ExecuteNonQuery();
                                    label2.ForeColor = Color.Black;
                                    label3.ForeColor = Color.Black;
                                    label4.ForeColor = Color.Black;
                                    label5.ForeColor = Color.Black;

                                    Form cthdb = new Hóa_đơn.Chi_tiết_hóa_đơn_bán();
                                    shdb = txtmahd.Text.ToString();
                                    cthdb.MdiParent = this.MdiParent;
                                    this.Close();
                                    cthdb.Show();

                                    clean();
                                    close();
                                    refresh();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mã hóa đơn đã tồn tại!");
                            }
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
                        DateTime ngayhientai = DateTime.Parse(Convert.ToDateTime(dtpngayban.Text).ToShortDateString());
                        if (ngayhientai > DateTime.Now)
                        {
                            MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại!");
                        }
                        else
                        {
                            if (txtmahd.Text != "")
                            {
                                string sql = "update HoaDonBan set dngayban =N'" + dtpngayban.Text + "', smakh='" + cbokh.SelectedValue + "',smanv='" + cbonv.SelectedValue + "' where smahdb ='" + txtmahd.Text + "'";
                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                clean();
                                close();
                                refresh();
                            }
                            MessageBox.Show("Sửa dữ liệu thành công!");
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập sai dữ liệu!");
                    }
                }
            }
        }

        private void dtghdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtghdb.CurrentRow.Index;
                        string mahd = dtghdb.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdhdb";
                        cmd.Parameters.AddWithValue("@hdb", mahd);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmahd.Text = rd[0].ToString();
                            dtpngayban.Text = rd[1].ToString();
                            cbokh.Text = rd[2].ToString();
                            cbonv.Text = rd[3].ToString();
                            txttt.Text = rd[4].ToString();
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

        private void dtghdb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form cthdb = new Hóa_đơn.Chi_tiết_hóa_đơn_bán();
            shdb = txtmahd.Text.ToString();
            cthdb.MdiParent = this.MdiParent;
            this.Close();
            cthdb.Show();
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (rdbmhd.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HoaDonBan.smahdb,HoaDonBan.dngayban,KhachHang.shotenkh,NhanVien.shotennv,HoaDonBan.ftongtien from HoaDonBan, KhachHang, NhanVien where HoaDonBan.smakh = KhachHang.smakh and HoaDonBan.smanv = NhanVien.smanv and HoaDonBan.smahdb like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtghdb.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtnvb.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HoaDonBan.smahdb,HoaDonBan.dngayban,KhachHang.shotenkh,NhanVien.shotennv,HoaDonBan.ftongtien from HoaDonBan, KhachHang, NhanVien where HoaDonBan.smakh = KhachHang.smakh and HoaDonBan.smanv = NhanVien.smanv and NhanVien.shotennv like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtghdb.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbkh.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HoaDonBan.smahdb,HoaDonBan.dngayban,KhachHang.shotenkh,NhanVien.shotennv,HoaDonBan.ftongtien from HoaDonBan, KhachHang, NhanVien where HoaDonBan.smakh = KhachHang.smakh and HoaDonBan.smanv = NhanVien.smanv and KhachHang.shotenkh like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtghdb.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
            }
        }

        private void txttk_DoubleClick(object sender, EventArgs e)
        {
            txttk.Text = "";
        }
    }
}
