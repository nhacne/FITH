using FitHealth.Domain.Common;
using System;

namespace FitHealth.Domain.Entities
{
    public class WeightHistory : BaseEntity
    {
        public Guid UserId { get; set; }
        public decimal Weight { get; set; }
        public string? Notes { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public User User { get; set; } = null!;
    }
}