namespace AIKnowledgeAssistant.Application.Configuration;

public sealed class RetrievalOptions
{
    public int TopK { get; init; } = 5;

    public double MinimumScore { get; init; } = 0.75;
}