using Microsoft.EntityFrameworkCore;
using MeFit.Data;
using MeFit.Data.Exceptions;
using MeFit.Data.Models;

namespace MeFit.Services.Exercises
{
    public class ExerciseService : IExercisesService
    {
        //Handle tasks like data validation, processing, and interactions with the database or external APIs.
        //Ensure that the application's business rules are enforced.

        private readonly MeFitDdContext _context;

        public ExerciseService(MeFitDdContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }
        public async Task<Exercise> GetByIdAsync(int id)
        {
            var exercise = await _context.Exercises.Where(e => e.Id == id).FirstAsync();

            if (exercise is null)
                throw new EntityNotFoundException(nameof(exercise), id);

            return exercise;
        }
        public async Task<Exercise> AddAsync(Exercise obj)
        {
            await _context.Exercises.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task DeleteByIdAsync(int id)
        {
            if (!await ExerciseExistsAsync(id))
                throw new EntityNotFoundException(nameof(Exercise), id);

            var exercise = await _context.Exercises
                .Where(e => e.Id == id)
                .FirstAsync();


            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
        public async Task<Exercise> UpdateAsync(Exercise obj)
        {
            {
                if (!await ExerciseExistsAsync(obj.Id))
                    throw new EntityNotFoundException(nameof(Exercise), obj.Id);


                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return obj;
            }
        }

        //Helper Methods
        private async Task<bool> ExerciseExistsAsync(int id)
        {
            return await _context.Exercises.AnyAsync(e => e.Id == id);
        }
        private Task<bool> PlanExistsAsync(int planId)
        {
            return _context.Plans.AnyAsync(p => p.Id == planId);
        }
        private Task<bool> WorkoutExistsAsync(int workoutId)
        {
            return _context.Workouts.AnyAsync(w => w.Id == workoutId);
        }
    }
}

