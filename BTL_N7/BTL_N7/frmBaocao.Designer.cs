namespace BTL_N7
{
    partial class frmBaocao
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dtThongKeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBaoCao = new BTL_N7.dsBaoCao();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnTaidl = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtNguoilap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtThongKeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBaoCao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtThongKeBindingSource
            // 
            this.dtThongKeBindingSource.DataMember = "dtThongKe";
            this.dtThongKeBindingSource.DataSource = this.dsBaoCao;
            // 
            // dsBaoCao
            // 
            this.dsBaoCao.DataSetName = "dsBaoCao";
            this.dsBaoCao.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.btnXuat);
            this.groupBox1.Controls.Add(this.btnTaidl);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(51, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 154);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BÁO CÁO";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Location = new System.Drawing.Point(239, 58);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(132, 65);
            this.btnXuat.TabIndex = 1;
            this.btnXuat.Text = "Xuất Excel";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnTaidl
            // 
            this.btnTaidl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaidl.Location = new System.Drawing.Point(40, 58);
            this.btnTaidl.Name = "btnTaidl";
            this.btnTaidl.Size = new System.Drawing.Size(144, 65);
            this.btnTaidl.TabIndex = 0;
            this.btnTaidl.Text = "Tải báo cáo";
            this.btnTaidl.UseVisualStyleBackColor = true;
            this.btnTaidl.Click += new System.EventHandler(this.btnTaidl_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsBaoCao";
            reportDataSource1.Value = this.dtThongKeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_N7.rptBaocao.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(37, 222);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1285, 984);
            this.reportViewer1.TabIndex = 4;
            // 
            // txtNguoilap
            // 
            this.txtNguoilap.Location = new System.Drawing.Point(925, 1249);
            this.txtNguoilap.Name = "txtNguoilap";
            this.txtNguoilap.Size = new System.Drawing.Size(256, 31);
            this.txtNguoilap.TabIndex = 5;
            // 
            // frmBaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1367, 1379);
            this.Controls.Add(this.txtNguoilap);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBaocao";
            this.Text = "Baocao";
            this.Load += new System.EventHandler(this.frmBaocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtThongKeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBaoCao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnTaidl;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dtThongKeBindingSource;
        private dsBaoCao dsBaoCao;
        private System.Windows.Forms.TextBox txtNguoilap;
    }
}