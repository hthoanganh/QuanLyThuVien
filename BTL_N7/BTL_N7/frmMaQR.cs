using QRCoder;
using System;
using System.Drawing; // Thư viện xử lý ảnh
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BTL_N7
{
    public partial class frmMaQR : Form
    {
        // Biến để nhận dữ liệu từ form Kho Sách truyền sang
        string _duLieuQR;
        public frmMaQR(string thongTinNhanDuoc)
        {
            InitializeComponent();
            this._duLieuQR = thongTinNhanDuoc;
        }

        private void frmMaQR_Load(object sender, EventArgs e)
        {
            // Khi form hiện lên thì vẽ QR luôn
            if (!string.IsNullOrEmpty(_duLieuQR))
            {
                TaoMaQR(_duLieuQR);
            }
        }

        void TaoMaQR(string noiDung)
        {
            try
            {
                // 1. Khởi tạo bộ tạo mã
                QRCodeGenerator qrGenerator = new QRCodeGenerator();

                // 2. Tạo dữ liệu QR
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(noiDung, QRCodeGenerator.ECCLevel.Q);

                // 3. Vẽ ra thành hình ảnh
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10); // Số 10 là độ phân giải ảnh (Pixels per Module)

                // 4. Gán vào PictureBox
                picQR.Image = qrCodeImage;

                // Chỉnh chế độ hiển thị để ảnh không bị méo hoặc bị cắt
                picQR.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (picQR.Image == null) return;

            // --- TỰ ĐỘNG ĐẶT TÊN FILE ---
            string tenFileGoiY = "QR_Book"; // Tên mặc định

            // Dùng Regex để tìm dòng "Mã sách: ..." trong nội dung QR để lấy mã ra đặt tên file
            // Ví dụ nội dung là: "Mã sách: 123\nTên sách..." => Nó sẽ lấy được số "123"
            if (!string.IsNullOrEmpty(_duLieuQR))
            {
                var match = Regex.Match(_duLieuQR, @"Mã sách:\s*(.+?)(\n|$)");
                if (match.Success)
                {
                    // Lấy mã sách và loại bỏ khoảng trắng thừa
                    string maSachTimDuoc = match.Groups[1].Value.Trim();
                    tenFileGoiY = "QR_" + maSachTimDuoc;
                }
            }

            // --- HỘP THOẠI LƯU ---
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PNG Image|*.png";
            save.FileName = tenFileGoiY + ".png"; // Gán tên file đã xử lý vào đây

            if (save.ShowDialog() == DialogResult.OK)
            {
                picQR.Image.Save(save.FileName);
                MessageBox.Show("Đã lưu ảnh mã QR thành công!");
            }
        }
    }
}
