using System;

class Fraction
{
    // Lưu tử số và mẫu số của phân số.
    private int tu;
    private int mau;

    // Hàm tạo mặc định
    public Fraction()
    {
        // Phân số mặc định là 0/1.
        tu = 0;
        mau = 1;
    }

    // Hàm tạo có tham số
    public Fraction(int tu, int mau)
    {
        // Không cho phép mẫu số bằng 0.
        if (mau == 0)
            throw new Exception("Mau so khong duoc bang 0");

        this.tu = tu;
        this.mau = mau;

        Simplify();
    }

    // Hàm tạo sao chép
    public Fraction(Fraction f)
    {
        // Sao chép tử và mẫu từ phân số đã cho.
        tu = f.tu;
        mau = f.mau;
    }

    // Tìm ước chung lớn nhất
    private int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }

        return a;
    }

    private void Simplify()
    {
        // Rút gọn phân số và chuyển dấu âm lên tử số.
        int g = GCD(tu, mau);

        tu /= g;
        mau /= g;

        if (mau < 0)
        {
            tu = -tu;
            mau = -mau;
        }
    }

    // Nhập phân số
    public void Input()
    {
        // Đọc tử số rồi yêu cầu mẫu số khác 0.
        Console.Write("Nhap tu so: ");
        tu = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Nhap mau so: ");
            mau = int.Parse(Console.ReadLine());

            if (mau == 0)
                Console.WriteLine("Mau so phai khac 0!");

        } while (mau == 0);

        Simplify();
    }

    // Hiển thị phân số
    public override string ToString()
    {
        // Bỏ mẫu số khi phân số có mẫu bằng 1.
        if (mau == 1)
            return tu.ToString();

        return $"{tu}/{mau}";
    }

    // Toán tử dương
    public static Fraction operator +(Fraction f)
    {
        return new Fraction(f);
    }

    // Toán tử âm
    public static Fraction operator -(Fraction f)
    {
        return new Fraction(-f.tu, f.mau);
    }

    // Phép cộng
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return new Fraction(
            f1.tu * f2.mau + f2.tu * f1.mau,
            f1.mau * f2.mau
        );
    }

    // Phép trừ
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        return new Fraction(
            f1.tu * f2.mau - f2.tu * f1.mau,
            f1.mau * f2.mau
        );
    }

    // Phép nhân
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(
            f1.tu * f2.tu,
            f1.mau * f2.mau
        );
    }

    // Phép chia
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        return new Fraction(
            f1.tu * f2.mau,
            f1.mau * f2.tu
        );
    }

    // So sánh lớn hơn
    public static bool operator >(Fraction f1, Fraction f2)
    {
        return f1.tu * f2.mau >
               f2.tu * f1.mau;
    }

    // So sánh nhỏ hơn
    public static bool operator <(Fraction f1, Fraction f2)
    {
        return f1.tu * f2.mau <
               f2.tu * f1.mau;
    }

    // So sánh lớn hơn hoặc bằng
    public static bool operator >=(Fraction f1, Fraction f2)
    {
        return f1 > f2 || f1 == f2;
    }

    // So sánh nhỏ hơn hoặc bằng
    public static bool operator <=(Fraction f1, Fraction f2)
    {
        return f1 < f2 || f1 == f2;
    }

    // So sánh bằng
    public static bool operator ==(Fraction f1, Fraction f2)
    {
        return f1.tu * f2.mau ==
               f2.tu * f1.mau;
    }

    // So sánh khác
    public static bool operator !=(Fraction f1, Fraction f2)
    {
        return !(f1 == f2);
    }

    public override bool Equals(object obj)
    {
        // So sánh nội dung khi đối tượng kia cũng là phân số.
        if (obj is Fraction f)
            return this == f;

        return false;
    }

    public override int GetHashCode()
    {
        // Tạo mã băm dựa trên tử số và mẫu số.
        return HashCode.Combine(tu, mau);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Nhập hai phân số để thực hiện các phép toán.
        Fraction a = new Fraction();
        Fraction b = new Fraction();

        Console.WriteLine("Nhap phan so a:");
        a.Input();

        Console.WriteLine("Nhap phan so b:");
        b.Input();

        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);

        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
    }
}