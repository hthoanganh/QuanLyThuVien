using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq; 
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

namespace BTL_N7
{

    public partial class frmKhosach : Form
    {
        bool isLoading = false;
        public frmKhosach()
        {

            InitializeComponent();

            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            LoadComboboxTheLoai();
            PhanQuyenChucNang();

        }


        void PhanQuyenChucNang()
        {
            // 1. QUYỀN ĐỘC GIẢ (Chỉ xem)
            if (Session.QuyenHan == "DocGia")
            {
                // Ẩn toàn bộ nút thao tác
                btnThemsach.Visible = false;
                btnSuasach.Visible = false;
                btnXoasach.Visible = false;
                btnExcel.Visible = false; // Độc giả không cần xuất báo cáo

                // Khóa các ô nhập liệu (Chỉ cho nhìn)
                txtTensach.Enabled = false;
                txtTacgia.Enabled = false;
                txtNXB.Enabled = false;
                txtNamxuatban.Enabled = false;
                txtSoluong.Enabled = false;
                combTHELOAI.Enabled = false;

                // Đổi tiêu đề GroupBox cho hợp lý
                grbKHOSACH.Text = "THÔNG TIN CHI TIẾT SÁCH";
            }

            // 2. QUYỀN NHÂN VIÊN (Không được xóa)
            if (Session.QuyenHan == "NhanVien")
            {
                btnXoasach.Enabled = false; // Làm mờ nút xóa
            }
        }


        private void LoadData()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                var list = db.Saches.Select(s => new {
                    MaSach = s.MaSach,
                    TenSach = s.TenSach,
                    TacGia = s.TacGia,     // Cột Tác Giả
                    TheLoai = s.TheLoai,
                    NhaXB = s.NhaXB,
                    NamXB = s.NamXB,
                    SoLuong = s.SoLuong    // Cột Số Lượng
                }).ToList();

                dgvBooks.DataSource = list;

                dgvBooks.Columns["MaSach"].Width = 60;

                dgvBooks.Columns["TacGia"].Width = 110;
                dgvBooks.Columns["TheLoai"].Width = 70;
                dgvBooks.Columns["NhaXB"].Width = 90;
                dgvBooks.Columns["NamXB"].Width = 70;
                dgvBooks.Columns["SoLuong"].Width = 70;
                dgvBooks.Columns["TenSach"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



                dgvBooks.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvBooks.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvBooks.Columns["TacGia"].HeaderText = "Tác Giả";
                dgvBooks.Columns["TheLoai"].HeaderText = "Thể loại";
                dgvBooks.Columns["NhaXB"].HeaderText = "Nhà cuất bản";
                dgvBooks.Columns["NamXB"].HeaderText = "Năm xuất bản";
                dgvBooks.Columns["SoLuong"].HeaderText = "Số Lượng";
            }
        }

        void LoadComboboxTheLoai()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                var listTheLoai = db.Saches
                                    .Select(s => s.TheLoai)
                                    .Distinct()
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .ToList();

                // Đổ vào ô nhập liệu
                combTHELOAI.DataSource = new List<string>(listTheLoai);
                combTHELOAI.SelectedIndex = -1;

                // Bật cờ lên: Đang nạp, cấm tìm kiếm
                isLoading = true;

                cmbTheloai.DataSource = new List<string>(listTheLoai);
                cmbTheloai.SelectedIndex = -1; // Chọn về rỗng

