using AutoMapper;
using ShiftSystem002.Application.Generic.Handlers;
using ShiftSystem002.Application.Generic.Interfaces;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Application.PersonQueue.Dto;

namespace ShiftSystem002.Application.PersonQueue.Handler
{
    public interface IPersonQueueHandler : IBaseCrudHandler<PersonQueueDto, Domain.Entities.PersonQueue>
    {
        Task<PersonQueueDto> GetNext();
        Task<PersonQueueDto> UpdateStatusInPersonQueue(int id, Domain.Enums.Status status);
    }

    public class PersonQueueHandler : BaseCrudHandler<PersonQueueDto, Domain.Entities.PersonQueue>, IPersonQueueHandler
    {
        private new readonly IPersonQueueService _crudService;
        private readonly IUtils _utils;
        private readonly IPersonService _personService;
        private new readonly IMapper _mapper;

        public PersonQueueHandler(IPersonQueueService crudService,
                                  IMapper mapper,
                                  IUtils utils,
                                  IPersonService personService) : base(crudService, mapper)
        {
            _personService = personService;
            _utils = utils;
            _crudService = crudService;
            _mapper = mapper;
        }

        public override async Task<PersonQueueDto> Create(PersonQueueDto dto)
        {
            var entity = _mapper.Map<Domain.Entities.PersonQueue>(dto);

            if (await IsPersonInQueue(dto)) throw new Exception($"Person with id: {dto.PersonId} already in queue");

            /*var person = await _personService.GetyById(dto.PersonId);

            if (await _utils.IsOverweight(person.Height, person.Weight))
            {
                entity.Conditions = Domain.Enums.Conditions.OverWeight;
            }*/

            var result = await _crudService.Create(entity);

            return _mapper.Map<PersonQueueDto>(result);
        }

        public override async Task<List<PersonQueueDto>> Get(int top = 50)
        {
            var result = _crudService.Get(top)
                .Result.OrderBy(x => x.Status);

            return await Task.FromResult(_mapper.Map<List<PersonQueueDto>>(result));
        }

        public async Task<PersonQueueDto> GetNext()
        {
            var result = _crudService.Get()
                .Result
                .OrderBy(x => x.Conditions)
                .Where(x => x.Status != Domain.Enums.Status.Attended);

            return await Task.FromResult(_mapper.Map<PersonQueueDto>(result.First()));
        }

        public async Task<PersonQueueDto> UpdateStatusInPersonQueue(int id, Domain.Enums.Status status)
        {
            var personQueue = await _crudService.GetById(id);

            personQueue.Status = status;

            var result = await _crudService.Update(personQueue);

            return _mapper.Map<PersonQueueDto>(result);
        }

        private async Task<bool> IsPersonInQueue(PersonQueueDto personQueueDto)
        {
            var result = await _crudService.Get();

            result.Where(x => x.QueueLineId == personQueueDto.QueueLineId && x.Status != Domain.Enums.Status.Attended)
                .OrderBy(x => x.Created);

            if (result.Any(x => x.PersonId == personQueueDto.PersonId)) return true;

            return false;
        }
    }
}
