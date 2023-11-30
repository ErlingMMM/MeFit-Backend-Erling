using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MeFit.Data.Models
{
    //Define the structure of the data that will be stored in the database. 
    [Table("Workouts")]
    public class Workout
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(100)]
        public string Name { get; set; } = null!;

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


        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public List<WorkoutPlan> WorkoutPlans { get; set; } = new List<WorkoutPlan>();

    }
}
