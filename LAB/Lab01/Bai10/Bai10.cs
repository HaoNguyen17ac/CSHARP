using System;// Khai báo thư viện System

class Bai10// Khai báo lớp Bai10
{
    static bool KiemTraDoiXung(string chuoi)// Khai báo phương thức KiemTraDoiXung để kiểm tra chuỗi có đối xứng hay không
    {
        int left = 0;// Khai báo biến left để lưu chỉ số của ký tự bên trái
        int right = chuoi.Length - 1;// Khai báo biến right để lưu chỉ số của ký tự bên phải

        while (left < right)// Vòng lặp kiểm tra các ký tự từ hai đầu chuỗi
        {
            if (chuoi[left] != chuoi[right])// Nếu ký tự bên trái không bằng ký tự bên phải
                return false;// Trả về false, chuỗi không đối xứng

            left++;// Tăng chỉ số left lên 1
            right--;// Giảm chỉ số right xuống 1
        }

        return true;// Nếu tất cả các ký tự đều đối xứng, trả về true
    }

    static void Main()
    {
        Console.Write("Nhap chuoi: ");// Yêu cầu người dùng nhập chuỗi
        string chuoi = Console.ReadLine()!;// Đọc giá trị nhập vào từ bàn phím và lưu vào biến chuoi

        if (KiemTraDoiXung(chuoi))// Gọi phương thức KiemTraDoiXung để kiểm tra chuỗi có đối xứng hay không
            Console.WriteLine("Chuoi doi xung");// Nếu chuỗi đối xứng, hiển thị thông báo "Chuoi doi xung"
        else
            Console.WriteLine("Chuoi khong doi xung");// Nếu chuỗi không đối xứng, hiển thị thông báo "Chuoi khong doi xung"
    }
}