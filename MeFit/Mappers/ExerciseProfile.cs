



using AutoMapper;
using MeFit.Data.DTO.Exercise;
using MeFit.Data.DTO.Workout;
using MeFit.Data.Dtos.Workout;
using MeFit.Data.Models;

namespace MeFit.Mappers
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExercisePostDTO, Exercise>().ReverseMap();

            CreateMap<Exercise, ExerciseDTO>()
                .ForMember(wdto => wdto.ExerciseWorkouts, options => options.MapFrom(ew => ew.ExerciseWorkouts.Select(w => w.WorkoutId).ToArray()));
        }
    }
}

