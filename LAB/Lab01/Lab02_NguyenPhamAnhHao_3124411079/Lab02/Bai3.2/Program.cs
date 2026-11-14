using System;

public interface IComparable<T>
{
    // So sánh đối tượng hiện tại với đối tượng khác.
    int CompareTo(T other);
}

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

public static class MySort
{
    // Sắp xếp mảng bằng cách so sánh và đổi chỗ các phần tử.
    public static void Sort<T>(T[] a) where T : IComparable<T>
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i].CompareTo(a[j]) > 0)
                {
                    T temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
        }
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
            new Student("Em", 5.0),
            new Student("Hieu", 8.0)
        };

        // In danh sách trước và sau khi sắp xếp theo điểm.
        Console.WriteLine("Truoc khi sap xep:");

        foreach (Student s in students)
            Console.WriteLine(s);

        MySort.Sort(students);

        Console.WriteLine("\nSau khi sap xep:");

        foreach (Student s in students)
            Console.WriteLine(s);
    }
}