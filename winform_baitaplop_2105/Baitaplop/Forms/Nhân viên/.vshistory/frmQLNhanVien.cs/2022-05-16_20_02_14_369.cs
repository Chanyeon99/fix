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

namespace Baitaplop.Forms
{
    public partial class frmQLNhanVien : Form
    {
        DBAccess context = new DBAccess();

        public bool isHasPermissionEdit;



        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        bool themmoi;
        private void Nhân_viên_Load(object sender, EventArgs e)
        {
            MessageBox.Show("is Has Permission to Edit Data: " + this.isHasPermissionEdit.ToString());
            refresh();
        }
        public void refresh()
        {
            context.connect();
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
            context.disconnect();
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
                    catch (Exception ex)
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
            if (txtmanv.Text == "" || txthoten.Text == "" || rdbnam.Checked == false && rdbnu.Checked == false || txtdiachi.Text == "" || txtsdt.Text == "" || dtpns.Text == "" || txtluong.Text == "")
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
                if (themmoi == true)
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
                                cmd.Parameters.AddWithValue("@smnv", txtmanv.Text.Trim());
                                cmd.Parameters.AddWithValue("@sht", txthoten.Text.Trim());
                                cmd.Parameters.AddWithValue("@sdiachi", txtdiachi.Text.Trim());
                                cmd.Parameters.AddWithValue("@isdt", txtsdt.Text.Trim());
                                if (rdbnam.Checked == true)
                                {
                                    cmd.Parameters.AddWithValue("@sgioitinh", rdbnam.Text.Trim());
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@sgioitinh", rdbnu.Text.Trim());
                                }
                                cmd.Parameters.AddWithValue("@fluong", Math.Round(float.Parse(txtluong.Text.Trim()), 2));

                                DateTime ngaysinh = Convert.ToDateTime(dtpns.Text.ToString());
                                int du18tuoi = DateTime.Now.Year - 18;
                                DateTime n1 = Convert.ToDateTime("1/1/1980");

                                if (n1.Year < ngaysinh.Year && ngaysinh.Year <= du18tuoi)
                                {
                                    cmd.Parameters.AddWithValue("@dns", Convert.ToDateTime(dtpns.Text));
                                    cmd.ExecuteNonQuery();
                                    clean();
                                }
                                else
                                {
                                    MessageBox.Show("Năm sinh phải nằm trong khoảng từ năm 1980 đến năm " + du18tuoi + "!");
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
                                MessageBox.Show("Lỗi truy xuất dữ liệu, Liên hệ admin để báo cáo lỗi!", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
                        if (txtmanv.Text != "")
                        {
                            DateTime ngayhientai = Convert.ToDateTime(dtpns.Text);
                            DateTime n1 = Convert.ToDateTime("1/1/1980");
                            int du18tuoi = (DateTime.Now.Year - 18);
                            DateTime n2 = Convert.ToDateTime("1/1/1998");
                            if (n1.Year < ngayhientai.Year && ngayhientai.Year < du18tuoi)
                            {
                                if (rdbnam.Checked == true)
                                {
                                    string sql = "update NhanVien set shotennv=N'" + txthoten.Text 
                                        + "',sdiachinv=N'" + txtdiachi.Text 
                                        + "',isdtnv='" + txtsdt.Text 
                                        + "',sgioitinh=N'" + rdbnam.Text 
                                        + "',fluong='" + txtluong.Text 
                                        + "',dngaysinh='" + dtpns.Text 
                                        + "' where smanv = '" + txtmanv.Text + "'";

                                    SqlCommand cmd = new SqlCommand(sql, conn);
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                }
                                if (rdbnu.Checked == true)
                                {
                                    string sql = "update NhanVien set shotennv=N'" + txthoten.Text 
                                        + "',sdiachinv=N'" + txtdiachi.Text 
                                        + "',isdtnv='" + txtsdt.Text 
                                        + "',sgioitinh=N'" + rdbnu.Text 
                                        + "',fluong='" + txtluong.Text 
                                        + "',dngaysinh='" + dtpns.Text 
                                        + "'where smanv = '" + txtmanv.Text + "'";
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
                                MessageBox.Show("Ngày sinh phải nằm trong khoảng từ năm 1980 đến năm !"+ du18tuoi+"!");
                            }
                            close();
                            refresh();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập sai dữ liệu!","Thông báo");
                        throw new Exception(ex.Message);
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
