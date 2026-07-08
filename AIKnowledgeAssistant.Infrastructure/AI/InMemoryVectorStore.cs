using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;

public sealed class InMemoryVectorStore : IVectorStore
{
    private readonly List<DocumentEmbedding> _documents = new List<DocumentEmbedding>();
    private readonly ISimilarityCalculator _similarityCalculator;

    public InMemoryVectorStore(ISimilarityCalculator similarityCalculator)
    {
        _similarityCalculator = similarityCalculator;
    }

    public Task AddAsync(DocumentEmbedding document)
    {
        _documents.Add(document);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<DocumentEmbedding>> SearchAsync(VectorSearchRequest request)
    {
        IEnumerable<DocumentEmbedding> query = _documents;

        if (!string.IsNullOrWhiteSpace(request.Department))
        {
            query = query.Where(x => x.Metadata.Department.Equals(request.Department, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.DocumentName))
        {
            query = query.Where(x => x.Metadata.DocumentName.Equals(request.DocumentName, StringComparison.OrdinalIgnoreCase));
        }

        var result =
            query.Select(document => new
            {
                Document = document,
                Score = _similarityCalculator.Calculate(request.Embedding, document.Vector)
            })
            .OrderByDescending(x => x.Score)
            .Take(request.TopK)
            .Select(x => x.Document)
            .ToList();

        return Task.FromResult<IReadOnlyList<DocumentEmbedding>>(result);
    }

    public Task<int> CountAsync()
    {
        return Task.FromResult(_documents.Count());
    }
}