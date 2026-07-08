using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IRetriever
{
    Task<IReadOnlyList<SearchResult>> RetrieveAsync(VectorSearchRequest request);
}