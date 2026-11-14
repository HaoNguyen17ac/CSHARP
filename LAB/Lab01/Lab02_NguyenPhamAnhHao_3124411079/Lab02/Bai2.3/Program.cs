using System;

public class DaySoNguyen
{
    // Mảng lưu các số nguyên và số lượng phần tử.
    private int[] a;
    private int n;

    // a. Default constructor
    public DaySoNguyen()
    {
        // Khởi tạo dãy rỗng.
        n = 0;
        a = new int[0];
    }

    // a. Constructor có tham số
    public DaySoNguyen(int n)
    {
        // Tạo dãy có n phần tử.
        this.n = n;
        a = new int[n];
    }

    // a. Copy constructor
    public DaySoNguyen(DaySoNguyen other)
    {
        // Sao chép số lượng và từng phần tử của dãy.
        n = other.n;
        a = new int[n];

        for (int i = 0; i < n; i++)
            a[i] = other.a[i];
    }

    // b. Indexer
    public int this[int i]
    {
        get { return a[i]; }
        set { a[i] = value; }
    }

    // c. Input
    public void Input()
    {
        // Nhập số lượng phần tử rồi đọc từng giá trị.
        Console.Write("Nhap n: ");
        n = int.Parse(Console.ReadLine());

        a = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            a[i] = int.Parse(Console.ReadLine());
        }
    }

    // c. Output
    public void Output()
    {
        // In các phần tử theo thứ tự trong dãy.
        for (int i = 0; i < n; i++)
        {
            Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }

    // d. Tìm số chẵn
    public void FindEven()
    {
        // Duyệt dãy và in các số chia hết cho 2.
        Console.Write("Cac so chan: ");

        for (int i = 0; i < n; i++)
        {
            if (a[i] % 2 == 0)
                Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Nhập dãy, in dãy, phần tử đầu và các số chẵn.
        DaySoNguyen d = new DaySoNguyen();

        d.Input();

        Console.WriteLine("Day so:");
        d.Output();

        Console.WriteLine("Phan tu dau tien: " + d[0]);

        d.FindEven();
    }
}