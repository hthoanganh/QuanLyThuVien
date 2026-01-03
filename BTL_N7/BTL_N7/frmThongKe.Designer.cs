namespace BTL_N7
{
    partial class frmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbThongke = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.cmbTieuchi = new System.Windows.Forms.ComboBox();
            this.lblTIEUCHI = new System.Windows.Forms.Label();
            this.chartBookStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvThongke = new System.Windows.Forms.DataGridView();
            this.grbThongke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBookStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongke
            // 
            this.grbThongke.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grbThongke.Controls.Add(this.button1);
            this.grbThongke.Controls.Add(this.btnXacnhan);
            this.grbThongke.Controls.Add(this.cmbTieuchi);
            this.grbThongke.Controls.Add(this.lblTIEUCHI);
            this.grbThongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongke.Location = new System.Drawing.Point(50, 64);
            this.grbThongke.Name = "grbThongke";
            this.grbThongke.Size = new System.Drawing.Size(593, 378);
            this.grbThongke.TabIndex = 0;
            this.grbThongke.TabStop = false;
            this.grbThongke.Text = "THỐNG KÊ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(424, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 72);
            this.button1.TabIndex = 21;
            this.button1.Text = "Xuất Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacnhan.Location = new System.Drawing.Point(213, 253);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(125, 72);
            this.btnXacnhan.TabIndex = 3;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.UseVisualStyleBackColor = true;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // cmbTieuchi
            // 
            this.cmbTieuchi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTieuchi.FormattingEnabled = true;
            this.cmbTieuchi.Location = new System.Drawing.Point(67, 117);
            this.cmbTieuchi.Name = "cmbTieuchi";
            this.cmbTieuchi.Size = new System.Drawing.Size(482, 37);
            this.cmbTieuchi.TabIndex = 2;
            // 
            // lblTIEUCHI
            // 
            this.lblTIEUCHI.AutoSize = true;
            this.lblTIEUCHI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIEUCHI.Location = new System.Drawing.Point(31, 65);
            this.lblTIEUCHI.Name = "lblTIEUCHI";
            this.lblTIEUCHI.Size = new System.Drawing.Size(158, 25);
            this.lblTIEUCHI.TabIndex = 1;
            this.lblTIEUCHI.Text = "Chọn tiêu chí ";
            // 
            // chartBookStats
            // 
            this.chartBookStats.BackColor = System.Drawing.SystemColors.InactiveCaption;
            chartArea2.Name = "ChartArea1";
            this.chartBookStats.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBookStats.Legends.Add(legend2);
            this.chartBookStats.Location = new System.Drawing.Point(675, 38);
            this.chartBookStats.Name = "chartBookStats";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartBookStats.Series.Add(series2);
            this.chartBookStats.Size = new System.Drawing.Size(748, 460);
            this.chartBookStats.TabIndex = 1;
            this.chartBookStats.Text = "chart1";
            // 
            // dgvThongke
            // 
            this.dgvThongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongke.Location = new System.Drawing.Point(50, 521);
            this.dgvThongke.Name = "dgvThongke";
            this.dgvThongke.RowHeadersWidth = 82;
            this.dgvThongke.RowTemplate.Height = 33;
            this.dgvThongke.Size = new System.Drawing.Size(1273, 469);
            this.dgvThongke.TabIndex = 20;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1475, 1148);
            this.Controls.Add(this.dgvThongke);
            this.Controls.Add(this.chartBookStats);
            this.Controls.Add(this.grbThongke);
            this.Name = "frmThongKe";
            this.Text = "Thong ke";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.grbThongke.ResumeLayout(false);
            this.grbThongke.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBookStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongke;
        private System.Windows.Forms.Label lblTIEUCHI;
        private System.Windows.Forms.ComboBox cmbTieuchi;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBookStats;
        private System.Windows.Forms.DataGridView dgvThongke;
        private System.Windows.Forms.Button btnXacnhan;
        private System.Windows.Forms.Button button1;
    }
}