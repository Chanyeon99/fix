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

namespace Baitaplop
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        private void frmlogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btndn_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from login_us where suser='"+txtdn.Text+"' and spass='"+txtmk.Text+"'", cnn))
                {
                    try
                    {
                        cnn.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read() == true)
                        {
                            Form main = new frmMain();
                            main.isAdmin = true;
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            lbthongbao.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi đăng nhập!");
                    }
                }
            }
        }

        private void ckbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbshow.Checked)
            {
                txtmk.UseSystemPasswordChar = false;
            }
            else
            {
                txtmk.UseSystemPasswordChar = true;
            }
        }

        private void txtdn_Click(object sender, EventArgs e)
        {
            lbthongbao.Text = "";
        }

        private void txtmk_Click(object sender, EventArgs e)
        {
            lbthongbao.Text = "";
        }

        private void btnt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
