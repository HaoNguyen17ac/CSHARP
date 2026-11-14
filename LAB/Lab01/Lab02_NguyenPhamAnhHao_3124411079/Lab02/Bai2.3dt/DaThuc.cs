using System;

public class DaThuc
{
    // Lưu các đơn thức theo số mũ và bậc lớn nhất của đa thức.
    private DonThuc[] ds;
    private int n;

    // a. Default constructor
    public DaThuc()
    {
        // Khởi tạo đa thức rỗng.
        n = 0;
        ds = new DonThuc[0];
    }

    // a. Constructor có tham số
    public DaThuc(int n)
    {
        // Tạo đa thức bậc n với các hệ số ban đầu bằng 0.
        this.n = n;
        ds = new DonThuc[n + 1];

        for (int i = 0; i <= n; i++)
            ds[i] = new DonThuc(0, i);
    }

    // a. Copy constructor
    public DaThuc(DaThuc other)
    {
        // Sao chép từng đơn thức để không dùng chung phần tử.
        n = other.n;
        ds = new DonThuc[n + 1];

        for (int i = 0; i <= n; i++)
            ds[i] = new DonThuc(other.ds[i]);
    }

    // b. Indexer
    public DonThuc this[int i]
    {
        get { return ds[i]; }
        set { ds[i] = value; }
    }

    // c. Input
    public void Input()
    {
        // Nhập bậc đa thức và hệ số của từng số mũ.
        Console.Write("Nhap bac cua da thuc: ");
        n = int.Parse(Console.ReadLine());

        ds = new DonThuc[n + 1];

        for (int i = 0; i <= n; i++)
        {
            Console.Write($"Nhap he so a{i}: ");
            double a = double.Parse(Console.ReadLine());

            ds[i] = new DonThuc(a, i);
        }
    }

    // c. Output
    public void Output()
    {
        // In các hạng tử theo thứ tự số mũ tăng dần.
        for (int i = 0; i <= n; i++)
        {
            if (i > 0 && ds[i].A >= 0)
                Console.Write(" + ");

            Console.Write(ds[i].A);

            if (i == 1)
                Console.Write("x");
            else if (i > 1)
                Console.Write($"x^{i}");
        }

        Console.WriteLine();
    }

    // d. Tính P(x)
    public double Value(double x)
    {
        // Cộng giá trị các đơn thức tại x.
        double result = 0;

        for (int i = 0; i <= n; i++)
        {
            result += ds[i].Value(x);
        }

        return result;
    }
}
