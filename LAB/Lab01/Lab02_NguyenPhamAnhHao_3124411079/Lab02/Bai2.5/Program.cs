using System;
using System.Collections.Generic;

public class NhanVien
{
    // Thông tin nhân viên dùng để tính lương thực nhận.
    private string hoTen;
    private double mucLuong;
    private int soNgayVang;

    public NhanVien()
    {
        // Khởi tạo thông tin mặc định.
        hoTen = "";
        mucLuong = 0;
        soNgayVang = 0;
    }

    public NhanVien(string hoTen, double mucLuong, int soNgayVang)
    {
        // Khởi tạo nhân viên từ thông tin được cung cấp.
        this.hoTen = hoTen;
        this.mucLuong = mucLuong;
        this.soNgayVang = soNgayVang;
    }

    public void Input()
    {
        // Nhập họ tên, mức lương và số ngày vắng.
        Console.Write("Ho ten: ");
        hoTen = Console.ReadLine();

        Console.Write("Muc luong: ");
        mucLuong = double.Parse(Console.ReadLine());

        Console.Write("So ngay vang: ");
        soNgayVang = int.Parse(Console.ReadLine());
    }

    public double TinhLuong()
    {
        // Trừ 100.000 đồng cho mỗi ngày vắng.
        return mucLuong - soNgayVang * 100000;
    }

    public void Output()
    {
        // In tên và mức lương sau khi trừ ngày vắng.
        Console.WriteLine(
            $"{hoTen} - Luong: {TinhLuong():N0} VNĐ"
        );
    }
}

public class PhongBan
{
    // Danh sách nhân viên của phòng ban.
    private List<NhanVien> ds;

    public PhongBan()
    {
        // Tạo phòng ban chưa có nhân viên.
        ds = new List<NhanVien>();
    }

    public void Input()
    {
        // Nhập số lượng nhân viên rồi đọc thông tin từng người.
        Console.Write("Nhap so nhan vien: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhan vien {i + 1}:");

            NhanVien nv = new NhanVien();
            nv.Input();

            ds.Add(nv);
        }
    }

    public void Output()
    {
        // Hiển thị thông tin của tất cả nhân viên.
        foreach (NhanVien nv in ds)
        {
            nv.Output();
        }
    }

    public double TongLuong()
    {
        // Cộng lương thực nhận của toàn bộ nhân viên.
        double tong = 0;

        foreach (NhanVien nv in ds)
        {
            tong += nv.TinhLuong();
        }

        return tong;
    }
}

class Program
{
    static void Main()
    {
        // Nhập nhân viên, in thông tin và tổng lương phòng ban.
        PhongBan pb = new PhongBan();

        pb.Input();

        Console.WriteLine("\n===== DANH SACH NHAN VIEN =====");
        pb.Output();

        Console.WriteLine(
            $"\nTong luong phong ban: {pb.TongLuong():N0} VNĐ"
        );
    }
}