using FitHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitHealth.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<WeightHistory> WeightHistories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================================
            // 1. CẤU HÌNH KHÓA CHÍNH VÀ CASCADE BẢNG FOLLOWER
            // ==========================================
            modelBuilder.Entity<Follower>()
                .HasKey(f => new { f.FollowerId, f.FollowingId });

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowerUser)
                .WithMany()
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict); // Đổi thành Restrict để tránh lỗi

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowingUser)
                .WithMany()
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Restrict); // Đổi thành Restrict để tránh lỗi

            // ==========================================
            // 2. XỬ LÝ LỖI CASCADE BẢNG LIKES VÀ COMMENTS
            // ==========================================
            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.PostId, l.UserId });

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Giữ luồng Post->Like (Cascade), cắt luồng User->Like (Restrict)

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Giữ luồng Post->Comment (Cascade), cắt luồng User->Comment (Restrict)

            // ==========================================
            // 3. XỬ LÝ LỖI CASCADE BẢNG WORKOUT LOGS
            // ==========================================
            modelBuilder.Entity<WorkoutLog>()
                .HasOne(wl => wl.Exercise)
                .WithMany(e => e.WorkoutLogs)
                .HasForeignKey(wl => wl.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict); // Xóa bài tập gốc (Exercise) không được phép nếu đang có người dùng lưu log tập luyện

            // ==========================================
            // 4. CẤU HÌNH ĐỘ CHÍNH XÁC CHO KIỂU DECIMAL
            // ==========================================
            modelBuilder.Entity<User>()
                .Property(u => u.Height).HasPrecision(5, 2);
            modelBuilder.Entity<User>()
                .Property(u => u.CurrentWeight).HasPrecision(5, 2);
            modelBuilder.Entity<WeightHistory>()
                .Property(w => w.Weight).HasPrecision(5, 2);
            modelBuilder.Entity<WorkoutLog>()
                .Property(wl => wl.Weight).HasPrecision(5, 2);
        }
    }
}