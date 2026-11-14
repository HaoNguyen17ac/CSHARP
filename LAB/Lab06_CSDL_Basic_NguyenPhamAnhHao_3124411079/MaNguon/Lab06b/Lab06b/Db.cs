using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06b
{
    // Lớp dùng chung: chỉ nhận SQL do chương trình định nghĩa; dữ liệu người dùng
    // luôn truyền bằng SqlParameter, không nối trực tiếp vào câu SQL.
    internal static class Db
    {
        private static SqlConnection CreateConnection()
        {
            var item = ConfigurationManager.ConnectionStrings["QLSinhVien"];
            if (item == null)
                throw new InvalidOperationException("Thiếu kết nối QLSinhVien trong App.config.");
            return new SqlConnection(item.ConnectionString);
        }

        // HasRows của SqlDataReader dùng để kiểm tra khóa chính và khóa ngoại.
        // using đóng reader, command, connection kể cả khi truy vấn bị lỗi.
        public static bool Exists(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection cn = CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parameters);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                    return reader.HasRows;
            }
        }

        // INSERT/UPDATE/DELETE trả số dòng thực sự bị tác động, không trả bool.
        public static void ExecuteOne(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection cn = CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parameters);
                cn.Open();
                if (cmd.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("Không có đúng một dòng được cập nhật. Hãy kiểm tra lại mã.");
            }
        }

        // Truy vấn chỉ chọn cột mã. DropDownList buộc chọn mã đã có trong CSDL.
        public static void LoadCodes(ComboBox combo, string sql)
        {
            combo.Items.Clear();
            using (SqlConnection cn = CreateConnection())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read()) combo.Items.Add(reader.GetString(0));
            }
            combo.SelectedIndex = -1;
        }

        // Khai báo rõ kiểu và độ dài trùng schema để tránh suy luận sai kiểu.
        public static SqlParameter Code(string name, string value)
        { return new SqlParameter(name, SqlDbType.VarChar, 10) { Value = value }; }

        public static SqlParameter Name(string name, string value)
        { return new SqlParameter(name, SqlDbType.NVarChar, 100) { Value = value }; }

        public static SqlParameter Date(string name, DateTime value)
        { return new SqlParameter(name, SqlDbType.Date) { Value = value.Date }; }

        public static SqlParameter Score(decimal value)
        {
            return new SqlParameter("@diem", SqlDbType.Decimal)
                { Precision = 4, Scale = 2, Value = value };
        }

        public static void Require(bool condition, string message)
        { if (!condition) throw new InvalidOperationException(message); }
    }
}
