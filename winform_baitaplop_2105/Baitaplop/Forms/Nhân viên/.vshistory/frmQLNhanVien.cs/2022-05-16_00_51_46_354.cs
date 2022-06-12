using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplop.QLNV
{
    public partial class frmQlNhanVien : Form
    {
        public frmQlNhanVien()
        {
            InitializeComponent();
        }
        bool themmoi;
        private void Nhân_viên_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from NhanVien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgnhanvien.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }

        private void dtgnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgnhanvien.CurrentRow.Index;
                        string manv = dtgnhanvien.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdnv";
                        cmd.Parameters.AddWithValue("@smanv", manv);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmanv.Text = rd[0].ToString();
                            txthoten.Text = rd[1].ToString();
                            txtdiachi.Text = rd[2].ToString();
                            string gt = this.dtgnhanvien.Rows[e.RowIndex].Cells[3].Value.ToString();
                            {
                                if (gt.Trim() == "Nam")
                                {
                                    rdbnam.Checked = true;
                                }
                                else
                                {
                                    rdbnu.Checked = true;
                                }
                            }
                            txtsdt.Text = rd[4].ToString();
                            txtluong.Text = rd[5].ToString();
                            dtpns.Text = rd[6].ToString();
                        }
                        cnn.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public void open()
        {
            txthoten.Enabled = true;
            txtdiachi.Enabled = true;
            rdbnam.Enabled = true;
            rdbnu.Enabled = true;
            txtsdt.Enabled = true;
            dtpns.Enabled = true;
            txtluong.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;

        }
        public void close()
        {
            txthoten.Enabled = false;
            txtdiachi.Enabled = false;
            rdbnam.Enabled = false;
            rdbnu.Enabled = false;
            txtsdt.Enabled = false;
            dtpns.Enabled = false;
            txtluong.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtmanv.Text = "";
            txthoten.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            dtpns.Text = "";
            txtluong.Text = "";
            rdbnam.Checked = false;
            rdbnu.Checked = false;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            
            themmoi = true;
            open();
            clean();
            txtmanv.Enabled = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            open();
            txtmanv.Enabled = false;
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
                    string sql = "delete from NhanVien where smanv = '" + txtmanv.Text + "'";
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
            if (txtmanv.Text == "" || txthoten.Text == "" || rdbnam.Checked == false && rdbnu.Checked == false || txtdiachi.Text == "" || txtsdt.Text == ""||dtpns.Text==""||txtluong.Text=="")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmanv.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (txtdiachi.Text == "")
                {
                    label5.ForeColor = Color.Red;
                }
                if (txthoten.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (rdbnam.Checked == false && rdbnu.Checked == false)
                {
                    label4.ForeColor = Color.Red;
                }
                if (txtsdt.Text == "")
                {
                    label6.ForeColor = Color.Red;
                }
                if (dtpns.Text == "")
                {
                    label7.ForeColor = Color.Red;
                }
                if (txtluong.Text == "")
                {
                    label8.ForeColor = Color.Red;
                }
            }
            else
            {
                if(themmoi == true)
                {
                    string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cnn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "pcdthemnv";
                            try
                            {
                                cmd.Parameters.AddWithValue("@smnv", txtmanv.Text);
                                cmd.Parameters.AddWithValue("@sht", txthoten.Text);
                                cmd.Parameters.AddWithValue("@sdiachi", txtdiachi.Text);
                                cmd.Parameters.AddWithValue("@isdt", txtsdt.Text);
                                if (rdbnam.Checked == true)
                                {
                                    cmd.Parameters.AddWithValue("@sgioitinh", rdbnam.Text);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@sgioitinh", rdbnu.Text);
                                }
                                cmd.Parameters.AddWithValue("@fluong", Math.Round(float.Parse(txtluong.Text), 2));
                                cmd.Parameters.AddWithValue("@dns", Convert.ToDateTime(dtpns.Text));

                                DateTime ngayhientai = Convert.ToDateTime(dtpns.Text);
                                DateTime n1 = Convert.ToDateTime("1/1/1980");
                                DateTime n2 = Convert.ToDateTime("1/1/1998");
                                if (n1.Year<ngayhientai.Year && ngayhientai.Year<n2.Year)
                                {
                                    cmd.ExecuteNonQuery();
                                    clean();
                                }
                                else
                                {
                                    MessageBox.Show("Thời gian phải nằm trong khoảng từ năm 1980 đến năm 1998!");
                                }
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                label4.ForeColor = Color.Black;
                                label5.ForeColor = Color.Black;
                                label6.ForeColor = Color.Black;
                                label7.ForeColor = Color.Black;
                                label8.ForeColor = Color.Black;
                                txtmanv.Enabled = false;
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
                        if (txtmanv.Text != "")
                        {
                            DateTime ngayhientai = Convert.ToDateTime(dtpns.Text);
                            DateTime n1 = Convert.ToDateTime("1/1/1980");
                            DateTime n2 = Convert.ToDateTime("1/1/1998");
                            if (n1.Year < ngayhientai.Year && ngayhientai.Year < n2.Year)
                            {
                                if (rdbnam.Checked == true)
                                {
                                    string sql = "update NhanVien set shotennv=N'" + txthoten.Text + "',sdiachinv=N'" + txtdiachi.Text + "',isdtnv='" + txtsdt.Text + "',sgioitinh=N'" + rdbnam.Text + "',fluong='" + txtluong.Text + "',dngaysinh='" + dtpns.Text + "' where smanv = '" + txtmanv.Text + "'";
                                    SqlCommand cmd = new SqlCommand(sql, conn);
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                }
                                if (rdbnu.Checked == true)
                                {
                                    string sql = "update NhanVien set shotennv=N'" + txthoten.Text + "',sdiachinv=N'" + txtdiachi.Text + "',isdtnv='" + txtsdt.Text + "',sgioitinh=N'" + rdbnu.Text + "',fluong='" + txtluong.Text + "',dngaysinh='" + dtpns.Text + "'where smanv = '" + txtmanv.Text + "'";
                                    SqlCommand cmd = new SqlCommand(sql, conn);
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                }
                                MessageBox.Show("Sửa dữ liệu thành công!");
                                clean();
                                txtmanv.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Thời gian phải nằm trong khoảng từ năm 1980 đến năm 1998!");
                            }
                            close();
                            refresh();
                        }
                        conn.Close();
                        }
                        catch (Exception ex)
                        {
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

        private void txtluong_KeyPress(object sender, KeyPressEventArgs e)
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
                if (rdbmnv.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from NhanVien where smanv like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgnhanvien.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtnv.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from NhanVien where shotennv like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgnhanvien.DataSource = dt;
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
