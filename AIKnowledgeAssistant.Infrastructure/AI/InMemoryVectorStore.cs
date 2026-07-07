using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;

public sealed class InMemoryVectorStore : IVectorStore
{
    private readonly List<DocumentEmbedding> _documents = new List<DocumentEmbedding>();

    public Task AddAsync(DocumentEmbedding document)
    {
        _documents.Add(document);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<DocumentEmbedding>> SearchAsync(float[] embedding, int topK = 5)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync()
    {
        return Task.FromResult(_documents.Count());
    }
}