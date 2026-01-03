namespace BTL_N7
{
    partial class frmdangnhap
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
            this.txtTaikhoan = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.lblTaikhoan = new System.Windows.Forms.Label();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grboxĐangnhap = new System.Windows.Forms.GroupBox();
            this.chkHienmk = new System.Windows.Forms.CheckBox();
            this.btnQuenmk = new System.Windows.Forms.Button();
            this.btnDangky = new System.Windows.Forms.Button();
            this.grboxĐangnhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaikhoan.ForeColor = System.Drawing.Color.Gray;
            this.txtTaikhoan.Location = new System.Drawing.Point(108, 147);
            this.txtTaikhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.Size = new System.Drawing.Size(370, 31);
            this.txtTaikhoan.TabIndex = 3;
            this.txtTaikhoan.TextChanged += new System.EventHandler(this.txtTaikhoan_TextChanged);
            this.txtTaikhoan.Enter += new System.EventHandler(this.txtTaikhoan_Enter);
            this.txtTaikhoan.Leave += new System.EventHandler(this.txtTaikhoan_Leave);
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatkhau.ForeColor = System.Drawing.Color.Gray;
            this.txtMatkhau.Location = new System.Drawing.Point(108, 296);
            this.txtMatkhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(370, 31);
            this.txtMatkhau.TabIndex = 4;
            this.txtMatkhau.Enter += new System.EventHandler(this.txtMatkhau_Enter);
            this.txtMatkhau.Leave += new System.EventHandler(this.txtMatkhau_Leave);
            // 
            // lblTaikhoan
            // 
            this.lblTaikhoan.AutoSize = true;
            this.lblTaikhoan.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaikhoan.Location = new System.Drawing.Point(52, 86);
            this.lblTaikhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaikhoan.Name = "lblTaikhoan";
            this.lblTaikhoan.Size = new System.Drawing.Size(117, 31);
            this.lblTaikhoan.TabIndex = 5;
            this.lblTaikhoan.Text = "Tài Khoản";
            // 
            // lblMatkhau
            // 
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatkhau.Location = new System.Drawing.Point(52, 241);
            this.lblMatkhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Size = new System.Drawing.Size(113, 31);
            this.lblMatkhau.TabIndex = 6;
            this.lblMatkhau.Text = "Mật Khẩu";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(108, 505);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(370, 67);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grboxĐangnhap
            // 
            this.grboxĐangnhap.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grboxĐangnhap.Controls.Add(this.chkHienmk);
            this.grboxĐangnhap.Controls.Add(this.btnQuenmk);
            this.grboxĐangnhap.Controls.Add(this.btnDangky);
            this.grboxĐangnhap.Controls.Add(this.btnLogin);
            this.grboxĐangnhap.Controls.Add(this.txtTaikhoan);
            this.grboxĐangnhap.Controls.Add(this.lblMatkhau);
            this.grboxĐangnhap.Controls.Add(this.txtMatkhau);
            this.grboxĐangnhap.Controls.Add(this.lblTaikhoan);
            this.grboxĐangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grboxĐangnhap.Location = new System.Drawing.Point(1054, 118);
            this.grboxĐangnhap.Name = "grboxĐangnhap";
            this.grboxĐangnhap.Size = new System.Drawing.Size(565, 754);
            this.grboxĐangnhap.TabIndex = 8;
            this.grboxĐangnhap.TabStop = false;
            this.grboxĐangnhap.Text = "ĐĂNG NHẬP";
            // 
            // chkHienmk
            // 
            this.chkHienmk.AutoSize = true;
            this.chkHienmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienmk.Location = new System.Drawing.Point(351, 390);
            this.chkHienmk.Name = "chkHienmk";
            this.chkHienmk.Size = new System.Drawing.Size(182, 29);
            this.chkHienmk.TabIndex = 13;
            this.chkHienmk.Text = "Hiện mật khẩu";
            this.chkHienmk.UseVisualStyleBackColor = true;
            this.chkHienmk.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            // 
            // btnQuenmk
            // 
            this.btnQuenmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuenmk.Location = new System.Drawing.Point(51, 383);
            this.btnQuenmk.Name = "btnQuenmk";
            this.btnQuenmk.Size = new System.Drawing.Size(190, 42);
            this.btnQuenmk.TabIndex = 10;
            this.btnQuenmk.Text = "Quên mật khẩu?";
            this.btnQuenmk.UseVisualStyleBackColor = true;
            this.btnQuenmk.Click += new System.EventHandler(this.btnQuenmk_Click);
            // 
            // btnDangky
            // 
            this.btnDangky.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDangky.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangky.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangky.Location = new System.Drawing.Point(108, 614);
            this.btnDangky.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(370, 67);
            this.btnDangky.TabIndex = 9;
            this.btnDangky.Text = "Đăng ký";
            this.btnDangky.UseVisualStyleBackColor = false;
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
            // 
            // frmdangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTL_N7.Properties.Resources.hinhnen11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1726, 945);
            this.Controls.Add(this.grboxĐangnhap);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmdangnhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmdangnhap_Load);
            this.grboxĐangnhap.ResumeLayout(false);
            this.grboxĐangnhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtTaikhoan;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label lblTaikhoan;
        private System.Windows.Forms.Label lblMatkhau;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox grboxĐangnhap;
        private System.Windows.Forms.Button btnDangky;
        private System.Windows.Forms.Button btnQuenmk;
        private System.Windows.Forms.CheckBox chkHienmk;
    }
}