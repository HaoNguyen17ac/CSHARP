using System;// Khai báo thư viện System  

class Bai11 // Khai báo lớp Bai11
{
    static string DaoChuoi(string chuoi)// Khai báo phương thức DaoChuoi nhận vào một chuỗi và trả về chuỗi đảo ngược
    {
        string ketQua = "";// Khởi tạo biến ketQua để lưu trữ kết quả

        for (int i = chuoi.Length - 1; i >= 0; i--)// Vòng lặp từ cuối chuỗi đến đầu chuỗi
        {
            ketQua += chuoi[i];// Thêm ký tự hiện tại vào kết quả
        }

        return ketQua;// Trả về chuỗi đảo ngược
    }

    static void Main()
    {
        Console.Write("Nhap chuoi: ");// Hiển thị thông báo yêu cầu người dùng nhập chuỗi
        string chuoi = Console.ReadLine()!;// Đọc chuỗi từ bàn phím và lưu vào biến chuoi

        string chuoiDao = DaoChuoi(chuoi);// Gọi phương thức DaoChuoi để đảo ngược chuỗi và lưu kết quả vào biến chuoiDao

        Console.WriteLine($"Chuoi sau khi dao: {chuoiDao}");// Hiển thị chuỗi sau khi đảo ngược
    }
}