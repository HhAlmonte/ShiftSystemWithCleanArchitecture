using AutoMapper;
using ShiftSystem002.Application.PersonQueue.Dto;

namespace ShiftSystem002.Application.PersonQueue.Mapping
{
    public class PersonQueueMapping : Profile
    {
        public PersonQueueMapping()
        {
            CreateMap<Domain.Entities.PersonQueue, PersonQueueDto>()
                .ForMember(x => x.Conditions, opt => opt.MapFrom(x => x.Conditions))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status))
                .ForMember(x => x.Created, opt => opt.MapFrom(x => x.Created))
                .ReverseMap();
        }
    }
}
