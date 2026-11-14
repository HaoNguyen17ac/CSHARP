using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ;

class Program
{
    static void Main(string[] args)
    {
        // Hỗ trợ hiển thị tiếng Việt trên Terminal
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Gọi lần lượt các hàm bài tập
        Bai21();
        Bai22();
        Bai31();
        Bai32();
        Bai51();
    }

    static void Bai21()
    {
        Console.WriteLine("BAI 2.1");
        int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

        // a. Liệt kê các phần tử chia hết cho 4 và 3
        var kq21_a = mangSo.Where(x => x != 0 && x % 4 == 0 && x % 3 == 0);
        Console.WriteLine($"a: {string.Join(", ", kq21_a)}");

        // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3
        var kq21_b = mangSo.Where(x => x <= 3);
        Console.WriteLine($"b: {string.Join(", ", kq21_b)}");

        // c. Số chẵn chia đôi, số lẻ giữ nguyên giá trị
        var kq21_c = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
        Console.WriteLine($"c: {string.Join(", ", kq21_c)}\n");
    }

    static void Bai22()
    {
        Console.WriteLine("BAI 2.2");
        string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

        // a. Liệt kê các phần tử có 4 ký tự và sắp xếp tăng dần theo ký tự đầu tiên
        var kq22_a = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
        Console.WriteLine($"a: {string.Join(", ", kq22_a)}");

        // b. Biến đổi mỗi phần tử thành dạng: <chữ thường> - <CHỮ HOA>
        var kq22_b = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
        Console.WriteLine($"b: {string.Join("; ", kq22_b)}");

        // c. Liệt kê các phần tử có chứa ký tự “u” hoặc “U”
        var kq22_c = mangChuoi.Where(s => s.Contains('u') || s.Contains('U'));
        Console.WriteLine($"c: {string.Join(", ", kq22_c)}");

        // d. Liệt kê các từ bắt đầu bằng chữ in hoa
        var kq22_d = mangChuoi.Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
        Console.WriteLine($"d: {string.Join(", ", kq22_d)}\n");
    }

    static void Bai31()
    {
        Console.WriteLine("BAI 3.1");
        int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

        // a. Tổng số phần tử, số phần tử chẵn và số phần tử lẻ
        int tongSo = mangSo.Count();
        int soChan = mangSo.Count(x => x % 2 == 0);
        int soLe = mangSo.Count(x => x % 2 != 0);
        Console.WriteLine($"a: Tong = {tongSo}, Chan = {soChan}, Le = {soLe}");

        // b. Tính tổng các giá trị, giá trị lớn nhất và nhỏ nhất
        Console.WriteLine($"b: Tong gia tri = {mangSo.Sum()}, Max = {mangSo.Max()}, Min = {mangSo.Min()}");

        // c. Số lượng giá trị khác nhau trong mảng
        int khacNhau = mangSo.Distinct().Count();
        Console.WriteLine($"c: So gia tri khac nhau = {khacNhau}");

        // d. Phân nhóm các phần tử theo số dư khi chia cho 5
        var kq31_d = mangSo.GroupBy(x => x % 5);
        Console.WriteLine("d:");
        foreach (var group in kq31_d)
        {
            Console.WriteLine($"So du {group.Key}: {string.Join(", ", group)}");
        }
        Console.WriteLine();
    }

    static void Bai32()
    {
        Console.WriteLine("BAI 3.2");
        string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì", "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

        // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
        int minLen = monAn.Min(s => s.Length);
        int maxLen = monAn.Max(s => s.Length);
        var nganNhat = monAn.Where(s => s.Length == minLen);
        var daiNhat = monAn.Where(s => s.Length == maxLen);
        Console.WriteLine($"a ngan nhat: {string.Join(", ", nganNhat)}");
        Console.WriteLine($"a dai nhat: {string.Join(", ", daiNhat)}");

        // b. Phân nhóm theo từ đầu tiên của tên món
        var kq32_b = monAn.GroupBy(s => s.Split(' ')[0]);
        Console.WriteLine("b:");
        foreach (var g in kq32_b)
        {
            Console.WriteLine($"{g.Key}: {string.Join(", ", g)}");
        }

        // c. Đếm số phần tử có từ đầu tiên là “Bánh”
        int demBanh = monAn.Count(s => s.StartsWith("Bánh"));
        Console.WriteLine($"c: {demBanh}\n");
    }

    static void Bai51()
    {
        Console.WriteLine("BAI 5.1");
        var listMon = DuLieu.DS_Mon();

        // a. Liệt kê tên các môn học bắt đầu bằng “Lập trình”
        var kq51_a = listMon.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon);
        Console.WriteLine($"a: {string.Join(", ", kq51_a)}");

        // b. Liệt kê các môn thuộc hệ “CD”, sắp xếp số tiết giảm dần rồi mã môn tăng dần
        var kq51_b = listMon.Where(m => m.He == "CD")
                          .OrderByDescending(m => m.SoTiet)
                          .ThenBy(m => m.MaMon);
        Console.WriteLine("b:");
        foreach (var m in kq51_b)
        {
            Console.WriteLine($"{m.MaMon} - {m.TenMon} - {m.SoTiet}");
        }

        // c. Liệt kê các môn có tên chứa từ “web”, chỉ lấy Tên môn và Hệ
        var kq51_c = listMon.Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                          .Select(m => new { m.TenMon, m.He });
        Console.WriteLine("c:");
        foreach (var m in kq51_c)
        {
            Console.WriteLine($"{m.TenMon} - {m.He}");
        }
        Console.WriteLine();
    }
}