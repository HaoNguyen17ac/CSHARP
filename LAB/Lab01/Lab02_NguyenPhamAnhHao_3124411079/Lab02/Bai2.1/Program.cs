class Program
{
    static void Main()
    {
        // Tạo danh sách và thêm ba điểm mẫu.
        ArrayPoint arr = new ArrayPoint();

        arr.Add(new Point(1, 2));
        arr.Add(new Point(3, 4));
        arr.Add(new Point(5, 6));

        // In từng điểm kèm chỉ số trong danh sách.
        for (int i = 0; i < arr.Count; i++)
        {
            Console.WriteLine($"Point[{i}] = {arr[i]}");
        }
    }
}