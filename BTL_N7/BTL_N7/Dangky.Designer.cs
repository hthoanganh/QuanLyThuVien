namespace BTL_N7
{
    partial class Dangky
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
            this.grboxĐangnhap = new System.Windows.Forms.GroupBox();
            this.chkHienmk = new System.Windows.Forms.CheckBox();
            this.lblFULLNAME = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.btnDangky = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblMatkhau = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblTaikhoan = new System.Windows.Forms.Label();
            this.grboxĐangnhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // grboxĐangnhap
            // 
            this.grboxĐangnhap.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grboxĐangnhap.Controls.Add(this.chkHienmk);
            this.grboxĐangnhap.Controls.Add(this.lblFULLNAME);
            this.grboxĐangnhap.Controls.Add(this.txtFullname);
            this.grboxĐangnhap.Controls.Add(this.btnDangky);
            this.grboxĐangnhap.Controls.Add(this.txtUser);
            this.grboxĐangnhap.Controls.Add(this.lblMatkhau);
            this.grboxĐangnhap.Controls.Add(this.txtPass);
            this.grboxĐangnhap.Controls.Add(this.lblTaikhoan);
            this.grboxĐangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grboxĐangnhap.Location = new System.Drawing.Point(866, 146);
            this.grboxĐangnhap.Name = "grboxĐangnhap";
            this.grboxĐangnhap.Size = new System.Drawing.Size(561, 730);
            this.grboxĐangnhap.TabIndex = 9;
            this.grboxĐangnhap.TabStop = false;
            this.grboxĐangnhap.Text = "ĐĂNG KÝ";
            // 
            // chkHienmk
            // 
            this.chkHienmk.AutoSize = true;
            this.chkHienmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienmk.Location = new System.Drawing.Point(296, 493);
            this.chkHienmk.Name = "chkHienmk";
            this.chkHienmk.Size = new System.Drawing.Size(182, 29);
            this.chkHienmk.TabIndex = 12;
            this.chkHienmk.Text = "Hiện mật khẩu";
            this.chkHienmk.UseVisualStyleBackColor = true;
            this.chkHienmk.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // lblFULLNAME
            // 
            this.lblFULLNAME.AutoSize = true;
            this.lblFULLNAME.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFULLNAME.Location = new System.Drawing.Point(65, 76);
            this.lblFULLNAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFULLNAME.Name = "lblFULLNAME";
            this.lblFULLNAME.Size = new System.Drawing.Size(83, 27);
            this.lblFULLNAME.TabIndex = 11;
            this.lblFULLNAME.Text = "Họ tên";
            // 
            // txtFullname
            // 
            this.txtFullname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullname.ForeColor = System.Drawing.Color.Gray;
            this.txtFullname.Location = new System.Drawing.Point(93, 134);
            this.txtFullname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(370, 35);
            this.txtFullname.TabIndex = 0;
            this.txtFullname.Text = "Nhập họ tên";
            this.txtFullname.Enter += new System.EventHandler(this.txtFullname_Enter);
            this.txtFullname.Leave += new System.EventHandler(this.txtFullname_Leave);
            // 
            // btnDangky
            // 
            this.btnDangky.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDangky.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangky.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangky.Location = new System.Drawing.Point(93, 575);
            this.btnDangky.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(370, 67);
            this.btnDangky.TabIndex = 9;
            this.btnDangky.Text = "Đăng ký";
            this.btnDangky.UseVisualStyleBackColor = false;
            this.btnDangky.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Gray;
            this.txtUser.Location = new System.Drawing.Point(93, 273);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(370, 35);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "Nhập mã hoặc tên tài khoản";
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // lblMatkhau
            // 
            this.lblMatkhau.AutoSize = true;
            this.lblMatkhau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatkhau.Location = new System.Drawing.Point(65, 353);
            this.lblMatkhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatkhau.Name = "lblMatkhau";
            this.lblMatkhau.Size = new System.Drawing.Size(115, 27);
            this.lblMatkhau.TabIndex = 6;
            this.lblMatkhau.Text = "Mật Khẩu";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Gray;
            this.txtPass.Location = new System.Drawing.Point(93, 413);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(370, 35);
            this.txtPass.TabIndex = 3;
            this.txtPass.Text = "Nhập mật khẩu";
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // lblTaikhoan
            // 
            this.lblTaikhoan.AutoSize = true;
            this.lblTaikhoan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaikhoan.Location = new System.Drawing.Point(65, 212);
            this.lblTaikhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaikhoan.Name = "lblTaikhoan";
            this.lblTaikhoan.Size = new System.Drawing.Size(121, 27);
            this.lblTaikhoan.TabIndex = 5;
            this.lblTaikhoan.Text = "Tài Khoản";
            // 
            // Dangky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTL_N7.Properties.Resources.hinhnen21;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1504, 918);
            this.Controls.Add(this.grboxĐangnhap);
            this.DoubleBuffered = true;
            this.Name = "Dangky";
            this.Text = "Dangky";
            this.Load += new System.EventHandler(this.Dangky_Load);
            this.grboxĐangnhap.ResumeLayout(false);
            this.grboxĐangnhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grboxĐangnhap;
        private System.Windows.Forms.Button btnDangky;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMatkhau;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblTaikhoan;
        private System.Windows.Forms.Label lblFULLNAME;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.CheckBox chkHienmk;
    }
}