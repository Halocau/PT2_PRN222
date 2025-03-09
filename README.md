# Hướng Dẫn Tạo và Cấu Hình Database với Entity Framework Code First

Dưới đây là các bước chi tiết để tạo một ứng dụng sử dụng Entity Framework (EF) Code First, bao gồm việc tạo model `Student`, cấu hình database và thực thi migration.

---

## Bước 1: Tạo Model `Student` và `ApplicationDbContext`

- Tạo class `Student` để định nghĩa cấu trúc dữ liệu.
- Tạo class `ApplicationDbContext` để thiết lập kết nối với database.

### Minh họa
![Tạo Student](https://github.com/user-attachments/assets/7b08a355-c88f-43e5-befc-4b448318b4a2)
![Tạo ApplicationDbContext](https://github.com/user-attachments/assets/a1d7be1a-9a15-4dd1-8b38-f48df2797bca)

---

## Bước 2: Cấu Hình Ứng Dụng

### 1. Cấu hình trong `Program.cs`
Thêm dịch vụ `ApplicationDbContext` vào ứng dụng và chỉ định sử dụng SQL Server với chuỗi kết nối từ `appsettings.json`.

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
```
### 2. Cấu hình trong `appsettings.json`
```csharp
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StudentCodeFirst;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## Bước 3: Chạy lệnh
### dotnet ef migrations add "InitialDB"
=> Xuất hiện thư mục Migration 
    + 1 file ngày+giờ+InitialDB có 2 hàm là Up và Down. Up là cái commit vừa rồi mình tạo bảng còn Down là kiểu nếu mình gọi lệnh xoá
    
![image](https://github.com/user-attachments/assets/51038ed5-3de6-444f-bde3-cf651cccf3c8)

### dotnet ef database update 
=> tạo database dựa vào file appsettings.json:

![image](https://github.com/user-attachments/assets/365501ce-6f30-4cea-967f-6f7428617d40)


