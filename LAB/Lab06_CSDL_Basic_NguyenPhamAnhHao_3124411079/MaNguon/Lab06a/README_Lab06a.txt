LAB06A - TƯƠNG TÁC CƠ SỞ DỮ LIỆU
Họ tên: Nguyễn Phạm Anh Hào
Mã sinh viên: 3124411079

1. PHẠM VI BÀI LÀM
- Bài 1 của báo cáo: Quản lý môn học, tương ứng mục 2 Bài 1 (bài tập tại lớp).
- Bài 2 của báo cáo: Quản lý lớp, tương ứng mục 4 Bài 1 (bài tập về nhà).
- Đây là hai bài cơ bản còn lại của đề 06a sau khi bỏ bài mẫu và nâng cao.

2. CHUẨN BỊ VÀ CHẠY
- Hệ điều hành Windows, Visual Studio có workload .NET desktop development
  và bộ công cụ nhắm đích .NET Framework 4.8.
- SQL Server Express hoặc SQL Server LocalDB; SSMS để chạy script.
- Chạy toàn bộ Database/Create_QLSinhVien.sql trong gói bài nộp để tạo CSDL
  QLSinhVien và dữ liệu mẫu. Đường dẫn này tính từ thư mục gốc gói bài nộp.
- Sửa Lab06a/App.config nếu tên máy chủ khác (localdb)\MSSQLLocalDB.
  Ví dụ SQL Express: Data Source=.\SQLEXPRESS.
  Máy chủ chạy script SQL và Data Source trong ứng dụng phải trùng nhau.
- Mở Lab06a.sln, Build Solution, nhấn F5. Chọn form môn học hoặc lớp.
- Đây là project WinForms .NET Framework, không dùng lệnh dotnet run.

3. CÁCH DÙNG
- Thêm môn học: nhập mã và tên, nhấn Thêm.
- Sửa môn học: nhập mã đã có cùng tên mới, nhấn Sửa.
- Xóa môn học: chỉ nhập mã, xóa nội dung ô tên, nhấn Xóa và xác nhận.
- Thêm lớp: nhập mã lớp, tên lớp, mã khoa đã tồn tại, nhấn Thêm.
- Sửa lớp: nhập mã lớp và ít nhất một trong hai ô tên lớp/mã khoa.
  Ô không nhập giữ nguyên giá trị cũ, khóa mã lớp không bị đổi.
- Xóa lớp: chỉ nhập mã lớp; để trống tên lớp, mã khoa rồi nhấn Xóa.
- Nút Làm mới xóa nội dung ô nhập và tải lại danh sách trong CSDL.
- Danh sách chỉ đọc; các ô nhập được điền trực tiếp để đúng yêu cầu đề bài.

4. CÁC CA ĐỐI CHIẾU KẾT QUẢ
Các kết quả dưới đây là kết quả mong đợi để kiểm tra trên Windows/SQL Server.

Môn học:
1) Nhập MH06A / Lập trình C# cơ bản, bấm Thêm -> xuất hiện dòng mới.
2) Giữ MH06A, đổi tên thành Lập trình C# ứng dụng, bấm Sửa -> tên đổi.
3) Xóa nội dung ô tên, giữ MH06A, bấm Xóa và chọn Có -> dòng bị xóa.
4) Bỏ trống mã hoặc tên khi Thêm/Sửa -> báo thiếu trường, không ghi CSDL.
5) Thêm mã CSHARP đã có -> báo trùng mã, chương trình tiếp tục chạy.
6) Xóa CSHARP trên dữ liệu mẫu -> bị chặn do môn đã có bản ghi điểm.

Lớp:
1) Nhập L06A / Lớp thực hành C# / CNTT, bấm Thêm -> xuất hiện dòng mới.
2) Giữ L06A, nhập tên Lớp C# đã sửa và để trống mã khoa, bấm Sửa ->
   tên mới được lưu, mã khoa vẫn là CNTT.
3) Giữ L06A, để trống tên, nhập QTKD, bấm Sửa -> khoa đổi thành QTKD,
   tên giữ nguyên từ bước 2.
4) Chỉ nhập L06A, để trống hai ô còn lại và bấm Xóa -> lớp bị xóa.
5) Thêm lớp với mã khoa KHONGCO -> báo ràng buộc, không thêm dòng.
6) Sửa với mã lớp có dữ liệu nhưng để trống tên và mã khoa -> báo thiếu dữ liệu.
7) Xóa DCT1241 trên dữ liệu mẫu -> bị chặn vì lớp còn sinh viên.
8) Sửa/xóa mã KHONGCO -> thông báo không tìm thấy; không báo thành công giả.

5. GIẢI THÍCH TỆP NGUỒN
- Program.cs: điểm bắt đầu, chạy menu MainForm.
- MainForm.cs: chọn bài; mở/đóng form bằng ShowDialog và using.
- Db.cs: đọc chuỗi kết nối, tạo SqlParameter, ExecuteNonQuery và ExecuteReader.
- Ui.cs: thông báo thiếu dữ liệu, xác nhận xóa, báo số dòng và xử lý lỗi PK/FK.
- MonHocForm.cs: kiểm tra trường nhập và xử lý Thêm/Xóa/Sửa môn học.
- LopForm.cs: xử lý lớp; dùng CASE trong UPDATE để giữ trường không nhập.
- Các tệp .Designer.cs: khai báo giao diện và gắn sự kiện cho nút.
- App.config: cấu hình máy chủ/CSDL; không chứa mật khẩu tài khoản SQL.

6. TÌNH TRẠNG KIỂM TRA
Nguồn đã được đối chiếu đề, kiểm tra project/SQL và biên dịch thành công
với bộ tham chiếu .NET Framework 4.8.
Môi trường soạn nguồn không có Windows/SQL Server nên không kèm tuyên bố
đã kiểm tra tương tác trực tiếp với CSDL. Hãy thực hiện các ca ở mục 4 sau
khi tạo CSDL và thiết lập chuỗi kết nối trên máy chạy chương trình.
