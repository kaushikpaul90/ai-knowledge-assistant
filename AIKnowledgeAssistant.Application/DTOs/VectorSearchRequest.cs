namespace AIKnowledgeAssistant.Application.DTOs;

public sealed class VectorSearchRequest
{
    public required float[] Embedding { get; init; }

    public int TopK { get; init; } = 5;

    public string? Department { get; init; }

    public string? DocumentName { get; init; }
}