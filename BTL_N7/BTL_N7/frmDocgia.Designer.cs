namespace BTL_N7
{
    partial class frmDocgia
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
            this.grbTIMKIEMSACH = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lbltimtheolop = new System.Windows.Forms.Label();
            this.cmbTimtheolop = new System.Windows.Forms.ComboBox();
            this.btnTimdocgia = new System.Windows.Forms.Button();
            this.txtTimdocgia = new System.Windows.Forms.TextBox();
            this.rdbTendocgia = new System.Windows.Forms.RadioButton();
            this.rdbMadocgia = new System.Windows.Forms.RadioButton();
            this.grbDOCGIA = new System.Windows.Forms.GroupBox();
            this.lblKHOA = new System.Windows.Forms.Label();
            this.cmbKHOA = new System.Windows.Forms.ComboBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.lblDiachi = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnXoadocgia = new System.Windows.Forms.Button();
            this.btnSuadocgia = new System.Windows.Forms.Button();
            this.btnThemdocgia = new System.Windows.Forms.Button();
            this.txtLOP = new System.Windows.Forms.TextBox();
            this.txtTendocgia = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtMadocgia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblTendocgia = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblMadocgia = new System.Windows.Forms.Label();
            this.dgvdocgia = new System.Windows.Forms.DataGridView();
            this.grbTIMKIEMSACH.SuspendLayout();
            this.grbDOCGIA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdocgia)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTIMKIEMSACH
            // 
            this.grbTIMKIEMSACH.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grbTIMKIEMSACH.Controls.Add(this.btnHuy);
            this.grbTIMKIEMSACH.Controls.Add(this.lbltimtheolop);
            this.grbTIMKIEMSACH.Controls.Add(this.cmbTimtheolop);
            this.grbTIMKIEMSACH.Controls.Add(this.btnTimdocgia);
            this.grbTIMKIEMSACH.Controls.Add(this.txtTimdocgia);
            this.grbTIMKIEMSACH.Controls.Add(this.rdbTendocgia);
            this.grbTIMKIEMSACH.Controls.Add(this.rdbMadocgia);
            this.grbTIMKIEMSACH.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTIMKIEMSACH.Location = new System.Drawing.Point(1081, 101);
            this.grbTIMKIEMSACH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbTIMKIEMSACH.Name = "grbTIMKIEMSACH";
            this.grbTIMKIEMSACH.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbTIMKIEMSACH.Size = new System.Drawing.Size(685, 375);
            this.grbTIMKIEMSACH.TabIndex = 5;
            this.grbTIMKIEMSACH.TabStop = false;
            this.grbTIMKIEMSACH.Text = "Tìm kiếm ";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(380, 272);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 53);
            this.btnHuy.TabIndex = 23;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lbltimtheolop
            // 
            this.lbltimtheolop.AutoSize = true;
            this.lbltimtheolop.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimtheolop.Location = new System.Drawing.Point(53, 186);
            this.lbltimtheolop.Name = "lbltimtheolop";
            this.lbltimtheolop.Size = new System.Drawing.Size(126, 24);
            this.lbltimtheolop.TabIndex = 5;
            this.lbltimtheolop.Text = "Tìm theo lớp";
            // 
            // cmbTimtheolop
            // 
            this.cmbTimtheolop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTimtheolop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTimtheolop.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimtheolop.FormattingEnabled = true;
            this.cmbTimtheolop.Location = new System.Drawing.Point(252, 177);
            this.cmbTimtheolop.Name = "cmbTimtheolop";
            this.cmbTimtheolop.Size = new System.Drawing.Size(314, 40);
            this.cmbTimtheolop.TabIndex = 4;
            this.cmbTimtheolop.SelectedIndexChanged += new System.EventHandler(this.cmbTimtheolop_SelectedIndexChanged);
            // 
            // btnTimdocgia
            // 
            this.btnTimdocgia.Font = new System.Drawing.Font("Arial Narrow", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimdocgia.Location = new System.Drawing.Point(536, 273);
            this.btnTimdocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimdocgia.Name = "btnTimdocgia";
            this.btnTimdocgia.Size = new System.Drawing.Size(112, 52);
            this.btnTimdocgia.TabIndex = 3;
            this.btnTimdocgia.Text = "Tìm";
            this.btnTimdocgia.UseVisualStyleBackColor = true;
            this.btnTimdocgia.Click += new System.EventHandler(this.btnTimdocgia_Click);
            // 
            // txtTimdocgia
            // 
            this.txtTimdocgia.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimdocgia.Location = new System.Drawing.Point(252, 61);
            this.txtTimdocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimdocgia.Name = "txtTimdocgia";
            this.txtTimdocgia.Size = new System.Drawing.Size(314, 39);
            this.txtTimdocgia.TabIndex = 2;
            // 
            // rdbTendocgia
            // 
            this.rdbTendocgia.AutoSize = true;
            this.rdbTendocgia.Font = new System.Drawing.Font("Arial Narrow", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTendocgia.Location = new System.Drawing.Point(57, 115);
            this.rdbTendocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbTendocgia.Name = "rdbTendocgia";
            this.rdbTendocgia.Size = new System.Drawing.Size(141, 29);
            this.rdbTendocgia.TabIndex = 1;
            this.rdbTendocgia.TabStop = true;
            this.rdbTendocgia.Text = "Tên độc giả";
            this.rdbTendocgia.UseVisualStyleBackColor = true;
            // 
            // rdbMadocgia
            // 
            this.rdbMadocgia.AutoSize = true;
            this.rdbMadocgia.Font = new System.Drawing.Font("Arial Narrow", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMadocgia.Location = new System.Drawing.Point(57, 61);
            this.rdbMadocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbMadocgia.Name = "rdbMadocgia";
            this.rdbMadocgia.Size = new System.Drawing.Size(135, 29);
            this.rdbMadocgia.TabIndex = 0;
            this.rdbMadocgia.TabStop = true;
            this.rdbMadocgia.Text = "Mã độc giả";
            this.rdbMadocgia.UseVisualStyleBackColor = true;
            // 
            // grbDOCGIA
            // 
            this.grbDOCGIA.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grbDOCGIA.Controls.Add(this.lblKHOA);
            this.grbDOCGIA.Controls.Add(this.cmbKHOA);
            this.grbDOCGIA.Controls.Add(this.txtDiachi);
            this.grbDOCGIA.Controls.Add(this.lblDiachi);
            this.grbDOCGIA.Controls.Add(this.btnExcel);
            this.grbDOCGIA.Controls.Add(this.btnXoadocgia);
            this.grbDOCGIA.Controls.Add(this.btnSuadocgia);
            this.grbDOCGIA.Controls.Add(this.btnThemdocgia);
            this.grbDOCGIA.Controls.Add(this.txtLOP);
            this.grbDOCGIA.Controls.Add(this.txtTendocgia);
            this.grbDOCGIA.Controls.Add(this.txtSDT);
            this.grbDOCGIA.Controls.Add(this.txtMadocgia);
            this.grbDOCGIA.Controls.Add(this.label6);
            this.grbDOCGIA.Controls.Add(this.lblLop);
            this.grbDOCGIA.Controls.Add(this.lblTendocgia);
            this.grbDOCGIA.Controls.Add(this.lblSDT);
            this.grbDOCGIA.Controls.Add(this.lblMadocgia);
            this.grbDOCGIA.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDOCGIA.Location = new System.Drawing.Point(22, 42);
            this.grbDOCGIA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDOCGIA.Name = "grbDOCGIA";
            this.grbDOCGIA.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbDOCGIA.Size = new System.Drawing.Size(1022, 434);
            this.grbDOCGIA.TabIndex = 6;
            this.grbDOCGIA.TabStop = false;
            this.grbDOCGIA.Text = "THÔNG TIN ĐỘC GIA";
            this.grbDOCGIA.Enter += new System.EventHandler(this.grbDOCGIA_Enter);
            // 
            // lblKHOA
            // 
            this.lblKHOA.AutoSize = true;
            this.lblKHOA.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKHOA.Location = new System.Drawing.Point(513, 239);
            this.lblKHOA.Name = "lblKHOA";
            this.lblKHOA.Size = new System.Drawing.Size(59, 24);
            this.lblKHOA.TabIndex = 17;
            this.lblKHOA.Text = "Khoa";
            // 
            // cmbKHOA
            // 
            this.cmbKHOA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKHOA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKHOA.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKHOA.FormattingEnabled = true;
            this.cmbKHOA.Location = new System.Drawing.Point(660, 229);
            this.cmbKHOA.Name = "cmbKHOA";
            this.cmbKHOA.Size = new System.Drawing.Size(314, 40);
            this.cmbKHOA.TabIndex = 16;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiachi.Location = new System.Drawing.Point(660, 145);
            this.txtDiachi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(309, 39);
            this.txtDiachi.TabIndex = 15;
            // 
            // lblDiachi
            // 
            this.lblDiachi.AutoSize = true;
            this.lblDiachi.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiachi.Location = new System.Drawing.Point(512, 151);
            this.lblDiachi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiachi.Name = "lblDiachi";
            this.lblDiachi.Size = new System.Drawing.Size(76, 29);
            this.lblDiachi.TabIndex = 14;
            this.lblDiachi.Text = "Địa chỉ";
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(829, 333);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(138, 61);
            this.btnExcel.TabIndex = 13;
            this.btnExcel.Text = "Xuất Ecxel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnXoadocgia
            // 
            this.btnXoadocgia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoadocgia.Location = new System.Drawing.Point(660, 333);
            this.btnXoadocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXoadocgia.Name = "btnXoadocgia";
            this.btnXoadocgia.Size = new System.Drawing.Size(109, 61);
            this.btnXoadocgia.TabIndex = 12;
            this.btnXoadocgia.Text = "Xóa";
            this.btnXoadocgia.UseVisualStyleBackColor = true;
            // 
            // btnSuadocgia
            // 
            this.btnSuadocgia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuadocgia.Location = new System.Drawing.Point(491, 333);
            this.btnSuadocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSuadocgia.Name = "btnSuadocgia";
            this.btnSuadocgia.Size = new System.Drawing.Size(109, 61);
            this.btnSuadocgia.TabIndex = 11;
            this.btnSuadocgia.Text = "Sửa";
            this.btnSuadocgia.UseVisualStyleBackColor = true;
            this.btnSuadocgia.Click += new System.EventHandler(this.btnSuadocgia_Click);
            // 
            // btnThemdocgia
            // 
            this.btnThemdocgia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemdocgia.Location = new System.Drawing.Point(319, 333);
            this.btnThemdocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThemdocgia.Name = "btnThemdocgia";
            this.btnThemdocgia.Size = new System.Drawing.Size(114, 61);
            this.btnThemdocgia.TabIndex = 10;
            this.btnThemdocgia.Text = "Thêm";
            this.btnThemdocgia.UseVisualStyleBackColor = true;
            this.btnThemdocgia.Click += new System.EventHandler(this.btnThemdocgia_Click);
            // 
            // txtLOP
            // 
            this.txtLOP.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLOP.Location = new System.Drawing.Point(178, 239);
            this.txtLOP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLOP.Name = "txtLOP";
            this.txtLOP.Size = new System.Drawing.Size(274, 39);
            this.txtLOP.TabIndex = 9;
            // 
            // txtTendocgia
            // 
            this.txtTendocgia.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTendocgia.Location = new System.Drawing.Point(178, 158);
            this.txtTendocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTendocgia.Name = "txtTendocgia";
            this.txtTendocgia.Size = new System.Drawing.Size(274, 39);
            this.txtTendocgia.TabIndex = 8;
            this.txtTendocgia.TextChanged += new System.EventHandler(this.txtTendocgia_TextChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(658, 59);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(309, 39);
            this.txtSDT.TabIndex = 7;
            // 
            // txtMadocgia
            // 
            this.txtMadocgia.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMadocgia.Location = new System.Drawing.Point(182, 59);
            this.txtMadocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMadocgia.Name = "txtMadocgia";
            this.txtMadocgia.ReadOnly = true;
            this.txtMadocgia.Size = new System.Drawing.Size(232, 39);
            this.txtMadocgia.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(897, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 32);
            this.label6.TabIndex = 5;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(32, 245);
            this.lblLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(49, 29);
            this.lblLop.TabIndex = 3;
            this.lblLop.Text = "Lớp";
            // 
            // lblTendocgia
            // 
            this.lblTendocgia.AutoSize = true;
            this.lblTendocgia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTendocgia.Location = new System.Drawing.Point(32, 163);
            this.lblTendocgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTendocgia.Name = "lblTendocgia";
            this.lblTendocgia.Size = new System.Drawing.Size(120, 29);
            this.lblTendocgia.TabIndex = 2;
            this.lblTendocgia.Text = "Tên độc giả";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(501, 65);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(134, 29);
            this.lblSDT.TabIndex = 1;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblMadocgia
            // 
            this.lblMadocgia.AutoSize = true;
            this.lblMadocgia.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadocgia.Location = new System.Drawing.Point(32, 69);
            this.lblMadocgia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMadocgia.Name = "lblMadocgia";
            this.lblMadocgia.Size = new System.Drawing.Size(114, 29);
            this.lblMadocgia.TabIndex = 0;
            this.lblMadocgia.Text = "Mã độc giả";
            // 
            // dgvdocgia
            // 
            this.dgvdocgia.AllowUserToAddRows = false;
            this.dgvdocgia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdocgia.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvdocgia.Location = new System.Drawing.Point(22, 497);
            this.dgvdocgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvdocgia.MultiSelect = false;
            this.dgvdocgia.Name = "dgvdocgia";
            this.dgvdocgia.ReadOnly = true;
            this.dgvdocgia.RowHeadersWidth = 51;
            this.dgvdocgia.RowTemplate.Height = 24;
            this.dgvdocgia.Size = new System.Drawing.Size(1744, 700);
            this.dgvdocgia.TabIndex = 7;
            this.dgvdocgia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdocgia_CellClick);
            // 
            // frmDocgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1780, 1211);
            this.Controls.Add(this.dgvdocgia);
            this.Controls.Add(this.grbDOCGIA);
            this.Controls.Add(this.grbTIMKIEMSACH);
            this.Name = "frmDocgia";
            this.Text = "Doc gia";
            this.Load += new System.EventHandler(this.frmDocgia_Load);
            this.grbTIMKIEMSACH.ResumeLayout(false);
            this.grbTIMKIEMSACH.PerformLayout();
            this.grbDOCGIA.ResumeLayout(false);
            this.grbDOCGIA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdocgia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTIMKIEMSACH;
        private System.Windows.Forms.Label lbltimtheolop;
        private System.Windows.Forms.ComboBox cmbTimtheolop;
        private System.Windows.Forms.Button btnTimdocgia;
        private System.Windows.Forms.TextBox txtTimdocgia;
        private System.Windows.Forms.RadioButton rdbTendocgia;
        private System.Windows.Forms.RadioButton rdbMadocgia;
        private System.Windows.Forms.GroupBox grbDOCGIA;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Label lblDiachi;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnXoadocgia;
        private System.Windows.Forms.Button btnSuadocgia;
        private System.Windows.Forms.Button btnThemdocgia;
        private System.Windows.Forms.TextBox txtLOP;
        private System.Windows.Forms.TextBox txtTendocgia;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtMadocgia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblTendocgia;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblMadocgia;
        private System.Windows.Forms.DataGridView dgvdocgia;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblKHOA;
        private System.Windows.Forms.ComboBox cmbKHOA;
    }
}