using Microsoft.Reporting.WinForms; 
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BTL_N7
{
    public partial class frmBaocao : Form
    {
        public frmBaocao()
        {
            InitializeComponent();
        }

        private void frmBaocao_Load(object sender, EventArgs e)
        {

            LoadBaoCao(); // Gọi hàm tải dữ liệu ngay khi mở
                          // Tạo tham số (Thay "Nguyễn Văn A" bằng tên bạn muốn hiển thị)
            string tenNguoiLap = txtNguoilap.Text; // Lấy chữ gõ trong ô Textbox
            if (string.IsNullOrEmpty(tenNguoiLap)) tenNguoiLap = "Người thực hiện"; // Giá trị mặc định nếu quên nhập

            ReportParameter p = new ReportParameter("pNguoiLap", tenNguoiLap);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
            this.reportViewer1.RefreshReport();
        }

        private void btnTaidl_Click(object sender, EventArgs e)
        {
            LoadBaoCao(); // Gọi lại hàm tải dữ liệu
            MessageBox.Show("Đã cập nhật dữ liệu mới nhất!", "Thông báo");
        }

        private async void btnXuat_Click(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show();
            await Task.Delay(1000);

            try
            {
                // 1. Cấu hình các tham số xuất file
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                // 2. Render báo cáo ra dạng byte (Excel)
                byte[] bytes = reportViewer1.LocalReport.Render(
                    "Excel", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);

                // 3. Mở hộp thoại để người dùng chọn nơi lưu
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Files|*.xls";
                saveFileDialog1.FileName = "BaoCao_ThuVien_" + DateTime.Now.ToString("ddMMyyyy_HHmm");
                saveFileDialog1.Title = "Lưu báo cáo Excel";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // 4. Ghi file xuống ổ cứng
                    File.WriteAllBytes(saveFileDialog1.FileName, bytes);
                    MessageBox.Show("Xuất Excel thành công!\nĐường dẫn: " + saveFileDialog1.FileName, "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi");
            }
            finally
            {
                frm.Close();
            }
        }

        // --- HÀM CHUYÊN XỬ LÝ VIỆC LẤY DỮ LIỆU ---
        // Tách ra để dùng chung cho cả Form_Load và Nút Tải lại
        private void LoadBaoCao()
        {
            try
            {
                using (var db = new QLTV_Nhom7Entities())
                {
                    // 1. LẤY DỮ LIỆU TỪ DATABASE
                    var list = (from pm in db.PhieuMuons
                                join ct in db.ChiTietPhieuMuons on pm.MaPhieu equals ct.MaPhieu
                                join dg in db.DocGias on pm.MaDocGia equals dg.MaDocGia
                                join s in db.Saches on ct.MaSach equals s.MaSach
                                select new
                                {
                                    TenDocGia = dg.TenDocGia,
                                    Lop = dg.Lop,
                                    TenSach = s.TenSach,
                                    NgayMuon = pm.NgayMuon,
                                    HanTra = pm.HanTra,
                                    TrangThai = pm.TrangThai,
                                    GhiChu = ct.GhiChu,
                                    TienPhat = ct.TienPhat
                                }).ToList();

                    // 2. ĐỔ VÀO DATATABLE
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TenDocGia");
                    dt.Columns.Add("Lop");
                    dt.Columns.Add("TenSach");
                    dt.Columns.Add("NgayMuon");
                    dt.Columns.Add("HanTra");
                    dt.Columns.Add("TrangThai");
                    dt.Columns.Add("GhiChu");
                    dt.Columns.Add("TienPhat");

                    foreach (var item in list)
                    {
                        string sNgayMuon = string.Format("{0:dd/MM/yyyy}", item.NgayMuon);
                        string sHanTra = string.Format("{0:dd/MM/yyyy}", item.HanTra);
                        decimal tien = item.TienPhat ?? 0;
                        string sTienPhat = string.Format("{0:#,##0}", tien);

                        dt.Rows.Add(item.TenDocGia, item.Lop, item.TenSach, sNgayMuon, sHanTra, item.TrangThai, item.GhiChu, sTienPhat);
                    }

                    // 3. CẤU HÌNH REPORT
                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.ReportPath = "rptBaocao.rdlc";

                    // Đưa dữ liệu vào
                    ReportDataSource rds = new ReportDataSource("dsBaoCao", dt);
                    this.reportViewer1.LocalReport.DataSources.Add(rds);

                    
                    // Lấy tên từ ô nhập liệu txtNguoiLap
                    string tenNguoiLap = txtNguoilap.Text;

                    // Nếu quên nhập thì lấy mặc định
                    if (string.IsNullOrEmpty(tenNguoiLap)) tenNguoiLap = "Người thực hiện";

                    // Đẩy tên vào tham số pNguoiLap trong báo cáo
                    ReportParameter p = new ReportParameter("pNguoiLap", tenNguoiLap);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
                    

                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: " + ex.Message);
            }
        }
    }
}
