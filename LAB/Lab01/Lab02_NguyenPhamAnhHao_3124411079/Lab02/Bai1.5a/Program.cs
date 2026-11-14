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

    // Tính giá trị đơn thức tại x.
    public double Value(double x)
    {
        return a * Math.Pow(x, n);
    }

    // Định dạng đơn thức thành chuỗi.
    public override string ToString()
    {
        return $"{a}x^{n}";
    }
}

class Program
{
    static void Main()
    {
        // Nhập hệ số và số mũ của đơn thức.
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        Monomial p = new Monomial(a, n);

        // Nhập x rồi hiển thị giá trị của đơn thức tại x.
        Console.Write("Nhap x: ");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine("P(x) = " + p);
        Console.WriteLine("P(" + x + ") = " + p.Value(x));
    }
}