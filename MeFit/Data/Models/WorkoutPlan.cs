using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeFit.Data.Models
{
    public class WorkoutPlan
    {
        [ForeignKey("WorkoutId")]
        public Guid WorkoutId { get; set; }

        public Workout? Workout { get; set; }

        [ForeignKey("PlanId")]
        public Guid PlanId { get; set; }

        public Plan? Plan { get; set; }
    }
}
