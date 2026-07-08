using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IVectorStore
{
    Task AddAsync(DocumentEmbedding document);
    
    Task<IReadOnlyList<SearchResult>> SearchAsync(VectorSearchRequest request);

    Task<int> CountAsync();

    Task<IReadOnlyList<DocumentEmbedding>>GetAllAsync();
}