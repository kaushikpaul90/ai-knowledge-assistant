using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Application.Services;
public sealed class EmbeddingService : IEmbeddingService
{
    private readonly IAIClient _aiClient;

    public EmbeddingService(IAIClient aiClient)
    {
        _aiClient = aiClient;
    }

    public async Task<EmbeddingResponse> GenerateAsync(EmbeddingRequest request)
    {
        var embedding = await _aiClient.GetEmbeddingAsync(request.Text);
        return new EmbeddingResponse(embedding);
    }
}