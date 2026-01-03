using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

namespace BTL_N7
{
    public partial class frmDocgia : Form
    {
        bool isLoading = false;
        public frmDocgia()
        {
            InitializeComponent();
        }

        private void frmDocgia_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCmbLop();
            LoadCmbKhoa();
            CauHinhCombobox();

            // --- PHÂN QUYỀN ---
            if (Session.QuyenHan == "NhanVien")
            {
                btnXoadocgia.Enabled = false; // Nhân viên không được xóa hồ sơ khách
            }

            // 1. Gỡ bỏ sự kiện trước khi can thiệp (Tránh sự kiện chạy ngầm gây lỗi)
            rdbMadocgia.CheckedChanged -= rdb_CheckedChanged;
            rdbTendocgia.CheckedChanged -= rdb_CheckedChanged;

            // --- KHẮC PHỤC LỖI TỰ CHỌN ---
            // Tạm thời tắt tính năng tự động check của Radio
            rdbMadocgia.AutoCheck = false;
            rdbTendocgia.AutoCheck = false;

            // Bây giờ bỏ chọn mới thực sự có tác dụng
            rdbMadocgia.Checked = false;
            rdbTendocgia.Checked = false;

            // Bật lại tính năng tự động để người dùng click được
            rdbMadocgia.AutoCheck = true;
            rdbTendocgia.AutoCheck = true;
            // ------------------------------------

            // Reset các điều khiển khác
            cmbTimtheolop.SelectedIndex = -1;
            txtTimdocgia.Text = "";
            txtTimdocgia.Enabled = false; // Đảm bảo Textbox MỜ

            // Gắn lại sự kiện
            rdbMadocgia.CheckedChanged += rdb_CheckedChanged;
            rdbTendocgia.CheckedChanged += rdb_CheckedChanged;

            // Chuyển focus sang bảng để nó không tự chọn nhầm Radio
            dgvdocgia.Focus();
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu có bất kỳ Radio nào được chọn -> BẬT ô nhập liệu (Sáng lên)
            if (rdbMadocgia.Checked || rdbTendocgia.Checked)
            {
                txtTimdocgia.Enabled = true;
                txtTimdocgia.Focus(); // Đưa trỏ chuột vào luôn cho tiện
            }
            else
            {
                // Nếu không chọn cái nào -> TẮT (Mờ đi)
                txtTimdocgia.Enabled = false;
            }
        }


        void LoadData()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                var list = db.DocGias.Select(d => new
                {
                    MaDocGia = d.MaDocGia,
                    TenDocGia = d.TenDocGia,
                    Khoa = d.Khoa,
                    Lop = d.Lop,
                    SDT = d.SoDienThoai,
                    DiaChi = d.DiaChi
                }).ToList();

                dgvdocgia.DataSource = list;

                // Tắt chế độ tự động chung
                dgvdocgia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // Ép cột Mã nhỏ lại
                dgvdocgia.Columns["MaDocGia"].Width = 80;
                dgvdocgia.Columns["TenDocGia"].Width = 200;

                // Các cột còn lại để kích thước vừa phải
                dgvdocgia.Columns["Khoa"].Width = 130;
                dgvdocgia.Columns["Lop"].Width = 120;
                dgvdocgia.Columns["SDT"].Width = 120;
                dgvdocgia.Columns["DiaChi"].Width = 150;

