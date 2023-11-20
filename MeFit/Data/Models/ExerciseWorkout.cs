using System.ComponentModel.DataAnnotations.Schema;

namespace MeFit.Data.Models
{
    public class ExerciseWorkout
    {
        [ForeignKey("ExerciseId")]
        public int ExerciseId { get; set; }

        public Exercise? Exercise { get; set; }

        [ForeignKey("WorkoutId")]

        public int WorkoutId { get; set; }
        public Workout? Workout { get; set; }

    }
}

