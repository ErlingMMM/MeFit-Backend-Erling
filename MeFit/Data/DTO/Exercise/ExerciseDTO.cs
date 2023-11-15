using MeFit.Data.Dtos.Workout;
using System.ComponentModel.DataAnnotations;

namespace MeFit.Data.DTO.Exercise
{
    public class ExerciseDTO
    {
        public string Name { get; set; } = null!;
        public string Difficulty { get; set; } = null!;
        public string Equipment { get; set; } = null!;
        public string MuscleGroup { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;
        public List<WorkoutDTO>? Workouts { get; set; }

    }
}
