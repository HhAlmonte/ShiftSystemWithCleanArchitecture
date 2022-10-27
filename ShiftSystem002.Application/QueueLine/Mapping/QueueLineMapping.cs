using AutoMapper;
using ShiftSystem002.Application.QueueLine.Dto;

namespace ShiftSystem002.Application.QueueLine.Mapping
{
    public class QueueLineMapping : Profile
    {
        public QueueLineMapping()
        {
            CreateMap<Domain.Entities.QueueLine, QueueLineDto>().ReverseMap();
        }
    }
}
