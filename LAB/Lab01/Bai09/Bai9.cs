using System;// Khai báo thư viện System

class Bai09// Khai báo lớp Bai09
{
    static void TimMaxMin(double a, double b, double c, out double max, out double min)// Khai báo phương thức TimMaxMin với tham số truyền ra ngoài
    {
        max = a;// Gán giá trị của a cho max
        min = a;// Gán giá trị của a cho min

        if (b > max)// Nếu b lớn hơn max hiện tại
            max = b;// Gán giá trị của b cho max

        if (c > max)// Nếu c lớn hơn max hiện tại
            max = c;// Gán giá trị của c cho max

        if (b < min)// Nếu b nhỏ hơn min hiện tại
            min = b;// Gán giá trị của b cho min

        if (c < min)// Nếu c nhỏ hơn min hiện tại
            min = c;// Gán giá trị của c cho min
    }

    static void Main()
    {
        Console.Write("Nhap so thuc a: ");// Yêu cầu người dùng nhập số thực a
        double a = double.Parse(Console.ReadLine()!);// Đọc giá trị nhập vào từ bàn phím và chuyển đổi sang kiểu double

        Console.Write("Nhap so thuc b: ");// Yêu cầu người dùng nhập số thực b
        double b = double.Parse(Console.ReadLine()!);// Đọc giá trị nhập vào từ bàn phím và chuyển đổi sang kiểu double

        Console.Write("Nhap so thuc c: ");// Yêu cầu người dùng nhập số thực c
        double c = double.Parse(Console.ReadLine()!);// Đọc giá trị nhập vào từ bàn phím và chuyển đổi sang kiểu double

        double max, min;// Khai báo biến max và min để lưu giá trị lớn nhất và nhỏ nhất

        TimMaxMin(a, b, c, out max, out min);// Gọi phương thức TimMaxMin để tìm giá trị lớn nhất và nhỏ nhất trong ba số thực a, b, c

        Console.WriteLine($"Gia tri lon nhat: {max}");// Hiển thị giá trị lớn nhất
        Console.WriteLine($"Gia tri nho nhat: {min}");// Hiển thị giá trị nhỏ nhất
    }
}