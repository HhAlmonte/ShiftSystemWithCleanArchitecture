using FluentValidation;
using ShiftSystem002.Application.PersonQueue.Dto;

namespace ShiftSystem002.Application.PersonQueue.Validator
{
    public class PersonQueueValidator : AbstractValidator<PersonQueueDto>
    {
        public PersonQueueValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.QueueLineId).NotEmpty();
        }
    }
}
