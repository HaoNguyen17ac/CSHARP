using System;

class Monomial
{
    // Hệ số a và số mũ n của đơn thức a*x^n.
    private double a;
    private int n;

    // Tạo đơn thức 0.
    public Monomial()
    {
        a = 0;
        n = 0;
    }

    // Tạo đơn thức với hệ số và số mũ cho trước.
    public Monomial(double a, int n)
    {
        this.a = a;
        this.n = n;
    }

    // Tính giá trị
    // Tính giá trị đơn thức tại x.
    public double Value(double x)
    {
        return a * Math.Pow(x, n);
    }

    // Đạo hàm
    // Tạo đơn thức đạo hàm theo quy tắc lũy thừa.
    public Monomial Derivative()
    {
        if (n == 0)
            return new Monomial(0, 0);

        return new Monomial(a * n, n - 1);
    }

    // Định dạng đơn thức thành chuỗi dễ đọc.
    public override string ToString()
    {
        if (n == 0)
            return a.ToString();

        if (n == 1)
            return $"{a}x";

        return $"{a}x^{n}";
    }
}

class Program
{
    static void Main()
    {
        // Nhập hệ số và số mũ để tạo đơn thức.
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        Monomial p = new Monomial(a, n);

        // Hiển thị đơn thức và đạo hàm của nó.
        Console.WriteLine("P(x) = " + p);

        Monomial daoHam = p.Derivative();

        Console.WriteLine("P'(x) = " + daoHam);
    }
}