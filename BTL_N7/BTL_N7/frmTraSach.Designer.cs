namespace BTL_N7
{
    partial class frmTraSach
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
            this.GboxTimkiem = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnHuyChonTimTTMuon = new System.Windows.Forms.Button();
            this.btnTimnguoimuon = new System.Windows.Forms.Button();
            this.btnXacNhanTra = new System.Windows.Forms.Button();
            this.txtTimMaDGhoacMaPhieum = new System.Windows.Forms.TextBox();
            this.rdbMaphieumuon = new System.Windows.Forms.RadioButton();
            this.rdbMadocgia = new System.Windows.Forms.RadioButton();
            this.cboDocGia = new System.Windows.Forms.Label();
            this.cmbTendocgia = new System.Windows.Forms.ComboBox();
            this.lblTendocgia = new System.Windows.Forms.Label();
            this.dgvBangNguoiMuon = new System.Windows.Forms.DataGridView();
            this.GbxXulyVP = new System.Windows.Forms.GroupBox();
            this.txtThongtinhinhphat = new System.Windows.Forms.TextBox();
            this.lblThongtinphat = new System.Windows.Forms.Label();
            this.btnHuyChonHinhThucXL = new System.Windows.Forms.Button();
            this.btnXacnhanHTXL = new System.Windows.Forms.Button();
            this.lblHinhThucXL = new System.Windows.Forms.Label();
            this.cbmHinhPhat = new System.Windows.Forms.ComboBox();
            this.GboxTimkiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangNguoiMuon)).BeginInit();
            this.GbxXulyVP.SuspendLayout();
            this.SuspendLayout();
            // 
            // GboxTimkiem
            // 
            this.GboxTimkiem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GboxTimkiem.Controls.Add(this.btnExcel);
            this.GboxTimkiem.Controls.Add(this.btnHuyChonTimTTMuon);
            this.GboxTimkiem.Controls.Add(this.btnTimnguoimuon);
            this.GboxTimkiem.Controls.Add(this.btnXacNhanTra);
            this.GboxTimkiem.Controls.Add(this.txtTimMaDGhoacMaPhieum);
            this.GboxTimkiem.Controls.Add(this.rdbMaphieumuon);
            this.GboxTimkiem.Controls.Add(this.rdbMadocgia);
            this.GboxTimkiem.Controls.Add(this.cboDocGia);
            this.GboxTimkiem.Controls.Add(this.cmbTendocgia);
            this.GboxTimkiem.Controls.Add(this.lblTendocgia);
            this.GboxTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GboxTimkiem.Location = new System.Drawing.Point(37, 54);
            this.GboxTimkiem.Name = "GboxTimkiem";
            this.GboxTimkiem.Size = new System.Drawing.Size(715, 396);
            this.GboxTimkiem.TabIndex = 11;
            this.GboxTimkiem.TabStop = false;
            this.GboxTimkiem.Text = "THÔNG TIN TRẢ SÁCH";
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(559, 288);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(138, 61);
            this.btnExcel.TabIndex = 24;
            this.btnExcel.Text = "Xuất Ecxel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnHuyChonTimTTMuon
            // 
            this.btnHuyChonTimTTMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyChonTimTTMuon.Location = new System.Drawing.Point(407, 287);
            this.btnHuyChonTimTTMuon.Name = "btnHuyChonTimTTMuon";
            this.btnHuyChonTimTTMuon.Size = new System.Drawing.Size(106, 62);
            this.btnHuyChonTimTTMuon.TabIndex = 22;
            this.btnHuyChonTimTTMuon.Text = "Hủy";
            this.btnHuyChonTimTTMuon.UseVisualStyleBackColor = true;
            this.btnHuyChonTimTTMuon.Click += new System.EventHandler(this.btnHuyChonTimTTMuon_Click);
            // 
            // btnTimnguoimuon
            // 
            this.btnTimnguoimuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimnguoimuon.Location = new System.Drawing.Point(87, 287);
            this.btnTimnguoimuon.Name = "btnTimnguoimuon";
            this.btnTimnguoimuon.Size = new System.Drawing.Size(112, 62);
            this.btnTimnguoimuon.TabIndex = 23;
            this.btnTimnguoimuon.Text = "Tìm";
            this.btnTimnguoimuon.UseVisualStyleBackColor = true;
            this.btnTimnguoimuon.Click += new System.EventHandler(this.btnTimnguoimuon_Click);
            // 
            // btnXacNhanTra
            // 
            this.btnXacNhanTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanTra.Location = new System.Drawing.Point(243, 287);
            this.btnXacNhanTra.Name = "btnXacNhanTra";
            this.btnXacNhanTra.Size = new System.Drawing.Size(116, 62);
            this.btnXacNhanTra.TabIndex = 21;
            this.btnXacNhanTra.Text = "Trả";
            this.btnXacNhanTra.UseVisualStyleBackColor = true;
            this.btnXacNhanTra.Click += new System.EventHandler(this.btnXacNhanTra_Click);
            // 
            // txtTimMaDGhoacMaPhieum
            // 
            this.txtTimMaDGhoacMaPhieum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimMaDGhoacMaPhieum.Location = new System.Drawing.Point(230, 144);
            this.txtTimMaDGhoacMaPhieum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimMaDGhoacMaPhieum.Name = "txtTimMaDGhoacMaPhieum";
            this.txtTimMaDGhoacMaPhieum.Size = new System.Drawing.Size(256, 35);
            this.txtTimMaDGhoacMaPhieum.TabIndex = 19;
            // 
            // rdbMaphieumuon
            // 
            this.rdbMaphieumuon.AutoSize = true;
            this.rdbMaphieumuon.Font = new System.Drawing.Font("Arial Narrow", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaphieumuon.Location = new System.Drawing.Point(37, 187);
            this.rdbMaphieumuon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbMaphieumuon.Name = "rdbMaphieumuon";
            this.rdbMaphieumuon.Size = new System.Drawing.Size(172, 29);
            this.rdbMaphieumuon.TabIndex = 18;
            this.rdbMaphieumuon.TabStop = true;
            this.rdbMaphieumuon.Text = "Mã phiếu mượn";
            this.rdbMaphieumuon.UseVisualStyleBackColor = true;
            this.rdbMaphieumuon.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbMadocgia
            // 
            this.rdbMadocgia.AutoSize = true;
            this.rdbMadocgia.Font = new System.Drawing.Font("Arial Narrow", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMadocgia.Location = new System.Drawing.Point(37, 133);
            this.rdbMadocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbMadocgia.Name = "rdbMadocgia";
            this.rdbMadocgia.Size = new System.Drawing.Size(135, 29);
            this.rdbMadocgia.TabIndex = 17;
            this.rdbMadocgia.TabStop = true;
            this.rdbMadocgia.Text = "Mã độc giả";
            this.rdbMadocgia.UseVisualStyleBackColor = true;
            this.rdbMadocgia.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // cboDocGia
            // 
            this.cboDocGia.AutoSize = true;
            this.cboDocGia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocGia.Location = new System.Drawing.Point(32, 65);
            this.cboDocGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(136, 29);
            this.cboDocGia.TabIndex = 16;
            this.cboDocGia.Text = "Chọn độc giả";
            // 
            // cmbTendocgia
            // 
            this.cmbTendocgia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTendocgia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTendocgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTendocgia.FormattingEnabled = true;
            this.cmbTendocgia.Location = new System.Drawing.Point(204, 59);
            this.cmbTendocgia.Name = "cmbTendocgia";
            this.cmbTendocgia.Size = new System.Drawing.Size(314, 37);
            this.cmbTendocgia.TabIndex = 9;
            // 
            // lblTendocgia
            // 
            this.lblTendocgia.AutoSize = true;
            this.lblTendocgia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTendocgia.Location = new System.Drawing.Point(53, 334);
            this.lblTendocgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTendocgia.Name = "lblTendocgia";
            this.lblTendocgia.Size = new System.Drawing.Size(0, 29);
            this.lblTendocgia.TabIndex = 8;
            // 
            // dgvBangNguoiMuon
            // 
            this.dgvBangNguoiMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangNguoiMuon.Location = new System.Drawing.Point(21, 504);
            this.dgvBangNguoiMuon.Name = "dgvBangNguoiMuon";
            this.dgvBangNguoiMuon.RowHeadersWidth = 82;
            this.dgvBangNguoiMuon.RowTemplate.Height = 33;
            this.dgvBangNguoiMuon.Size = new System.Drawing.Size(1543, 611);
            this.dgvBangNguoiMuon.TabIndex = 20;
            this.dgvBangNguoiMuon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangNguoiMuon_CellFormatting);
            // 
            // GbxXulyVP
            // 
            this.GbxXulyVP.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GbxXulyVP.Controls.Add(this.txtThongtinhinhphat);
            this.GbxXulyVP.Controls.Add(this.lblThongtinphat);
            this.GbxXulyVP.Controls.Add(this.btnHuyChonHinhThucXL);
            this.GbxXulyVP.Controls.Add(this.btnXacnhanHTXL);
            this.GbxXulyVP.Controls.Add(this.lblHinhThucXL);
            this.GbxXulyVP.Controls.Add(this.cbmHinhPhat);
            this.GbxXulyVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbxXulyVP.Location = new System.Drawing.Point(807, 54);
            this.GbxXulyVP.Name = "GbxXulyVP";
            this.GbxXulyVP.Size = new System.Drawing.Size(632, 396);
            this.GbxXulyVP.TabIndex = 21;
            this.GbxXulyVP.TabStop = false;
            this.GbxXulyVP.Text = "XỬ LÝ QUÁ HẠN";
            // 
            // txtThongtinhinhphat
            // 
            this.txtThongtinhinhphat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongtinhinhphat.Location = new System.Drawing.Point(117, 234);
            this.txtThongtinhinhphat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtThongtinhinhphat.Name = "txtThongtinhinhphat";
            this.txtThongtinhinhphat.Size = new System.Drawing.Size(314, 35);
            this.txtThongtinhinhphat.TabIndex = 24;
            // 
            // lblThongtinphat
            // 
            this.lblThongtinphat.AutoSize = true;
            this.lblThongtinphat.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongtinphat.Location = new System.Drawing.Point(53, 172);
            this.lblThongtinphat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongtinphat.Name = "lblThongtinphat";
            this.lblThongtinphat.Size = new System.Drawing.Size(94, 29);
            this.lblThongtinphat.TabIndex = 23;
            this.lblThongtinphat.Text = "Thông tin";
            // 
            // btnHuyChonHinhThucXL
            // 
            this.btnHuyChonHinhThucXL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyChonHinhThucXL.Location = new System.Drawing.Point(316, 301);
            this.btnHuyChonHinhThucXL.Name = "btnHuyChonHinhThucXL";
            this.btnHuyChonHinhThucXL.Size = new System.Drawing.Size(115, 62);
            this.btnHuyChonHinhThucXL.TabIndex = 22;
            this.btnHuyChonHinhThucXL.Text = "Hủy";
            this.btnHuyChonHinhThucXL.UseVisualStyleBackColor = true;
            this.btnHuyChonHinhThucXL.Click += new System.EventHandler(this.btnHuyChonHinhThucXL_Click);
            // 
            // btnXacnhanHTXL
            // 
            this.btnXacnhanHTXL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacnhanHTXL.Location = new System.Drawing.Point(478, 301);
            this.btnXacnhanHTXL.Name = "btnXacnhanHTXL";
            this.btnXacnhanHTXL.Size = new System.Drawing.Size(137, 62);
            this.btnXacnhanHTXL.TabIndex = 21;
            this.btnXacnhanHTXL.Text = "Xác nhận";
            this.btnXacnhanHTXL.UseVisualStyleBackColor = true;
            this.btnXacnhanHTXL.Click += new System.EventHandler(this.btnXacnhanHTXL_Click);
            // 
            // lblHinhThucXL
            // 
            this.lblHinhThucXL.AutoSize = true;
            this.lblHinhThucXL.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThucXL.Location = new System.Drawing.Point(53, 65);
            this.lblHinhThucXL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHinhThucXL.Name = "lblHinhThucXL";
            this.lblHinhThucXL.Size = new System.Drawing.Size(149, 29);
            this.lblHinhThucXL.TabIndex = 16;
            this.lblHinhThucXL.Text = "Chọn hình thức";
            // 
            // cbmHinhPhat
            // 
            this.cbmHinhPhat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbmHinhPhat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbmHinhPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmHinhPhat.FormattingEnabled = true;
            this.cbmHinhPhat.Location = new System.Drawing.Point(117, 113);
            this.cbmHinhPhat.Name = "cbmHinhPhat";
            this.cbmHinhPhat.Size = new System.Drawing.Size(314, 37);
            this.cbmHinhPhat.TabIndex = 9;
            this.cbmHinhPhat.SelectedIndexChanged += new System.EventHandler(this.cbmHinhPhat_SelectedIndexChanged);
            // 
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1576, 1142);
            this.Controls.Add(this.GbxXulyVP);
            this.Controls.Add(this.dgvBangNguoiMuon);
            this.Controls.Add(this.GboxTimkiem);
            this.Name = "frmTraSach";
            this.Text = "Tra sach";
            this.Load += new System.EventHandler(this.frmTraSach_Load);
            this.GboxTimkiem.ResumeLayout(false);
            this.GboxTimkiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangNguoiMuon)).EndInit();
            this.GbxXulyVP.ResumeLayout(false);
            this.GbxXulyVP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GboxTimkiem;
        private System.Windows.Forms.Label cboDocGia;
        private System.Windows.Forms.ComboBox cmbTendocgia;
        private System.Windows.Forms.Label lblTendocgia;
        private System.Windows.Forms.DataGridView dgvBangNguoiMuon;
        private System.Windows.Forms.Button btnXacNhanTra;
        private System.Windows.Forms.Button btnHuyChonTimTTMuon;
        private System.Windows.Forms.Button btnTimnguoimuon;
        private System.Windows.Forms.TextBox txtTimMaDGhoacMaPhieum;
        private System.Windows.Forms.RadioButton rdbMaphieumuon;
        private System.Windows.Forms.RadioButton rdbMadocgia;
        private System.Windows.Forms.GroupBox GbxXulyVP;
        private System.Windows.Forms.Button btnHuyChonHinhThucXL;
        private System.Windows.Forms.Button btnXacnhanHTXL;
        private System.Windows.Forms.Label lblHinhThucXL;
        private System.Windows.Forms.ComboBox cbmHinhPhat;
        private System.Windows.Forms.TextBox txtThongtinhinhphat;
        private System.Windows.Forms.Label lblThongtinphat;
        private System.Windows.Forms.Button btnExcel;
    }
}