using System;
using System.Globalization;

namespace Lab06b
{
    // Bài 2 tại lớp: Diem có khóa chính GHÉP (MaSinhVien, MaMonHoc).
    internal static class DiemService
    {
        public static bool TonTai(string maSV, string maMon)
        {
            return Db.Exists("SELECT 1 FROM dbo.Diem WHERE MaSinhVien=@sv AND MaMonHoc=@mon",
                             Db.Code("@sv", maSV), Db.Code("@mon", maMon));
        }

        private static void KiemTraKhoa(string maSV, string maMon)
        {
            Db.Require(!string.IsNullOrWhiteSpace(maSV), "Phải chọn mã sinh viên.");
            Db.Require(!string.IsNullOrWhiteSpace(maMon), "Phải chọn mã môn học.");
            // Kiểm tra lại cả hai khóa ngoại: dữ liệu có thể đã bị thay đổi sau
            // thời điểm tải combobox. FK trong SQL Server vẫn bảo vệ bước ghi.
            Db.Require(Db.Exists("SELECT 1 FROM dbo.SinhVien WHERE MaSinhVien=@sv",
                       Db.Code("@sv", maSV)), "Mã sinh viên không tồn tại.");
            Db.Require(Db.Exists("SELECT 1 FROM dbo.MonHoc WHERE MaMonHoc=@mon",
                       Db.Code("@mon", maMon)), "Mã môn học không tồn tại.");
        }

        private static decimal DocDiem(string text)
        {
            decimal diem;
            // Chấp nhận cả 8,5 và 8.5 nhưng không chấp nhận dấu phân cách hàng nghìn.
            string normalized = (text ?? "").Trim().Replace(',', '.');
            Db.Require(decimal.TryParse(normalized,
                       NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                       CultureInfo.InvariantCulture, out diem), "Điểm phải là một số.");
            // Đề ghi '(0-10)'; bài làm hiểu theo thang điểm 0 đến 10, gồm hai biên.
            Db.Require(diem >= 0 && diem <= 10, "Điểm phải từ 0 đến 10.");
            // Schema DECIMAL(4,2): từ chối thay vì âm thầm làm tròn dữ liệu nhập.
            Db.Require(decimal.Round(diem, 2) == diem, "Điểm có tối đa 2 chữ số thập phân.");
            return diem;
        }

        public static void Them(string maSV, string maMon, string textDiem)
        {
            KiemTraKhoa(maSV, maMon);
            decimal diem = DocDiem(textDiem);
            Db.Require(!TonTai(maSV, maMon), "Trùng cặp mã sinh viên và mã môn học; không thể thêm.");
            Db.ExecuteOne("INSERT INTO dbo.Diem(MaSinhVien,MaMonHoc,Diem) VALUES(@sv,@mon,@diem)",
                          Db.Code("@sv", maSV), Db.Code("@mon", maMon), Db.Score(diem));
        }

        public static void Sua(string maSV, string maMon, string textDiem)
        {
            KiemTraKhoa(maSV, maMon);
            decimal diem = DocDiem(textDiem);
            Db.Require(TonTai(maSV, maMon), "Chưa có điểm của cặp sinh viên và môn học cần sửa.");
            // UPDATE chỉ thay đổi Điểm, giữ nguyên hai thành phần khóa chính.
            Db.ExecuteOne("UPDATE dbo.Diem SET Diem=@diem WHERE MaSinhVien=@sv AND MaMonHoc=@mon",
                          Db.Score(diem), Db.Code("@sv", maSV), Db.Code("@mon", maMon));
        }

        public static void Xoa(string maSV, string maMon)
        {
            KiemTraKhoa(maSV, maMon);
            Db.Require(TonTai(maSV, maMon), "Không có điểm của cặp sinh viên và môn học cần xóa.");
            // Diem không bị bảng nào khác tham chiếu trong schema của đề.
            // WHERE phải chứa đủ cả hai mã để không xóa nhầm các môn khác.
            Db.ExecuteOne("DELETE FROM dbo.Diem WHERE MaSinhVien=@sv AND MaMonHoc=@mon",
                          Db.Code("@sv", maSV), Db.Code("@mon", maMon));
        }
    }
}
