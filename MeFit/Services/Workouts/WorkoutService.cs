using Microsoft.EntityFrameworkCore;
using MeFit.Data;
using MeFit.Data.Exceptions;
using MeFit.Data.Models;
using MeFit.Services.Exercises;
using MeFit.Services.Plans;



namespace MeFit.Services.Workouts
{

    public class WorkoutService : IWorkoutService
    {
        //Handle tasks like data validation, processing, and interactions with the database or external APIs.
        //Ensure that the application's business rules are enforced.

        private readonly MeFitDdContext _context;

        public WorkoutService(MeFitDdContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Workout>> GetAllAsync()
        {
            return await _context.Workouts.ToListAsync();
        }
        public async Task<Workout> GetByIdAsync(Guid id)
        {
            var workout = await _context.Workouts.Where(w => w.Id == id).FirstAsync();

            if (workout is null)
                throw new EntityNotFoundException(nameof(workout), id);

            return workout;
        }
        public async Task<Workout> AddAsync(Workout obj)
        {
            await _context.Workouts.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            if (!await PlanExistsAsync(id))
                throw new EntityNotFoundException(nameof(Workout), id);

            var workout = await _context.Workouts
                .Where(e => e.Id == id)
                .FirstAsync();


            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        }
        public async Task<Workout> UpdateAsync(Workout obj)
        {
            {
                if (!await PlanExistsAsync(obj.Id))
                    throw new EntityNotFoundException(nameof(Workout), obj.Id);


                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

                return obj;
            }
        }



        //Helper Methods

        private Task<bool> PlanExistsAsync(Guid planId)
        {
            return _context.Plans.AnyAsync(p => p.Id == planId);
        }

        private async Task<bool> ExerciseExistsAsync(Guid exerciseId)
        {
            return await _context.Exercises.AnyAsync(e => e.Id == exerciseId);
        }
        private Task<bool> WorkoutExistsAsync(Guid id)
        {
            return _context.Workouts.AnyAsync(w => w.Id == id);
        }


        public async Task AddExerciseToWorkoutAsync(ExerciseWorkout exerciseWorkout)
        {
            try
            {
                // Check if the workout exists
                if (!await WorkoutExistsAsync(exerciseWorkout.WorkoutId))
                {
                    throw new EntityNotFoundException(nameof(Workout), exerciseWorkout.WorkoutId);
                }

                // Check if the exercise exists
                if (!await ExerciseExistsAsync(exerciseWorkout.ExerciseId))
                {
                    throw new EntityNotFoundException(nameof(Exercise), exerciseWorkout.ExerciseId);
                }

                // Check if the ExerciseWorkout already exists for this workout and exercise combination
                if (await _context.ExerciseWorkouts
                    .AnyAsync(ew => ew.WorkoutId == exerciseWorkout.WorkoutId && ew.ExerciseId == exerciseWorkout.ExerciseId))
                {
                    throw new InvalidOperationException("ExerciseWorkout already exists for this workout and exercise combination.");
                }

                // If all checks pass, add the ExerciseWorkout to the database
                _context.ExerciseWorkouts.Add(exerciseWorkout);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any additional exceptions or log the error
                throw new ApplicationException("Error adding ExerciseWorkout to the database.", ex);
            }
        }


    }
}


