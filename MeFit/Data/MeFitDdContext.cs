using Microsoft.EntityFrameworkCore;
using MeFit.Data.Models;
using System;

namespace MeFit.Data
{
    public class MeFitDdContext : DbContext
    {
        public MeFitDdContext(DbContextOptions<MeFitDdContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=N-NO-01-01-6434\\SQLEXPRESS; Initial Catalog=MoviesEF; Integrated Security= true; Trust Server Certificate= true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid exercise1Id = Guid.NewGuid();
            Guid exercise2Id = Guid.NewGuid();
            Guid workout1Id = Guid.NewGuid();
            Guid workout2Id = Guid.NewGuid();
            Guid plan1Id = Guid.NewGuid();
            Guid plan2Id = Guid.NewGuid();


            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = exercise1Id,
                    Name = "Jumping Jacks",
                    Description = "Jumping jacks are a simple and effective cardiovascular exercise...",
                    Difficulty = 1,
                    MuscleGroup = "Legs, Arms, Cardio",
                    Equipment = "Jump Rope"
                },
                new Exercise
                {
                    Id = exercise2Id,
                    Name = "Bicycle Crunches",
                    Description = "Bicycle crunches are a great abdominal exercise that targets multiple muscle groups...",
                    Difficulty = 2,
                    MuscleGroup = "Abdominals, Legs",
                    Equipment = "Exercise Mat"
                }
            );

            modelBuilder.Entity<Workout>().HasData(
                new Workout
                {
                    Id = workout1Id,
                    Description = "Full Body Circuit",
                    Difficulty = 2,
                    Name = "Full Body Circuit Workout",
                    Sets = 3,
                    Reps = 10,
                    MuscleGroup = "Legs, Arms, Core"
                },
                new Workout
                {
                    Id = workout2Id,
                    Description = "High-Intensity Interval Training (HIIT)",
                    Difficulty = 3,
                    Name = "HIIT Workout",
                    Sets = 4,
                    Reps = 12,
                    MuscleGroup = "Cardio, Legs, Arms"
                }
            );




            modelBuilder.Entity<Plan>().HasData(
       new Plan
       {
           Id = plan1Id,
           Name = "Beginner Plan",
           Description = "A beginner workout plan for getting started.",
           Difficulty = 1,
       },
       new Plan
       {
           Id = plan2Id,
           Name = "Intermediate Plan",
           Description = "An intermediate workout plan for advancing your fitness.",
           Difficulty = 2,
       }
   );


            modelBuilder.Entity<ExerciseWorkout>().HasData(
                new ExerciseWorkout() { ExerciseId = exercise1Id, WorkoutId = workout1Id },
                new ExerciseWorkout() { ExerciseId = exercise2Id, WorkoutId = workout2Id }
            );
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Plan> Plans { get; set; }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
    }
}
