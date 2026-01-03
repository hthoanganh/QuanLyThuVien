using System;
using System.Data;
using System.Drawing; // Để dùng màu sắc
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

namespace BTL_N7
{
    public partial class frmTraSach : Form
    {
        // Cấu hình tiền phạt cơ bản
        const decimal MUC_PHAT_QUA_HAN_MOT_NGAY = 5000;
        public frmTraSach()
        {
            InitializeComponent();
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {

            LoadComboboxDocGia();
            LoadComboboxHinhPhat();
            LoadDanhSachDangMuon();

            // Reset ComboBox
            cmbTendocgia.SelectedIndex = -1;

            // Ban đầu không chọn Radio nào -> Textbox bị khóa (MỜ)
            rdbMadocgia.Checked = false;
            rdbMaphieumuon.Checked = false;

            txtTimMaDGhoacMaPhieum.Text = "";
            txtTimMaDGhoacMaPhieum.Enabled = false;
        }


        void LoadComboboxDocGia()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                cmbTendocgia.DataSource = db.DocGias.ToList();
                cmbTendocgia.DisplayMember = "TenDocGia";
                cmbTendocgia.ValueMember = "MaDocGia";
                cmbTendocgia.SelectedIndex = -1;
            }
        }


        void LoadComboboxHinhPhat()
        {
            cbmHinhPhat.Items.Clear();
            // Hình thức phạt theo yêu cầu
            cbmHinhPhat.Items.Add("Phạt tiền quá hạn");
            cbmHinhPhat.Items.Add("Bồi thường sách (mất, hỏng)");
            cbmHinhPhat.Items.Add("Khóa tài khoản/dịch vụ");
            cbmHinhPhat.Items.Add("Trừ điểm rèn luyện");

            cbmHinhPhat.SelectedIndex = -1;
        }


        void LoadDanhSachDangMuon()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                var list = (from pm in db.PhieuMuons
                            join ct in db.ChiTietPhieuMuons on pm.MaPhieu equals ct.MaPhieu
                            join s in db.Saches on ct.MaSach equals s.MaSach
                            join dg in db.DocGias on pm.MaDocGia equals dg.MaDocGia
                            where pm.TrangThai == "Đang mượn"
                            && (ct.GhiChu == null || ct.GhiChu == "")
                            select new
                            {
                                MaPhieu = pm.MaPhieu,
                                MaSach = s.MaSach,
                                // Lấy mã độc giả xuống
                                MaDocGia = pm.MaDocGia,
                                TenDocGia = dg.TenDocGia,
                                TenSach = s.TenSach,
                                NgayMuon = pm.NgayMuon,
                                HanTra = pm.HanTra
                            }).ToList();

                DataTable dt = new DataTable();
                // THÊM CỘT NÀY VÀO DATATABLE:
                dt.Columns.Add("MaDocGia", typeof(int));

                dt.Columns.Add("MaPhieu", typeof(int));
                dt.Columns.Add("MaSach", typeof(int));
                dt.Columns.Add("TenDocGia", typeof(string));
                dt.Columns.Add("TenSach", typeof(string));
                dt.Columns.Add("NgayMuon", typeof(DateTime));
                dt.Columns.Add("HanTra", typeof(DateTime));
                dt.Columns.Add("SoNgayQuaHan", typeof(int));
                dt.Columns.Add("TrangThai", typeof(string));

                foreach (var item in list)
                {
                    DateTime hanTra = item.HanTra ?? DateTime.Now;
                    int quaHan = (DateTime.Now.Date - hanTra.Date).Days;
                    string trangThai = (quaHan <= 0) ? "Đúng hạn" : "QUÁ HẠN";
                    if (quaHan < 0) quaHan = 0;

                    // THÊM item.MaDocGia VÀO ĐẦU DÒNG (Theo thứ tự cột add bên trên)
                    dt.Rows.Add(item.MaDocGia, item.MaPhieu, item.MaSach, item.TenDocGia, item.TenSach, item.NgayMuon, item.HanTra, quaHan, trangThai);
                }

                dgvBangNguoiMuon.DataSource = dt;
                TrangTriLuoi();

