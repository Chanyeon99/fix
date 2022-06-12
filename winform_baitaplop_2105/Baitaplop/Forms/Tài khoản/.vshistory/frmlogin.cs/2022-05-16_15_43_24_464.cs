using Baitaplop.Model;
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
    public partial class frmlogin : Form
    {
        DBConnect dB;
        public frmlogin()
        {
            InitializeComponent();
            dB = new DBConnect();
        }
        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void btndn_Click(object sender, EventArgs e)
        {
            string username = txtdn.Text;
            string password = txtmk.Text;
            try
            {
                bool isValidUser = dB.login(username, password);
                Console.WriteLine(isValidUser.ToString());
                bool isAdmin = dB.isAdmin;

                if (isValidUser)
                {
                    frmMain main = new frmMain();
                    main.isAdmin = isAdmin;
                    main.Show();
                    this.Hide();
                }
                else
                {
                    lbthongbao.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("ex:"+ex.Message);
            }
            //string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            //using (SqlConnection cnn = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("select * from account where user_name='" + txtdn.Text + "' and pass='" + txtmk.Text + "'", cnn))
            //    {
            //        try
            //        {
            //            cnn.Open();
            //            SqlDataReader rd = cmd.ExecuteReader();
            //            if (rd.Read() == true)
            //            {
            //                UserInfo user = new UserInfo();
            //                user.DisplayName = rd["name"].ToString();
            //                user.IsAdmin = (bool)rd["isAdmin"];
            //                Console.WriteLine(user);

            //            }
            //            else
            //            {
            //                lbthongbao.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.Write(ex.Message.ToString());
            //            MessageBox.Show("Lỗi đăng nhập!");
            //        }
            //    }
            //}
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
