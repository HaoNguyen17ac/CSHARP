using System;// Khai báo thư viện System

class Bai06// Khai báo một lớp (class) có tên là Bai06
{
    static int TimMax(int a, int b, int c)// Khai báo một phương thức (method) có tên là TimMax, nhận vào ba tham số a, b, c có kiểu dữ liệu int và trả về giá trị có kiểu dữ liệu int
    {
        int max = a;// Khai báo biến max có kiểu dữ liệu int, khởi tạo giá trị bằng a

        if (b > max)// Nếu b lớn hơn max, thực hiện các lệnh trong if
        {
            max = b;// Gán giá trị của b cho max
        }

        if (c > max)// Nếu c lớn hơn max, thực hiện các lệnh trong if
        {
            max = c;// Gán giá trị của c cho max
        }

        return max;// Trả về giá trị của max
    }

    static void Main()
    {
        Console.Write("Nhap so nguyen a: ");// Hiển thị "Nhap so nguyen a: ", không xuống dòng sau khi hiển thị
        int a = int.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến a

        Console.Write("Nhap so nguyen b: ");// Hiển thị "Nhap so nguyen b: ", không xuống dòng sau khi hiển thị
        int b = int.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến b

        Console.Write("Nhap so nguyen c: ");// Hiển thị "Nhap so nguyen c: ", không xuống dòng sau khi hiển thị
        int c = int.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến c

        int ketqua = TimMax(a, b, c);// Gọi phương thức TimMax với các tham số a, b, c và lưu kết quả trả về vào biến ketqua

        Console.WriteLine("Gia tri lon nhat la: " + ketqua);// Hiển thị "Gia tri lon nhat la: " và giá trị của ketqua

        Console.ReadKey();// Chờ người dùng nhấn một phím bất kỳ trước khi kết thúc chương trình
    }
}