using System;

public class Student : IComparable<Student>
{
    // Họ tên và điểm của sinh viên.
    public string Name { get; set; }
    public double Score { get; set; }

    public Student(string name, double score)
    {
        // Gán thông tin ban đầu cho sinh viên.
        Name = name;
        Score = score;
    }

    public int CompareTo(Student other)
    {
        // So sánh sinh viên theo điểm.
        return Score.CompareTo(other.Score);
    }

    public override string ToString()
    {
        // Trả về chuỗi gồm tên và điểm.
        return $"{Name} - {Score}";
    }
}

class Program
{
    static void Main()
    {
        // Tạo danh sách sinh viên mẫu.
        Student[] students =
        {
            new Student("An", 8.5),
            new Student("Binh", 6.5),
            new Student("Cuong", 9.0),
            new Student("Dung", 7.5),
            new Student("Hieu", 9.5),
            new Student("Khanh", 5.0),
            new Student("Linh", 6.0)
        };

        // In danh sách trước và sau khi sắp xếp điểm tăng dần.
        Console.WriteLine("Truoc khi sap xep:");
        foreach (Student s in students)
            Console.WriteLine(s);

        // Sắp xếp bằng hàm dựng sẵn.
        Array.Sort(students);

        Console.WriteLine("\nSau khi sap xep:");
        foreach (Student s in students)
            Console.WriteLine(s);
    }
}