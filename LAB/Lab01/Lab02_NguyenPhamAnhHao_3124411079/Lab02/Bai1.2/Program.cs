using System;

namespace Bai1_2_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhập hai điểm để thực hiện các phép toán.
            Point A = new Point();
            Point B = new Point();

            Console.WriteLine("NHAP DIEM A =");
            A.Input();


            Console.WriteLine("\nNHAP DIEM B =");
            B.Input();


            Console.WriteLine("\n===== HAI DIEM =====");
            Console.WriteLine("A = " + A);
            Console.WriteLine("B = " + B);

            // Thực hiện các phép cộng, trừ và đổi dấu điểm.
            Console.WriteLine("\n===== PHEP CONG =====");
            Point C = A + B;
            Console.WriteLine("A + B = " + C);


            Console.WriteLine("\n===== PHEP TRU =====");
            Point D = A - B;
            Console.WriteLine("A - B = " + D);

            Console.WriteLine("\n===== LAY AM =====");
            Point E = -A;
            Console.WriteLine("-A = " + E);

            // So sánh cách gọi khoảng cách và trung điểm.
            Console.WriteLine("\n===== 1.2.a KHOANG CACH =====");

            // Phương thức thành viên

            double d1 = A.Distance(B);
            Console.WriteLine(
                "Khoang cach (thanh vien) = " + d1);

            // Phương thức tĩnh

            double d2 = Point.Distance(A, B);
            Console.WriteLine(
                "Khoang cach (tinh) = " + d2);
            Console.WriteLine("\n===== 1.2.b TRUNG DIEM =====");


            // Phương thức thành viên

            Point I1 = A.MidPoint(B);
            Console.WriteLine(
                "Trung diem (thanh vien) = " + I1);


            // Phương thức tĩnh

            Point I2 = Point.MidPoint(A, B);
            Console.WriteLine(
                "Trung diem (tinh) = " + I2);
                
            Console.ReadKey();
        }
    }
}