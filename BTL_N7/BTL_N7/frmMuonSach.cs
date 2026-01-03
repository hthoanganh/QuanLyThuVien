using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL_N7
{
    public partial class frmMuonSach : Form
    {
        DataTable dtGioHang;
        public frmMuonSach()
        {
            InitializeComponent();
            
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();      
            LoadDataToCombobox(); // Tải Độc giả, Sách lên ô chọn
            ThietLapNgay();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            frmMuonSach_Load(this, null);
        }

        // 1. Cài đặt giao diện ban đầu
        void ThietLapNgay()
        {
            dtpNgayMuon.Format = DateTimePickerFormat.Custom;
            dtpNgayMuon.CustomFormat = "dd/MM/yyyy";

            dtpHanTra.Format = DateTimePickerFormat.Custom;
            dtpHanTra.CustomFormat = "dd/MM/yyyy";

            // Mặc định ngày mượn là hôm nay
            dtpNgayMuon.Value = DateTime.Now;
            // Tự động cộng 30 ngày cho hạn trả
            dtpHanTra.Value = dtpNgayMuon.Value.AddDays(30);

            // Sự kiện: Nếu sửa ngày mượn -> Ngày trả tự nhảy theo
            dtpNgayMuon.ValueChanged += (s, e) => dtpHanTra.Value = dtpNgayMuon.Value.AddDays(30);
        }


        private void LoadDataToCombobox()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                // Độc giả
                cmbTendocgia.DataSource = db.DocGias.ToList();
                cmbTendocgia.DisplayMember = "TenDocGia";
                cmbTendocgia.ValueMember = "MaDocGia";
                cmbTendocgia.SelectedIndex = -1;

                // Sách
                cbmChonsach.DataSource = db.Saches.ToList();
                cbmChonsach.DisplayMember = "TenSach";
                cbmChonsach.ValueMember = "MaSach";
                cbmChonsach.SelectedIndex = -1;
            }
        }

        // Tạo cấu trúc cho lưới (DataGridView)
        void KhoiTaoLuoi()
        {
            dtGioHang = new DataTable();

            // Định nghĩa các cột dữ liệu (7 Cột)
            dtGioHang.Columns.Add("MaDocGia", typeof(int));
            dtGioHang.Columns.Add("TenDocGia", typeof(string));
            dtGioHang.Columns.Add("MaSach", typeof(int));
            dtGioHang.Columns.Add("TenSach", typeof(string));
            dtGioHang.Columns.Add("NgayMuon", typeof(DateTime));
            dtGioHang.Columns.Add("HanTra", typeof(DateTime));
            dtGioHang.Columns.Add("SoLuong", typeof(int));

            // Gán vào lưới
            dgvChiTietMuon.DataSource = dtGioHang;

            // --- TRANG TRÍ LẠI TÊN CỘT ---
            // Đặt tên Tiếng Việt hiển thị
            dgvChiTietMuon.Columns["MaDocGia"].HeaderText = "Mã ĐG";
            dgvChiTietMuon.Columns["TenDocGia"].HeaderText = "Tên Độc Giả";
            dgvChiTietMuon.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvChiTietMuon.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvChiTietMuon.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dgvChiTietMuon.Columns["HanTra"].HeaderText = "Hạn Trả";
            dgvChiTietMuon.Columns["SoLuong"].HeaderText = "SL";

            // Định dạng ngày tháng trong bảng (dd/MM/yyyy)
            dgvChiTietMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvChiTietMuon.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Chỉnh độ rộng cột
            dgvChiTietMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietMuon.Columns["TenSach"].FillWeight = 200; // Cột tên sách rộng gấp đôi
            dgvChiTietMuon.Columns["TenDocGia"].FillWeight = 150;
        }


        private void btnThemmuon_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (cmbTendocgia.SelectedIndex == -1) { MessageBox.Show("Chưa chọn độc giả!"); return; }
            if (cbmChonsach.SelectedIndex == -1) { MessageBox.Show("Chưa chọn sách!"); return; }

            int soLuong = 1;
            if (!string.IsNullOrEmpty(txtSoluong.Text)) int.TryParse(txtSoluong.Text, out soLuong);

            // Lấy thông tin từ các ô trên form
            int maDG = (int)cmbTendocgia.SelectedValue;
            string tenDG = cmbTendocgia.Text; // Lấy tên người đang hiện
            Sach sach = cbmChonsach.SelectedItem as Sach;
            DateTime ngayMuon = dtpNgayMuon.Value;
            DateTime hanTra = dtpHanTra.Value;

            // KIỂM TRA TRÙNG (Nếu cùng người, cùng sách thì cộng dồn)
            foreach (DataRow row in dtGioHang.Rows)
            {
                if ((int)row["MaSach"] == sach.MaSach)
                {
                    row["SoLuong"] = (int)row["SoLuong"] + soLuong;
                    return;
                }
            }

            // THÊM DÒNG MỚI VỚI ĐẦY ĐỦ CỘT
            dtGioHang.Rows.Add(maDG, tenDG, sach.MaSach, sach.TenSach, ngayMuon, hanTra, soLuong);
        }
        private void btnLuuphieu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra giỏ hàng có trống không
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm sách trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QLTV_Nhom7Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // BƯỚC 1: Lấy danh sách các Mã Độc Giả riêng biệt trong giỏ hàng
                        var danhSachNguoiMuon = dtGioHang.AsEnumerable()
                                                         .Select(row => new {
                                                             MaDG = row.Field<int>("MaDocGia"),
                                                             TenDG = row.Field<string>("TenDocGia")
                                                         })
                                                         .Distinct()
                                                         .ToList();

                        string msgKetQua = "Lưu phiếu mượn thành công:\n";

                        // BƯỚC 2: Duyệt qua từng người để tạo phiếu riêng
                        foreach (var nguoi in danhSachNguoiMuon)
                        {
                            // Lọc lấy những dòng sách của người này trong giỏ hàng
                            var sachCuaNguoiNay = dtGioHang.Select($"MaDocGia = {nguoi.MaDG}");

                            if (sachCuaNguoiNay.Length == 0) continue;

                            // Tạo Phiếu Mượn (Header)
                            PhieuMuon pm = new PhieuMuon();
                            pm.MaDocGia = nguoi.MaDG;
                            // Lấy ngày mượn/hạn trả từ dòng đầu tiên (vì chung 1 lần mượn)
                            pm.NgayMuon = (DateTime)sachCuaNguoiNay[0]["NgayMuon"];
                            pm.HanTra = (DateTime)sachCuaNguoiNay[0]["HanTra"];
                            pm.TrangThai = "Đang mượn";

                            db.PhieuMuons.Add(pm);
                            db.SaveChanges(); // Lưu ngay để lấy MaPhieu tự tăng

                            int maPhieuMoi = pm.MaPhieu;
                            msgKetQua += $"- Độc giả {nguoi.TenDG}: Mã phiếu {maPhieuMoi}\n";

                            // Lưu Chi Tiết Sách (Details) và Trừ Kho
                            foreach (DataRow row in sachCuaNguoiNay)
                            {
                                int maSach = (int)row["MaSach"];
                                int soLuongMuon = (int)row["SoLuong"]; // Số lượng lấy từ GridView

                                // A. Kiểm tra và Trừ kho
                                var sachTrongKho = db.Saches.FirstOrDefault(s => s.MaSach == maSach);
                                if (sachTrongKho != null)
                                {
                                    if (sachTrongKho.SoLuong < soLuongMuon)
                                    {
                                        // Nếu kho không đủ thì Rollback (hủy toàn bộ) và báo lỗi
                                        throw new Exception($"Sách '{sachTrongKho.TenSach}' chỉ còn {sachTrongKho.SoLuong} cuốn. Không đủ để mượn {soLuongMuon} cuốn!");
                                    }
                                    // Trừ số lượng tồn kho
                                    sachTrongKho.SoLuong = sachTrongKho.SoLuong - soLuongMuon;
                                }

                                // B. Lưu vào bảng ChiTietPhieuMuon
                                ChiTietPhieuMuon ct = new ChiTietPhieuMuon();
                                ct.MaPhieu = maPhieuMoi;
                                ct.MaSach = maSach;

                                // --- QUAN TRỌNG: Lưu số lượng mượn vào Database ---
                                
                                ct.SoLuongMuon = soLuongMuon;

                                // Ghi chú nếu có (để trống hoặc lấy từ form)
                                ct.GhiChu = "";

                                db.ChiTietPhieuMuons.Add(ct);
                            }
                        }

                        // BƯỚC 3: Chốt đơn (Commit transaction)
                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show(msgKetQua, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset giao diện sau khi lưu xong
                        dtGioHang.Rows.Clear();
                        cmbTendocgia.SelectedIndex = -1;
                        cbmChonsach.SelectedIndex = -1;
                        txtSoluong.Text = "";
                    }
                    catch (Exception ex)
                    {
                        // Gặp lỗi thì hoàn tác mọi thứ, không lưu gì cả
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi lưu phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
