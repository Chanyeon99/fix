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
    public partial class frmThongKe : Form
    {
        public bool isHasPermissionEdit;
        public frmThongKe()
        {
            InitializeComponent();
        }
        
        private Form activeBaoCaoForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeBaoCaoForm != null)
            {
                activeBaoCaoForm.Close();
            }
            activeBaoCaoForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlBaoCaoChildForm.Controls.Add(childForm);
            pnlBaoCaoChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        
        private void Báo_cáo_Load(object sender, EventArgs e)
        {
            cbohdb.SelectedValue = "";
        }
        
        private void btnhdb_Click(object sender, EventArgs e)
        {
            ThongKecrt frm = new ThongKecrt();
            openChildForm(frm);
        }

    }
}
