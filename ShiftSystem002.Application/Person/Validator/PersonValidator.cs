using FluentValidation;

namespace ShiftSystem002.Application.Person.Validator
{
    public class PersonValidator : AbstractValidator<Dto.PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Weight).NotEmpty().WithMessage("Weight is required");
            RuleFor(x => x.Height).NotEmpty().WithMessage("Height is required");
            RuleFor(x => x.fileUri).NotEmpty().WithMessage("FileUri is required");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age is required");

        }
    }
}
