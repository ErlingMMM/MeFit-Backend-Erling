



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
            .ForMember(
                dto => dto.Workouts,
                opt => opt.MapFrom(src => src.Workouts.Select(w => new WorkoutDTO { Id = w.Id })))
            .ReverseMap();
            CreateMap<ExercisePutDTO, Exercise>().ReverseMap();

            CreateMap<int, WorkoutDTO>().ConstructUsing(id => new WorkoutDTO { Id = id });
            CreateMap<WorkoutDTO, Workout>().ReverseMap();
        }
    }
}





