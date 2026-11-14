using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06a
{
    internal static class Ui
    {
        public static void Warn(IWin32Window owner, string message)
        {
            MessageBox.Show(owner, message, "Kiểm tra dữ liệu", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public static bool ConfirmDelete(IWin32Window owner, string item)
        {
            // Mặc định chọn Không để tránh xóa do vô tình nhấn Enter.
            return MessageBox.Show(owner, "Bạn có muốn xóa " + item + "?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool Try(IWin32Window owner, string operation, Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (SqlException ex)
            {
                string message;
                if (ex.Number == 2601 || ex.Number == 2627)
                    message = "Mã đã tồn tại. Hãy nhập một mã khác.";
                else if (ex.Number == 547)
                    message = "Không thỏa ràng buộc dữ liệu. Mã khoa phải tồn tại; " +
                        "không thể xóa lớp có sinh viên hoặc môn học đã có điểm.";
                else
                    message = "Không kết nối hoặc xử lý được SQL Server. " +
                        "Hãy kiểm tra máy chủ, CSDL và App.config.\n" + ex.Message;
                MessageBox.Show(owner, message, operation, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, ex.Message, operation, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return false;
        }

        public static void ShowAffected(IWin32Window owner, string operation, int count)
        {
            string text = count > 0 ? operation + " thành công." :
                "Không tìm thấy mã cần xử lý. Không có dòng nào thay đổi.";
            MessageBox.Show(owner, text, "Kết quả", MessageBoxButtons.OK,
                count > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
