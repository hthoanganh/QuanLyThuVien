using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Threading.Tasks; // Để dùng lệnh await Task.Delay

namespace BTL_N7
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập 
            if (string.IsNullOrEmpty(Session.TenDangNhap))
            {
                this.Hide();
                frmdangnhap login = new frmdangnhap();
                if (login.ShowDialog() != DialogResult.OK) { }
                this.Show();
            }
            txtHienten.Text = Session.HoTen;
            txtHienten.TabStop = false;
            this.ActiveControl = null;
            txtHienten.Cursor = Cursors.Arrow;

            // Gọi hàm phân quyền
            PhanQuyenMenu();


        }




        // Hàm dùng chung để mở form con (MDI Parent)
        private async void OpenChildForm(Form childForm)
        {
            // 1. KIỂM TRA: Nếu form này đã mở rồi thì chỉ cần kích hoạt lại (Không cần hiện Loading)
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == childForm.Name)
                {
                    f.Activate();
                    // Nếu form đã mở rồi thì hủy cái form mới tạo đi cho đỡ tốn Ram
                    childForm.Dispose();
                    return;
                }
            }

            // 2. HIỆN FORM LOADING
            frmLoading loading = new frmLoading();
            loading.Show();

            // Chờ
            await Task.Delay(800);

            // mở form con
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;
            childForm.Show(); // Lúc này form con mới bắt đầu load dữ liệu

            loading.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.TenDangNhap = "";
                Session.HoTen = "";
                this.Hide();
                new frmdangnhap().ShowDialog();
                this.Close();
            }
        }

        private void quảnLýSáchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhosach());
        }
        private void quảnLýĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDocgia());

        }



        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhosach());
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMuonSach());
        }

        private void quảnLýTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTraSach());
        }

        private void mượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMuonSach());
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
        }

        private void traCứuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaocao());
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e) // Tên hàm của bạn có thể khác chút
        {
            frmQuanLyMatKhau f = new frmQuanLyMatKhau();
            f.ShowDialog(); // Hiện form con lên
        }
        void PhanQuyenMenu()
        {
            // Lấy quyền 
            string quyen = Session.QuyenHan.Trim();

            // 1. Nếu là ADMIN -> Thấy hết -> Thoát luôn
            if (quyen == "Admin") return;

            // 2. XỬ LÝ CHO ĐỘC GIẢ
            if (quyen == "DocGia")
            {
                // Ẩn menu con "Quản Lý ĐG
                danhMụcToolStripMenuItem.Visible = false;
                quảnLýĐộcGiảToolStripMenuItem.Visible = false;
                quảnLýTrảMượnToolStripMenuItem.Visible = false;

                // Menu "Quản Lý Sách" giữ lại nhưng đổi tên thành Tra cứu
                Khosach.Text = "Tra cứu sách";
                SaoluuToolStripMenuItem.Visible = false;
                phụcHồiToolStripMenuItem.Visible = false;
            }


            // 3. XỬ LÝ CHO NHÂN VIÊN
            if (quyen == "NhanVien")
            {
                // Nhân viên chỉ được làm nghiệp vụ Mượn/Trả, không được đụng vào Hệ thống
                SaoluuToolStripMenuItem.Visible = false;
                phụcHồiToolStripMenuItem.Visible = false;

                // Ẩn luôn quản lý tài khoản (Không cho nhân viên tạo/xóa nick người khác)
                // quảnLýTàiKhoảnToolStripMenuItem.Visible = false; 
            }
        }

        private async void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoading loading = new frmLoading();
            loading.Show();

            await Task.Delay(800); // Chờ 0.8 giây

            // Mở form quản lý mật khẩu nhưng mở dạng Dialog (cửa sổ con bắt buộc xử lý xong mới đóng)
            frmQuanLyMatKhau f = new frmQuanLyMatKhau();

            // Ẩn loading đi rồi mới hiện form lên
            loading.Close();

            OpenChildForm(new frmQuanLyMatKhau());
        }

        private async void SaoluuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.QuyenHan.Trim() != "Admin")
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại 
            }
            // 1. Mở cửa sổ chọn nơi lưu file
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Backup File|*.bak";
            save.FileName = "QLTV_Backup_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".bak"; // Tự đặt tên có ngày giờ

            if (save.ShowDialog() == DialogResult.OK)
            {
                frmLoading loading = new frmLoading();
                loading.Show();
                await Task.Delay(1500);

                try
                {
                    // 2. Chạy lệnh Backup
                   
                    string dbName = "QLTV_Nhom7";
                    string sqlBackup = $"BACKUP DATABASE [{dbName}] TO DISK = '{save.FileName}'";

                    // Chạy lệnh Backup trong Task để không làm đơ giao diện
                    await Task.Run(() =>
                    {
                        using (var db = new QLTV_Nhom7Entities())
                        {
                            db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, sqlBackup);
                        }
                    });

                    // Tắt loading trước khi hiện thông báo
                    loading.Close();
                    MessageBox.Show("Sao lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    loading.Close(); // Nhớ tắt loading nếu lỗi
                    MessageBox.Show("Lỗi sao lưu: " + ex.Message);
                }
            }
        }

        private async void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.QuyenHan.Trim() != "Admin")
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Backup File|*.bak";

            if (open.ShowDialog() == DialogResult.OK)
            {
                frmLoading loading = new frmLoading();
                loading.Show();

                await Task.Delay(2000);

                try
                {
                    string dbName = "QLTV_Nhom7"; // Tên Database
                    string filePath = open.FileName;

                    // Câu lệnh SQL để Restore (Bất chấp đang có kết nối)
                    string sqlRestore = string.Format(
                        "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " + // Đá hết kết nối khác
                        "USE master; " +                                                   // Chuyển sang dùng master
                        "RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH REPLACE; " +        // Restore đè lên
                        "ALTER DATABASE [{0}] SET MULTI_USER;",                            // Mở lại cho mọi người dùng
                        dbName, filePath);

                    // Chạy Restore bất đồng bộ
                    await Task.Run(() =>
                    {
                        using (var db = new QLTV_Nhom7Entities())
                        {
                            db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, sqlRestore);
                        }
                    });

                    loading.Close();
                    MessageBox.Show("Phục hồi dữ liệu thành công! Phần mềm sẽ khởi động lại.", "Thông báo");
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    loading.Close();
                    MessageBox.Show("Lỗi phục hồi: " + ex.Message);
                }
            }
        }

        private async void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traloi == DialogResult.Yes)
            {
                // Hiện Loading
                frmLoading frm = new frmLoading();
                frm.Show();
                await Task.Delay(1500);


                // Xóa thông tin phiên đăng nhập cũ (Quan trọng)
                Session.TenDangNhap = "";
                Session.HoTen = "";
                Session.QuyenHan = "";

                // Tắt frm và ẩn form Main đi không đóng hẳn
                frm.Close();
                this.Hide();

                // Mở lại form Đăng nhập
                frmdangnhap login = new frmdangnhap();

                // Chờ kết quả từ form đăng nhập
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    // Gọi lại hàm Load để cập nhật tên người dùng mới lên giao diện
                    frmmain_Load(sender, e);
                }
                else
                {
                    // Nếu ở form đăng nhập bấm Thoát -> Thì tắt luôn chương trình
                    Application.Exit();
                }
            }
        }

        private async void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu chọn Yes thì tắt
            if (traloi == DialogResult.Yes)
            {
                // Hiện Loading 
                frmLoading frm = new frmLoading();
                frm.Show();
                await Task.Delay(1000); 
                frm.Close();
                Application.Exit();
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true; // Hủy lệnh đóng form (Giữ form lại)
            }
        }

        private async void vềChúngTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoading loading = new frmLoading();
            loading.Show();

            // Chờ 1 giây 
            await Task.Delay(1000);
            loading.Close();
            string thongtin = "PHẦN MỀM QUẢN LÝ THƯ VIỆN\n" +
                      "Phiên bản: 11.04.0\n\n" +
                      "--- THÀNH VIÊN NHÓM 7 ---\n" +
                      "1. Huỳnh Thanh Hoàng Anh - 0023411989 (Nhóm trưởng)\n" +
                      "2. Lê Đặng Phương Anh - 0023412580\n" +
                      "3. Trần Nhật Huy - 0023410381\n\n" +
                      "GVHD: Cô Huỳnh Lê Uyên Minh\n" +
                      "Cảm ơn cô và các bạn đã sử dụng!";

            MessageBox.Show(thongtin, "Về chúng tôi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}

