
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MeFit.Data.Exceptions;
using MeFit.Data.Models;
using MeFit.Services.Exercises;
using MeFit.Data.DTO.Exercise;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeFit.Controllers
{
    [ApiController]
    [Route("api/v1/Exercise")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    //These files define the API endpoints, their routes, and the actions to be taken for each endpoint.
    //Controllers interact with services to perform business logic.
    public class ExerciseController : ControllerBase
    {
        private readonly IExercisesService _exerciseService;
        private readonly IMapper _mapper;

        public ExerciseController(IExercisesService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets a list of all exercises in the database. No params.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExerciseDTO>>> GetWorkouts()
        {
            return Ok(_mapper
                .Map<IEnumerable<ExerciseDTO>>(
                    await _exerciseService.GetAllAsync()));
        }
        /// <summary>
        /// Get a spesific exercise from database using their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDTO>> GetExercise(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<ExerciseDTO>(
                        await _exerciseService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Updating a spesific exercise from database using their id, expects code 204
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, ExercisePutDTO exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest();
            }

            try
            {
                await _exerciseService.UpdateAsync(_mapper.Map<Exercise>(exercise));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Creating a new exercise to the database
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ExerciseDTO>> PostExercise(ExercisePostDTO exercise)
        {
            var newExercise = await _exerciseService.AddAsync(_mapper.Map<Exercise>(exercise));

            return CreatedAtAction("GetExercise",
                new { id = newExercise.Id },
                _mapper.Map<ExerciseDTO>(newExercise));
        }

        /// <summary>
        /// Deleting a exercise from the database using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            try
            {
                await _exerciseService.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
