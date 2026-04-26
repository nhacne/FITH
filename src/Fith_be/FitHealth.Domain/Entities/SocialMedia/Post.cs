using FitHealth.Domain.Common;
using System;
using System.Collections.Generic;

namespace FitHealth.Domain.Entities
{
    public class Post : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid? WorkoutId { get; set; } // Có thể null nếu post chỉ là text/ảnh bình thường
        public string? Content { get; set; }
        public string? MediaUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User User { get; set; } = null!;
        public Workout? Workout { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}