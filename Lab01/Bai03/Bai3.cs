using System;// Khai báo thư viện System

class Bai03 // Khai báo một lớp (class) có tên là Bai03
{
    static void Main()
    {
        Console.Write("Nhap so nguyen x: ");// Hiển thị “Nhap so nguyen x:”, không xuống dòng sau khi hiển thị
        int x = int.Parse(Console.ReadLine());//Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến x

        Console.Write("Nhap so nguyen y: ");// Hiển thị “Nhap so nguyen y:”, không xuống dòng sau khi hiển thị
        int y = int.Parse(Console.ReadLine());//Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến y

        int ketqua = (int)Math.Pow(x,y);//Tính lũy thừa x^y, chuyển đổi sang kiểu int và lưu vào biến ketqua

        Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + ketqua);//Hiển thị kết quả, xuống dòng sau khi hiển thị
        Console.ReadKey();// Đóng cửa sổ console khi nhập phím bất kì
    }
}