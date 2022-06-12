using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplop
{
    public partial class frmMain : Form
    {
        public bool isAdmin;
        public frmMain()
        {
            InitializeComponent();
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
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Nhân_viên"))
            {
                Form nv = new Nhân_viên.Nhân_viên();
                nv.MdiParent = this;
                nv.Show();
            }
            else
                activeform("Nhân_viên");
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Checkform("Sản_phẩm"))
            {
                Form sp = new Sản_phẩm.Sản_phẩm();
                sp.MdiParent = this;

                sp.Show();
            }
            else
                activeform("Sản_phẩm");
        }
        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Loại_sản_phẩm"))
            {
                Form lsp = new Sản_phẩm.Loại_sản_phẩm();
                lsp.MdiParent = this;
                lsp.Show();
            }
            else
                activeform("Loại_sản_phẩm");
        }

        private void hãngSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Hãng_sx"))
            {
                Form hsx = new Sản_phẩm.Hãng_sx();
                hsx.MdiParent = this;
                hsx.Show();
            }
            else
                activeform("Hãng_sx");
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Khách_hàng"))
            {
                Form kh = new Khách_hàng.Khách_hàng();
                kh.MdiParent = this;
                kh.Show();
            }
            else
                activeform("Khách_hàng");
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Hóa_đơn_nhập"))
            {
                Form hdn = new Hóa_đơn.Hóa_đơn_nhập();
                hdn.MdiParent = this;
                hdn.Show();
            }
            else
                activeform("Hóa_đơn_nhập");
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Hóa_đơn_bán"))
            {
                Form hdb = new Hóa_đơn.Hóa_đơn_bán();
                hdb.MdiParent = this;
                hdb.Show();
            }
            else
                activeform("Hóa_đơn_bán");
        }

        private void hóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Checkform("Chi_tiết_hóa_đơn_nhập"))
            {
                Form cthdn = new Hóa_đơn.Chi_tiết_hóa_đơn_nhập();
                cthdn.MdiParent = this;
                cthdn.Show();
            }
            else
                activeform("Chi_tiết_hóa_đơn_nhập");
        }

        private void hóaĐơnBánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Checkform("Chi_tiết_hóa_đơn_bán"))
            {
                Form cthdb = new Hóa_đơn.Chi_tiết_hóa_đơn_bán();
                cthdb.MdiParent = this;
                cthdb.Show();
            }
            else
                activeform("Chi_tiết_hóa_đơn_bán");
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form lg = new frmlogin();
            this.Hide();
            lg.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Nhà_cung_cấp"))
            {
                Form ncc = new Sản_phẩm.Nhà_cung_cấp();
                ncc.MdiParent = this;
                ncc.Show();
            }
            else
                activeform("Nhà_cung_cấp");
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Checkform("Báo_cáo"))
            {
                Form bc = new Báo_cáo.Báo_cáo();
                bc.MdiParent = this;
                bc.Show();
            }
            else
                activeform("Báo_cáo");
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
