using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ShiftSystem002.Domain.Base;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem002.Application.Interfaces
{
    public interface IAzureFormRecognizerService
    {
        Task<AnalyzeResult> GetAnalyzeResultValue(AzureConfig azureConfig, Uri fileUri);
    }
}