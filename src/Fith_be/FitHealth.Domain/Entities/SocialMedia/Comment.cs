using FitHealth.Domain.Common;
using System;

namespace FitHealth.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}