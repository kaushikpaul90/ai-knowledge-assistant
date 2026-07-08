using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class DocumentIndexer : IDocumentIndexer
{
    private readonly IDocumentChunker _documentChunker;
    private readonly IEmbeddingService _embeddingService;
    private readonly IVectorStore _vectorStore;

    public DocumentIndexer(IDocumentChunker documentChunker, IEmbeddingService embeddingService, IVectorStore vectorStore)
    {
        _documentChunker = documentChunker;
        _embeddingService = embeddingService;
        _vectorStore = vectorStore;
    }

    public async Task IndexAsync(string document)
    {
        var chunks = _documentChunker.Chunk(document);

        foreach (var chunk in chunks)
        {
            var embedding = await _embeddingService.GenerateAsync(new EmbeddingRequest(chunk.Content));
            await _vectorStore.AddAsync(
                new DocumentEmbedding
                {
                    Content = chunk.Content,
                    Vector = embedding.Embedding,
                    Metadata = new DocumentMetadata
                    {
                        DocumentName = "Sample Document",
                        ChunkNumber = chunk.ChunkNumber,
                        Department = "Engineering",
                        Author = "Kaushik Paul"
                    }
                }
            );
        }
    }
}