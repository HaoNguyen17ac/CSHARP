using System;

class Person
{
    // Lưu mã, họ tên, năm sinh và năm mất.
    private string id;
    private string name;
    private int yob;
    private int yod;

    // Tạo đối tượng với dữ liệu ban đầu rỗng.
    public Person()
    {
        id = "";
        name = "";
        yob = 0;
        yod = 0;
    }

    // Sao chép thông tin từ một đối tượng khác.
    public Person(Person p)
    {
        id = p.id;
        name = p.name;
        yob = p.yob;
        yod = p.yod;
    }

    // Nhập thông tin cá nhân từ bàn phím.
    public void Input()
    {
        Console.Write("Nhap ID: ");
        id = Console.ReadLine();

        Console.Write("Nhap ho ten: ");
        name = Console.ReadLine();

        Console.Write("Nhap nam sinh: ");
        yob = int.Parse(Console.ReadLine());

        Console.Write("Nhap nam mat (0 neu con song): ");
        yod = int.Parse(Console.ReadLine());
    }

    // Hiển thị thông tin cá nhân.
    public void Output()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Ho ten: " + name);
        Console.WriteLine("Nam sinh: " + yob);
        Console.WriteLine("Nam mat: " + yod);
        Console.WriteLine("Con song: " + IsLiving());
    }

    // Trả về true nếu chưa có năm mất.
    public bool IsLiving()
    {
        return yod == 0;
    }
}

class Program
{
    static void Main()
    {
        // Nhập và hiển thị thông tin người đầu tiên.
        Person p = new Person();

        p.Input();

        Console.WriteLine("\nThong tin Person:");
        p.Output();

        // Tạo bản sao rồi hiển thị thông tin đã sao chép.
        Person p2 = new Person(p);

        Console.WriteLine("\nPerson copy:");
        p2.Output();
    }
}