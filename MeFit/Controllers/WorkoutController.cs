using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MeFit.Data.Dtos.Workout;
using MeFit.Data.Exceptions;
using MeFit.Data.Models;
using MeFit.Services.Workouts;
using MeFit.Data.DTO.Workout;
using MeFit.Data.DTO.Exercise;
using MeFit.Data.DTO.ExerciseWorkout;
using MeFit.Services.Exercises;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeFit.Controllers
{
    [ApiController]
    [Route("api/v1/Workout")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    //These files define the API endpoints, their routes, and the actions to be taken for each endpoint.
    //Controllers interact with services to perform business logic.
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExercisesService _exerciseService;
        private readonly IMapper _mapper;

        public WorkoutController(IWorkoutService workoutService, IExercisesService exercisesService, IMapper mapper)
        {
            _workoutService = workoutService;
            _exerciseService = exercisesService;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets a list of all workouts in the database. No params.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WorkoutDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WorkoutDTO>>> GetWorkouts()
        {
            return Ok(_mapper
                .Map<IEnumerable<WorkoutDTO>>(
                    await _workoutService.GetAllAsync()));
        }
        /// <summary>
        /// Get a spesific workout from database using their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutDTO>> GetWorkout(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<WorkoutDTO>(
                        await _workoutService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updating a spesific workout from database using their id, expects code 204
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workout"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout(int id, WorkoutPutDTO workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            try
            {
                await _workoutService.UpdateAsync(_mapper.Map<Workout>(workout));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Creating a new workout to the database
        /// </summary>
        /// <param name="workout"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<WorkoutDTO>> PostWorkout(WorkoutPostDTO workout)
        {
            var newWorkout = await _workoutService.AddAsync(_mapper.Map<Workout>(workout));

            return CreatedAtAction("GetWorkout",
                new { id = newWorkout.Id },
                _mapper.Map<WorkoutDTO>(newWorkout));
        }

        /// <summary>
        /// Deleting a workout from the database using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            try
            {
                await _workoutService.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Get all exercises in a workout by workout id
        /// </summary>
        /// <param name="workoutId"></param>
        /// <returns></returns>
        [HttpGet("{id}/exercises")]
        public async Task<ActionResult<IEnumerable<ExerciseDTO>>> GetAllExercisesInWorkout(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<ExerciseDTO>>(
                        await _workoutService.GetAllExercisesInWorkoutAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}