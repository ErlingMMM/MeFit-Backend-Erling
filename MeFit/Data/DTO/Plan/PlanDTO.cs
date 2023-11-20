using MeFit.Data.Dtos.Workout;
using System.ComponentModel.DataAnnotations;

namespace MeFit.Data.DTO.Plan
{
    public class PlanDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Difficulty { get; set; }

        public string Image { get; set; } = null!;
        public List<WorkoutDTO>? Workouts { get; set; }

    }
}
