using System.Drawing;
using System.Windows.Forms;

namespace Lab06a
{
    public sealed class MainForm : Form
    {
        public MainForm()
        {
            Text = "Lab06a - Nguyễn Phạm Anh Hào - 3124411079";
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(600, 300);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(new Label
            {
                Text = "LAB06A - TƯƠNG TÁC CƠ SỞ DỮ LIỆU",
                Font = new Font(Font, FontStyle.Bold), AutoSize = true,
                Location = new Point(38, 28)
            });
            Controls.Add(new Label
            {
                Text = "Nguyễn Phạm Anh Hào - MSSV 3124411079\n" +
                    "Chọn một bài tập để mở form quản lý.",
                AutoSize = true, Location = new Point(38, 66)
            });
            var monHoc = new Button
            {
                Text = "Bài 1 - Quản lý môn học", Location = new Point(38, 132),
                Size = new Size(248, 58)
            };
            var lop = new Button
            {
                Text = "Bài 2 - Quản lý lớp", Location = new Point(306, 132),
                Size = new Size(248, 58)
            };
            // Mỗi form con được giải phóng sau khi người dùng đóng cửa sổ.
            monHoc.Click += (sender, e) => { using (var form = new MonHocForm()) form.ShowDialog(this); };
            lop.Click += (sender, e) => { using (var form = new LopForm()) form.ShowDialog(this); };
            Controls.Add(monHoc);
            Controls.Add(lop);
            Controls.Add(new Label
            {
                Text = "Bài 1 tương ứng mục 2 Bài 1; Bài 2 tương ứng mục 4 Bài 1 của đề.\n" +
                    "Chạy script SQL và kiểm tra App.config trước khi sử dụng.",
                AutoSize = true, Location = new Point(38, 222), Font = new Font("Segoe UI", 9F)
            });
        }
    }
}
