using System;// Khai báo thư viện System

class Bai05 // Khai báo một lớp (class) có tên là Bai05
{
    static void Main()
    {
        double x = 0, y = 0;// Khai báo hai biến x và y có kiểu dữ liệu double, khởi tạo giá trị ban đầu là 0
        int chon;// Khai báo biến chon có kiểu dữ liệu int

        do
        {
            Console.WriteLine("MENU");// Hiển thị "MENU"
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");// Hiển thị "1. Nhap hai gia tri so thuc cho x, y"
            Console.WriteLine("2. Tinh x^y");// Hiển thị "2. Tinh x^y"
            Console.WriteLine("3. Tinh can bac 2 cua x va y");// Hiển thị "3. Tinh can bac 2 cua x va y"
            Console.WriteLine("4. Thoat");// Hiển thị "4. Thoat"
            Console.Write("Chon chuc nang: ");// Hiển thị "Chon chuc nang: ", không xuống dòng sau khi hiển thị

            chon = int.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu int và lưu vào biến chon

            switch (chon)// Sử dụng câu lệnh switch để kiểm tra giá trị của biến chon
            {
                case 1:// Nếu chon = 1, thực hiện các lệnh trong case 1
                    Console.Write("Nhap x: ");// Hiển thị "Nhap x: ", không xuống dòng sau khi hiển thị
                    x = double.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu double và lưu vào biến x

                    Console.Write("Nhap y: ");// Hiển thị "Nhap y: ", không xuống dòng sau khi hiển thị
                    y = double.Parse(Console.ReadLine()!);// Đọc dữ liệu từ bàn phím, trả về chuỗi string, chuyển đổi sang kiểu double và lưu vào biến y
                    break;

                case 2:// Nếu chon = 2, thực hiện các lệnh trong case 2
                    Console.WriteLine($"x^y = {Math.Pow(x, y)}");// Tính lũy thừa x^y và hiển thị kết quả
                    break;

                case 3:// Nếu chon = 3, thực hiện các lệnh trong case 3
                    Console.WriteLine($"Can bac 2 cua x = {Math.Sqrt(x)}");// Tính căn bậc 2 của x và hiển thị kết quả
                    Console.WriteLine($"Can bac 2 cua y = {Math.Sqrt(y)}");// Tính căn bậc 2 của y và hiển thị kết quả
                    break;

                case 4:// Nếu chon = 4, thực hiện các lệnh trong case 4
                    Console.WriteLine("Thoat chuong trinh.");// Hiển thị "Thoat chuong trinh."
                    break;

                default:// Nếu chon không phải là 1, 2, 3 hoặc 4, thực hiện các lệnh trong default
                    Console.WriteLine("Lua chon khong hop le!");// Hiển thị "Lua chon khong hop le!"
                    break;
            }

            Console.WriteLine();// Hiển thị một dòng trống để phân tách các lần lặp

        } while (chon != 4);
    }
}