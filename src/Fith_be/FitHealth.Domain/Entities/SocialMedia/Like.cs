using System;

namespace FitHealth.Domain.Entities
{
    public class Like
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}