using AutoMapper;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Application.Person.Dto;

namespace ShiftSystem002.Application.Person.Handler
{
    public interface IPersonHandler
    {
        Task<PersonDto> GetById(int id);
        Task<List<PersonDto>> Get(int top = 50);
        Task<PersonDto> Create(PersonDto personDto);
    }

    public class PersonHandler : IPersonHandler
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonDto> Create(PersonDto personDto)
        {
            var person = _mapper.Map<Domain.Entities.Person>(personDto);
            
            person = await _personService.Create(person);
            
            return _mapper.Map(person, personDto);
        }
        
        public async Task<List<PersonDto>> Get(int top = 50)
        {
            var persons = await _personService.Get();
            
            var personsDto = _mapper.Map<List<PersonDto>>(persons);
            
            return personsDto;
        }

        public async Task<PersonDto> GetById(int id)
        {
            var person =  await _personService.GetyById(id);
            
            var personDto = _mapper.Map<PersonDto>(person);
            
            return personDto;
        }
    }
}
