using AIKnowledgeAssistant.Application.Configuration;
using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;
using Microsoft.Extensions.Options;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class Retriever : IRetriever
{
    private readonly IVectorStore _vectorStore;
    private readonly IKeywordSearchService _keywordSearchService;
    private readonly RetrievalOptions _options;
    public Retriever(IVectorStore vectorStore, IKeywordSearchService keywordSearchService, IOptions<RetrievalOptions> options)
    {
        _vectorStore = vectorStore;
        _keywordSearchService = keywordSearchService;
        _options = options.Value;
    }

    public async Task<IReadOnlyList<SearchResult>>RetrieveAsync(VectorSearchRequest request)
    {
        var vectorResults =
            await _vectorStore.SearchAsync(request);

        var keywordResults =
            await _keywordSearchService.SearchAsync(
                request.Query,
                request.TopK);

        var merged =
            vectorResults
                .Concat(keywordResults)
                .GroupBy(x => x.Document.Id)
                .Select(g => g
                    .OrderByDescending(x => x.Score)
                    .First())
                .OrderByDescending(x => x.Score)
                .Take(request.TopK)
                .ToList();
        
        var filtered = merged
            .Where(x => x.Score >= _options.MinimumScore)
            .Take(_options.TopK)
            .ToList();

        return filtered;
    }
}