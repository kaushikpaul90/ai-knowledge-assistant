namespace AIKnowledgeAssistant.Infrastructure.Configuration;

public sealed class AzureSearchOptions
{
    public const string SectionName = "AzureSearch";

    public required string Endpoint { get; init; }

    public required string ApiKey { get; init; }

    public required string IndexName { get; init; }
}