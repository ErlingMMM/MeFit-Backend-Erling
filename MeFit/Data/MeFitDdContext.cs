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
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Plan> Plans { get; set; }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=N-NO-01-01-6434\\SQLEXPRESS; Initial Catalog=MeFitEF; Integrated Security= true; Trust Server Certificate= true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int exercise1Id = 1;
            int exercise2Id = 2;
            int workout1Id = 1;
            int workout2Id = 2;
            int plan1Id = 1;
            int plan2Id = 2;


            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = exercise1Id,
                    Name = "Jumping Jacks",
                    Description = "Jumping jacks are a simple and effective cardiovascular exercise...",
                    Difficulty = 1,
                    MuscleGroup = "Legs, Arms, Cardio",
                    Equipment = "Jump Rope",
                    Image = "https://unsplash.com/photos/a-woman-squatting-on-a-barbell-in-a-gym-iqr5wW_xwLY" 

                },
                new Exercise
                {
                    Id = exercise2Id,
                    Name = "Bicycle Crunches",
                    Description = "Bicycle crunches are a great abdominal exercise that targets multiple muscle groups...",
                    Difficulty = 2,
                    MuscleGroup = "Abdominals, Legs",
                    Equipment = "Exercise Mat",
                    Image = "https://unsplash.com/photos/woman-exercising-indoors-lrQPTQs7nQQ"

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
                    MuscleGroup = "Legs, Arms, Core",
                    Image = "https://example.com/bicyclecrunches.jpg", // Replace this URL with an actual image URL
                    Equipment = "Jump Rope"

                },
                new Workout
                {
                    Id = workout2Id,
                    Description = "High-Intensity Interval Training (HIIT)",
                    Difficulty = 3,
                    Name = "HIIT Workout",
                    Sets = 4,
                    Reps = 12,
                    MuscleGroup = "Cardio, Legs, Arms",
                    Equipment = "Exercise Mat",

                    Image = "https://example.com/bicyclecrunches.jpg" // Replace this URL with an actual image URL

                }
            );




            modelBuilder.Entity<Plan>().HasData(
       new Plan
       {
           Id = plan1Id,
           Name = "Beginner Plan",
           Description = "A beginner workout plan for getting started.",
           Difficulty = 1,
           Image = "https://example.com/bicyclecrunches.jpg" // Replace this URL with an actual image URL

       },
       new Plan
       {
           Id = plan2Id,
           Name = "Intermediate Plan",
           Description = "An intermediate workout plan for advancing your fitness.",
           Difficulty = 2,
           Image = "https://example.com/bicyclecrunches.jpg" // Replace this URL with an actual image URL

       }
   );

           
            modelBuilder.Entity<ExerciseWorkout>().HasKey(ew => new { ew.ExerciseId, ew.WorkoutId });


            modelBuilder.Entity<Exercise>()
                .HasMany(left => left.Workouts)
                .WithMany(right => right.Exercises)
                .UsingEntity<ExerciseWorkout>(
                    right => right.HasOne(e => e.Workout).WithMany(),
                    left => left.HasOne(e => e.Exercise).WithMany().HasForeignKey(e => e.ExerciseId),
                    join => join.ToTable("ExerciseWorkout")
                );

            modelBuilder.Entity<ExerciseWorkout>().HasData(
                new ExerciseWorkout() { ExerciseId = 1, WorkoutId = 1 },
                new ExerciseWorkout() { ExerciseId = 2, WorkoutId = 2 },
                new ExerciseWorkout() { ExerciseId = 1, WorkoutId = 2 },
                new ExerciseWorkout() { ExerciseId = 2, WorkoutId = 1 });


            modelBuilder.Entity<WorkoutPlan>()
.HasKey(e => new { e.PlanId, e.WorkoutId });

            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan() { PlanId = plan1Id, WorkoutId = workout1Id },
                new WorkoutPlan() { PlanId = plan2Id, WorkoutId = workout2Id }
            );
        }
    }
}
