using AutoMapper;
using ShiftSystem.Infrastructure.Context;
using ShiftSystem.Infrastructure.Service;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem.Infrastructure.Services.Modules_Services
{
    public class PersonQueueService : BaseCrudService<PersonQueue>, IPersonQueueService
    {
        public PersonQueueService(IShiftSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
