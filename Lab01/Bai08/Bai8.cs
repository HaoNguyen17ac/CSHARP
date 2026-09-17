using System;// Khai báo thư viện System 

class Bai08 // Khai báo lớp Bai08
{
    static void HoanVi(ref double a, ref double b)// Khai báo phương thức HoanVi với tham số truyền theo tham chiếu
    {
        double temp = a;// Lưu giá trị của a vào biến tạm temp
        a = b;// Gán giá trị của b cho a
        b = temp;// Gán giá trị của temp (giá trị ban đầu của a) cho b
    }

    static void Main()
    {
        Console.Write("Nhap so thuc a: ");// Yêu cầu người dùng nhập số thực a
        double a = double.Parse(Console.ReadLine()!);// Đọc giá trị nhập vào từ bàn phím và chuyển đổi sang kiểu double

        Console.Write("Nhap so thuc b: ");// Yêu cầu người dùng nhập số thực b
        double b = double.Parse(Console.ReadLine()!);// Đọc giá trị nhập vào từ bàn phím và chuyển đổi sang kiểu double

        Console.WriteLine($"Truoc khi hoan vi: a = {a}, b = {b}");// Hiển thị giá trị của a và b trước khi hoán vị

        HoanVi(ref a, ref b);// Gọi phương thức HoanVi để hoán vị giá trị của a và b

        Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");// Hiển thị giá trị của a và b sau khi hoán vị
    }
}