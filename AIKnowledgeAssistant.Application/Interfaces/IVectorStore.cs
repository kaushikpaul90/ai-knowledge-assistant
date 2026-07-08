using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IVectorStore
{
    Task AddAsync(DocumentEmbedding document);
    
    Task<IReadOnlyList<DocumentEmbedding>> SearchAsync(VectorSearchRequest request);

    Task<int> CountAsync();
}