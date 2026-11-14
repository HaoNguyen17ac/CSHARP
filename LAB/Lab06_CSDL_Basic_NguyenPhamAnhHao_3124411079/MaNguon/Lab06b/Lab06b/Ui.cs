using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Lab06b
{
    // Mã dựng giao diện dùng chung, tương đương phần Designer của WinForms.
    // Các xử lý bài tập được giữ riêng trong hai lớp Service để dễ đọc.
    internal static class Ui
    {
        public static void Init(Form form, string title, int height)
        {
            form.Text = title;
            form.Font = new Font("Segoe UI", 10F);
            form.ClientSize = new Size(510, height);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.AutoScaleMode = AutoScaleMode.Font;
        }

        public static void Field(Form form, string caption, Control control, int top)
        {
            form.Controls.Add(new Label { Text = caption, Left = 25, Top = top + 4,
                                          Width = 135, Height = 28 });
            control.SetBounds(170, top, 310, 28);
            form.Controls.Add(control);
        }

        public static void Button(Form form, string caption, int left, int top, Action action)
        {
            var button = new Button { Text = caption, Left = left, Top = top,
                                      Width = 100, Height = 36 };
            button.Click += (s, e) => Run(form, action);
            form.Controls.Add(button);
        }

        // Bắt lỗi ngay tại ranh giới giao diện. Không báo 'thành công' nếu SQL lỗi.
        // PK/FK còn được CSDL kiểm tra nên vẫn đúng nếu có thay đổi đồng thời.
        public static void Run(IWin32Window owner, Action action)
        {
            try { action(); }
            catch (SqlException ex)
            {
                string message;
                if (ex.Number == 2601 || ex.Number == 2627)
                    message = "Trùng khóa chính. Dữ liệu có thể đã được thêm từ phiên khác.";
                else if (ex.Number == 547)
                    message = "Dữ liệu vi phạm khóa ngoại hoặc ràng buộc. Hãy kiểm tra bản ghi liên quan.";
                else
                    message = "Lỗi SQL Server. Kiểm tra Server name, QLSinhVien và App.config.\n" + ex.Message;
                MessageBox.Show(owner, message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(owner, ex.Message, "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(owner, "App.config không hợp lệ.\n" + ex.Message,
                    "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(owner, "Kiểm tra cú pháp chuỗi kết nối trong App.config.\n" + ex.Message,
                    "Lỗi tham số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void Success(IWin32Window owner, string message)
        { MessageBox.Show(owner, message, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        public static bool Confirm(IWin32Window owner, string message)
        {
            return MessageBox.Show(owner, message, "Xác nhận xóa", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
    }
}
