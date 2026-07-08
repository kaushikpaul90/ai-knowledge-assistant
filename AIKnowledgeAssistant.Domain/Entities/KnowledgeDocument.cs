namespace AIKnowledgeAssistant.Domain.Entities;

public sealed class KnowledgeDocument
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Name { get; init; }

    public required string Department { get; init; }

    public required string Author { get; init; }

    public required string DocumentType { get; init; }

    public required string Content { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}