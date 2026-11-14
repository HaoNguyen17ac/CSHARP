using System;

namespace Lab06b
{
    // Bài 1 tại lớp: thêm, xóa, sửa SinhVien; không thay đổi mã sinh viên khi sửa.
    internal static class SinhVienService
    {
        public static bool TonTai(string ma)
        {
            return Db.Exists("SELECT 1 FROM dbo.SinhVien WHERE MaSinhVien=@ma",
                             Db.Code("@ma", ma));
        }

        // Gọi trước INSERT/UPDATE. Tuổi được tính theo NĂM đúng yêu cầu đề,
        // không trừ thêm một tuổi nếu chưa đến ngày sinh nhật trong năm hiện tại.
        private static void KiemTra(string ma, string hoTen, DateTime? ngaySinh, string maLop)
        {
            Db.Require(!string.IsNullOrWhiteSpace(ma) && ma.Length <= 10,
                       "Mã sinh viên bắt buộc nhập và tối đa 10 ký tự.");
            Db.Require(!string.IsNullOrWhiteSpace(hoTen) && hoTen.Length <= 100,
                       "Họ tên bắt buộc nhập và tối đa 100 ký tự.");
            Db.Require(ngaySinh.HasValue, "Phải chọn ngày sinh.");
            Db.Require(DateTime.Today.Year - ngaySinh.Value.Year >= 17,
                       "Sinh viên phải từ 17 tuổi trở lên, tính theo năm sinh.");
            Db.Require(!string.IsNullOrWhiteSpace(maLop), "Phải chọn mã lớp.");
            Db.Require(Db.Exists("SELECT 1 FROM dbo.Lop WHERE MaLop=@lop",
                       Db.Code("@lop", maLop)), "Mã lớp không còn tồn tại. Hãy mở lại form để tải lớp.");
        }

        public static void Them(string ma, string hoTen, DateTime? ngaySinh, string maLop)
        {
            KiemTra(ma, hoTen, ngaySinh, maLop);
            Db.Require(!TonTai(ma), "Trùng mã sinh viên; không thể thêm.");
            Db.ExecuteOne("INSERT INTO dbo.SinhVien(MaSinhVien,HoTen,NgaySinh,MaLop) " +
                          "VALUES(@ma,@ten,@ngay,@lop)",
                          Db.Code("@ma", ma), Db.Name("@ten", hoTen),
                          Db.Date("@ngay", ngaySinh.Value), Db.Code("@lop", maLop));
        }

        public static void Sua(string ma, string hoTen, DateTime? ngaySinh, string maLop)
        {
            KiemTra(ma, hoTen, ngaySinh, maLop);
            Db.Require(TonTai(ma), "Mã sinh viên cần sửa không tồn tại.");
            // Giữ nguyên PK để các dòng Điểm đang tham chiếu vẫn hợp lệ.
            Db.ExecuteOne("UPDATE dbo.SinhVien SET HoTen=@ten,NgaySinh=@ngay,MaLop=@lop " +
                          "WHERE MaSinhVien=@ma",
                          Db.Name("@ten", hoTen), Db.Date("@ngay", ngaySinh.Value),
                          Db.Code("@lop", maLop), Db.Code("@ma", ma));
        }

        public static void Xoa(string ma)
        {
            // Xóa chỉ cần mã; không ép nhập lại họ tên, ngày sinh và lớp.
            Db.Require(!string.IsNullOrWhiteSpace(ma), "Phải nhập mã sinh viên cần xóa.");
            Db.Require(TonTai(ma), "Mã sinh viên cần xóa không tồn tại.");
            Db.Require(!Db.Exists("SELECT 1 FROM dbo.Diem WHERE MaSinhVien=@ma",
                       Db.Code("@ma", ma)),
                       "Sinh viên đã có điểm. Hãy xóa điểm liên quan trước khi xóa sinh viên.");
            Db.ExecuteOne("DELETE FROM dbo.SinhVien WHERE MaSinhVien=@ma", Db.Code("@ma", ma));
        }
    }
}
