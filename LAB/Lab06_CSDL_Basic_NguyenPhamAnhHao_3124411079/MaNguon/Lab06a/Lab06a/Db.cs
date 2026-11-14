using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lab06a
{
    internal static class Db
    {
        private static SqlConnection CreateConnection()
        {
            // Đọc cấu hình thay vì ghi cứng máy chủ trong từng form.
            var setting = ConfigurationManager.ConnectionStrings["QLSinhVien"];
            if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                throw new InvalidOperationException("Thiếu chuỗi kết nối QLSinhVien trong App.config.");
            return new SqlConnection(setting.ConnectionString);
        }

        public static SqlParameter Text(string name, SqlDbType type, int size, string value)
        {
            // Tham số có kiểu và kích thước đúng với cột SQL. Dữ liệu có dấu nháy
            // đơn vẫn được lưu đúng, không bị ghép vào nội dung câu lệnh SQL.
            return new SqlParameter(name, type, size) { Value = value.Trim() };
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            // using luôn đóng kết nối và giải phóng command, kể cả khi có lỗi.
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddRange(parameters);
                connection.Open();
                // ExecuteNonQuery trả số dòng bị tác động, không trả về bool.
                return command.ExecuteNonQuery();
            }
        }

        public static DataTable Query(string sql)
        {
            using (SqlConnection connection = CreateConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }
    }
}
