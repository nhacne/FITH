using FitHealth.Domain.Common;
using System;

namespace FitHealth.Domain.Entities
{
    public class WorkoutLog : BaseEntity
    {
        public Guid WorkoutId { get; set; }
        public Guid ExerciseId { get; set; }
        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }

        // Navigation
        public Workout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
}