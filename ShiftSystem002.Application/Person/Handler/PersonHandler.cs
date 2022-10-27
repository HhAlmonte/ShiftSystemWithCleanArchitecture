using AutoMapper;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Application.Person.Dto;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem002.Application.Person.Handler
{
    public interface IPersonHandler
    {
        Task<PersonDto> GetById(int id);
        Task<List<PersonDto>> Get(int top = 50);
        Task<PersonDto> Create(PersonDto personDto);
        Task<PersonDto> GetPersonFromAnalyzeResult(AnalyzeResult analyzeResult);
    }

    public class PersonHandler : IPersonHandler
    {
        private readonly IPersonService _personService;
        private readonly IAzureFormRecognizedService _azureFormRecognizedService;
        private readonly IMapper _mapper;

        public PersonHandler(IPersonService personService,
                             IMapper mapper,
                             IAzureFormRecognizedService azureFormRecognizedService)
        {
            _personService = personService;
            _mapper = mapper;
            _azureFormRecognizedService = azureFormRecognizedService;
        }

        public async Task<PersonDto> Create(PersonDto personDto)
        {
            var azureConfig = new AzureConfig
            {
                endpoint = "https://validatorrr.cognitiveservices.azure.com/",
                key = "6e6fe3c8899d452ca8cc2902008fc812",
                modelId = "dni"
            };

            var person = _mapper.Map<Domain.Entities.Person>(personDto);

            var analyzeResult = await _azureFormRecognizedService.GetAnalyzeResultValue(azureConfig, personDto.fileUri);

            var personFromAnalyzeResult = await _personService.GetPersonFromAnalyzeResult(analyzeResult);

            person.FullName = personFromAnalyzeResult.FullName;
            
            person.DNI = personFromAnalyzeResult.DNI;

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
            var person = await _personService.GetyById(id);

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public async Task<PersonDto> GetPersonFromAnalyzeResult(AnalyzeResult analyzeResult)
        {
            var person = await _personService.GetPersonFromAnalyzeResult(analyzeResult);

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }
    }
}
