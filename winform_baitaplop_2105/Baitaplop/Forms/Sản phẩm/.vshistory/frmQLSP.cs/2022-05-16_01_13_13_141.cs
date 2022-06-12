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

namespace Baitaplop.Sản_phẩm
{
    public partial class frmQLSP : Form
    {
        bool themmoi;
        public frmQLSP()
        {
            InitializeComponent();
        }
        public void showcombobox()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Hangsx", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbohangsx.DataSource = tb;
                    cbohangsx.DisplayMember = "shangsx";
                    cbohangsx.ValueMember = "smahangsx";
                }
            }
        }
        public void showcombobox1()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from LoaiSanPham", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbotenloai.DataSource = tb;
                    cbotenloai.DisplayMember = "stenloai";
                    cbotenloai.ValueMember = "smalsp";
                }
            }
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select SanPham.smasp,SanPham.stensp,SanPham.isoluong,SanPham.fgianhap,SanPham.fgiaban,LoaiSanPham.stenloai,Hangsx.shangsx from SanPham,LoaiSanPham,Hangsx where SanPham.smalsp=LoaiSanPham.smalsp and SanPham.smahangsx=Hangsx.smahangsx", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgsanpham.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        private void Sản_phẩm_Load(object sender, EventArgs e)
        {
            showcombobox();
            showcombobox1();
            refresh();
            cbohangsx.SelectedValue = "";
            cbotenloai.SelectedValue = "";
            txtsl.Text = "0";
        }
        public void open()
        {
            txttensp.Enabled = true;
            //txtsl.Enabled = true;
            txtgianhap.Enabled = true;
            txtgiaban.Enabled = true;
            cbohangsx.Enabled = true;
            cbotenloai.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            txtmasp.Enabled = false;
            txttensp.Enabled = false;
            //txtsl.Enabled = false;
            txtgianhap.Enabled = false;
            txtgiaban.Enabled = false;
            cbohangsx.Enabled = false;
            cbotenloai.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            //txtsl.Text = "";
            txtgiaban.Text = "";
            txtgianhap.Text = "";
            cbohangsx.SelectedValue = "";
            cbotenloai.SelectedValue = "";
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (rdbmsp.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from SanPham where smasp like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgsanpham.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtsp.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from SanPham where stensp like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgsanpham.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
            }
        }

        private void txttk_DoubleClick(object sender, EventArgs e)
        {
            txtsl.Text = "";
        }

        private void dtgsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgsanpham.CurrentRow.Index;
                        string masp = dtgsanpham.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdsanpham";
                        cmd.Parameters.AddWithValue("@smsp", masp);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmasp.Text = rd[0].ToString();
                            txttensp.Text = rd[1].ToString();
                            txtsl.Text = rd[2].ToString();
                            txtgianhap.Text = rd[3].ToString();
                            txtgiaban.Text = rd[4].ToString();
                            cbotenloai.Text = rd[5].ToString();
                            cbohangsx.Text = rd[6].ToString();
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

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            themmoi = true;
            txtmasp.Enabled = true;
            open();
            clean();
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            themmoi = false;
            txtsl.Enabled = true;
            open();
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                try
                {
                    string cnn = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
                    SqlConnection conn = new SqlConnection(cnn);
                    conn.Open();
                    string sql = "delete from SanPham where smasp = '" + txtmasp.Text + "'";
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

        private void btnluu_Click_1(object sender, EventArgs e)
        {
            if (txtmasp.Text == "" || txttensp.Text == "" || txtsl.Text == "" || txtgianhap.Text == "" || txtgiaban.Text == "" || cbotenloai.Text == "" || cbohangsx.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmasp.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (txttensp.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (txtsl.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                if (txtgianhap.Text == "")
                {
                    label5.ForeColor = Color.Red;
                }
                if (txtgiaban.Text == "")
                {
                    label6.ForeColor = Color.Red;
                }
                if (cbotenloai.Text == "")
                {
                    label7.ForeColor = Color.Red;
                }
                if (cbohangsx.Text == "")
                {
                    label8.ForeColor = Color.Red;
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
                            cmd.CommandText = "pcdthemsp";
                            try
                            {
                                cmd.Parameters.AddWithValue("@smsp", txtmasp.Text);
                                cmd.Parameters.AddWithValue("@stsp", txttensp.Text);
                                cmd.Parameters.AddWithValue("@isl", Convert.ToInt32(txtsl.Text));
                                cmd.Parameters.AddWithValue("@fgn", Math.Round(float.Parse(txtgianhap.Text), 2));
                                cmd.Parameters.AddWithValue("@fgb", Math.Round(float.Parse(txtgiaban.Text), 2));
                                cmd.Parameters.AddWithValue("@smlsp", cbotenloai.SelectedValue);
                                cmd.Parameters.AddWithValue("@smhsx", cbohangsx.SelectedValue);

                                cmd.ExecuteNonQuery();
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                label6.ForeColor = Color.Black;
                                label7.ForeColor = Color.Black;
                                label8.ForeColor = Color.Black;
                                clean();
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
                        if (txtmasp.Text != "")
                        {
                            string sql = "update SanPham set stensp=N'" + txttensp.Text + "', isoluong='" + txtsl.Text + "',fgianhap='" + txtgianhap.Text + "',fgiaban='" + txtgiaban.Text + "',smalsp='" + cbotenloai.SelectedValue + "',smahangsx='" + cbohangsx.SelectedValue + "' where smasp = '" + txtmasp.Text + "'";
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
                        MessageBox.Show("Nhập sai dữ liệu!");
                    }
                }
            }
        }

        private void txtsl_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgiaban_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
