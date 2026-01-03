namespace BTL_N7
{
    partial class frmQuanLyMatKhau
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
            this.lblMKcu = new System.Windows.Forms.Label();
            this.lblMKmoi = new System.Windows.Forms.Label();
            this.txtPassCu = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblNhapMKMoi = new System.Windows.Forms.Label();
            this.txtPassMoi = new System.Windows.Forms.TextBox();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHienmkMoi = new System.Windows.Forms.CheckBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMKcu
            // 
            this.lblMKcu.AutoSize = true;
            this.lblMKcu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMKcu.Location = new System.Drawing.Point(36, 57);
            this.lblMKcu.Name = "lblMKcu";
            this.lblMKcu.Size = new System.Drawing.Size(140, 29);
            this.lblMKcu.TabIndex = 0;
            this.lblMKcu.Text = "Mật khẩu cũ";
            // 
            // lblMKmoi
            // 
            this.lblMKmoi.AutoSize = true;
            this.lblMKmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMKmoi.Location = new System.Drawing.Point(478, 53);
            this.lblMKmoi.Name = "lblMKmoi";
            this.lblMKmoi.Size = new System.Drawing.Size(155, 29);
            this.lblMKmoi.TabIndex = 1;
            this.lblMKmoi.Text = "Mật khẩu mới";
            // 
            // txtPassCu
            // 
            this.txtPassCu.Location = new System.Drawing.Point(80, 100);
            this.txtPassCu.Name = "txtPassCu";
            this.txtPassCu.Size = new System.Drawing.Size(319, 38);
            this.txtPassCu.TabIndex = 2;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(225, 308);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(137, 65);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblNhapMKMoi
            // 
            this.lblNhapMKMoi.AutoSize = true;
            this.lblNhapMKMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapMKMoi.Location = new System.Drawing.Point(36, 188);
            this.lblNhapMKMoi.Name = "lblNhapMKMoi";
            this.lblNhapMKMoi.Size = new System.Drawing.Size(219, 29);
            this.lblNhapMKMoi.TabIndex = 4;
            this.lblNhapMKMoi.Text = "Nhập mật khẩu mới";
            // 
            // txtPassMoi
            // 
            this.txtPassMoi.Location = new System.Drawing.Point(522, 100);
            this.txtPassMoi.Name = "txtPassMoi";
            this.txtPassMoi.Size = new System.Drawing.Size(319, 38);
            this.txtPassMoi.TabIndex = 5;
            // 
            // txtXacNhan
            // 
            this.txtXacNhan.Location = new System.Drawing.Point(284, 179);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.Size = new System.Drawing.Size(319, 38);
            this.txtXacNhan.TabIndex = 6;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(41, 308);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 65);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.chkHienmkMoi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.txtXacNhan);
            this.groupBox1.Controls.Add(this.txtPassMoi);
            this.groupBox1.Controls.Add(this.btnXacNhan);
            this.groupBox1.Controls.Add(this.lblNhapMKMoi);
            this.groupBox1.Controls.Add(this.lblMKcu);
            this.groupBox1.Controls.Add(this.txtPassCu);
            this.groupBox1.Controls.Add(this.lblMKmoi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 428);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ĐỔI MẬT KHẨU";
            // 
            // chkHienmkMoi
            // 
            this.chkHienmkMoi.AutoSize = true;
            this.chkHienmkMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienmkMoi.Location = new System.Drawing.Point(710, 187);
            this.chkHienmkMoi.Name = "chkHienmkMoi";
            this.chkHienmkMoi.Size = new System.Drawing.Size(182, 29);
            this.chkHienmkMoi.TabIndex = 14;
            this.chkHienmkMoi.Text = "Hiện mật khẩu";
            this.chkHienmkMoi.UseVisualStyleBackColor = true;
            this.chkHienmkMoi.CheckedChanged += new System.EventHandler(this.chkHienmkMoi_CheckedChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(639, 308);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(137, 65);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(435, 308);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(137, 65);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(12, 486);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 82;
            this.dgvTaiKhoan.RowTemplate.Height = 33;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(1167, 470);
            this.dgvTaiKhoan.TabIndex = 9;
            this.dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellContentClick);
            // 
            // frmQuanLyMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1314, 1057);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmQuanLyMatKhau";
            this.Text = "Quan ly mat khau";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMKcu;
        private System.Windows.Forms.Label lblMKmoi;
        private System.Windows.Forms.TextBox txtPassCu;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblNhapMKMoi;
        private System.Windows.Forms.TextBox txtPassMoi;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.CheckBox chkHienmkMoi;
    }
}