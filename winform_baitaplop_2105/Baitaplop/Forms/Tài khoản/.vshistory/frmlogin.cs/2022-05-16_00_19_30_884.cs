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

namespace Baitaplop
{
    public partial class frmlogin : Form
    {
        DBConnect dB = new DBConnect();
        public frmlogin()
        {
            InitializeComponent();
        }
        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void btndn_Click(object sender, EventArgs e)
        {
            string username = txtdn.Text.ToString().Trim();
            string password = txtmk.Text.ToString().Trim();

            bool isValidUser = dB.login(username, password);

            if (isValidUser)
            {
                frmMain main = new frmMain();
                main.isAdmin = true;
                //main.user = user;
                main.Show();
                this.Hide();
            }
            else
            {
                lbthongbao.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
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
