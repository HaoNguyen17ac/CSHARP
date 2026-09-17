using System;// Khai bao thư viện System

class Bai15// Khai bao lớp Bai15
{
    int[] a;// Khai bao mảng a

    // Nhap mang
    public void NhapMang()
    {
        Console.Write("Nhap so phan tu n: ");// Nhap so phan tu n
        int n = int.Parse(Console.ReadLine()!);// Chuyen doi chuoi nhap vao thanh so nguyen

        a = new int[n];//   Khai bao mảng a có n phần tử

        for (int i = 0; i < n; i++)// Vòng lặp để nhập các phần tử của mảng
        {
            Console.Write($"Nhap a[{i}]: ");// Nhap phan tu thu i cua mang
            a[i] = int.Parse(Console.ReadLine()!);// Chuyen doi chuoi nhap vao thanh so nguyen va gan vao phan tu thu i cua mang
        }
    }

    // In mang
    public void InMang()
    {
        Console.Write("Mang: ");// In ra chuoi "Mang: "

        for (int i = 0; i < a.Length; i++)// Vòng lặp để in các phần tử của mảng
        {
            Console.Write(a[i] + " ");// In ra phan tu thu i cua mang
        }

        Console.WriteLine();// Xuong dong
    }

    // Tim phan tu lon nhat va nho nhat
    public void TimMaxMin()
    {
        int max = a[0];// Khai bao bien max va gan gia tri cua phan tu dau tien cua mang a
        int min = a[0];// Khai bao bien min va gan gia tri cua phan tu dau tien cua mang a

        for (int i = 1; i < a.Length; i++)// Vòng lặp để tìm phần tử lớn nhất và nhỏ nhất trong mảng
        {
            if (a[i] > max)// Kiem tra neu phan tu thu i cua mang lon hon max
                max = a[i];// Gan gia tri cua phan tu thu i cua mang vao max

            if (a[i] < min)// Kiem tra neu phan tu thu i cua mang nho hon min
                min = a[i];// Gan gia tri cua phan tu thu i cua mang vao min
        }

        Console.WriteLine($"Phan tu lon nhat: {max}");// In ra phan tu lon nhat
        Console.WriteLine($"Phan tu nho nhat: {min}");// In ra phan tu nho nhat
    }

    // Kiem tra so nguyen to
    public bool LaSoNguyenTo(int n)// Kiem tra so nguyen to
    {
        if (n < 2)// Kiem tra neu n nho hon 2
            return false;// Tra ve false

        for (int i = 2; i <= Math.Sqrt(n); i++)// Vòng lặp để kiểm tra các ước số của n từ 2 đến căn bậc hai của n
        {
            if (n % i == 0)// Kiem tra neu n chia het cho i
                return false;// Tra ve false
        }

        return true;// Tra ve true
    }

    // Tra ve mang cac so nguyen to
    public int[] MangSoNguyenTo()
    {
        int dem = 0;// Khai bao bien dem de dem so luong so nguyen to trong mang

        for (int i = 0; i < a.Length; i++)// Vòng lặp để đếm số lượng số nguyên tố trong mảng
        {
            if (LaSoNguyenTo(a[i]))// Kiem tra neu phan tu thu i cua mang la so nguyen to
                dem++;// Tang bien dem len 1
        }

        int[] ketQua = new int[dem];// Khai bao mang ketQua co kich thuoc bang dem de luu cac so nguyen to
        int j = 0;// Khai bao bien j de luu vi tri cua mang ketQua

        for (int i = 0; i < a.Length; i++)// Vòng lặp để lưu các số nguyên tố vào mảng ketQua
        {
            if (LaSoNguyenTo(a[i]))// Kiem tra neu phan tu thu i cua mang la so nguyen to
            {
                ketQua[j] = a[i];// Gan gia tri cua phan tu thu i cua mang vao phan tu thu j cua mang ketQua
                j++;// Tang bien j len 1 de luu vi tri tiep theo cua mang ketQua
            }
        }

        return ketQua;// Tra ve mang ketQua chua cac so nguyen to
    }

    static void Main()
    {
        Bai15 mang = new Bai15();// Khai bao doi tuong mang cua lop Bai15

        mang.NhapMang();// Goi phuong thuc NhapMang de nhap mang

        Console.WriteLine();
        mang.InMang();// Goi phuong thuc InMang de in mang

        Console.WriteLine();
        mang.TimMaxMin();// Goi phuong thuc TimMaxMin de tim phan tu lon nhat va nho nhat trong mang

        Console.WriteLine();

        int[] soNguyenTo = mang.MangSoNguyenTo();// Goi phuong thuc MangSoNguyenTo de tra ve mang cac so nguyen to trong mang a

        Console.Write("Mang cac so nguyen to: ");// In ra chuoi "Mang cac so nguyen to: "

        for (int i = 0; i < soNguyenTo.Length; i++)// Vòng lặp để in các phần tử của mảng soNguyenTo
        {
            Console.Write(soNguyenTo[i] + " ");// In ra phan tu thu i cua mang soNguyenTo
        }

        Console.WriteLine();// Xuong dong
    }
}