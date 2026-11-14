using System;
using System.Collections.Generic;

public class PhanSo
{
    // Tử số và mẫu số của phân số.
    public int Tu { get; set; }
    public int Mau { get; set; }

    public PhanSo()
    {
        // Khởi tạo phân số 0/1.
        Tu = 0;
        Mau = 1;
    }

    public PhanSo(int tu, int mau)
    {
        // Tạo phân số từ tử và mẫu cho trước.
        Tu = tu;
        Mau = mau;
    }

    public PhanSo(PhanSo p)
    {
        // Sao chép tử số và mẫu số.
        Tu = p.Tu;
        Mau = p.Mau;
    }

    public void Input()
    {
        // Nhập tử số và mẫu số từ bàn phím.
        Console.Write("Tu so: ");
        Tu = int.Parse(Console.ReadLine());

        Console.Write("Mau so: ");
        Mau = int.Parse(Console.ReadLine());
    }

    public override string ToString()
    {
        // Hiển thị phân số theo dạng tử/mẫu.
        return $"{Tu}/{Mau}";
    }

    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        // Quy đồng mẫu số rồi cộng hai tử số.
        return new PhanSo(
            a.Tu * b.Mau + b.Tu * a.Mau,
            a.Mau * b.Mau
        );
    }
}

public class DayPhanSo
{
    // Danh sách lưu các phân số.
    private List<PhanSo> ds;

    public DayPhanSo()
    {
        // Tạo danh sách phân số rỗng.
        ds = new List<PhanSo>();
    }

    public void Input()
    {
        // Nhập số lượng phân số rồi đọc từng phân số.
        Console.Write("Nhap so luong phan so: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nPhan so {i + 1}:");

            PhanSo p = new PhanSo();
            p.Input();

            ds.Add(p);
        }
    }

    public void Output()
    {
        // In lần lượt các phân số.
        foreach (PhanSo p in ds)
        {
            Console.Write(p + " ");
        }

        Console.WriteLine();
    }

    public PhanSo Sum()
    {
        // Cộng tất cả phân số và trả về tổng.
        PhanSo tong = new PhanSo(0, 1);

        foreach (PhanSo p in ds)
        {
            tong = tong + p;
        }

        return tong;
    }
}

class Program
{
    static void Main()
    {
        // Nhập danh sách, hiển thị và tính tổng phân số.
        DayPhanSo ds = new DayPhanSo();

        ds.Input();

        Console.WriteLine("\nDay phan so:");
        ds.Output();

        Console.WriteLine("Tong = " + ds.Sum());
    }
}