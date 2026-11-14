using System;// Khai báo thư viện System

class Lab01 // Khai báo một lớp (class) có tên là Lab01
{
    static void Main()
    {
        Console.Write("Nhap ho va ten cua ban: ");// Hiển thị “Nhap ho va ten cua ban:”, không xuống dòng sau khi hiển thị 
        string hoten = Console.ReadLine();//Đọc dữ liệu từ bàn phím, trả về chuỗi string lưu vào biến hoten

        Console.WriteLine("Ho va ten cua ban la: " + hoten);//Hiển thị biến hoten vừa nhập, xuống dòng sau khi hiển thị
        Console.ReadKey();// Đóng cửa sổ console khi nhập phím bất kì
    }
}