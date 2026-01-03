using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_N7
{
    public partial class Dangky : Form
    {
        
        public Dangky()
        {
            InitializeComponent();
        }

        private void Dangky_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtUser, "Nhập mã hoặc tên tài khoản");
            SetPlaceholder(txtPass, "Nhập mật khẩu");
            SetPlaceholder(txtFullname, "Nhập họ tên");

            txtPass.UseSystemPasswordChar = false;
            this.ActiveControl = txtFullname;
        }
        private void SetPlaceholder(TextBox txt, string placeholderText)
        {
            txt.Text = placeholderText;
            txt.ForeColor = Color.Gray;
        }

        

        // --- Ô TÀI KHOẢN ---
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.ForeColor == Color.Gray)
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
                // Ô tài khoản thì không cần chỉnh UseSystemPasswordChar
            }

        }
        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                SetPlaceholder(txtUser, "Nhập mã hoặc tên tài khoản");
            }
        }
        // --- Ô HỌ TÊN ---
        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if (txtFullname.ForeColor == Color.Gray)
            {
                txtFullname.Text = "";
                txtFullname.ForeColor = Color.Black;
            }
        }
        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                SetPlaceholder(txtFullname, "Nhập họ tên");
            }
        }

        // --- Ô MẬT KHẨU (có ẩn/hiện) ---
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.ForeColor == Color.Gray)
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                // Nếu không tích "Hiện mật khẩu" thì ẩn nó đi
                if (!chkHienmk.Checked) txtPass.UseSystemPasswordChar = true;
            }
        }
        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                SetPlaceholder(txtPass, "Nhập mật khẩu");
                txtPass.UseSystemPasswordChar = false; // Hiện chữ gợi ý ra
            }
        }
        //  CHECKBOX HIỆN MẬT KHẨU
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == "Nhập mật khẩu") return;
            // Nếu check thì hiện chữ (UseSystemPasswordChar = false) và ngược lại
            txtPass.UseSystemPasswordChar = !chkHienmk.Checked;
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
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e) 
        {

            // 1. Lấy dữ liệu
            string user = txtUser.Text.Trim();
            if (user == "Nhập mã hoặc tên tài khoản") user = "";

            string pass = txtPass.Text.Trim();
            if (pass == "Nhập mật khẩu") pass = "";

            string name = txtFullname.Text.Trim();
            if (name == "Nhập họ tên" || name == "Nhập họ tên đầy đủ") name = "";

            // 2. Kiểm tra rỗng
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLTV_Nhom7Entities())
                {
                    // 3. Kiểm tra trùng
                    bool isExist = db.TaiKhoans.Any(u => u.TenDangNhap == user);
                    if (isExist)
                    {
                        MessageBox.Show("Tên tài khoản này đã có người sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Tạo tài khoản mới (CÓ MÃ HÓA)
                    var newUser = new TaiKhoan()
                    {
                        TenDangNhap = user,
                        // --- MÃ HÓA TRƯỚC KHI LƯU ---
                        MatKhau = MaHoaMD5(pass),
                        
                        HoTen = name,
                        QuyenHan = "DocGia" 
                    };

                    db.TaiKhoans.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    // Hiện Loading
                    frmLoading frm = new frmLoading();
                    frm.Show();
                    await Task.Delay(1000); // Chờ 1 giây
                    frm.Close();


                    frmdangnhap loginForm = new frmdangnhap();
                    this.Hide();
                    loginForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi Nghiêm Trọng");
            }

        }
    }
}