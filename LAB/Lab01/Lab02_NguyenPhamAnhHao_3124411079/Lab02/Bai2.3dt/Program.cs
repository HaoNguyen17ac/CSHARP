class Program
{
    static void Main()
    {
        // Nhập đa thức rồi hiển thị biểu thức.
        DaThuc p = new DaThuc();

        p.Input();

        Console.Write("P(x) = ");
        p.Output();

        // Nhập x và tính giá trị đa thức tại x.
        Console.Write("Nhap x = ");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine($"P({x}) = {p.Value(x)}");

        // In đơn thức có chỉ số 0 trong đa thức.
        Console.WriteLine("Don thuc thu 0: " + p[0]);
    }
}