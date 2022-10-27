using ShiftSystem002.Application.Generic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftSystem002.Application.Person.Dto
{
    public class PersonUriDto : BaseDto
    {
        public Uri FileUri { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
