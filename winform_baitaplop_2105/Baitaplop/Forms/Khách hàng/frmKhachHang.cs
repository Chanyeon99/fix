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
    public partial class frmKhachHang : Form
    {
        public bool isHasPermissionEdit;
        bool themmoi;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from KhachHang", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgkhachhang.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        private void Khách_hàng_Load(object sender, EventArgs e)
        {
            refresh();
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

        private void dtgkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            close();
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgkhachhang.CurrentRow.Index;
                        string makh = dtgkhachhang.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdkhachhang";
                        cmd.Parameters.AddWithValue("@smkh", makh);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmakh.Text = rd[0].ToString();
                            txttenkh.Text = rd[1].ToString();
                            txtdiachi.Text = rd[2].ToString();
                            txtsdt.Text = rd[3].ToString();
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
            txttenkh.Enabled = true;
            txtdiachi.Enabled = true;
            txtsdt.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            txtmakh.Enabled = false;
            txttenkh.Enabled = false;
            txtdiachi.Enabled = false;
            txtsdt.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtmakh.Enabled = true;
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
                    string sql = "delete from KhachHang where smakh = '" + txtmakh.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    clean();
                    refresh();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Không có dữ liệu!");
                }
            }
            else
                return;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "" || txttenkh.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmakh.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (txttenkh.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (txtdiachi.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                if (txtsdt.Text == "")
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
                            cmd.CommandText = "pcdthemkh";
                            try
                            {
                                cmd.Parameters.AddWithValue("@smkh", txtmakh.Text);
                                cmd.Parameters.AddWithValue("@stenkh", txttenkh.Text);
                                cmd.Parameters.AddWithValue("@sdc", txtdiachi.Text);
                                cmd.Parameters.AddWithValue("@ssdt", txtsdt.Text);

                                cmd.ExecuteNonQuery();
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                close();
                                clean();
                                refresh();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Xuất hiện lỗi khi truy xuất thêm/sửa dữ liệu\n Vui lòng liên hệ IT để báo lỗi!", "Thông báo");
                                throw new Exception(ex.Message);
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
                        if (txtmakh.Text != "")
                        {
                            string sql = "update KhachHang set shotenkh=N'" + txttenkh.Text + "',sdiachikh=N'" + txtdiachi.Text + "',ssdtkh='" + txtsdt.Text + "' where smakh = '" + txtmakh.Text + "'";
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Nhập sai dữ liệu!");
                    }
                }
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
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
                if (rdbmkh.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from KhachHang where smakh like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgkhachhang.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtkh.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from KhachHang where shotenkh like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgkhachhang.DataSource = dt;
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

        private void txttk_Click(object sender, EventArgs e)
        {
          
        }
    }
}
