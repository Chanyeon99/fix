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
    public partial class frmQLSP_LSP : Form
    {
        bool themmoi;
        public frmQLSP_LSP()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from LoaiSanPham", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgloaisp.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        public void open()
        {
            txttenloai.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            txtmaloai.Enabled = false;
            txttenloai.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtmaloai.Text = "";
            txttenloai.Text = "";
        }
        private void Loại_sản_phẩm_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            open();
            txtmaloai.Enabled = true;
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
                    string sql = "delete from LoaiSanPham where smalsp = '" + txtmaloai.Text + "'";
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
            if (txtmaloai.Text == "" || txttenloai.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmaloai.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (txttenloai.Text == "")
                {
                    label3.ForeColor = Color.Red;
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
                            cmd.CommandText = "pcdthemloaisp";
                            try
                            {
                                cmd.Parameters.AddWithValue("@smal", txtmaloai.Text);
                                cmd.Parameters.AddWithValue("@stenl", txttenloai.Text);
                                cmd.ExecuteNonQuery();
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                clean();
                                txtmaloai.Enabled = false;
                                close();
                                refresh();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mã nhân viên đã tồn tại!");
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
                        if (txtmaloai.Text != "")
                        {
                            string sql = "update loaiSanPham set smalsp=N'" + txtmaloai.Text + "',stenloai=N'" + txttenloai.Text + "' where smalsp = '" + txtmaloai.Text + "'";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            clean();
                            txtmaloai.Enabled = false;
                            close();
                            refresh();
                        }
                        MessageBox.Show("Sửa dữ liệu thành công!");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập sai dữ liệu!");
                    }
                }
            }
        }

        private void dtgloaisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgloaisp.CurrentRow.Index;
                        string mal = dtgloaisp.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdloaisp";
                        cmd.Parameters.AddWithValue("@smal", mal);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmaloai.Text = rd[0].ToString();
                            txttenloai.Text = rd[1].ToString();
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

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (rdbml.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT smalsp,stenloai from LoaiSanPham where smalsp like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("Loaisanpham");
                        da.Fill(dt);
                        da.Dispose();
                        dtgloaisp.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtl.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT smalsp,stenloai from LoaiSanPham where stenloai like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("Loaisanpham");
                        da.Fill(dt);
                        da.Dispose();
                        dtgloaisp.DataSource = dt;
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
