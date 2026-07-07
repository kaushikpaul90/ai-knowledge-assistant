using AIKnowledgeAssistant.Application.DTOs;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IEmbeddingService
{
    Task<EmbeddingResponse> GenerateAsync(EmbeddingRequest request);
}