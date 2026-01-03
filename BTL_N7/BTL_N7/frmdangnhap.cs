using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BTL_N7
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void frmdangnhap_Load(object sender, EventArgs e)
        {
            SetupPlaceholder(txtTaikhoan, "Nhập tài khoản");
            SetupPlaceholder(txtMatkhau, "Nhập mật khẩu");
            txtMatkhau.UseSystemPasswordChar = false;
            this.ActiveControl = lblTaikhoan;

        }
        private void SetupPlaceholder(TextBox txt, string text)
        {
            txt.Text = text;
            txt.ForeColor = Color.Gray;
        }
        private void lblTaikhoan_Click(object sender, EventArgs e)// dòng này lỡ tay
        {

        }
        // SỰ KIỆN CHO Ô TÀI KHOẢN
        private void txtTaikhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaikhoan.Text == "Nhập tài khoản")
            {
                txtTaikhoan.Text = "";
                txtTaikhoan.ForeColor = Color.Black;
            }
        }
        private void txtTaikhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaikhoan.Text))
                SetupPlaceholder(txtTaikhoan, "Nhập tài khoản");
        }


        // SỰ KIỆN CHO Ô MẬT KHẨU
        private void txtMatkhau_Enter(object sender, EventArgs e)
        {

            if (txtMatkhau.Text == "Nhập mật khẩu")
            {
                txtMatkhau.Text = "";
                txtMatkhau.ForeColor = Color.Black;
                if (!chkHienmk.Checked) txtMatkhau.UseSystemPasswordChar = true;
            }
        }
        private void txtMatkhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                SetupPlaceholder(txtMatkhau, "Nhập mật khẩu");
                txtMatkhau.UseSystemPasswordChar = false;
            }
        }

        //  CHECKBOX HIỆN MẬT KHẨU
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatkhau.Text == "Nhập mật khẩu") return;
            txtMatkhau.UseSystemPasswordChar = !chkHienmk.Checked;
        }
        private void txtTaikhoan_TextChanged(object sender, EventArgs e)
        {// dòng này bỏ
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Hiện Form Loading 
            frmLoading frm = new frmLoading();
            frm.Show();

            await Task.Delay(1000); // 1s

            // Lấy dữ liệu
            string user = txtTaikhoan.Text.Trim();
            string pass = txtMatkhau.Text.Trim();

            if (user == "Nhập tài khoản") user = "";
            if (pass == "Nhập mật khẩu") pass = "";

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                
                frm.Close(); // tắt Loading trước khi thoát

                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Cảnh báo");
                return; // Thoát hàm
            }

            try
            {
                using (var db = new QLTV_Nhom7Entities())
                {
                    string passMD5 = MaHoaMD5(pass);
                    var account = db.TaiKhoans.FirstOrDefault(u => u.TenDangNhap == user && u.MatKhau == passMD5);

                    
                    // Để khi mở form Main lên thì loading đã tắt rồi, không bị che màn hình
                    frm.Close();

                    if (account != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!\nXin chào: " + account.HoTen, "Thông báo");

                        Session.MaTK = account.MaTK;
                        Session.TenDangNhap = account.TenDangNhap;
                        Session.QuyenHan = account.QuyenHan;
                        Session.HoTen = account.HoTen;

                        frmMain f = new frmMain();
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Loading đã tắt ở trên rồi, giờ chỉ hiện thông báo lỗi
                        MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                frm.Close(); // lỗi kết nối thì cũng phải tắt loading
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        
        private async void btnDangky_Click(object sender, EventArgs e)
        {

            // Hiện Loading
            frmLoading frm = new frmLoading();
            frm.Show();
            // Giả vờ đang kết nối server để mở form đăng ký
            await Task.Delay(1000);
            frm.Close();

            // Mở form Đăng ký
            Dangky f = new Dangky();
            this.Hide(); // Ẩn form đăng nhập đi
            f.ShowDialog();
            this.Show();
        }

        // HÀM MÃ HÓA MD5 
        private string MaHoaMD5(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            using (MD5 md5 = MD5.Create())
            {
                // Chuyển chuỗi thành mảng byte
                byte[] inputBytes = Encoding.ASCII.GetBytes(text);

                // Băm (Hash) dữ liệu
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển ngược lại thành chuỗi Hex (VD: A3F1...)
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2")); // X2 để viết hoa
                }
                return sb.ToString();
            }
        }

        private async void btnQuenmk_Click(object sender, EventArgs e)
        {
            // Hiện Loading
            frmLoading frm = new frmLoading();
            frm.Show();
            await Task.Delay(1000);
            frm.Close();
            MessageBox.Show("Vui lòng liên hệ với Quản Trị Viên (Admin) hoặc Nhân viên thư viện để được cấp lại mật khẩu mặc định!",
                                "Hướng dẫn lấy lại mật khẩu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

    }
}