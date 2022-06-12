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
    public partial class Hãng_sx : Form
    {
        bool themmoi;
        public Hãng_sx()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Hangsx", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtghangsx.DataSource = tb;
                    }
                    cnn.Close();
                }
            }
        }
        public void open()
        {
            txttenhang.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }
        public void close()
        {
            txttenhang.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
        }
        public void clean()
        {
            txtmahang.Text = "";
            txttenhang.Text = "";
        }
        private void Hãng_sx_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dtghangsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtghangsx.CurrentRow.Index;
                        string mahang = dtghangsx.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdhangsx";
                        cmd.Parameters.AddWithValue("@smh",mahang);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtmahang.Text = rd[0].ToString();
                            txttenhang.Text = rd[1].ToString();
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            open();
            txtmahang.Enabled = true;
            clean();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            open();
            txtmahang.Enabled = false;
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
                    string sql = "delete from Hangsx where smahangsx = '" + txtmahang.Text + "'";
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
            if (txtmahang.Text == "" || txttenhang.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtmahang.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (txttenhang.Text == "")
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
                            cmd.CommandText = "pcdthemhang";
                            try
                            {
                                cmd.Parameters.AddWithValue("@smh", txtmahang.Text);
                                cmd.Parameters.AddWithValue("@stenh", txttenhang.Text);
                                cmd.ExecuteNonQuery();
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                clean();
                                txtmahang.Enabled = false;
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
                        if (txtmahang.Text != "")
                        {
                            string sql = "update Hangsx set shangsx=N'" + txttenhang.Text + "' where smahangsx = '" + txtmahang.Text + "'";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            clean();
                            txtmahang.Enabled = false;
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

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (rdbmh.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT smahangsx,shangsx from Hangsx where smahangsx like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("hangsx");
                        da.Fill(dt);
                        da.Dispose();
                        dtghangsx.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbth.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT smahangsx,shangsx from Hangsx where shangsx like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("hangsx");
                        da.Fill(dt);
                        da.Dispose();
                        dtghangsx.DataSource = dt;
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
