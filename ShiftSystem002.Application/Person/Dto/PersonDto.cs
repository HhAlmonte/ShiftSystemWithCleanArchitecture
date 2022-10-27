using ShiftSystem002.Application.Generic.Dtos;
using ShiftSystem002.Domain.Base;

namespace ShiftSystem002.Application.Person.Dto
{
    public class PersonDto : BaseDto
    {
        public string DNI { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
