using FitHealth.Domain.Common;
using System;
using System.Collections.Generic;

namespace FitHealth.Domain.Entities
{
    public class Workout : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Notes { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
        public ICollection<Post> Posts { get; set; } = new List<Post>(); // Nếu người dùng share bài tập này
    }
}