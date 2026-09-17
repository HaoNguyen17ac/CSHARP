using System;// Khai báo thư viện System  

class SinhVien// Khai báo lớp SinhVien
{
    public string MaSinhVien;// Khai báo thuộc tính MaSinhVien
    public string HoTen;// Khai báo thuộc tính HoTen
    public string DiaChi;// Khai báo thuộc tính DiaChi
    public int NamThu;// Khai báo thuộc tính NamThu

    public void Nhap()// Khai báo phương thức Nhap
    {
        Console.Write("Nhap ma sinh vien: ");// Hiển thị thông báo nhập mã sinh viên
        MaSinhVien = Console.ReadLine()!;// Nhập mã sinh viên từ bàn phím

        Console.Write("Nhap ho ten: ");// Hiển thị thông báo nhập họ tên
        HoTen = Console.ReadLine()!;// Nhập họ tên từ bàn phím

        Console.Write("Nhap dia chi: ");// Hiển thị thông báo nhập địa chỉ
        DiaChi = Console.ReadLine()!;// Nhập địa chỉ từ bàn phím

        Console.Write("Nhap sinh vien nam thu may: ");// Hiển thị thông báo nhập năm thứ
        NamThu = int.Parse(Console.ReadLine()!);// Nhập năm thứ từ bàn phím và chuyển đổi sang kiểu int
    }

    public void Xuat()// Khai báo phương thức Xuat
    {
        Console.WriteLine("\n--- THONG TIN SINH VIEN ---");// Hiển thị thông tin sinh viên
        Console.WriteLine($"Ma sinh vien: {MaSinhVien}");// Hiển thị mã sinh viên
        Console.WriteLine($"Ho ten: {HoTen}");// Hiển thị họ tên
        Console.WriteLine($"Dia chi: {DiaChi}");// Hiển thị địa chỉ
        Console.WriteLine($"Nam thu: {NamThu}");// Hiển thị năm thứ
    }
}

class Bai13// Khai báo lớp Bai13
{
    static void Main()
    {
        SinhVien sv = new SinhVien();// Tạo đối tượng sv của lớp SinhVien

        sv.Nhap();// Gọi phương thức Nhap để nhập thông tin sinh viên
        sv.Xuat();// Gọi phương thức Xuat để xuất thông tin sinh viên
    }
}