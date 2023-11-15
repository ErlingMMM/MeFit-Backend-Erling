using System;

namespace MeFit
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public int Difficulty { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? MuscleGroup { get; set; }
        public string? Equipment { get; set; }
    }
}
