using AutoMapper;

namespace ShiftSystem002.Application.Person.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Dto.PersonDto, Domain.Entities.Person>();

            CreateMap<Domain.Entities.Person, Dto.PersonDto>();

            CreateMap<Domain.Entities.Person, Dto.ResponsePersonDto>();
        }
    }
}
