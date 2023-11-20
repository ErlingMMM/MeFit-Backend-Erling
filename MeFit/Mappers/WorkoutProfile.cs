using AutoMapper;
using MeFit.Data.DTO.Workout;
using MeFit.Data.Dtos.Workout;
using MeFit.Data.Models;

namespace MeFit.Mappers
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile() 
        {
            CreateMap<WorkoutPostDTO, Workout>().ReverseMap();

            CreateMap<Workout, WorkoutDTO>()
                    .ForMember(wdto => wdto.Exercises, options => options.MapFrom(w => w.Exercises.Select(c => c.Id).ToArray()))
                .ForMember(wdto => wdto.WorkoutPlans, options => options.MapFrom(wp => wp.WorkoutPlans.Select(w => w.WorkoutId).ToArray())).ReverseMap();
        }
    }
}




