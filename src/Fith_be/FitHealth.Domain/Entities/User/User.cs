using FitHealth.Domain.Common;
using System;
using System.Collections.Generic;

namespace FitHealth.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public decimal? Height { get; set; }
        public decimal? CurrentWeight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties (Thể hiện mối quan hệ)
        public ICollection<WeightHistory> WeightHistories { get; set; } = new List<WeightHistory>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}