                // Tắt cờ, cho phép tìm kiếm lại
                isLoading = false;

               
            }
        }

        private void frmKhosach_Load(object sender, EventArgs e)
        {
            
            LoadComboboxTheLoai(); 
        }

        private void label5_Click(object sender, EventArgs e)// dòng này bỏ
        {

        }

        private void frmdocgia_Load(object sender, EventArgs e)// dòng này bỏ
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)// dòng này bỏ
        {

        }

        private void txtLUU_Click(object sender, EventArgs e)// bỏ
        {

        }

        private async void btnThemsach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTensach.Text))
            {
                MessageBox.Show("Chưa nhập tên sách!");
                return;
            }

            using (var db = new QLTV_Nhom7Entities())
            {
                try
                {
                    Sach s = new Sach();
                    s.TenSach = txtTensach.Text;
                    s.TacGia = txtTacgia.Text;       // Dùng đúng txtTacgia
                    s.NhaXB = txtNXB.Text;           // Dùng đúng txtNXB cho Nhà Xuất Bản
                    s.TheLoai = combTHELOAI.Text.Trim();

                    // Xử lý Năm xuất bản
                    if (int.TryParse(txtNamxuatban.Text, out int nam)) s.NamXB = nam;
                    else s.NamXB = DateTime.Now.Year;

                    // Xử lý Số lượng
                    if (int.TryParse(txtSoluong.Text, out int sl)) s.SoLuong = sl; // Dùng đúng txtSoluong
                    else s.SoLuong = 0;

                    db.Saches.Add(s);
                    db.SaveChanges();

                    MessageBox.Show("Thêm sách thành công!");
                    LoadData();
                    ClearInput();
                    LoadComboboxTheLoai();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }

        }

        private async void btnSuasach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMasach.Text)) return;

            using (var db = new QLTV_Nhom7Entities())
            {
                try
                {
                    int id = int.Parse(txtMasach.Text);
                    var s = db.Saches.Find(id);
                    if (s != null)
                    {
                        s.TenSach = txtTensach.Text;
                        s.TacGia = txtTacgia.Text;
                        s.NhaXB = txtNXB.Text;
                        s.TheLoai = combTHELOAI.Text;

                        if (int.TryParse(txtNamxuatban.Text, out int nam)) s.NamXB = nam;
                        if (int.TryParse(txtSoluong.Text, out int sl)) s.SoLuong = sl;

                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công!");
                        LoadData();
                        ClearInput();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private async void btnXoasach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMasach.Text)) return;
            if (MessageBox.Show("Xóa sách này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var db = new QLTV_Nhom7Entities())
                {
                    try
                    {
                        int id = int.Parse(txtMasach.Text);
                        var s = db.Saches.Find(id);
                        if (s != null)
                        {
                            db.Saches.Remove(s);
                            db.SaveChanges();
                            MessageBox.Show("Đã xóa!");
                            LoadData();
                            ClearInput();
                        }
                    }
                    catch { MessageBox.Show("Không thể xóa (Sách đang được mượn)!"); }
                }
            }
        }


        private void ClearInput()
        {
            txtMasach.Clear(); txtTensach.Clear(); txtTacgia.Clear();
            txtNXB.Clear(); txtNamxuatban.Clear(); txtSoluong.Clear();
            combTHELOAI.SelectedIndex = -1;
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBooks.Rows[e.RowIndex];
                try
                {
                    txtMasach.Text = row.Cells["MaSach"].Value?.ToString();
                    txtTensach.Text = row.Cells["TenSach"].Value?.ToString();
                    txtTacgia.Text = row.Cells["TacGia"].Value?.ToString();
                    txtNXB.Text = row.Cells["NhaXB"].Value?.ToString();
                    combTHELOAI.Text = row.Cells["TheLoai"].Value?.ToString();
                    txtNamxuatban.Text = row.Cells["NamXB"].Value?.ToString();
                    txtSoluong.Text = row.Cells["SoLuong"].Value?.ToString();
                }
                catch { }
            }
        }

        private void btnTimsach_Click(object sender, EventArgs e)
        {
            // Nếu không nhập gì và không chọn thể loại -> Load lại tất cả (Reset)
            if (string.IsNullOrWhiteSpace(txtTimsach.Text) && cmbTheloai.SelectedIndex == -1)
            {
                LoadData();
                return;
            }

            using (var db = new QLTV_Nhom7Entities())
            {
                var query = db.Saches.AsQueryable();

                if (!string.IsNullOrEmpty(txtTimsach.Text))
                {
                    // Tìm theo MÃ SÁCH
                    if (radioButtonMASACH.Checked)
                    {
                        if (int.TryParse(txtTimsach.Text, out int id))
                        {
                            query = query.Where(x => x.MaSach == id);
                        }
                        else
                        {
                            MessageBox.Show("Mã sách bắt buộc phải là số!", "Lỗi nhập liệu");
                            return; 
                        }
                    }
                    // Tìm theo TÊN SÁCH
                    else if (radioButtonTENSACH.Checked)
                    {
                        query = query.Where(x => x.TenSach.Contains(txtTimsach.Text));
                    }
                }

                // Tìm theo Thể loại
                if (cmbTheloai.SelectedIndex != -1)
                {
                    string tl = cmbTheloai.SelectedValue.ToString();
                    query = query.Where(x => x.TheLoai == tl);
                }

                // Hiển thị kết quả
                var list = query.Select(s => new {
                    MaSach = s.MaSach,
                    TenSach = s.TenSach,
                    TacGia = s.TacGia,
                    TheLoai = s.TheLoai,
                    NhaXB = s.NhaXB,
                    NamXB = s.NamXB,
                    SoLuong = s.SoLuong
                }).ToList();

                if (list.Count == 0) MessageBox.Show("Không tìm thấy cuốn sách nào!");

                dgvBooks.DataSource = list;
            }
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            //Hiện Loading
            frmLoading frm = new frmLoading();
            frm.Show();
            await Task.Delay(1000);

            try
            {
                XuatExcelVIP(dgvBooks, "DANH SÁCH THÔNG TIN KHO SÁCH");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                // Tắt Loading (Dù lỗi hay không cũng phải tắt)
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
                worksheet.Name = "DocGia";

                // --- 1. HEADER ---
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

                // --- 2. DATA ---
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

                // --- 3. FORMAT CỘT RỘNG ---
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

                // Header
                for (int i = 1; i < g.Columns.Count + 1; i++)
                {
                    obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
                }

                // Dữ liệu
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
                obj.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTimsach.Clear();
            cmbTheloai.SelectedIndex = -1;
            radioButtonTENSACH.Checked = true;
            LoadData();
        }

        private async void btnTaoQR_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn dòng nào chưa
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để tạo mã!");
                return;
            }
            frmLoading loading = new frmLoading();
            loading.Show();

            // Giả lập thời gian chờ tạo mã (1 giây) cho chuyên nghiệp
            await Task.Delay(1000);

            // Tắt loading
            loading.Close();

            // 2. Lấy thông tin dòng đang chọn
            var row = dgvBooks.SelectedRows[0];

            // Lấy dữ liệu an toàn (tránh lỗi nếu ô rỗng)
            string ma = row.Cells["MaSach"].Value?.ToString() ?? "";
            string ten = row.Cells["TenSach"].Value?.ToString() ?? "";
            string tacGia = row.Cells["TacGia"].Value?.ToString() ?? "";
            string theLoai = row.Cells["TheLoai"].Value?.ToString() ?? "";
            string nxb = row.Cells["NhaXB"].Value?.ToString() ?? "";
            string nam = row.Cells["NamXB"].Value?.ToString() ?? "";

            // 3. Gộp tất cả thành 1 đoạn văn (Dùng \n để xuống dòng)
            string noiDungDayDu = $"Mã sách: {ma}\n" +
                                  $"Tên sách: {ten}\n" +
                                  $"Tác giả: {tacGia}\n" +
                                  $"Thể loại: {theLoai}\n" +
                                  $"NXB: {nxb}\n" +
                                  $"Năm: {nam}";

            // 4. Mở form QR và truyền đoạn văn dài này sang
            // (frmMaQR bây giờ chỉ nhận 1 biến string)
            frmMaQR f = new frmMaQR(noiDungDayDu);
            f.ShowDialog();
        }

        private void cmbTheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (cmbTheloai.SelectedIndex != -1)
            {
                btnTimsach.PerformClick();
            }
        }
    }
    
    
}
