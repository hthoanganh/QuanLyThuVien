using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTL_N7
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }


        private void frmThongKe_Load(object sender, EventArgs e)
        {
            SetupGiaoDien();
        }

        // Để đảm bảo load được
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cmbTieuchi.Items.Count == 0)
                SetupGiaoDien();
        }


        private void SetupGiaoDien()
        {
            cmbTieuchi.Items.Clear();
            cmbTieuchi.Items.Add("Thống kê số lượng sách theo Thể loại");
            cmbTieuchi.Items.Add("Top 5 sách được mượn nhiều nhất");
            cmbTieuchi.Items.Add("Tình trạng sách (Đang mượn vs Trong kho)");
            cmbTieuchi.Items.Add("Top 5 Độc giả mượn sách tích cực nhất");

            cmbTieuchi.SelectedIndex = 0;

            // Đăng ký lại sự kiện để tránh bị double click
            btnXacnhan.Click -= btnXacnhan_Click;
            btnXacnhan.Click += btnXacnhan_Click;
            button1.Click -= btnXuatExcel_Click;
            button1.Click += btnXuatExcel_Click;
        }


        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            // 1. Xóa sạch biểu đồ cũ
            if (chartBookStats.Series.Count > 0)
                chartBookStats.Series[0].Points.Clear();

            using (var db = new QLTV_Nhom7Entities())
            {
                try
                {
                    var dataResult = new List<dynamic>();
                    string chartTitle = "";
                    string headerTen = "";

                    switch (cmbTieuchi.SelectedIndex)
                    {
                        
                        // CASE 0: THEO THỂ LOẠI 
                        
                        case 0:
                            chartTitle = "Cơ cấu sách trong kho theo Thể loại";
                            headerTen = "Tên Thể Loại";
                            dataResult = db.Saches
                                .GroupBy(s => s.TheLoai)
                                .Select(g => new
                                {
                                    Ten = g.Key,
                                    SoLuong = g.Sum(x => (int?)x.SoLuong) ?? 0
                                }).ToList<dynamic>();
                            break;

                      
                        // CASE 1: TOP 5 SÁCH (Nếu NULL tính là 1)
                       
                        case 1:
                            chartTitle = "Top 5 Sách được mượn nhiều nhất";
                            headerTen = "Tên Sách";
                            var queryTop5 = from ct in db.ChiTietPhieuMuons
                                            join s in db.Saches on ct.MaSach equals s.MaSach
                                            group ct by s.TenSach into g
                                            select new
                                            {
                                                Ten = g.Key,
                                                //  (x.SoLuongMuon ?? 1) -> Nếu rỗng thì lấy 1
                                                SoLuong = g.Sum(x => (int?)x.SoLuongMuon ?? 1)
                                            };
                            dataResult = queryTop5.OrderByDescending(x => x.SoLuong).Take(5).ToList<dynamic>();
                            break;

                      
                        // CASE 2: TÌNH TRẠNG SÁCH ( Nếu NULL tính là 1)
                       
                        case 2:
                            chartTitle = "Tình trạng Sách (Thực tế)";
                            headerTen = "Trạng Thái";

                            // Chỉ đếm những dòng nào CHƯA CÓ ngày trả (NgayTraSach bị NULL)
                            // Bất kể trạng thái phiếu là gì, hễ chưa điền ngày trả là tính đang mượn
                            // Chính xác với những gì vừa xử lý bên form Trả Sách
                            var sumDangMuon = (from ct in db.ChiTietPhieuMuons
                                               where ct.NgayTraSach == null
                                               select (int?)ct.SoLuongMuon ?? 1).Sum();

                            int slDangMuon = sumDangMuon;

                            // Tính tổng kho (Lấy tổng số lượng sách ban đầu)
                            // Giả định SoLuong trong bảng Sach là tổng nhập ban đầu
                            int slTrongKho = (int)(db.Saches.Sum(s => (int?)s.SoLuong) ?? 0);

                            // Hoặc nếu cột SoLuong là "số còn lại trên kệ", thì dùng dòng dưới:
                            // int slTrongKho = (int)(db.Saches.Sum(s => (int?)s.SoLuong) ?? 0); 
                            // Và không cần trừ slDangMuon nữa. 
                            // Với code trả sách  thì cột SoLuong là số thực trên kệ.
                            // Nên ta lấy trực tiếp:

                            dataResult.Add(new { Ten = "Đang được mượn", SoLuong = slDangMuon });
                            dataResult.Add(new { Ten = "Sẵn sàng trong kho", SoLuong = slTrongKho });
                            break;

                        // CASE 3: TOP ĐỘC GIẢ (Nếu NULL tính là 1)

                        case 3:
                            chartTitle = "Top 5 Độc giả mượn sách tích cực nhất";
                            headerTen = "Tên Độc Giả";
                            var queryDocGia = from pm in db.PhieuMuons
                                              join ct in db.ChiTietPhieuMuons on pm.MaPhieu equals ct.MaPhieu
                                              join dg in db.DocGias on pm.MaDocGia equals dg.MaDocGia
                                              group ct by new { dg.MaDocGia, dg.TenDocGia } into g
                                              select new
                                              {
                                                  Ten = g.Key.TenDocGia,
                                                  //(x.SoLuongMuon ?? 1)
                                                  SoLuong = g.Sum(x => (int?)x.SoLuongMuon ?? 1)
                                              };
                            dataResult = queryDocGia.OrderByDescending(x => x.SoLuong).Take(5).ToList<dynamic>();
                            break;
                    }

                    // Gọi hàm hiển thị
                    HienThiDuLieu(dataResult, chartTitle, headerTen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
                }
            }
        }

        private void HienThiDuLieu(List<dynamic> dataList, string title, string headerName)
        {
            double tongSoLuong = 0;
            foreach (var item in dataList) tongSoLuong += item.SoLuong;

            var listHienThi = dataList.Select(x => new {
                Ten = x.Ten,
                SoLuong = x.SoLuong,
                TyLe = (tongSoLuong > 0) ? Math.Round((double)x.SoLuong / tongSoLuong * 100, 1) + "%" : "0%"
            }).ToList();

            dgvThongke.DataSource = listHienThi;
            dgvThongke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvThongke.Columns["Ten"] != null) dgvThongke.Columns["Ten"].HeaderText = headerName;
            if (dgvThongke.Columns["SoLuong"] != null) dgvThongke.Columns["SoLuong"].HeaderText = "Số Lượng";
            if (dgvThongke.Columns["TyLe"] != null) dgvThongke.Columns["TyLe"].HeaderText = "Tỷ Lệ";

            chartBookStats.Titles.Clear();
            chartBookStats.Titles.Add(title);
            chartBookStats.Series.Clear();
            var series = chartBookStats.Series.Add("Series1");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;

            foreach (var item in dataList)
            {
                if (item.SoLuong > 0)
                {
                    int i = series.Points.AddXY(item.Ten, item.SoLuong);
                    series.Points[i].Label = "#PERCENT{P1}";
                    series.Points[i].LegendText = item.Ten;
                }
            }
        }





        // Hàm xuất Excel VIP: Có cả Bảng số liệu + Biểu đồ
        private void XuatExcelVIP(DataGridView dgv, Chart chart, string tieuDe)
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
                worksheet.Name = "Thống kê";

                // --- PHẦN HEADER ---
                int colCount = dgv.Columns.Count;

                // Tiêu đề lớn
                // Merge ô để tiêu đề nằm giữa cả bảng và biểu đồ (cộng thêm 5 cột cho rộng)
                Excel.Range head = worksheet.get_Range("A1", GetExcelColumnName(colCount + 5) + "1");
                head.MergeCells = true;
                head.Value2 = tieuDe.ToUpper();
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = 18;
                head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Ngày giờ
                Excel.Range info = worksheet.get_Range("A2", GetExcelColumnName(colCount + 5) + "2");
                info.MergeCells = true;
                info.Value2 = $"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                info.Font.Name = "Times New Roman";
                info.Font.Size = 11;
                info.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // --- ĐỔ DỮ LIỆU BẢNG ---
                // Tiêu đề cột
                int rowStart = 4;
                for (int i = 0; i < colCount; i++)
                {
                    worksheet.Cells[rowStart, i + 1] = dgv.Columns[i].HeaderText;
                }

                // Format tiêu đề cột
                Excel.Range rowHead = worksheet.get_Range("A4", GetExcelColumnName(colCount) + "4");
                rowHead.Font.Bold = true;
                rowHead.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rowHead.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                rowHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Dữ liệu dòng
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
                // 1. Cho Excel tự co giãn vừa chữ trước
                worksheet.Columns.AutoFit();

                // 2. Duyệt qua từng cột của bảng để cộng thêm độ rộng
                // Lưu ý: Chỉ chỉnh độ rộng các cột có dữ liệu (từ 1 đến colCount)
                for (int i = 1; i <= colCount; i++)
                {
                    Excel.Range col = (Excel.Range)worksheet.Columns[i];
                    // Cộng thêm 5 đơn vị vào độ rộng hiện tại -> Bảng sẽ rất thoáng
                    col.ColumnWidth = (double)col.ColumnWidth + 5;
                }


                // --- CHÈN BIỂU ĐỒ (PHẦN MỚI) ---
                if (chart != null)
                {
                    // Bước A: Lưu biểu đồ thành ảnh vào bộ nhớ (MemoryStream)
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        chart.SaveImage(ms, ChartImageFormat.Png);

                        // Bước B: Copy ảnh vào Clipboard
                        using (System.Drawing.Bitmap bm = new System.Drawing.Bitmap(ms))
                        {
                            Clipboard.SetImage(bm);
                        }
                    }

                    // Bước C: Dán vào Excel (Đặt bên cạnh cái bảng, cách ra 1 cột)
                    // Vị trí dán: Cột (colCount + 2), Dòng 4 (ngang hàng tiêu đề bảng)
                    string pos = GetExcelColumnName(colCount + 2) + "4";
                    Excel.Range pasteRange = worksheet.get_Range(pos);
                    pasteRange.Select();
                    worksheet.Paste();

                    // Xóa clipboard để sạch bộ nhớ
                    Clipboard.Clear();
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


        private async void btnXuatExcel_Click(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show();
            await Task.Delay(1000);

            try
            {
                // Tạo tiêu đề
                string tieuDe = "";
                switch (cmbTieuchi.SelectedIndex)
                {
                    case 0: tieuDe = "THỐNG KÊ SÁCH THEO THỂ LOẠI"; break;
                    case 1: tieuDe = "TOP 5 SÁCH ĐƯỢC MƯỢN NHIỀU NHẤT"; break;
                    case 2: tieuDe = "BÁO CÁO TÌNH TRẠNG SÁCH"; break;
                    case 3: tieuDe = "TOP 5 ĐỘC GIẢ MƯỢN SÁCH TÍCH CỰC"; break;
                    default: tieuDe = "BÁO CÁO THỐNG KÊ"; break;
                }

                // GỌI HÀM (Truyền thêm chartBookStats vào tham số thứ 2)
                XuatExcelVIP(dgvThongke, chartBookStats, tieuDe);
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

        // Hàm phụ trợ để đổi số thành chữ cái cột Excel (Ví dụ: 1 -> A, 2 -> B...)
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
