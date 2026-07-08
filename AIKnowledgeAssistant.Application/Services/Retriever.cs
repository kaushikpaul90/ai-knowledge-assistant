using AIKnowledgeAssistant.Application.Configuration;
using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;
using Microsoft.Extensions.Options;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class Retriever : IRetriever
{
    private readonly IVectorStore _vectorStore;
    private readonly RetrievalOptions _options;
    public Retriever(IVectorStore vectorStore, IOptions<RetrievalOptions> options)
    {
        _vectorStore = vectorStore;
        _options = options.Value;
    }

    public async Task<IReadOnlyList<SearchResult>>RetrieveAsync(VectorSearchRequest request)
    {
        var results = await _vectorStore.SearchAsync(request);
        results = results
            .Where(x => x.Score >= _options.MinimumScore)
            .Take(_options.TopK)
            .ToList();

        return results;
    }
}