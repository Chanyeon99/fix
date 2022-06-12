namespace Baitaplop
{
    partial class frmlogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdn = new System.Windows.Forms.TextBox();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbthongbao = new System.Windows.Forms.Label();
            this.ckbshow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtdn
            // 
            this.txtdn.Location = new System.Drawing.Point(164, 44);
            this.txtdn.Name = "txtdn";
            this.txtdn.Size = new System.Drawing.Size(129, 20);
            this.txtdn.TabIndex = 4;
            this.txtdn.Click += new System.EventHandler(this.txtdn_Click);
            // 
            // txtmk
            // 
            this.txtmk.Location = new System.Drawing.Point(164, 72);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(129, 20);
            this.txtmk.TabIndex = 5;
            this.txtmk.UseSystemPasswordChar = true;
            this.txtmk.Click += new System.EventHandler(this.txtmk_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(109, 154);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btndn_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(207, 154);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnt_Click);
            // 
            // lbthongbao
            // 
            this.lbthongbao.AutoSize = true;
            this.lbthongbao.ForeColor = System.Drawing.Color.Red;
            this.lbthongbao.Location = new System.Drawing.Point(72, 128);
            this.lbthongbao.Name = "lbthongbao";
            this.lbthongbao.Size = new System.Drawing.Size(0, 13);
            this.lbthongbao.TabIndex = 9;
            // 
            // ckbshow
            // 
            this.ckbshow.AutoSize = true;
            this.ckbshow.Location = new System.Drawing.Point(164, 98);
            this.ckbshow.Name = "ckbshow";
            this.ckbshow.Size = new System.Drawing.Size(95, 17);
            this.ckbshow.TabIndex = 6;
            this.ckbshow.Text = "Hiện mật khẩu";
            this.ckbshow.UseVisualStyleBackColor = true;
            this.ckbshow.CheckedChanged += new System.EventHandler(this.ckbshow_CheckedChanged);
            // 
            // frmlogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.ckbshow);
            this.Controls.Add(this.lbthongbao);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txtdn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "frmlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Cửa Hàng - Đăng nhập";
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdn;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbthongbao;
        private System.Windows.Forms.CheckBox ckbshow;
    }
}

