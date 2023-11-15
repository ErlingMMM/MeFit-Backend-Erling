using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MeFit.Data.Models
{
    //Define the structure of the data that will be stored in the database. 
    [Table(nameof(Workout))]
    public class Workout
    {
        [Key]
        public Guid Id { get; set; } 

        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        public int Difficulty { get; set; }

        [StringLength(200)]
        public string Equipment { get; set; } = null!;

        [StringLength(200)]
        public string MuscleGroup { get; set; } = null!;

        [StringLength(500)]
        public string Description { get; set; } = null!;

        [StringLength(500)]
        public string Image { get; set; } = null!;

        public int Sets { get; set; }

        public int Reps { get; set; }


        public ICollection<ExerciseWorkout>? ExerciseWorkouts { get; set; }
        public ICollection<WorkoutPlan>? WorkoutPlans { get; set; }

    }
}
