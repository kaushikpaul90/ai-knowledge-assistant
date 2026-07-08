namespace AIKnowledgeAssistant.Domain.Entities;

public sealed class SearchResult
{
    public required DocumentEmbedding Document { get; init; }

    public required double Score { get; init; }
}