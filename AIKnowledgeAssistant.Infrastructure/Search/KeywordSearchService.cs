using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Infrastructure.Search;

public sealed class KeywordSearchService
    : IKeywordSearchService
{
    private readonly IVectorStore _vectorStore;

    public KeywordSearchService(
        IVectorStore vectorStore)
    {
        _vectorStore = vectorStore;
    }

    public async Task<IReadOnlyList<SearchResult>>
        SearchAsync(
            string query,
            int topK = 5)
    {
        var allDocuments =
            await _vectorStore.GetAllAsync();

        var results =
            allDocuments
                .Where(d =>
                    d.Content.Contains(
                        query,
                        StringComparison.OrdinalIgnoreCase))
                .Select(d =>
                    new SearchResult
                    {
                        Document = d,
                        Score = 1.0
                    })
                .Take(topK)
                .ToList();

        return results;
    }
}