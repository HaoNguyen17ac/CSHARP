using System;

public class DonThuc
{
    // Hệ số và số mũ của đơn thức.
    public double A { get; set; }
    public int N { get; set; }

    // Tạo đơn thức 0.
    public DonThuc()
    {
        A = 0;
        N = 0;
    }

    // Tạo đơn thức với hệ số và số mũ cho trước.
    public DonThuc(double a, int n)
    {
        A = a;
        N = n;
    }

    // Sao chép một đơn thức.
    public DonThuc(DonThuc other)
    {
        A = other.A;
        N = other.N;
    }

    // Tính giá trị đơn thức tại x.
    public double Value(double x)
    {
        return A * Math.Pow(x, N);
    }

    // Chuyển đơn thức thành chuỗi.
    public override string ToString()
    {
        return $"{A}x^{N}";
    }
}