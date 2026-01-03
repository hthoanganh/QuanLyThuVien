using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_N7.Dtos;
using System.Text;

namespace BTL_N7
{
    public partial class frmDOCGIA : Form
    {
        private readonly string _baseUrl = "https://localhost:7040/api/Readers";
        public frmDOCGIA()
        {
            InitializeComponent();
            this.Load += frmDocgia_Load;
        }

        public class ReaderDto
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public DateTime DateOfBirth { get; set; } // Thêm trường Ngày sinh
        }

        private async void frmDocgia_Load(object sender, EventArgs e) // Đổi tên sự kiện Load
        {
            // Tên GridView là dgvDocGia
            dgvDocgia.AutoGenerateColumns = false;
            dgvDocgia.Columns.Clear();

            // 2. Tạo cột thủ công cho ĐỘC GIẢ
            dgvDocgia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã ĐG", Name = "colId" });
            dgvDocgia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ Tên", Name = "colFullName", Width = 200 });
            dgvDocgia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "SĐT", Name = "colPhoneNumber" });
            dgvDocgia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Địa Chỉ", Name = "colAddress" });
            dgvDocgia.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DateOfBirth", HeaderText = "Ngày Sinh", Name = "colDateOfBirth", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });

            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Fix lỗi API trả về chữ thường, DTO chữ Hoa
                    var options = new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var books = await client.GetFromJsonAsync<List<BookDto>>(_baseUrl, options);
                    dgvDocgia.DataSource = books;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void lblTensach_Click(object sender, EventArgs e)
        {

        }

        private async void btnThemsach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTendocgia.Text)) { MessageBox.Show("Chưa nhập tên sách!"); return; }

            var newBook = new
            {
                Title = txtTendocgia.Text,
                Author = txtSDT.Text, // Gửi dữ liệu ô này vào trường Author của API
                Category = txtDIACHI.Text       // Gửi dữ liệu ô này vào trường Category của API
            };

            await CallApi(HttpMethod.Post, _baseUrl, newBook, "Thêm thành công!");
        }

        private async void btnSuasach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMasach.Text)) return;
            int id = int.Parse(txtMasach.Text);

            var updateBook = new
            {
                Id = id,
                Title = txtTendocgia.Text,
                Author = txtSDT.Text,
                Category = txtDIACHI.Text
            };

            await CallApi(HttpMethod.Put, $"{_baseUrl}/{id}", updateBook, "Sửa thành công!");
        
        }

        private async void btnXoasach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMasach.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = int.Parse(txtMasach.Text);
                using (HttpClient client = new HttpClient())
                {
                    // Gắn Token Admin
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);

                    var res = await client.DeleteAsync($"{_baseUrl}/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa!");
                        await LoadData();
                        ClearInput();
                    }
                    else MessageBox.Show("Lỗi xóa (Có thể do thiếu quyền Admin)!");
                }
            }
        }

        // Hàm gọi API chung cho gọn
        private async Task CallApi(HttpMethod method, string url, object data, string successMsg)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);

                HttpResponseMessage res;
                if (method == HttpMethod.Post) res = await client.PostAsJsonAsync(url, data);
                else res = await client.PutAsJsonAsync(url, data);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show(successMsg);
                    await LoadData();
                    ClearInput();
                }
                else MessageBox.Show("Thất bại! Mã lỗi: " + res.StatusCode);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy dòng hiện tại
            var row = dgvDocgia.Rows[e.RowIndex];

            // Lấy object từ dòng đó (cần ép kiểu về BookDto)
            var book = row.DataBoundItem as BookDto;

            if (book != null)
            {
                txtMasach.Text = book.Id.ToString();
                txtTendocgia.Text = book.Title;
                txtSDT.Text = book.Author;   // Map Author vào ô Năm XB
                txtDIACHI.Text = book.Category;        // Map Category vào ô Nhà XB
            }
        }

            private void ClearInput()
        {
            txtMasach.Clear();
            txtTendocgia.Clear();
            txtSDT.Clear();
            txtDIACHI.Clear();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
    }
}