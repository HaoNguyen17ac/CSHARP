using System;

public class Point
{
    // Tọa độ ngang và dọc của điểm.
    public double X { get; set; }
    public double Y { get; set; }

    // Tạo điểm tại gốc tọa độ.
    public Point()
    {
        X = 0;
        Y = 0;
    }

    // Tạo điểm từ hai tọa độ đã cho.
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Trả về biểu diễn tọa độ của điểm.
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}