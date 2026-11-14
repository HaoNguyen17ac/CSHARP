using System;// Khai báo thư viện System

class Bai04 // Khai báo một lớp (class) có tên là Bai04
{
    static void Main()
    {
        Console.Write("Nhap so nguyen x: ");// Hiển thị “Nhap so nguyen x:”, không xuống dòng sau khi hiển thị
        if (!int.TryParse(Console.ReadLine(), out int x))//Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến x
        {
            Console.WriteLine("Loi: x khong phai la so nguyen!");//Hiển thị thông báo lỗi nếu x không phải là số nguyên
            return;
        }
        Console.Write("Nhap so nguyen y: ");// Hiển thị “Nhap so nguyen y:”, không xuống dòng sau khi hiển thị
        if (!int.TryParse(Console.ReadLine(), out int y))//Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến y
        {
            Console.WriteLine("Loi: y khong phai la so nguyen!");//Hiển thị thông báo lỗi nếu y không phải là số nguyên
            return;
        }

        int ketqua = (int)Math.Pow(x,y);//Tính lũy thừa x^y, chuyển đổi sang kiểu int và lưu vào biến ketqua

        Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + ketqua);//Hiển thị kết quả, xuống dòng sau khi hiển thị
        Console.ReadKey();// Đóng cửa sổ console khi nhập phím bất kì
    }
}
