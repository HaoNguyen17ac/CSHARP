using System;

class Student
{
    // Lưu họ tên và năm sinh của sinh viên.
    private string name;
    private int yob;

    // Khởi tạo sinh viên với giá trị mặc định.
    public Student()
    {
        name = "";
        yob = 2000;
    }

    // Khởi tạo sinh viên với thông tin được cung cấp.
    public Student(string name, int yob)
    {
        this.name = name;
        this.yob = yob;
    }

    // Tính tuổi dựa trên năm hiện tại.
    public int Age()
    {
        return DateTime.Now.Year - yob;
    }

    // Nhập thông tin sinh viên từ bàn phím.
    public void Input()
    {
        Console.Write("Nhap ho ten: ");
        name = Console.ReadLine();

        Console.Write("Nhap nam sinh: ");
        yob = int.Parse(Console.ReadLine());
    }

    // In thông tin sinh viên và tuổi.
    public void Output()
    {
        Console.WriteLine("Ho ten: " + name);
        Console.WriteLine("Nam sinh: " + yob);
        Console.WriteLine("Tuoi: " + Age());
    }
}

class Program
{
    static void Main()
    {
        // Tạo sinh viên, nhập thông tin rồi hiển thị kết quả.
        Student sv = new Student();

        sv.Input();
        sv.Output();
    }
}