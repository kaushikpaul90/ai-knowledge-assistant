namespace AIKnowledgeAssistant.Domain.Entities;

public sealed class DocumentMetadata
{
    public required string DocumentName { get; init; }

    public string DocumentType { get; init; } = "Text";

    public string Department { get; init; } = "General";

    public string Author { get; init; } = "Unknown";

    public int ChunkNumber { get; init; }

    public DateTime IndexedAt { get; init; } = DateTime.UtcNow;
}