

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeFit.Data.Models
{
    //Define the structure of the data that will be stored in the database. 
    [Table(nameof(Exercise))]
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        public string Difficulty { get; set; } = null!;
        [StringLength(200)]
        public string Equipment { get; set; } = null!;
        [StringLength(200)]
        public string MuscleGroup { get; set; } = null!;
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [StringLength(500)]
        public string Image { get; set; } = null!;


        public ICollection<ExerciseWorkout>? ExerciseWorkouts { get; set; }
    }
}
