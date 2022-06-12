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
    public partial class frmHoaDonNhap : Form
    {
        public bool isHasPermissionEdit;
        bool themmoi;
        public static string shdn = null;
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }
        public void showcombobox()
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
        public void showcombobox1()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select smancc,stenncc from Nhacungcap", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cboncc.DataSource = tb;
                    cboncc.DisplayMember = "stenncc";
                    cboncc.ValueMember = "smancc";
                }
            }
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select HoaDonNhap.smahdn, NhanVien.shotennv, HoaDonNhap.dngaynhap, Nhacungcap.stenncc, HoaDonNhap.ftongtien from HoaDonNhap,NhanVien,Nhacungcap where HoaDonNhap.smanv=NhanVien.smanv and HoaDonNhap.smancc=Nhacungcap.smancc", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtghoadonnhap.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        private void Hóa_đơn_nhập_Load(object sender, EventArgs e)
        {
            showcombobox();
            showcombobox1();
            refresh();
            cbonv.SelectedValue = "";
            cboncc.SelectedValue = "";
            if (isHasPermissionEdit == true)
            {
                enableEditButton(true);
                lblPermissionText.Text = "Thêm / Sửa / Xóa";
            }
            else
            {
                enableEditButton(false);
                lblPermissionText.Text = "Thêm";
            }
        }

        private void enableEditButton(bool b)
        {
            btnsua.Enabled = b;
            btnxoa.Enabled = b;
        }

        public void open()
        {
            cbonv.Enabled = true;
            dtpnn.Enabled = true;
            cboncc.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            txtmhd.Enabled = false;
            cbonv.Enabled = false;
            dtpnn.Enabled = false;
            cboncc.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtmhd.Text = "";
            cboncc.SelectedValue = "";
            cbonv.SelectedValue = "";
            txttt.Text = "0";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            open();
            txtmhd.Enabled = true;
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
                    string sql = "delete from HoaDonNhap where smahdn = '" + txtmhd.Text + "'";
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
                    Console.WriteLine(ex.Message);
                }
            }
            else
                return;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txtmhd.Text == "" || dtpnn.Text == "" || cboncc.Text == "" || cbonv.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmhd.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (cbonv.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (dtpnn.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                if (cboncc.Text == "")
                {
                    label6.ForeColor = Color.Red;
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
                            cmd.CommandText = "pcdthemhdn";
                            try
                            {
                                DateTime ngayhientai = Convert.ToDateTime(dtpnn.Text);
                                if (ngayhientai > DateTime.Now)
                                {
                                    MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại!");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@hdn", txtmhd.Text);
                                    cmd.Parameters.AddWithValue("@mnv", cbonv.SelectedValue);
                                    cmd.Parameters.AddWithValue("@nn", ngayhientai);
                                    cmd.Parameters.AddWithValue("@ncc", cboncc.SelectedValue);
                                    cmd.Parameters.AddWithValue("@tt", float.Parse(txttt.Text));

                                    cmd.ExecuteNonQuery();
                                    label2.ForeColor = Color.Black;
                                    label3.ForeColor = Color.Black;
                                    label4.ForeColor = Color.Black;
                                    label6.ForeColor = Color.Black;

                                    frmCTHDNhap cthdn = new frmCTHDNhap();
                                    shdn = txtmhd.Text.ToString();
                                    cthdn.MdiParent = this.MdiParent;
                                    this.Close();
                                    cthdn.Show();

                                    clean();
                                    close();
                                    refresh();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mã hóa đơn đã tồn tại!");
                                Console.WriteLine(ex.Message);
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
                        DateTime ngayhientai = Convert.ToDateTime(dtpnn.Text);
                        if (ngayhientai > DateTime.Now)
                        {
                            MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại!");
                        }
                        else
                        {
                            if (txtmhd.Text != "")
                            {
                                string sql = "update HoaDonNhap set dngaynhap =N'" + dtpnn.Text + "', smanv='" + cbonv.SelectedValue + "',smancc='" + cboncc.SelectedValue + "' where smahdn ='" + txtmhd.Text + "'";
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
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void dtghoadonnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtghoadonnhap.CurrentRow.Index;
                        string mahd = dtghoadonnhap.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdhdn";
                        cmd.Parameters.AddWithValue("@hdn", mahd);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmhd.Text = rd[0].ToString();
                            cbonv.Text = rd[1].ToString();
                            dtpnn.Text = rd[2].ToString();
                            cboncc.Text = rd[3].ToString();
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

        private void dtghoadonnhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCTHDNhap cthdn = new frmCTHDNhap();
            shdn = txtmhd.Text.ToString();
            cthdn.MdiParent = this.MdiParent;
            this.Close();
            cthdn.Show();
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (rdbmhd.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HoaDonNhap.smahdn, NhanVien.shotennv, HoaDonNhap.dngaynhap, Nhacungcap.stenncc, HoaDonNhap.ftongtien from HoaDonNhap,NhanVien,Nhacungcap where HoaDonNhap.smanv=NhanVien.smanv and HoaDonNhap.smancc=Nhacungcap.smancc and HoaDonNhap.smahdn like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtghoadonnhap.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtnvn.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT HoaDonNhap.smahdn, NhanVien.shotennv, HoaDonNhap.dngaynhap, Nhacungcap.stenncc, HoaDonNhap.ftongtien from HoaDonNhap,NhanVien,Nhacungcap where HoaDonNhap.smanv=NhanVien.smanv and HoaDonNhap.smancc=Nhacungcap.smancc and NhanVien.shotennv like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtghoadonnhap.DataSource = dt;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