                // Mặc định clear hết dòng chọn
                dgvBangNguoiMuon.ClearSelection();
                dgvBangNguoiMuon.CurrentCell = null;
            }
        }


        void TrangTriLuoi()
        {
            dgvBangNguoiMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangNguoiMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangNguoiMuon.MultiSelect = false;

            // Ẩn các cột mã không cần thiết
            if (dgvBangNguoiMuon.Columns["MaSach"] != null) dgvBangNguoiMuon.Columns["MaSach"].Visible = false;
            if (dgvBangNguoiMuon.Columns["MaDocGia"] != null) dgvBangNguoiMuon.Columns["MaDocGia"].Visible = false;

            dgvBangNguoiMuon.Columns["TenDocGia"].HeaderText = "Người Mượn";
            dgvBangNguoiMuon.Columns["TenSach"].HeaderText = "Sách Mượn";
            dgvBangNguoiMuon.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dgvBangNguoiMuon.Columns["HanTra"].HeaderText = "Hạn Trả";
            dgvBangNguoiMuon.Columns["SoNgayQuaHan"].HeaderText = "Số Ngày Quá";
            dgvBangNguoiMuon.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvBangNguoiMuon.Columns["MaPhieu"].HeaderText = "Mã Phiếu";

            dgvBangNguoiMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvBangNguoiMuon.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        // Sự kiện chọn ComboBox Tên Độc Giả
        private void cmbTendocgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu có chọn một độc giả hợp lệ
            if (cmbTendocgia.SelectedIndex != -1 && cmbTendocgia.SelectedValue != null)
            {
                // Tự động clear ô nhập text để tránh nhầm lẫn
                txtTimMaDGhoacMaPhieum.Clear();

                // Thực hiện lọc ngay lập tức
                if (int.TryParse(cmbTendocgia.SelectedValue.ToString(), out int maDG))
                {
                    DataTable dt = dgvBangNguoiMuon.DataSource as DataTable;
                    if (dt != null)
                    {
                        dt.DefaultView.RowFilter = $"MaDocGia = {maDG}";
                        dgvBangNguoiMuon.ClearSelection();
                    }
                }
            }
        }


        private void cbmHinhPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvBangNguoiMuon.CurrentRow == null || !dgvBangNguoiMuon.CurrentRow.Selected) return;

            string hinhPhat = cbmHinhPhat.Text;
            int quaHan = 0;
            if (dgvBangNguoiMuon.CurrentRow.Cells["SoNgayQuaHan"].Value != null)
                quaHan = Convert.ToInt32(dgvBangNguoiMuon.CurrentRow.Cells["SoNgayQuaHan"].Value);

            if (hinhPhat == "Phạt tiền quá hạn")
            {
                if (quaHan > 0)
                {
                    decimal tienPhat = quaHan * MUC_PHAT_QUA_HAN_MOT_NGAY;
                    txtThongtinhinhphat.Text = tienPhat.ToString("#,###");
                }
                else
                {
                    txtThongtinhinhphat.Text = "0"; // Không quá hạn thì phạt 0
                }
            }
            else if (hinhPhat.Contains("Bồi thường"))
            {
                txtThongtinhinhphat.Text = "";
            }
            else if (hinhPhat.Contains("Khóa tài khoản"))
            {
                txtThongtinhinhphat.Text = "Khóa 1 tháng";
            }
            else if (hinhPhat.Contains("Trừ điểm"))
            {
                txtThongtinhinhphat.Text = "Trừ 10 điểm";
            }
        }

        private void dgvBangNguoiMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Chỉ xử lý cột "SoNgayQuaHan"
            if (dgvBangNguoiMuon.Columns[e.ColumnIndex].Name == "SoNgayQuaHan")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int days))
                {
                    if (days > 0)
                    {
                        // Chỉ tô màu cho Ô (Cell), không tô cả dòng
                        e.CellStyle.BackColor = Color.MistyRose;
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);
                    }
                }
            }
        }


        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có chọn dòng nào chưa
            if (dgvBangNguoiMuon.CurrentRow == null || !dgvBangNguoiMuon.CurrentRow.Selected)
            {
                MessageBox.Show("Vui lòng chọn sách cần trả!", "Chưa chọn");
                return;
            }

            // 2. Lấy thông tin từ dòng đang chọn
            int maPhieu = Convert.ToInt32(dgvBangNguoiMuon.CurrentRow.Cells["MaPhieu"].Value);
            int maSach = Convert.ToInt32(dgvBangNguoiMuon.CurrentRow.Cells["MaSach"].Value);
            string tenSach = dgvBangNguoiMuon.CurrentRow.Cells["TenSach"].Value.ToString();

            // Lấy số ngày quá hạn an toàn (tránh lỗi null)
            int soNgayQua = 0;
            if (dgvBangNguoiMuon.CurrentRow.Cells["SoNgayQuaHan"].Value != null)
            {
                int.TryParse(dgvBangNguoiMuon.CurrentRow.Cells["SoNgayQuaHan"].Value.ToString(), out soNgayQua);
            }

            // 3. XỬ LÝ 
            // TRƯỜNG HỢP A: Sách bị QUÁ HẠN
            if (soNgayQua > 0)
            {
                decimal tienPhat = soNgayQua * MUC_PHAT_QUA_HAN_MOT_NGAY;

                // Tạo câu thông báo cảnh báo
                string canhBao = $"CẢNH BÁO: Cuốn sách '{tenSach}' đang QUÁ HẠN {soNgayQua} ngày!\n" +
                                 $"Tiền phạt dự kiến (5.000đ/ngày): {tienPhat.ToString("#,###")} VNĐ.\n\n" +
                                 "Nếu bạn bấm 'Yes', hệ thống sẽ ghi nhận trả sách và BỎ QUA việc thu tiền phạt này.\n" +
                                 "Bạn có chắc chắn muốn tiếp tục không?";

                // Hiện hộp thoại cảnh báo (Icon Warning màu vàng)
                DialogResult tl = MessageBox.Show(canhBao, "Cảnh báo sách quá hạn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (tl == DialogResult.Yes)
                {
                    // Người dùng chấp nhận bỏ qua phạt -> Ghi chú vào DB là trả trễ
                    XuLyTraSachTrongDB(maPhieu, maSach, "Trả quá hạn", "Đã bỏ qua phạt tiền");
                }
                // Nếu chọn No thì không làm gì cả, để họ qua bên kia xử lý
            }
            // TRƯỜNG HỢP B: Sách ĐÚNG HẠN (Bình thường)
            else
            {
                if (MessageBox.Show($"Xác nhận trả sách: {tenSach}?\n(Sách nguyên vẹn, trả đúng hạn)", "Xác nhận trả", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XuLyTraSachTrongDB(maPhieu, maSach, "Trả đúng hạn", "Không phạt");
                }
            }
        }

        private void btnXacnhanHTXL_Click(object sender, EventArgs e)
        {
            // BẪY LỖI 1: Chưa chọn dòng nào trên bảng
            if (dgvBangNguoiMuon.CurrentRow == null || !dgvBangNguoiMuon.CurrentRow.Selected)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xử lý trên bảng!", "Chưa chọn dòng");
                return;
            }

            // BẪY LỖI 2: Chưa chọn hình thức phạt
            if (cbmHinhPhat.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hình thức xử lý/phạt!", "Thiếu thông tin");
                cbmHinhPhat.Focus();
                return;
            }

            // Lấy dữ liệu để kiểm tra logic "Tránh xử hoang"
            int quaHan = 0;
            if (dgvBangNguoiMuon.CurrentRow.Cells["SoNgayQuaHan"].Value != null)
                quaHan = Convert.ToInt32(dgvBangNguoiMuon.CurrentRow.Cells["SoNgayQuaHan"].Value);

            string hinhThuc = cbmHinhPhat.Text;

            // --- LOGIC CHẶN PHẠT OAN ---
            // Nếu khách ĐÚNG HẠN (quaHan <= 0) mà lại chọn "Phạt tiền quá hạn" -> CHẶN LUÔN
            if (quaHan <= 0 && hinhThuc == "Phạt tiền quá hạn")
            {
                MessageBox.Show("Độc giả này trả sách ĐÚNG HẠN (Không quá hạn).\n\nKHÔNG THỂ áp dụng hình phạt tiền quá hạn!", "Lỗi Logic Xử Phạt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return; // Dừng ngay, không cho chạy tiếp
            }

            // Lấy thông tin chi tiết
            int maPhieu = Convert.ToInt32(dgvBangNguoiMuon.CurrentRow.Cells["MaPhieu"].Value);
            int maSach = Convert.ToInt32(dgvBangNguoiMuon.CurrentRow.Cells["MaSach"].Value);
            string tenSach = dgvBangNguoiMuon.CurrentRow.Cells["TenSach"].Value.ToString();
            string chiTiet = txtThongtinhinhphat.Text;

            // BẪY LỖI 3: Thông tin phạt trống
            if (string.IsNullOrWhiteSpace(chiTiet))
            {
                MessageBox.Show("Vui lòng nhập số tiền phạt hoặc ghi chú xử lý!", "Thiếu chi tiết phạt");
                txtThongtinhinhphat.Focus();
                return;
            }

            // Hỏi xác nhận lần cuối cho chắc chắn
            if (MessageBox.Show($"Xác nhận XỬ PHẠT:\n\n- Sách: {tenSach}\n- Lỗi: {hinhThuc}\n- Chi tiết: {chiTiet}\n\nBạn có chắc chắn không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XuLyTraSachTrongDB(maPhieu, maSach, hinhThuc, chiTiet);
            }
        }
        

       

        // --- 4. TÌM KIẾM ---
        private void btnTimnguoimuon_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu nguồn
            DataTable dt = dgvBangNguoiMuon.DataSource as DataTable;
            if (dt == null) return;

            string keyword = txtTimMaDGhoacMaPhieum.Text.Trim();
            object selectedDocGia = cmbTendocgia.SelectedValue;

            // Reset lại bộ lọc trước khi tìm mới
            dt.DefaultView.RowFilter = "";

            // BẪY LỖI: Chưa nhập gì cả
            if (string.IsNullOrEmpty(keyword) && cmbTendocgia.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Tên độc giả hoặc nhập Mã để tìm!", "Thiếu thông tin");
                return;
            }

            try
            {
                // TRƯỜNG HỢP 1: Tìm theo ComboBox (Tên độc giả)
                if (cmbTendocgia.SelectedIndex != -1 && selectedDocGia != null)
                {
                    if (int.TryParse(selectedDocGia.ToString(), out int maDG))
                    {
                        // Lọc theo Mã Độc Giả (Giờ bảng đã có cột này rồi nên không lỗi nữa)
                        dt.DefaultView.RowFilter = $"MaDocGia = {maDG}";

                        // --- BẪY LỖI: KIỂM TRA KẾT QUẢ ---
                        if (dt.DefaultView.Count == 0)
                        {
                            MessageBox.Show($"Độc giả '{cmbTendocgia.Text}' hiện không mượn cuốn sách nào!", "Kết quả tìm kiếm");
                            // Tùy chọn: Muốn reset lại bảng trắng hay hiện lại tất cả? 
                            // Nếu muốn hiện lại tất cả thì bỏ comment dòng dưới:
                            // dt.DefaultView.RowFilter = ""; 
                        }
                    }
                }
                // TRƯỜNG HỢP 2: Tìm theo ô nhập Text
                else if (!string.IsNullOrEmpty(keyword))
                {
                    if (rdbMadocgia.Checked) // Tìm theo Mã ĐG
                    {
                        if (int.TryParse(keyword, out int maDG))
                        {
                            dt.DefaultView.RowFilter = $"MaDocGia = {maDG}";
                            if (dt.DefaultView.Count == 0) MessageBox.Show("Không tìm thấy độc giả có mã này đang mượn sách!");
                        }
                        else MessageBox.Show("Mã độc giả phải là SỐ!");
                    }
                    else // Mặc định hoặc chọn Mã Phiếu -> Tìm theo Mã Phiếu
                    {
                        if (int.TryParse(keyword, out int maPhieu))
                        {
                            dt.DefaultView.RowFilter = $"MaPhieu = {maPhieu}";
                            if (dt.DefaultView.Count == 0) MessageBox.Show("Không tìm thấy phiếu mượn số: " + maPhieu);
                        }
                        else MessageBox.Show("Mã phiếu phải là SỐ!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                dt.DefaultView.RowFilter = ""; // Reset nếu lỗi
            }
        }

        private void btnHuyChonTimTTMuon_Click(object sender, EventArgs e)
        {
            // Reset ComboBox
            cmbTendocgia.SelectedIndex = -1;

            // Reset Textbox
            txtTimMaDGhoacMaPhieum.Clear();
            txtTimMaDGhoacMaPhieum.Enabled = false; // Khóa lại (làm mờ)

            // Bỏ chọn Radio
            rdbMadocgia.Checked = false;
            rdbMaphieumuon.Checked = false;

            // Load lại bảng gốc
            LoadDanhSachDangMuon();
        }

        private void txtTimmaphieu_TextChanged(object sender, EventArgs e)
        {

        }

        void XuLyTraSachTrongDB(int maPhieu, int maSach, string trangThaiTra, string ghiChu)
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                try
                {
                    // 1. Tìm chi tiết phiếu mượn
                    var ct = db.ChiTietPhieuMuons.FirstOrDefault(c => c.MaPhieu == maPhieu && c.MaSach == maSach);
                    if (ct != null)
                    {
                        ct.GhiChu = $"{trangThaiTra}. {ghiChu}";

                        
                        // Lưu thời gian thực tế trả sách vào Database
                        ct.NgayTraSach = DateTime.Now;
                    }

                    // 2. CỘNG LẠI KHO SÁCH
                    bool laMatSach = trangThaiTra.ToLower().Contains("mất") || ghiChu.ToLower().Contains("mất");
                    if (!laMatSach)
                    {
                        var sachTrongKho = db.Saches.FirstOrDefault(s => s.MaSach == maSach);
                        if (sachTrongKho != null)
                        {
                            int slHienTai = sachTrongKho.SoLuong ?? 0;
                            sachTrongKho.SoLuong = slHienTai + 1;
                        }
                    }

                    // 3. Kiểm tra đóng phiếu (Nếu tất cả sách trong phiếu đã có ngày trả)
                    // Đếm những dòng CHƯA có ngày trả
                    int soSachConLai = db.ChiTietPhieuMuons
                                         .Count(c => c.MaPhieu == maPhieu && c.NgayTraSach == null);

                    if (soSachConLai == 0)
                    {
                        var phieu = db.PhieuMuons.FirstOrDefault(p => p.MaPhieu == maPhieu);
                        if (phieu != null)
                        {
                            phieu.NgayTra = DateTime.Now;
                            phieu.TrangThai = "Đã trả";
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Trả sách thành công! (Thống kê đã cập nhật)");

                    // Reset giao diện
                    LoadDanhSachDangMuon();
                    txtThongtinhinhphat.Clear();
                    cbmHinhPhat.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }
        private void btnHuyChonHinhThucXL_Click(object sender, EventArgs e)
        {
            cbmHinhPhat.SelectedIndex = -1;
            txtThongtinhinhphat.Clear();
        }


        
        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            // Chỉ cần 1 trong 2 cái được chọn -> Mở khóa Textbox (SÁNG)
            if (rdbMadocgia.Checked || rdbMaphieumuon.Checked)
            {
                txtTimMaDGhoacMaPhieum.Enabled = true; // True = Sáng, cho nhập
                txtTimMaDGhoacMaPhieum.Focus();
            }
        }



        private async void btnExcel_Click(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show();
            await Task.Delay(1000);

            try
            {
                XuatExcelVIP(dgvBangNguoiMuon, "DANH SÁCH ĐỘC GIẢ ĐANG MƯỢN SÁCH");
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

        // --- HÀM XUẤT EXCEL (Dành riêng cho Trả Sách) ---
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
                worksheet.Name = "TraSach";

                // 1. HEADER
                int colCount = 0;
                // Chỉ đếm các cột ĐANG HIỆN (Visible = true) để bản in gọn đẹp
                foreach (DataGridViewColumn col in dgv.Columns) if (col.Visible) colCount++;

                // Tiêu đề
                Excel.Range head = worksheet.get_Range("A1", GetExcelColumnName(colCount) + "1");
                head.MergeCells = true;
                head.Value2 = tieuDe.ToUpper();
                head.Font.Bold = true;
                head.Font.Size = 18;
                head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Ngày giờ
                Excel.Range info = worksheet.get_Range("A2", GetExcelColumnName(colCount) + "2");
                info.MergeCells = true;
                info.Value2 = $"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                info.Font.Size = 11;
                info.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // 2. NỘI DUNG
                int colExcel = 1;
                // Viết tiêu đề cột
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible) // Chỉ xuất cột đang hiện
                    {
                        worksheet.Cells[4, colExcel] = dgv.Columns[i].HeaderText;
                        colExcel++;
                    }
                }

                // Format tiêu đề cột
                Excel.Range rowHead = worksheet.get_Range("A4", GetExcelColumnName(colCount) + "4");
                rowHead.Font.Bold = true;
                rowHead.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rowHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                rowHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Viết dữ liệu (Dùng mảng object để tăng tốc độ)
                object[,] dataArr = new object[dgv.Rows.Count, colCount];
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    int colIndex = 0;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible)
                        {
                            var val = dgv.Rows[i].Cells[j].Value;
                            dataArr[i, colIndex] = val != null ? val.ToString() : "";
                            colIndex++;
                        }
                    }
                }

                // Đổ dữ liệu xuống
                Excel.Range dataRange = worksheet.get_Range("A5", GetExcelColumnName(colCount) + (4 + dgv.Rows.Count));
                dataRange.Value2 = dataArr;
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.Font.Size = 11;

                // 3. CĂN CHỈNH
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
    }
}
