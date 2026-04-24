# 1. THÔNG TIN DỰ ÁN (PROJECT CONTEXT)
- [cite_start]**Tên dự án:** FITH - Nền tảng Website theo dõi và chia sẻ lịch trình tập luyện thể hình[cite: 2].
- [cite_start]**Mục tiêu:** Ứng dụng web cho phép người dùng tạo/theo dõi lịch trình tập, kết hợp mạng xã hội và AI chat box tư vấn sức khỏe[cite: 5].
- [cite_start]**Cấu trúc Module:** Hệ thống gồm 5 module chính: Auth & User, Exercise Library, Workout Logger, Analytics, và Social/AI Assistant[cite: 10, 11, 12, 13, 14, 15, 16].

# 2. CÔNG NGHỆ VÀ KIẾN TRÚC (TECH STACK & ARCHITECTURE)
- [cite_start]**Frontend:** Sử dụng ReactJs kết hợp TailwindCSS[cite: 25]. [cite_start]Lưu trữ trên Vercel[cite: 28].
- [cite_start]**Backend:** Sử dụng ASP.NET Core[cite: 26]. [cite_start]Lưu trữ trên Render[cite: 28].
- [cite_start]**Giao tiếp:** Frontend và Backend giao tiếp qua các đầu nối RESTful API[cite: 18].
- [cite_start]**Cơ sở dữ liệu:** PostgreSQL làm hệ quản trị CSDL chính (quản lý trực tuyến qua Supabase)[cite: 27, 28].
- [cite_start]**Môi trường Local:** Sử dụng Docker[cite: 27].
- **Hệ thống phụ trợ:**
  - [cite_start]Sử dụng Redis làm bộ nhớ đệm (Caching) để tăng tốc độ truy xuất[cite: 30].
  - [cite_start]Sử dụng RabbitMQ làm Message Broker để xử lý các tác vụ nền bất đồng bộ (gửi mail, gọi API AI)[cite: 29].

# 3. TIÊU CHUẨN KỸ THUẬT VÀ MÃ NGUỒN (SOFTWARE ENGINEERING PRACTICES)
- [cite_start]**Kiến trúc Backend:** Bắt buộc xây dựng ứng dụng dựa trên Clean Architecture.
- [cite_start]**Nguyên lý lập trình:** Áp dụng chặt chẽ OOP và nguyên tắc SOLID[cite: 33].
- [cite_start]**Design Patterns (Mẫu thiết kế):** Bắt buộc sử dụng Dependency Injection, Repository Pattern, và Unit Of Work[cite: 35].
- [cite_start]**Bảo mật:** Xác thực và phân quyền người dùng thông qua JWT (JSON Web Token)[cite: 19].
- [cite_start]**Tài liệu API:** Tự động hóa tài liệu bằng Swagger và kiểm thử qua Postman[cite: 36].
- [cite_start]**CI/CD:** Quản lý mã nguồn trên GitHub và thiết lập luồng triển khai tự động với GitHub Actions[cite: 37].

# 4. HƯỚNG DẪN DÀNH CHO AI LẬP TRÌNH (AI ASSISTANT INSTRUCTIONS)
- [cite_start]Tuyệt đối tuân thủ Clean Architecture khi tạo các logic Backend mới trong ASP.NET Core.
- [cite_start]Khi tạo API mới, luôn cấu hình Swagger document đầy đủ[cite: 36].
- [cite_start]Mọi chức năng liên quan đến xác thực đều phải sử dụng cơ chế JWT[cite: 19].
- [cite_start]Logic nào có độ trễ cao (như gửi email, tương tác module AI Assistant) phải được thiết kế để đẩy vào RabbitMQ[cite: 29].
- [cite_start]Với Frontend ReactJs, bắt buộc dùng TailwindCSS cho giao diện, tuân thủ nguyên tắc component tái sử dụng[cite: 25].