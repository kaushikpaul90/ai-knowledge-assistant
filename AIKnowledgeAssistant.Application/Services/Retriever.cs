using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class Retriever : IRetriever
{
    private readonly IVectorStore _vectorStore;

    public Retriever(IVectorStore vectorStore)
    {
        _vectorStore = vectorStore;
    }

    public async Task<IReadOnlyList<DocumentEmbedding>>RetrieveAsync(VectorSearchRequest request)
    {
        return await _vectorStore.SearchAsync(request);
    }
}