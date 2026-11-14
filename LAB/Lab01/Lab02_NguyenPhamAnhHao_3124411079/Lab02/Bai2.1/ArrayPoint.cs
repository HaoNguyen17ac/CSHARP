using System.Collections;

public class ArrayPoint
{
    // Danh sách lưu các điểm.
    private ArrayList ds;

    // Tạo danh sách điểm rỗng.
    public ArrayPoint()
    {
        ds = new ArrayList();
    }

    // Sao chép danh sách và tạo bản sao riêng cho từng điểm.
    public ArrayPoint(ArrayPoint other)
    {
        ds = new ArrayList();

        for (int i = 0; i < other.ds.Count; i++)
        {
            ds.Add(new Point(
                ((Point)other.ds[i]).X,
                ((Point)other.ds[i]).Y
            ));
        }
    }

    // Thêm một điểm vào cuối danh sách.
    public void Add(Point p)
    {
        ds.Add(p);
    }

    // Truy cập hoặc cập nhật điểm theo chỉ số.
    public Point this[int index]
    {
        get { return (Point)ds[index]; }
        set { ds[index] = value; }
    }

    // Trả về số điểm hiện có.
    public int Count
    {
        get { return ds.Count; }
    }
}