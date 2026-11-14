using System.Windows.Forms;

namespace Lab06b
{
    internal sealed class MainForm : Form
    {
        public MainForm()
        {
            Ui.Init(this, "Lab06b - Tương tác cơ sở dữ liệu", 210);
            Controls.Add(new Label { Text = "Nguyễn Phạm Anh Hào - 3124411079",
                                    Left = 25, Top = 25, Width = 460, Height = 30 });
            Controls.Add(new Label { Text = "Chọn bài tập tại lớp để thực hiện",
                                    Left = 25, Top = 65, Width = 460, Height = 28 });
            Ui.Button(this, "Bài 1", 55, 115, () =>
            { using (var form = new SinhVienForm()) form.ShowDialog(this); });
            Ui.Button(this, "Bài 2", 200, 115, () =>
            { using (var form = new DiemForm()) form.ShowDialog(this); });
            Ui.Button(this, "Thoát", 345, 115, Close);
        }
    }
}
