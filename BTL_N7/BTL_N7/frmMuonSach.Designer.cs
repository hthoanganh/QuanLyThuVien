namespace BTL_N7
{
    partial class frmMuonSach
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
            this.cmbTendocgia = new System.Windows.Forms.ComboBox();
            this.GboxDocGia = new System.Windows.Forms.GroupBox();
            this.cboDocGia = new System.Windows.Forms.Label();
            this.lblHantra = new System.Windows.Forms.Label();
            this.dtpHanTra = new System.Windows.Forms.DateTimePicker();
            this.lblNgaymuon = new System.Windows.Forms.Label();
            this.dtpNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemmuon = new System.Windows.Forms.Button();
            this.lblChonsach = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.lblSoluong = new System.Windows.Forms.Label();
            this.cbmChonsach = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvChiTietMuon = new System.Windows.Forms.DataGridView();
            this.btnLuuphieu = new System.Windows.Forms.Button();
            this.GboxDocGia.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTendocgia
            // 
            this.cmbTendocgia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTendocgia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTendocgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTendocgia.FormattingEnabled = true;
            this.cmbTendocgia.Location = new System.Drawing.Point(89, 117);
            this.cmbTendocgia.Name = "cmbTendocgia";
            this.cmbTendocgia.Size = new System.Drawing.Size(297, 39);
            this.cmbTendocgia.TabIndex = 9;
            // 
            // GboxDocGia
            // 
            this.GboxDocGia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.GboxDocGia.Controls.Add(this.cboDocGia);
            this.GboxDocGia.Controls.Add(this.lblHantra);
            this.GboxDocGia.Controls.Add(this.dtpHanTra);
            this.GboxDocGia.Controls.Add(this.lblNgaymuon);
            this.GboxDocGia.Controls.Add(this.dtpNgayMuon);
            this.GboxDocGia.Controls.Add(this.cmbTendocgia);
            this.GboxDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GboxDocGia.Location = new System.Drawing.Point(23, 36);
            this.GboxDocGia.Name = "GboxDocGia";
            this.GboxDocGia.Size = new System.Drawing.Size(628, 397);
            this.GboxDocGia.TabIndex = 10;
            this.GboxDocGia.TabStop = false;
            this.GboxDocGia.Text = "THÔNG TIN MƯỢN";
            // 
            // cboDocGia
            // 
            this.cboDocGia.AutoSize = true;
            this.cboDocGia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocGia.Location = new System.Drawing.Point(45, 61);
            this.cboDocGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(136, 29);
            this.cboDocGia.TabIndex = 16;
            this.cboDocGia.Text = "Chọn độc giả";
            // 
            // lblHantra
            // 
            this.lblHantra.AutoSize = true;
            this.lblHantra.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHantra.Location = new System.Drawing.Point(45, 279);
            this.lblHantra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHantra.Name = "lblHantra";
            this.lblHantra.Size = new System.Drawing.Size(81, 29);
            this.lblHantra.TabIndex = 15;
            this.lblHantra.Text = "Hạn trả";
            // 
            // dtpHanTra
            // 
            this.dtpHanTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHanTra.Location = new System.Drawing.Point(182, 279);
            this.dtpHanTra.Name = "dtpHanTra";
            this.dtpHanTra.Size = new System.Drawing.Size(297, 31);
            this.dtpHanTra.TabIndex = 14;
            // 
            // lblNgaymuon
            // 
            this.lblNgaymuon.AutoSize = true;
            this.lblNgaymuon.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaymuon.Location = new System.Drawing.Point(45, 212);
            this.lblNgaymuon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgaymuon.Name = "lblNgaymuon";
            this.lblNgaymuon.Size = new System.Drawing.Size(117, 29);
            this.lblNgaymuon.TabIndex = 13;
            this.lblNgaymuon.Text = "Ngày mượn";
            // 
            // dtpNgayMuon
            // 
            this.dtpNgayMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayMuon.Location = new System.Drawing.Point(182, 212);
            this.dtpNgayMuon.Name = "dtpNgayMuon";
            this.dtpNgayMuon.Size = new System.Drawing.Size(297, 31);
            this.dtpNgayMuon.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.btnThemmuon);
            this.groupBox1.Controls.Add(this.lblChonsach);
            this.groupBox1.Controls.Add(this.txtSoluong);
            this.groupBox1.Controls.Add(this.lblSoluong);
            this.groupBox1.Controls.Add(this.cbmChonsach);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(764, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 397);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " SÁCH";
            // 
            // btnThemmuon
            // 
            this.btnThemmuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemmuon.Location = new System.Drawing.Point(371, 279);
            this.btnThemmuon.Name = "btnThemmuon";
            this.btnThemmuon.Size = new System.Drawing.Size(111, 52);
            this.btnThemmuon.TabIndex = 17;
            this.btnThemmuon.Text = "Thêm";
            this.btnThemmuon.UseVisualStyleBackColor = true;
            this.btnThemmuon.Click += new System.EventHandler(this.btnThemmuon_Click);
            // 
            // lblChonsach
            // 
            this.lblChonsach.AutoSize = true;
            this.lblChonsach.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChonsach.Location = new System.Drawing.Point(33, 89);
            this.lblChonsach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChonsach.Name = "lblChonsach";
            this.lblChonsach.Size = new System.Drawing.Size(110, 29);
            this.lblChonsach.TabIndex = 16;
            this.lblChonsach.Text = "Chọn sách";
            // 
            // txtSoluong
            // 
            this.txtSoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoluong.Location = new System.Drawing.Point(183, 167);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(214, 38);
            this.txtSoluong.TabIndex = 11;
            // 
            // lblSoluong
            // 
            this.lblSoluong.AutoSize = true;
            this.lblSoluong.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoluong.Location = new System.Drawing.Point(33, 167);
            this.lblSoluong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoluong.Name = "lblSoluong";
            this.lblSoluong.Size = new System.Drawing.Size(98, 29);
            this.lblSoluong.TabIndex = 10;
            this.lblSoluong.Text = "Số lượng";
            // 
            // cbmChonsach
            // 
            this.cbmChonsach.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbmChonsach.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbmChonsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmChonsach.FormattingEnabled = true;
            this.cbmChonsach.Location = new System.Drawing.Point(183, 85);
            this.cbmChonsach.Name = "cbmChonsach";
            this.cbmChonsach.Size = new System.Drawing.Size(334, 39);
            this.cbmChonsach.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(176, 350);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 29);
            this.label6.TabIndex = 8;
            // 
            // dgvChiTietMuon
            // 
            this.dgvChiTietMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietMuon.Location = new System.Drawing.Point(23, 494);
            this.dgvChiTietMuon.Name = "dgvChiTietMuon";
            this.dgvChiTietMuon.RowHeadersWidth = 82;
            this.dgvChiTietMuon.RowTemplate.Height = 33;
            this.dgvChiTietMuon.Size = new System.Drawing.Size(1360, 453);
            this.dgvChiTietMuon.TabIndex = 19;
            // 
            // btnLuuphieu
            // 
            this.btnLuuphieu.Location = new System.Drawing.Point(1052, 983);
            this.btnLuuphieu.Name = "btnLuuphieu";
            this.btnLuuphieu.Size = new System.Drawing.Size(125, 70);
            this.btnLuuphieu.TabIndex = 18;
            this.btnLuuphieu.Text = "Lưu";
            this.btnLuuphieu.UseVisualStyleBackColor = true;
            this.btnLuuphieu.Click += new System.EventHandler(this.btnLuuphieu_Click);
            // 
            // frmMuonSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 1100);
            this.Controls.Add(this.btnLuuphieu);
            this.Controls.Add(this.dgvChiTietMuon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GboxDocGia);
            this.Name = "frmMuonSach";
            this.Text = "Muon sach";
            this.Load += new System.EventHandler(this.frmMuonSach_Load);
            this.GboxDocGia.ResumeLayout(false);
            this.GboxDocGia.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMuon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTendocgia;
        private System.Windows.Forms.GroupBox GboxDocGia;
        private System.Windows.Forms.Label lblNgaymuon;
        private System.Windows.Forms.DateTimePicker dtpNgayMuon;
        private System.Windows.Forms.Label lblHantra;
        private System.Windows.Forms.DateTimePicker dtpHanTra;
        private System.Windows.Forms.Label cboDocGia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblChonsach;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label lblSoluong;
        private System.Windows.Forms.ComboBox cbmChonsach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThemmuon;
        private System.Windows.Forms.DataGridView dgvChiTietMuon;
        private System.Windows.Forms.Button btnLuuphieu;
    }
}