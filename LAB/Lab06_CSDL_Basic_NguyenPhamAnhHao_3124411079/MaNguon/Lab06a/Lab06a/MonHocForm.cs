using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06a
{
    // Bài 1 tại lớp, mục 2 của đề 06a: thêm, xóa, sửa bảng MonHoc.
    public partial class MonHocForm : Form
    {
        public MonHocForm()
        {
            InitializeComponent();
            Shown += (sender, e) => LoadCourses();
        }

        private void LoadCourses()
        {
            // Lưới chỉ đọc giúp quan sát dữ liệu thật sau mỗi thao tác.
            Ui.Try(this, "Tải danh sách môn học", () =>
                grid.DataSource = Db.Query("SELECT MaMonHoc AS [Mã môn học], " +
                    "TenMonHoc AS [Tên môn học] FROM dbo.MonHoc ORDER BY MaMonHoc"));
        }

        private bool ValidateCode()
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                Ui.Warn(this, "Mã môn học không được để trống.");
                txtMa.Focus();
                return false;
            }
            return true;
        }

        private bool ValidateInfo()
        {
            if (!ValidateCode()) return false;
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                Ui.Warn(this, "Tên môn học không được để trống khi thêm hoặc sửa.");
                txtTen.Focus();
                return false;
            }
            return true;
        }

        private SqlParameter[] CourseParameters()
        {
            // Mã là VARCHAR; tên dùng NVARCHAR để giữ nguyên tiếng Việt.
            return new[]
            {
                Db.Text("@MaMonHoc", SqlDbType.VarChar, 10, txtMa.Text),
                Db.Text("@TenMonHoc", SqlDbType.NVarChar, 100, txtTen.Text)
            };
        }

        private void ApplyChange(string action, string sql, params SqlParameter[] parameters)
        {
            int count = 0;
            if (!Ui.Try(this, action, () => count = Db.Execute(sql, parameters))) return;
            // Phân biệt thành công với trường hợp mã cần sửa/xóa không tồn tại.
            Ui.ShowAffected(this, action, count);
            if (count > 0) LoadCourses();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInfo()) return;
            ApplyChange("Thêm môn học", "INSERT INTO dbo.MonHoc (MaMonHoc, TenMonHoc) " +
                "VALUES (@MaMonHoc, @TenMonHoc)", CourseParameters());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!ValidateCode()) return;
            // Đề yêu cầu xóa chỉ nhập mã, ô tên môn học để trống.
            if (!string.IsNullOrWhiteSpace(txtTen.Text))
            {
                Ui.Warn(this, "Khi xóa, chỉ nhập mã môn học và để trống tên môn học.");
                return;
            }
            if (!Ui.ConfirmDelete(this, "môn học " + txtMa.Text.Trim())) return;
            ApplyChange("Xóa môn học", "DELETE FROM dbo.MonHoc WHERE MaMonHoc = @MaMonHoc",
                Db.Text("@MaMonHoc", SqlDbType.VarChar, 10, txtMa.Text));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInfo()) return;
            // Giữ nguyên khóa MaMonHoc, chỉ thay đổi TenMonHoc.
            ApplyChange("Sửa môn học", "UPDATE dbo.MonHoc SET TenMonHoc = @TenMonHoc " +
                "WHERE MaMonHoc = @MaMonHoc", CourseParameters());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMa.Clear();
            txtTen.Clear();
            txtMa.Focus();
            LoadCourses();
        }
    }
}
