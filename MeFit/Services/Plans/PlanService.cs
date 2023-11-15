using Microsoft.EntityFrameworkCore;
using MeFit.Data;
using MeFit.Data.Exceptions;
using MeFit.Data.Models;
using MeFit.Services.Exercises;
using MeFit.Services.Plans;

namespace MeFit.Services.Plans
{

    public class PlanService : IPlanService
{
        //Handle tasks like data validation, processing, and interactions with the database or external APIs.
        //Ensure that the application's business rules are enforced.

        private readonly MeFitDdContext _context;

        public PlanService(MeFitDdContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Plan>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }
        public async Task<Plan> GetByIdAsync(Guid id)
        {
            var plan = await _context.Plans.Where(p => p.Id == id).FirstAsync();

            if (plan is null)
                throw new EntityNotFoundException(nameof(plan), id);

            return plan;
        }
        public async Task<Plan> AddAsync(Plan obj)
        {
            await _context.Plans.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            if (!await PlanExistsAsync(id))
                throw new EntityNotFoundException(nameof(Plan), id);

            var plan = await _context.Plans
                .Where(e => e.Id == id)
                .FirstAsync();


            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();
        }
        public async Task<Plan> UpdateAsync(Plan obj)
        {
            {
                if (!await PlanExistsAsync(obj.Id))
                    throw new EntityNotFoundException(nameof(Plan), obj.Id);


                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();

                return obj;
            }
        }

        //Helper Methods
       
        private Task<bool> PlanExistsAsync(Guid id)
        {
            return _context.Plans.AnyAsync(p => p.Id == id);
        }

        private async Task<bool> ExerciseExistsAsync(Guid exerciseId)
        {
            return await _context.Exercises.AnyAsync(e => e.Id == exerciseId);
        }
        private Task<bool> WorkoutExistsAsync(Guid workoutId)
        {
            return _context.Workouts.AnyAsync(w => w.Id == workoutId);
        }
    }
}

