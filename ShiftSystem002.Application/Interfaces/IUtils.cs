namespace ShiftSystem002.Application.Interfaces
{
    public interface IUtils
    {
        Task<bool> IsOverweight(decimal height, decimal weight);
    }
}
