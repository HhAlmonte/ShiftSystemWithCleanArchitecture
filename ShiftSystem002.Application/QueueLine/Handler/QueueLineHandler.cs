using AutoMapper;
using ShiftSystem002.Application.Generic.Handlers;
using ShiftSystem002.Application.Generic.Interfaces;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Application.QueueLine.Dto;

namespace ShiftSystem002.Application.QueueLine.Handler
{
    public interface IQueueLineHandler : IBaseCrudHandler<QueueLineDto, Domain.Entities.QueueLine>
    {
    }
    
    public class QueueLineHandler : BaseCrudHandler<QueueLineDto, Domain.Entities.QueueLine>, IQueueLineHandler
    {
        public QueueLineHandler(IQueueLineService crudService, IMapper mapper) : base(crudService, mapper)
        {
        }
    }
}
