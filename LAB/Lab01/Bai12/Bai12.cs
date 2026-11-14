using System;// Khai báo thư viện System

class Bai12// Khai báo lớp Bai12
{
    static int DemSoTu(string chuoi)// Khai báo phương thức DemSoTu để đếm số từ trong chuỗi
    {
        string[] tu = chuoi.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);// Tách chuỗi thành mảng các từ, loại bỏ các khoảng trắng thừa
        return tu.Length;// Trả về số lượng từ trong mảng
    }

    static void Main()
    {
        Console.Write("Nhap chuoi: ");// Yêu cầu người dùng nhập một chuỗi
        string chuoi = Console.ReadLine()!;// Đọc chuỗi từ bàn phím và gán cho biến chuoi

        Console.WriteLine($"Chuoi thuong: {chuoi.ToLower()}");// In ra chuỗi viết thường
        Console.WriteLine($"Chuoi hoa: {chuoi.ToUpper()}");// In ra chuỗi viết hoa
        Console.WriteLine($"So tu trong chuoi: {DemSoTu(chuoi)}");// In ra số từ trong chuỗi bằng cách gọi phương thức DemSoTu
    }
}