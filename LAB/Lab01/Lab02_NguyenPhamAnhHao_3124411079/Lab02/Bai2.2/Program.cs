using System;
using System.Collections.Generic;

public class Person
{
    // Lưu mã, họ tên, năm sinh và năm mất.
    private int id;
    private string name;
    private int yob;
    private int yod;

    public Person()
    {
        // Khởi tạo thông tin mặc định.
        id = 0;
        name = "";
        yob = 0;
        yod = 0;
    }

    public Person(Person p)
    {
        // Sao chép thông tin từ đối tượng khác.
        id = p.id;
        name = p.name;
        yob = p.yob;
        yod = p.yod;
    }

    public void Input()
    {
        // Nhập thông tin cá nhân từ bàn phím.
        Console.Write("ID: ");
        id = int.Parse(Console.ReadLine());

        Console.Write("Ho ten: ");
        name = Console.ReadLine();

        Console.Write("Nam sinh: ");
        yob = int.Parse(Console.ReadLine());

        Console.Write("Nam mat (0 neu con song): ");
        yod = int.Parse(Console.ReadLine());
    }

    public void Output()
    {
        // In các thông tin cơ bản của người.
        Console.WriteLine($"{id} - {name} - {yob} - {yod}");
    }

    public bool IsLiving()
    {
        // Năm mất bằng 0 biểu thị người còn sống.
        return yod == 0;
    }
}

public class PersonList
{
    // Danh sách lưu các đối tượng Person.
    private List<Person> ds;

    // Tạo danh sách người rỗng.
    public PersonList()
    {
        ds = new List<Person>();
    }

    // Sao chép danh sách cùng các đối tượng bên trong.
    public PersonList(PersonList other)
    {
        ds = new List<Person>();

        foreach (Person p in other.ds)
        {
            ds.Add(new Person(p));
        }
    }

    // Thêm một người vào danh sách.
    public void Add(Person x)
    {
        ds.Add(x);
    }

    // Nhập số người và thông tin từng người.
    public void Input()
    {
        Console.Write("Nhap so nguoi: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNguoi thu {i + 1}:");

            Person p = new Person();
            p.Input();

            Add(p);
        }
    }

    // Hiển thị thông tin của toàn bộ danh sách.
    public void Output()
    {
        foreach (Person p in ds)
        {
            p.Output();
        }
    }

    // Tạo danh sách bản sao chỉ gồm người còn sống.
    public PersonList LivingPeople()
    {
        PersonList result = new PersonList();

        foreach (Person p in ds)
        {
            if (p.IsLiving())
            {
                result.Add(new Person(p));
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        // Nhập danh sách, sau đó lọc và in người còn sống.
        PersonList list = new PersonList();

        list.Input();

        Console.WriteLine("\n===== DANH SACH =====");
        list.Output();

        PersonList living = list.LivingPeople();

        Console.WriteLine("\n===== NGUOI CON SONG =====");
        living.Output();
    }
}