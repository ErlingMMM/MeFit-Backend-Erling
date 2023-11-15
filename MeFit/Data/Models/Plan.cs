using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeFit.Data.Models
{
    [Table(nameof(Plan))]
    public class Plan
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(200)]
        public string Description { get; set; } = null!;

        public int Difficulty { get; set; }

        [StringLength(500)]
        public string Image { get; set; } = null!;

        public ICollection<WorkoutPlan>? WorkoutPlans { get; set; }
    }
}
