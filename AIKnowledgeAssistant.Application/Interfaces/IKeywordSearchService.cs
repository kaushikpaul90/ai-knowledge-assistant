using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IKeywordSearchService
{
    Task<IReadOnlyList<SearchResult>> SearchAsync(
        string query,
        int topK = 5);
}