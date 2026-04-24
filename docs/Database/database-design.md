-- ==============================================================================
-- DATABASE SCHEMA: FITHEALTH 
-- LƯU Ý: Các khóa chính (Id) kiểu UUID sẽ được sinh ra từ backend ASP.NET Core 
-- bằng hàm Guid.CreateVersion7() trước khi Insert vào database.
-- ==============================================================================

-- =========================================
-- 1. MODULE NGƯỜI DÙNG (Identity & Profile)
-- =========================================
CREATE TABLE Users (
    Id UUID PRIMARY KEY, 
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName VARCHAR(100),
    AvatarUrl VARCHAR(255), -- Đã thêm: Ảnh đại diện
    Height DECIMAL(5,2),
    CurrentWeight DECIMAL(5,2), -- Đã đổi tên để rõ nghĩa
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Đã thêm: Bảng theo dõi lịch sử cân nặng
CREATE TABLE Weight_History (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    Weight DECIMAL(5,2) NOT NULL,
    Notes TEXT,
    RecordedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- =========================================
-- 2. MODULE BÀI TẬP & GHI CHÉP
-- =========================================
CREATE TABLE Exercises (
    Id UUID PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    MuscleGroup VARCHAR(50) NOT NULL,
    Description TEXT,
    MediaUrl VARCHAR(255) -- Video/Ảnh hướng dẫn động tác
);

CREATE TABLE Workouts (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    Name VARCHAR(100) NOT NULL,
    StartTime TIMESTAMP NOT NULL,
    EndTime TIMESTAMP,
    Notes TEXT
);

CREATE TABLE Workout_Logs (
    Id UUID PRIMARY KEY,
    WorkoutId UUID REFERENCES Workouts(Id) ON DELETE CASCADE,
    ExerciseId UUID REFERENCES Exercises(Id) ON DELETE CASCADE,
    SetNumber INT NOT NULL,
    Reps INT NOT NULL,
    Weight DECIMAL(5,2) NOT NULL
);

-- =========================================
-- 3. MODULE CỘNG ĐỒNG (SOCIAL)
-- =========================================
CREATE TABLE Followers (
    FollowerId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    FollowingId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (FollowerId, FollowingId)
);

CREATE TABLE Posts (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    WorkoutId UUID REFERENCES Workouts(Id) ON DELETE SET NULL, -- Có thể post kèm bài tập
    Content TEXT,
    MediaUrl VARCHAR(255), -- Đã thêm: Ảnh/Video check-in của bài viết
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Comments (
    Id UUID PRIMARY KEY,
    PostId UUID REFERENCES Posts(Id) ON DELETE CASCADE,
    UserId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    Content TEXT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Likes (
    PostId UUID REFERENCES Posts(Id) ON DELETE CASCADE,
    UserId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (PostId, UserId)
);

-- =========================================
-- 4. MODULE TRỢ LÝ AI (AI AGENT)
-- =========================================
CREATE TABLE Chat_Sessions (
    Id UUID PRIMARY KEY,
    UserId UUID REFERENCES Users(Id) ON DELETE CASCADE,
    Title VARCHAR(255) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Chat_Messages (
    Id UUID PRIMARY KEY,
    SessionId UUID REFERENCES Chat_Sessions(Id) ON DELETE CASCADE,
    Role VARCHAR(20) NOT NULL, -- 'User' hoặc 'AI'
    Content TEXT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);







==================================================================
-- 1. Xóa toàn bộ schema public và tất cả các bảng bên trong nó
DROP SCHEMA public CASCADE;

-- 2. Tạo lại schema public mới tinh
CREATE SCHEMA public;

-- 3. Cấp lại quyền mặc định (để user của bạn có thể tạo bảng mới)
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;