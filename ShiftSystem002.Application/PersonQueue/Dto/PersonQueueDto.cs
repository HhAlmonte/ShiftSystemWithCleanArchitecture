using ShiftSystem002.Application.Generic.Dtos;

namespace ShiftSystem002.Application.PersonQueue.Dto
{
    public class PersonQueueDto : BaseDto
    {
        public int PersonId { get; set; }
        
        public int QueueLineId { get; set; }

        public Domain.Enums.Conditions Conditions { get; set; } = Domain.Enums.Conditions.Normal;

        public Domain.Enums.Status Status { get; set; } = Domain.Enums.Status.Registered;

        public DateTime Created { get; set; }
    }
}
