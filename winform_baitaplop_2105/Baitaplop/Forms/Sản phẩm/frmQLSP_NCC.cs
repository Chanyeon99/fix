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
    public partial class frmQLSP_NCC : Form
    {
        public bool isHasPermissionEdit;
        bool themmoi;
        public frmQLSP_NCC()
        {
            InitializeComponent();
        }

        private void Nhà_cung_cấp_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Nhacungcap", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dtgncc.DataSource = tb;
                    }
                    cnn.Close();
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
        public void open()
        {
            txtten.Enabled = true;
            txtdc.Enabled = true;
            txtsdt.Enabled = true;

            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
        }

        public void close()
        {
            txtma.Enabled = false;
            txtten.Enabled = false;
            txtdc.Enabled = false;
            txtsdt.Enabled = false;

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
        }
        public void clean()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdc.Text = "";
            txtsdt.Text = "";
        }
        private void dtgncc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        cnn.Open();
                        int cri = dtgncc.CurrentRow.Index;
                        string mancc = dtgncc.Rows[cri].Cells[0].Value.ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pcdncc";
                        cmd.Parameters.AddWithValue("@mncc", mancc);
                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            txtma.Text = rd[0].ToString();
                            txtten.Text = rd[1].ToString();
                            txtdc.Text = rd[2].ToString();
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            open();
            txtma.Enabled = true;
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
                    string sql = "delete from Nhacungcap where smancc = '" + txtma.Text + "'";
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
            if (txtma.Text == "" || txtten.Text == ""||txtdc.Text==""||txtsdt.Text=="")
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!");
                if (txtma.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (txtten.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (txtdc.Text == "")
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
                            cmd.CommandText = "pcdthemncc";
                            try
                            {
                                cmd.Parameters.AddWithValue("@mncc", txtma.Text);
                                cmd.Parameters.AddWithValue("@tncc", txtten.Text);
                                cmd.Parameters.AddWithValue("@dc", txtdc.Text);
                                cmd.Parameters.AddWithValue("@sdt", txtsdt.Text);
                                cmd.ExecuteNonQuery();
                                label2.ForeColor = Color.Black;
                                label3.ForeColor = Color.Black;
                                clean();
                                close();
                                refresh();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mã nhân viên đã tồn tại!");
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
                        if (txtma.Text != "")
                        {
                            string sql = "update Nhacungcap set stenncc=N'" + txtten.Text + "',sdiachi=N'" + txtdc.Text + "',ssdt='" + txtsdt.Text + "' where smancc = '" + txtma.Text + "'";
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
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (rdbmncc.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT smancc,stenncc,sdiachi,ssdt from Nhacungcap where smancc like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgncc.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
                if (rdbtncc.Checked == true)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT smancc,stenncc,sdiachi,ssdt from Nhacungcap where stenncc like N'%" + txttk.Text.ToString() + "%'", cnn))
                    {
                        cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable("ncc");
                        da.Fill(dt);
                        da.Dispose();
                        dtgncc.DataSource = dt;
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
