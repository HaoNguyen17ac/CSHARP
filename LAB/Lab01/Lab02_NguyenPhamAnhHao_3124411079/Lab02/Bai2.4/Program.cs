using System;

public class MaTran
{
    // Mảng hai chiều và kích thước ma trận.
    private int[,] a;
    private int n, m;

    // a. Default constructor
    public MaTran()
    {
        // Khởi tạo ma trận rỗng.
        n = 0;
        m = 0;
        a = new int[0, 0];
    }

    // a. Constructor có tham số
    public MaTran(int n, int m)
    {
        // Tạo ma trận có n dòng và m cột.
        this.n = n;
        this.m = m;
        a = new int[n, m];
    }

    // a. Copy constructor
    public MaTran(MaTran other)
    {
        // Sao chép kích thước và từng phần tử ma trận.
        n = other.n;
        m = other.m;

        a = new int[n, m];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                a[i, j] = other.a[i, j];
    }

    // b. Indexer
    public int this[int i, int j]
    {
        get { return a[i, j]; }
        set { a[i, j] = value; }
    }

    // c. Input
    public void Input()
    {
        // Nhập kích thước rồi đọc lần lượt từng ô.
        Console.Write("Nhap so dong n: ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Nhap so cot m: ");
        m = int.Parse(Console.ReadLine());

        a = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"a[{i},{j}] = ");
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    // c. Output
    public void Output()
    {
        // In các phần tử theo từng dòng của ma trận.
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(a[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    // d. Kiểm tra số nguyên tố
    private bool IsPrime(int x)
    {
        // Số nhỏ hơn 2 không phải số nguyên tố.
        if (x < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(x); i++)
        {
            if (x % i == 0)
                return false;
        }

        return true;
    }

    // d. Tìm số nguyên tố
    public void FindPrime()
    {
        // Kiểm tra và in các số nguyên tố trong ma trận.
        Console.Write("Cac so nguyen to: ");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (IsPrime(a[i, j]))
                    Console.Write(a[i, j] + " ");
            }
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Nhập ma trận, hiển thị nội dung và tìm số nguyên tố.
        MaTran mt = new MaTran();

        mt.Input();

        Console.WriteLine("\nMa tran:");
        mt.Output();

        Console.WriteLine("\nPhan tu [0,0] = " + mt[0, 0]);

        mt.FindPrime();
    }
}