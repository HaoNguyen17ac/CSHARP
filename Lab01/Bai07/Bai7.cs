using System;// Khai báo thư viện System

class Bai07// Khai báo một lớp (class) có tên là Bai07
{
    static bool LaSoNguyenTo(int n)// Khai báo một phương thức (method) có tên là LaSoNguyenTo, nhận vào một tham số n có kiểu dữ liệu int và trả về giá trị có kiểu dữ liệu bool
    {
        if (n < 2)// Nếu n nhỏ hơn 2, thực hiện các lệnh trong if
            return false;// Trả về false, vì n không phải là số nguyên tố

        for (int i = 2; i <= Math.Sqrt(n); i++)// Khởi tạo một vòng lặp for, với biến i bắt đầu từ 2, chạy đến căn bậc hai của n, tăng i lên 1 sau mỗi lần lặp
        {
            if (n % i == 0)// Nếu n chia hết cho i, thực hiện các lệnh trong if
                return false;// Trả về false, vì n không phải là số nguyên tố
        }

        return true;// Trả về true, vì n là số nguyên tố
    }

    static void Main()
    {
        Console.Write("Nhap n: ");// Hiển thị "Nhap n: ", không xuống dòng sau khi hiển thị
        int n = int.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến n

        if (LaSoNguyenTo(n))// Gọi phương thức LaSoNguyenTo với tham số n, nếu trả về true, thực hiện các lệnh trong if
            Console.WriteLine($"{n} la so nguyen to");// Hiển thị "{n} la so nguyen to", với {n} là giá trị của biến n
        else
            Console.WriteLine($"{n} khong phai la so nguyen to");// Hiển thị "{n} khong phai la so nguyen to", với {n} là giá trị của biến n
    }
}