                // Đặt tên tiếng Việt 
                dgvdocgia.Columns["MaDocGia"].HeaderText = "Mã";
                dgvdocgia.Columns["TenDocGia"].HeaderText = "Họ và Tên";
                dgvdocgia.Columns["Khoa"].HeaderText = "Khoa";
                dgvdocgia.Columns["Lop"].HeaderText = "Lớp";
                dgvdocgia.Columns["SDT"].HeaderText = "SĐT";
                dgvdocgia.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            }
        }


        void CauHinhCombobox()
        {
            // Cho phép nhập khoa mới nếu chưa có trong danh sách
            cmbKHOA.DropDownStyle = ComboBoxStyle.DropDown;
        }



        // --- HÀM TẢI COMBOBOX LỚP ---
        void LoadCmbLop()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                // Bật cờ, đang nạp cấm tìm kiếm
                isLoading = true;

                cmbTimtheolop.DataSource = db.DocGias.Select(d => d.Lop).Distinct().ToList();
                cmbTimtheolop.SelectedIndex = -1;

                // Tắt cờ, cho phép tìm kiếm
                isLoading = false;
            }
        }

        void LoadCmbKhoa()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                // Lấy danh sách Khoa đang có trong DB 
                var listKhoa = db.DocGias.Select(d => d.Khoa)
                                         .Distinct()
                                         .Where(k => !string.IsNullOrEmpty(k)) 
                                         .ToList();

                // Nếu muốn luôn luôn có các khoa cơ bản dù DB chưa có ai
                // thì add tay vào list này trước khi gán. Ví dụ:
                if (!listKhoa.Contains("CNTT")) listKhoa.Add("CNTT");
                if (!listKhoa.Contains("Kinh Tế")) listKhoa.Add("Kinh Tế");

                // Gán vào ComboBox
                cmbKHOA.DataSource = listKhoa;
                cmbKHOA.SelectedIndex = -1; // Mặc định để trống
            }
        }

        private void grbDOCGIA_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemdocgia_Click(object sender, EventArgs e)
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                try
                {
                    DocGia d = new DocGia();
                    d.TenDocGia = txtTendocgia.Text;
                    d.Khoa = cmbKHOA.Text;
                    d.Lop = txtLOP.Text;     
                    d.SoDienThoai = txtSDT.Text;
                    d.DiaChi = txtDiachi.Text;

                    db.DocGias.Add(d);
                    db.SaveChanges();
                    MessageBox.Show("Thêm độc giả thành công!");
                    LoadData(); LoadCmbLop(); ResetControl(); LoadCmbKhoa();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnSuadocgia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMadocgia.Text)) return;
            using (var db = new QLTV_Nhom7Entities())
            {
                try
                {
                    int id = int.Parse(txtMadocgia.Text);
                    var d = db.DocGias.Find(id);
                    if (d != null)
                    {
                        d.TenDocGia = txtTendocgia.Text;
                        d.Khoa = cmbKHOA.Text;
                        d.Lop = txtLOP.Text;
                        d.SoDienThoai = txtSDT.Text;
                        d.DiaChi = txtDiachi.Text;

                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công!");
                        LoadData(); LoadCmbKhoa();ResetControl();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- 4. XÓA ---
        private void btnXoadocgia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMadocgia.Text)) return;
            if (MessageBox.Show("Xóa độc giả này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var db = new QLTV_Nhom7Entities())
                {
                    try
                    {
                        int id = int.Parse(txtMadocgia.Text);
                        var d = db.DocGias.Find(id);
                        if (d != null)
                        {
                            db.DocGias.Remove(d);
                            db.SaveChanges();
                            MessageBox.Show("Đã xóa!");
                            LoadData(); LoadCmbKhoa(); ResetControl();
                        }
                    }
                    catch { MessageBox.Show("Không thể xóa!"); }
                }
            }
        }


        private void btnTimdocgia_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu đầu vào
            string tuKhoa = txtTimdocgia.Text.Trim();
            string lopChon = (cmbTimtheolop.SelectedIndex != -1) ? cmbTimtheolop.SelectedValue.ToString() : null;

            // BẪY LỖI: Nếu không nhập gì và cũng không chọn lớp -> Báo lỗi
            if (string.IsNullOrEmpty(tuKhoa) && string.IsNullOrEmpty(lopChon))
            {
                MessageBox.Show("Vui lòng nhập Từ khóa hoặc chọn Lớp để tìm kiếm!", "Thiếu thông tin");
                return;
            }

            using (var db = new QLTV_Nhom7Entities())
            {
                var query = db.DocGias.AsQueryable();

                // 1. Xử lý tìm theo TỪ KHÓA (chỉ chạy khi ô text ĐANG SÁNG/Được nhập)
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    if (rdbTendocgia.Checked)
                    {
                        query = query.Where(d => d.TenDocGia.Contains(tuKhoa));
                    }
                    else if (rdbMadocgia.Checked)
                    {
                        if (int.TryParse(tuKhoa, out int id))
                        {
                            query = query.Where(d => d.MaDocGia == id);
                        }
                        else
                        {
                            MessageBox.Show("Mã độc giả phải là SỐ!", "Lỗi nhập liệu");
                            txtTimdocgia.Focus();
                            return;
                        }
                    }
                    // Nếu có nhập chữ mà chưa chọn Radio nào (trường hợp hiếm vì mình đã khóa text)
                    else if (string.IsNullOrEmpty(lopChon))
                    {
                        MessageBox.Show("Vui lòng chọn tìm theo Tên hay Mã!", "Chưa chọn tiêu chí");
                        return;
                    }
                }

                // 2. Xử lý tìm theo LỚP (kết hợp)
                if (!string.IsNullOrEmpty(lopChon))
                {
                    query = query.Where(d => d.Lop == lopChon);
                }

                // 3. Lấy kết quả
                var list = query.Select(d => new {
                    MaDocGia = d.MaDocGia,
                    TenDocGia = d.TenDocGia,
                    Khoa = d.Khoa,
                    Lop = d.Lop,
                    SDT = d.SoDienThoai,
                    DiaChi = d.DiaChi
                }).ToList();

                if (list.Count == 0)
                    MessageBox.Show("Không tìm thấy độc giả nào phù hợp!");

                dgvdocgia.DataSource = list;
            }
        }
            private void dgvdocgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvdocgia.Rows[e.RowIndex];
                try
                {
                    txtMadocgia.Text = row.Cells["MaDocGia"].Value?.ToString();
                    txtTendocgia.Text = row.Cells["TenDocGia"].Value?.ToString();
                    cmbKHOA.Text = row.Cells["Khoa"].Value?.ToString();
                    txtLOP.Text = row.Cells["Lop"].Value?.ToString();
                    txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                    txtDiachi.Text = row.Cells["DiaChi"].Value?.ToString();
                }
                catch { }
            }
        }
        void ResetControl()
        {
            txtMadocgia.Clear(); txtTendocgia.Clear(); cmbKHOA.SelectedIndex = -1; txtLOP.Clear(); txtSDT.Clear(); txtDiachi.Clear();
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show();
            await Task.Delay(1000);

            try
            {
                XuatExcelVIP(dgvdocgia, "DANH SÁCH THÔNG TIN ĐỘC GIẢ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                frm.Close();
            }

        }


        private void XuatExcelVIP(DataGridView dgv, string tieuDe)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "KhoSach";

                // HEADER
                int colCount = dgv.Columns.Count;
                Excel.Range head = worksheet.get_Range("A1", GetExcelColumnName(colCount) + "1");
                head.MergeCells = true;
                head.Value2 = tieuDe.ToUpper();
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = 18;
                head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Excel.Range info = worksheet.get_Range("A2", GetExcelColumnName(colCount) + "2");
                info.MergeCells = true;
                info.Value2 = $"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                info.Font.Name = "Times New Roman";
                info.Font.Size = 11;
                info.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // TIÊU ĐỀ CỘT
                int rowStart = 4;
                for (int i = 0; i < colCount; i++)
                {
                    worksheet.Cells[rowStart, i + 1] = dgv.Columns[i].HeaderText;
                }

                Excel.Range rowHead = worksheet.get_Range("A4", GetExcelColumnName(colCount) + "4");
                rowHead.Font.Bold = true;
                rowHead.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rowHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                rowHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // DỮ LIỆU
                object[,] dataArr = new object[dgv.Rows.Count, colCount];
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        var val = dgv.Rows[i].Cells[j].Value;
                        dataArr[i, j] = val != null ? val.ToString() : "";
                    }
                }

                int rowEnd = rowStart + dgv.Rows.Count;
                Excel.Range dataRange = worksheet.get_Range("A5", GetExcelColumnName(colCount) + rowEnd);
                dataRange.Value2 = dataArr;
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // CĂN CHỈNH
                worksheet.Columns.AutoFit();
                for (int i = 1; i <= colCount; i++)
                {
                    Excel.Range col = (Excel.Range)worksheet.Columns[i];
                    col.ColumnWidth = (double)col.ColumnWidth + 5;
                }

                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
            finally
            {
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        private string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";
            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }
            return columnName;
        }

        private void ExportToExcel(DataGridView g)
        {
            if (g.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            try
            {
                app obj = new app();
                obj.Application.Workbooks.Add(Type.Missing);
                obj.Columns.ColumnWidth = 25;

                // 1. Lấy Header (Tên cột)
                for (int i = 1; i < g.Columns.Count + 1; i++)
                {
                    obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
                }

                // 2. Đổ dữ liệu vào
                for (int i = 0; i < g.Rows.Count; i++)
                {
                    for (int j = 0; j < g.Columns.Count; j++)
                    {
                        if (g.Rows[i].Cells[j].Value != null)
                        {
                            obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // 3. Mở file Excel lên
                obj.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message + "\n(Máy bạn cần cài Microsoft Excel để dùng tính năng này)");
            }
        }

        private void txtTendocgia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Gỡ sự kiện tạm thời
            rdbMadocgia.CheckedChanged -= rdb_CheckedChanged;
            rdbTendocgia.CheckedChanged -= rdb_CheckedChanged;

            // Reset dữ liệu nhập
            txtTimdocgia.Clear();
            cmbTimtheolop.SelectedIndex = -1;

           
            rdbMadocgia.AutoCheck = false;
            rdbTendocgia.AutoCheck = false;

            rdbMadocgia.Checked = false;
            rdbTendocgia.Checked = false;

            rdbMadocgia.AutoCheck = true;
            rdbTendocgia.AutoCheck = true;
            

            // Khóa textbox
            txtTimdocgia.Enabled = false;

            // Gắn lại sự kiện
            rdbMadocgia.CheckedChanged += rdb_CheckedChanged;
            rdbTendocgia.CheckedChanged += rdb_CheckedChanged;

            LoadData();
        }

        private void cmbTimtheolop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            // Nếu người dùng chọn 1 lớp thật thì bấm nút tìm luôn
            if (cmbTimtheolop.SelectedIndex != -1)
            {
                btnTimdocgia.PerformClick();
            }
        }
    }
}
