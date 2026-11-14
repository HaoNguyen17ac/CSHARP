using System;// Khai báo thư viện System

class NhanVien// Khai báo lớp NhanVien
{
    public string HoTen;// Khai báo thuộc tính HoTen
    public double MucLuong;//  Khai báo thuộc tính MucLuong
    public int SoNgayVang;// Khai báo thuộc tính SoNgayVang

    public void Nhap()// Khai báo phương thức Nhap
    {
        Console.Write("Nhap ho ten: ");// Hiển thị thông báo nhập họ tên
        HoTen = Console.ReadLine()!;// Nhập họ tên từ bàn phím

        Console.Write("Nhap muc luong: ");// Hiển thị thông báo nhập mức lương
        MucLuong = double.Parse(Console.ReadLine()!);// Nhập mức lương từ bàn phím và chuyển đổi sang kiểu double

        Console.Write("Nhap so ngay vang: ");// Hiển thị thông báo nhập số ngày vắng
        SoNgayVang = int.Parse(Console.ReadLine()!);// Nhập số ngày vắng từ bàn phím và chuyển đổi sang kiểu int
    }

    public double TinhLuong()// Khai báo phương thức TinhLuong
    {
        return MucLuong - SoNgayVang * 100000;// Tính lương thực nhận bằng cách trừ số tiền phạt (100000 VNĐ cho mỗi ngày vắng) từ mức lương
    }

    public void Xuat()// Khai báo phương thức Xuat
    {
        Console.WriteLine("\n--- THONG TIN NHAN VIEN ---");// Hiển thị thông báo thông tin nhân viên
        Console.WriteLine($"Ho ten: {HoTen}");// Hiển thị họ tên nhân viên
        Console.WriteLine($"Muc luong: {MucLuong:N0} VNĐ");// Hiển thị mức lương nhân viên với định dạng số nguyên và đơn vị VNĐ
        Console.WriteLine($"So ngay vang: {SoNgayVang}");// Hiển thị số ngày vắng của nhân viên
        Console.WriteLine($"Luong thuc nhan: {TinhLuong():N0} VNĐ");// Hiển thị lương thực nhận của nhân viên với định dạng số nguyên và đơn vị VNĐ
    }
}

class Bai14// Khai báo lớp Bai14
{
    static void Main()
    {
        NhanVien nv = new NhanVien();// Tạo đối tượng nv của lớp NhanVien

        nv.Nhap();// Gọi phương thức Nhap để nhập thông tin nhân viên
        nv.Xuat();// Gọi phương thức Xuat để xuất thông tin nhân viên
    }
}