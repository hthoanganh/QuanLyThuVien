using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_N7
{
    public partial class frmQuanLyMatKhau : Form
    {
        public frmQuanLyMatKhau()
        {
            InitializeComponent();
        }


        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtPassCu.UseSystemPasswordChar = true;
            txtPassMoi.UseSystemPasswordChar = true;
            txtXacNhan.UseSystemPasswordChar = true;

            if (Session.QuyenHan == "Admin")
            {
                // 1. Nếu là Admin: Hiện bảng và nút quản lý
                dgvTaiKhoan.Visible = true;
                btnReset.Visible = true;
                btnXoa.Visible = true;

                // Mở rộng chiều cao form để nhìn thấy bảng bên dưới
                this.Height = 1000;

                LoadDataAdmin();
            }
            else
            {
                // 2. Nếu là Độc giả: Ẩn đi
                dgvTaiKhoan.Visible = false;
                btnReset.Visible = false;
                btnXoa.Visible = false;

                // Thu nhỏ form lại, cắt bớt phần bảng bên dưới
                this.Height = 500;
            }
            this.BeginInvoke(new Action(() =>
            {
                dgvTaiKhoan.ClearSelection(); // Bỏ chọn dòng đầu tiên
                this.ActiveControl = null;    // Bỏ con trỏ khỏi ô mật khẩu cũ
            }));

        }


        void LoadDataAdmin()
        {
            using (var db = new QLTV_Nhom7Entities())
            {
                var list = db.TaiKhoans.Select(u => new
                {
                    u.TenDangNhap,
                    u.HoTen,
                    u.QuyenHan,
                    u.MatKhau // Lấy cả mật khẩu (đã mã hóa) để hiện lên bảng
                }).ToList();

                dgvTaiKhoan.DataSource = list;
                dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTaiKhoan.ReadOnly = true;

                dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tài Khoản";
                dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvTaiKhoan.Columns["QuyenHan"].HeaderText = "Quyền";
                dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật Khẩu (Mã hóa)";
                dgvTaiKhoan.Columns["MatKhau"].Width = 200;
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy dòng hiện tại
            DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
            string tenTK = row.Cells["TenDangNhap"].Value.ToString();
            string hoTen = row.Cells["HoTen"].Value.ToString();

            // Hiện thông báo nhỏ trên tiêu đề form để Admin biết đang chọn ai
            this.Text = $"ĐANG CHỌN: {hoTen} ({tenTK})";
        }

        // --- HÀM MÃ HÓA MD5 ---
        private string MaHoaMD5(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("X2"));
                return sb.ToString();
            }
        }


        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassCu.Text) || string.IsNullOrEmpty(txtPassMoi.Text) || string.IsNullOrEmpty(txtXacNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Cảnh báo"); return;
            }

            if (txtPassMoi.Text != txtXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi"); return;
            }

            frmLoading loading = new frmLoading();
            loading.Show();
            await Task.Delay(1000);

            try
            {
            using (var db = new QLTV_Nhom7Entities())
            {
                var user = db.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == Session.TenDangNhap);
                if (user != null)
                {
                    // Check pass cũ
                    if (MaHoaMD5(txtPassCu.Text) != user.MatKhau)
                    {
                            loading.Close();
                            MessageBox.Show("Mật khẩu cũ sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    // Lưu pass mới
                    user.MatKhau = MaHoaMD5(txtPassMoi.Text);
                    db.SaveChanges();
                    loading.Close();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    
                    btnHuy.PerformClick(); // Reset form
                    }
                }
            }
            catch (Exception ex)
            {
                loading.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
        


        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtPassCu.Clear();
            txtPassMoi.Clear();
            txtXacNhan.Clear();

            // Bỏ tích hiện mật khẩu
            chkHienmkMoi.Checked = false;

            // Bỏ chọn bảng
            dgvTaiKhoan.ClearSelection();


            // Bỏ focus
            this.ActiveControl = null;
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người cần Reset!", "Chưa chọn dòng"); return;
            }

            string userCanReset = dgvTaiKhoan.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
            string hoTen = dgvTaiKhoan.SelectedRows[0].Cells["HoTen"].Value.ToString();

            if (MessageBox.Show($"Reset mật khẩu của '{hoTen}' về '123'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                frmLoading loading = new frmLoading();
                loading.Show();
                await Task.Delay(1000);

                using (var db = new QLTV_Nhom7Entities())
                {
                    var tk = db.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == userCanReset);
                    if (tk != null)
                    {
                        tk.MatKhau = "202CB962AC59075B964B07152D234B70"; // MD5 123
                        db.SaveChanges();

                        loading.Close();
                        MessageBox.Show($"Đã Reset cho {hoTen} thành công!", "Thông báo");

                        LoadDataAdmin();
                        dgvTaiKhoan.ClearSelection();
                    }
                }
            }
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // lỡ tay bấm
        }

        private void chkHienmkMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienmkMoi.Checked)
            {
                // Nếu tích -> Hiện chữ bình thường
                txtPassCu.UseSystemPasswordChar = false;
                txtPassMoi.UseSystemPasswordChar = false;
                txtXacNhan.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu bỏ tích -> Hiện dấu chấm tròn (Password char)
                txtPassCu.UseSystemPasswordChar = true;
                txtPassMoi.UseSystemPasswordChar = true;
                txtXacNhan.UseSystemPasswordChar = true;
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            //  Chưa chọn dòng
            if (dgvTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userCanXoa = dgvTaiKhoan.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();

            // Cấm xóa chính mình (Đang đăng nhập thì ko được xóa)
            if (userCanXoa == Session.TenDangNhap)
            {
                MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Hỏi xác nhận lần cuối
            if (MessageBox.Show($"Bạn có chắc chắn muốn XÓA VĨNH VIỄN tài khoản [{userCanXoa}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frmLoading loading = new frmLoading();
                loading.Show();
                await Task.Delay(1500);

                using (var db = new QLTV_Nhom7Entities())
                {
                    try
                    {
                        var tk = db.TaiKhoans.Find(userCanXoa);
                        if (tk != null)
                        {
                            db.TaiKhoans.Remove(tk);
                            db.SaveChanges();
                            MessageBox.Show("Đã xóa thành công!");

                            // Load lại bảng và dọn dẹp form
                            LoadDataAdmin();
                            btnHuy.PerformClick(); // Gọi nút Hủy để clear form luôn
                        }
                    }
                    catch (Exception ex)
                    {
                        loading.Close();
                        // Bẫy lỗi SQL (Ví dụ tài khoản này đang dính khóa ngoại ở bảng Phiếu Mượn)
                        MessageBox.Show("Không thể xóa tài khoản này vì họ đang có dữ liệu trong hệ thống (Phiếu mượn/Trả)!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
