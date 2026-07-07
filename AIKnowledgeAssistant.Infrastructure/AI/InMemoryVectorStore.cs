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

    public Task<IReadOnlyList<DocumentEmbedding>> SearchAsync(float[] embedding, int topK = 5)
    {
        var result =
            _documents.Select(document => new
            {
                Document = document,
                Score = _similarityCalculator.Calculate(embedding, document.Vector)
            })
            .OrderByDescending(x => x.Score)
            .Take(topK)
            .Select(x => x.Document)
            .ToList();

        return Task.FromResult<IReadOnlyList<DocumentEmbedding>>(result);
    }

    public Task<int> CountAsync()
    {
        return Task.FromResult(_documents.Count());
    }
}