using System;
using System.Windows.Forms;

namespace Lab06b
{
    internal sealed class SinhVienForm : Form
    {
        private readonly TextBox txtMa = new TextBox { MaxLength = 10 };
        private readonly TextBox txtHoTen = new TextBox { MaxLength = 100 };
        private readonly DateTimePicker dtpNgaySinh = new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy",
            ShowCheckBox = true, Checked = false, MaxDate = DateTime.Today
        };
        private readonly ComboBox cboLop = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

        public SinhVienForm()
        {
            Ui.Init(this, "Bài 1 - Quản lý sinh viên", 310);
            Ui.Field(this, "Mã sinh viên", txtMa, 25);
            Ui.Field(this, "Họ tên", txtHoTen, 70);
            Ui.Field(this, "Ngày sinh", dtpNgaySinh, 115);
            Ui.Field(this, "Lớp", cboLop, 160);
            // LoadCodes dùng SqlDataReader đọc từng MaLop lên combobox.
            Load += (s, e) => Ui.Run(this, () =>
                Db.LoadCodes(cboLop, "SELECT MaLop FROM dbo.Lop ORDER BY MaLop"));
            Ui.Button(this, "Thêm", 25, 225, () =>
            {
                SinhVienService.Them(txtMa.Text.Trim(), txtHoTen.Text.Trim(), NgaySinh(), MaLop());
                Ui.Success(this, "Thêm sinh viên thành công.");
            });
            Ui.Button(this, "Xóa", 145, 225, () =>
            {
                Db.Require(!string.IsNullOrWhiteSpace(txtMa.Text), "Phải nhập mã sinh viên cần xóa.");
                if (!Ui.Confirm(this, "Xóa sinh viên " + txtMa.Text.Trim() + "?")) return;
                SinhVienService.Xoa(txtMa.Text.Trim());
                Ui.Success(this, "Xóa sinh viên thành công.");
            });
            Ui.Button(this, "Sửa", 265, 225, () =>
            {
                SinhVienService.Sua(txtMa.Text.Trim(), txtHoTen.Text.Trim(), NgaySinh(), MaLop());
                Ui.Success(this, "Sửa sinh viên thành công.");
            });
            Ui.Button(this, "Đóng", 385, 225, Close);
        }

        // Nullable<DateTime> biểu diễn trạng thái chưa nhập ngày sinh.
        private DateTime? NgaySinh()
        { return dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : (DateTime?)null; }

        private string MaLop()
        { return cboLop.SelectedItem == null ? "" : cboLop.SelectedItem.ToString(); }
    }
}
