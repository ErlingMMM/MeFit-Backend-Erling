using System.ComponentModel.DataAnnotations;

namespace MeFit.Data.DTO.Exercise
{
    public class ExercisePutDTO
    {
        public Guid Id { get; set; }
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


    }
}

