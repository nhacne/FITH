using FitHealth.Domain.Common;
using System.Collections.Generic;

namespace FitHealth.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? MediaUrl { get; set; }

        // Navigation
        public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
    }
}