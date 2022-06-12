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
        public bool isHasPermissionEdit;

        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        bool themmoi;
        private void frmQLNV_Load(object sender, EventArgs e)
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
        public void refresh()
        {
            //Access Database Object ADO.NET
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

        private void enableEditButton(bool b)
        {
            btnsua.Enabled = b;
            btnxoa.Enabled = b;
        }

        private void dtgnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            close();
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
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

            //Khi sửa thì chỉ hiển thị nút lưu
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

        //Hàm xóa trắng các ô dữ liệu để thêm mới
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
                    Console.WriteLine(ex.Message);
                }
            }
            else
                return;
        }

        private bool isEmptyTextBox(TextBox tb)
        {

            String[] listCheckNullOrNull = { txtmanv.Text, txthoten.Text, txtdiachi.Text, txtsdt.Text, txtluong.Text };
            bool isEmpty = String.IsNullOrWhiteSpace(listCheckNullOrNull[1]);

            return isEmpty;
        }

        private bool KiemTraDeTrongDuLieu()
        {
            TextBox[] listTextBox = { txtmanv, txthoten, txtdiachi, txtsdt, txtluong };
            bool isEmpty = false;
            bool isNotCheckGender = rdbnam.Checked == false && rdbnu.Checked == false;
            if (isNotCheckGender)
            {
                turnErrorLabel(6);
                MessageBox.Show("Chưa chọn giới tính!", "Cảnh báo");
                return isEmpty = true;
            }

            bool isNotSelectDate = dtpns.Value.Equals(DateTime.Now);
            if (isNotSelectDate) turnErrorLabel(7);

            for (int i = 0; i < listTextBox.Length; i++)
            {
                bool isEmptyOrWhiteSpace = String.IsNullOrWhiteSpace(listTextBox[i].Text);
                if (isEmptyOrWhiteSpace)
                {
                    turnErrorLabel(i);
                    isEmpty = isEmpty && !isEmptyOrWhiteSpace;
                }
            }

            //Tra ve ket qua 1 trong cac Textbox de trong hoac gioi tinh chua duoc chon
            return isEmpty;
        }

        private void turnErrorLabel(int i)
        {
            switch (i)
            {
                case 0:
                    label2.ForeColor = Color.Red;
                    break;
                case 1:
                    label3.ForeColor = Color.Red;
                    break;
                case 2:
                    label5.ForeColor = Color.Red;
                    break;
                case 3:
                    label6.ForeColor = Color.Red;
                    break;
                case 4:
                    label8.ForeColor = Color.Red;
                    break;
                    //end check text
                    //ngay sinh chua chon
                case 5:
                    label7.ForeColor = Color.Red;
                    break;
                case 6: //gender error label
                    label4.ForeColor = Color.Red;
                    break;
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (KiemTraDeTrongDuLieu())
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Case Them moi du lieu
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
                    //Neu khong them moi thi kiem tra de cap nhat du lieu
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
                                MessageBox.Show("Ngày sinh phải nằm trong khoảng từ năm 1980 đến năm !" + du18tuoi + "!");
                            }
                            close();
                            refresh();
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập sai dữ liệu!", "Thông báo");
                        throw new Exception(ex.Message);
                    }
                }
            }
        }


        //Chi cho phep nhap so'
        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Chi cho phep nhap so'
        private void txtluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Search
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
