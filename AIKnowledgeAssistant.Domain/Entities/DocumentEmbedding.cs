namespace AIKnowledgeAssistant.Domain.Entities;

public sealed class DocumentEmbedding
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Content { get; init; }

    public required float[] Vector { get; init; }

    public required DocumentMetadata Metadata { get; init; }
}