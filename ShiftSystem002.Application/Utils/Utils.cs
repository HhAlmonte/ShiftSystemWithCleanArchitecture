using ShiftSystem002.Application.Interfaces;

namespace ShiftSystem002.Application.Utils
{
    public class Utils : IUtils
    {
        public Task<bool> IsOverweight(decimal height, decimal weight)
        {
            decimal bmi = weight / (height * height);

            return Task.FromResult(bmi > 25);
        }
    }
}
