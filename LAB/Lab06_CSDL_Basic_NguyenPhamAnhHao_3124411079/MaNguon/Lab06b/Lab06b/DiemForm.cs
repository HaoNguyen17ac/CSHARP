using System.Windows.Forms;

namespace Lab06b
{
    internal sealed class DiemForm : Form
    {
        private readonly ComboBox cboSinhVien = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cboMonHoc = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TextBox txtDiem = new TextBox { MaxLength = 12 };

        public DiemForm()
        {
            Ui.Init(this, "Bài 2 - Cập nhật điểm", 270);
            Ui.Field(this, "Sinh viên", cboSinhVien, 25);
            Ui.Field(this, "Môn học", cboMonHoc, 70);
            Ui.Field(this, "Điểm", txtDiem, 115);
            // Mỗi lần mở form đều đọc lại mã, bao gồm sinh viên vừa thêm ở Bài 1.
            Load += (s, e) => Ui.Run(this, () =>
            {
                Db.LoadCodes(cboSinhVien, "SELECT MaSinhVien FROM dbo.SinhVien ORDER BY MaSinhVien");
                Db.LoadCodes(cboMonHoc, "SELECT MaMonHoc FROM dbo.MonHoc ORDER BY MaMonHoc");
            });
            Ui.Button(this, "Thêm", 25, 185, () =>
            {
                DiemService.Them(Ma(cboSinhVien), Ma(cboMonHoc), txtDiem.Text);
                Ui.Success(this, "Thêm điểm thành công.");
            });
            Ui.Button(this, "Xóa", 145, 185, () =>
            {
                Db.Require(cboSinhVien.SelectedIndex >= 0 && cboMonHoc.SelectedIndex >= 0,
                           "Phải chọn sinh viên và môn học cần xóa điểm.");
                if (!Ui.Confirm(this, "Xóa điểm của " + Ma(cboSinhVien) + " - " + Ma(cboMonHoc) + "?")) return;
                DiemService.Xoa(Ma(cboSinhVien), Ma(cboMonHoc));
                Ui.Success(this, "Xóa điểm thành công.");
            });
            Ui.Button(this, "Sửa", 265, 185, () =>
            {
                DiemService.Sua(Ma(cboSinhVien), Ma(cboMonHoc), txtDiem.Text);
                Ui.Success(this, "Sửa điểm thành công.");
            });
            Ui.Button(this, "Đóng", 385, 185, Close);
        }

        private static string Ma(ComboBox combo)
        { return combo.SelectedItem == null ? "" : combo.SelectedItem.ToString(); }
    }
}
