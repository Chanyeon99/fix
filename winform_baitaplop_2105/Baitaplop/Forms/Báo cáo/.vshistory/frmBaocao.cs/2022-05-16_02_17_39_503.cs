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
    public partial class Báo_cáo : Form
    {
        public static string shdb = null;
        public static string shdn = null;
        public Báo_cáo()
        {
            InitializeComponent();
        }
        public void showcombobox()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select smahdb from HoaDonBan", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbohdb.DataSource = tb;
                    cbohdb.DisplayMember = "smahdb";
                    cbohdb.ValueMember = "smahdb";
                }
            }
        }
        public void showcombobox1()
        {
            string constr = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select smahdn from HoaDonNhap", cnn))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    cbohdn.DataSource = tb;
                    cbohdn.DisplayMember = "smahdn";
                    cbohdn.ValueMember = "smahdn";
                }
            }
        }
        private void Báo_cáo_Load(object sender, EventArgs e)
        {
            showcombobox();
            showcombobox1();
            cbohdb.SelectedValue = "";
            cbohdn.SelectedValue = "";
        }
        private bool Checkform(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void activeform(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        private void btnhdb_Click(object sender, EventArgs e)
        {
            shdb = cbohdb.SelectedValue.ToString();
            if (!Checkform("Báo_cáo"))
            {
                HDBcrt hdb = new HDBcrt();
                hdb.MdiParent = this.MdiParent;
                hdb.Show();
            }
            else 
                activeform("Báo_cáo");
        }

        private void btnhdn_Click(object sender, EventArgs e)
        {
            shdn = cbohdn.SelectedValue.ToString();
            if (!Checkform("Báo_cáo"))
            {
                Form hdn = new HDNcrt();
                hdn.MdiParent = this.MdiParent;
                hdn.Show();
            }
            else
                activeform("Báo_cáo");
        }
    }
}
