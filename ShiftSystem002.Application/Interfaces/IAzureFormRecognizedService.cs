using Azure.AI.FormRecognizer.DocumentAnalysis;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem002.Application.Interfaces
{
    public interface IAzureFormRecognizedService
    {
        Task<AnalyzeResult> GetAnalyzeResultValue(AzureConfig azureConfig, Uri fileUri);
    }
}