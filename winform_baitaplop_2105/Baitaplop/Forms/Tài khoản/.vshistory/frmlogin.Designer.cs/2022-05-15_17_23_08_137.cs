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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdn = new System.Windows.Forms.TextBox();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.btndn = new System.Windows.Forms.Button();
            this.btnt = new System.Windows.Forms.Button();
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
            // btndn
            // 
            this.btndn.Location = new System.Drawing.Point(109, 154);
            this.btndn.Name = "btndn";
            this.btndn.Size = new System.Drawing.Size(75, 23);
            this.btndn.TabIndex = 6;
            this.btndn.Text = "Đăng nhập";
            this.btndn.UseVisualStyleBackColor = true;
            this.btndn.Click += new System.EventHandler(this.btndn_Click);
            // 
            // btnt
            // 
            this.btnt.Location = new System.Drawing.Point(207, 154);
            this.btnt.Name = "btnt";
            this.btnt.Size = new System.Drawing.Size(75, 23);
            this.btnt.TabIndex = 7;
            this.btnt.Text = "Thoát";
            this.btnt.UseVisualStyleBackColor = true;
            this.btnt.Click += new System.EventHandler(this.btnt_Click);
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
            this.ckbshow.TabIndex = 10;
            this.ckbshow.Text = "Hiện mật khẩu";
            this.ckbshow.UseVisualStyleBackColor = true;
            this.ckbshow.CheckedChanged += new System.EventHandler(this.ckbshow_CheckedChanged);
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 199);
            this.Controls.Add(this.ckbshow);
            this.Controls.Add(this.lbthongbao);
            this.Controls.Add(this.btnt);
            this.Controls.Add(this.btndn);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txtdn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmlogin";
            this.ShowIcon = false;
            this.Text = "ĐĂNG NHẬP";
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdn;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Button btndn;
        private System.Windows.Forms.Button btnt;
        private System.Windows.Forms.Label lbthongbao;
        private System.Windows.Forms.CheckBox ckbshow;
    }
}

