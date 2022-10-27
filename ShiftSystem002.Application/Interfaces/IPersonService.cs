using Azure.AI.FormRecognizer.DocumentAnalysis;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem002.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Domain.Entities.Person> Create( Domain.Entities.Person person);
        Task<List<Domain.Entities.Person>> Get(int top = 50);
        Task<Domain.Entities.Person> GetyById(int id);

        /*
        Task<Domain.Entities.Person> GetPersonFromAnalyzeResult(AnalyzeResult analyzeResult);*/
    }
}
