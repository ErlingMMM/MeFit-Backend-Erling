using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using MeFit.Data.DTO.Exercise;
using System.ComponentModel.DataAnnotations;
using MeFit.Data.DTO.Plan;

namespace MeFit.Data.Dtos.Workout
{
    public class WorkoutDTO
{
        //Used for transferring data between the client and the server.
        //Allow you to control what data is exposed to clients and provide a clear structure for data exchange.

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int Difficulty { get; set; }

        public string Equipment { get; set; } = null!;

        public string MuscleGroup { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int Sets { get; set; }

        public int Reps { get; set; }

        public Guid[]? ExerciseWorkouts { get; set; }
        public Guid[]? WorkoutPlans { get; set; }

    }
}








