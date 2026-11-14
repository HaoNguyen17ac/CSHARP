using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06a
{
    // Bài 1 về nhà, mục 4 của đề 06a; đánh số Bài 2 trong bài nộp.
    public partial class LopForm : Form
    {
        public LopForm()
        {
            InitializeComponent();
            Shown += (sender, e) => LoadClasses();
        }

        private void LoadClasses()
        {
            Ui.Try(this, "Tải danh sách lớp", () =>
                grid.DataSource = Db.Query("SELECT MaLop AS [Mã lớp], TenLop AS [Tên lớp], " +
                    "MaKhoa AS [Mã khoa] FROM dbo.Lop ORDER BY MaLop"));
        }

        private bool ValidateCode()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                Ui.Warn(this, "Mã lớp không được để trống.");
                txtMaLop.Focus();
                return false;
            }
            return true;
        }

        private SqlParameter[] ClassParameters()
        {
            return new[]
            {
                Db.Text("@MaLop", SqlDbType.VarChar, 10, txtMaLop.Text),
                Db.Text("@TenLop", SqlDbType.NVarChar, 100, txtTenLop.Text),
                Db.Text("@MaKhoa", SqlDbType.VarChar, 10, txtMaKhoa.Text)
            };
        }

        private void ApplyChange(string action, string sql, params SqlParameter[] parameters)
        {
            int count = 0;
            if (!Ui.Try(this, action, () => count = Db.Execute(sql, parameters))) return;
            Ui.ShowAffected(this, action, count);
            if (count > 0) LoadClasses();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateCode()) return;
            // Thêm mới bắt buộc có đủ ba trường. SQL Server kiểm tra mã khoa
            // qua khóa ngoại FK_Lop_Khoa, nên không thể thêm một khoa không có.
            if (string.IsNullOrWhiteSpace(txtTenLop.Text) ||
                string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                Ui.Warn(this, "Khi thêm, phải nhập đủ mã lớp, tên lớp và mã khoa.");
                return;
            }
            ApplyChange("Thêm lớp", "INSERT INTO dbo.Lop (MaLop, TenLop, MaKhoa) " +
                "VALUES (@MaLop, @TenLop, @MaKhoa)", ClassParameters());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!ValidateCode()) return;
            if (!string.IsNullOrWhiteSpace(txtTenLop.Text) ||
                !string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                Ui.Warn(this, "Khi xóa, chỉ nhập mã lớp; tên lớp và mã khoa phải để trống.");
                return;
            }
            if (!Ui.ConfirmDelete(this, "lớp " + txtMaLop.Text.Trim())) return;
            // Không xóa dây chuyền sinh viên. Nếu lớp có sinh viên, FK từ chối
            // và Ui.Try hiển thị thông báo thay vì làm chương trình dừng đột ngột.
            ApplyChange("Xóa lớp", "DELETE FROM dbo.Lop WHERE MaLop = @MaLop",
                Db.Text("@MaLop", SqlDbType.VarChar, 10, txtMaLop.Text));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateCode()) return;
            if (string.IsNullOrWhiteSpace(txtTenLop.Text) &&
                string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                Ui.Warn(this, "Khi sửa, cần nhập ít nhất tên lớp hoặc mã khoa.");
                return;
            }
            // CASE giữ nguyên trường để trống; không ghi chuỗi rỗng xuống CSDL.
            // Có thể chỉ sửa tên, chỉ sửa khoa hoặc sửa đồng thời cả hai trường.
            ApplyChange("Sửa lớp", "UPDATE dbo.Lop SET " +
                "TenLop = CASE WHEN @TenLop = N'' THEN TenLop ELSE @TenLop END, " +
                "MaKhoa = CASE WHEN @MaKhoa = '' THEN MaKhoa ELSE @MaKhoa END " +
                "WHERE MaLop = @MaLop", ClassParameters());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaKhoa.Clear();
            txtMaLop.Focus();
            LoadClasses();
        }
    }
}
