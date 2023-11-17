using System.ComponentModel.DataAnnotations;

namespace MeFit.Data.DTO.Workout
{
    public class WorkoutPostDTO
    {
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string Description { get; set; } = null!;

        public int Difficulty { get; set; }
        [StringLength(200)]

        public string Equipment { get; set; } = null!;
        [StringLength(200)]

        public string MuscleGroup { get; set; } = null!;
        [StringLength(500)]


        public string Image { get; set; } = null!;

        public int Sets { get; set; }

        public int Reps { get; set; }
    }
}
