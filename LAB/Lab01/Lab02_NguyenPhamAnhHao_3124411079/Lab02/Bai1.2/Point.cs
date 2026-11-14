using System;

namespace Bai1_2_Point
{
    public class Point
    {
        // Tọa độ của điểm trên mặt phẳng.
        private double x;
        private double y;

        // Truy cập tọa độ x.
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        // Truy cập tọa độ y.
        public double Y
        {
            get { return y; }
            set { y = value; }
        }


        // Tạo điểm tại gốc tọa độ.
        public Point()
        {
            x = 0;
            y = 0;
        }


        // Tạo điểm từ hai tọa độ.
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Tạo bản sao của một điểm.
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
        }

        // Nhập tọa độ điểm từ bàn phím.
        public void Input()
        {
            Console.Write("Nhap x: ");
            x = double.Parse(Console.ReadLine());

            Console.Write("Nhap y: ");
            y = double.Parse(Console.ReadLine());
        }

        // In tọa độ điểm ra màn hình.
        public void Output()
        {
            Console.WriteLine($"({x}, {y})");
        }

        // Trả về chuỗi biểu diễn tọa độ điểm.
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        // Cộng tọa độ tương ứng của hai điểm.
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(
                p1.x + p2.x,
                p1.y + p2.y
            );
        }

        // Trừ tọa độ tương ứng của hai điểm.
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(
                p1.x - p2.x,
                p1.y - p2.y
            );
        }

        // Đổi dấu cả hai tọa độ của điểm.
        public static Point operator -(Point p)
        {
            return new Point(
                -p.x,
                -p.y
            );
        }

        // Phương thức thành viên
        public double Distance(Point p)
        {
            // Tính khoảng cách Euclid từ điểm hiện tại đến p.
            double dx = x - p.x;
            double dy = y - p.y;

            return Math.Sqrt(dx * dx + dy * dy);
        }


        // Phương thức tĩnh
        public static double Distance(Point p1, Point p2)
        {
            // Tính khoảng cách Euclid giữa hai điểm.
            double dx = p1.x - p2.x;
            double dy = p1.y - p2.y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Phương thức thành viên
        public Point MidPoint(Point p)
        {
            // Tạo điểm nằm chính giữa điểm hiện tại và p.
            return new Point(
                (x + p.x) / 2,
                (y + p.y) / 2
            );
        }


        // Phương thức tĩnh
        public static Point MidPoint(Point p1, Point p2)
        {
            // Tạo trung điểm của hai điểm được truyền vào.
            return new Point(
                (p1.x + p2.x) / 2,
                (p1.y + p2.y) / 2
            );
        }
    }
}