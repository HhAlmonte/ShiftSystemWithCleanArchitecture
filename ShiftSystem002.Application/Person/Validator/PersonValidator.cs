using FluentValidation;

namespace ShiftSystem002.Application.Person.Validator
{
    public class PersonValidator : AbstractValidator<Dto.PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.DNI)
                .NotEmpty()
                .MaximumLength(13)
                .WithMessage("DNI is required");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("FullName is required");

            
        }
    }
}
