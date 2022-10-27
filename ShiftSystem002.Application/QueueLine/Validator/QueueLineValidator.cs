using FluentValidation;

namespace ShiftSystem002.Application.QueueLine.Validator
{
    public class QueueLineValidator : AbstractValidator<Dto.QueueLineDto>
    {
        public QueueLineValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
