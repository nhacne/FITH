using System;

namespace FitHealth.Domain.Entities
{
    public class Follower
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public User FollowerUser { get; set; } = null!;
        public User FollowingUser { get; set; } = null!;
    }
}