using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Domain.Base;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem.Infrastructure.Services.Modules_Services
{
    public class AzureFormRecognizerService : IAzureFormRecognizerService
    {
        public async Task<AnalyzeResult> GetAnalyzeResultValue(AzureConfig azureConfig, Uri fileUri)
        {
            var client = new DocumentAnalysisClient(new Uri(azureConfig.endpoint), new AzureKeyCredential(azureConfig.key));

            var operation = await client.AnalyzeDocumentFromUriAsync(WaitUntil.Completed, azureConfig.modelId, fileUri);

            return operation.Value;
        }
    }
}
