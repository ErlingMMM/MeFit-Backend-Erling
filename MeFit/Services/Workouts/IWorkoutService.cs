using MeFit.Data.Models;
using MeFit.Services;

namespace MeFit.Services.Workouts
{
    public interface IWorkoutService : ICrudService<Workout, int>
    {
        //Define the methods and operations that services must implement.
        //Provide a level of abstraction and help in unit testing and mocking.



        Task<ICollection<Exercise>> GetAllExercisesInWorkoutAsync(int id);

    }
}



