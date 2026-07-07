namespace AIKnowledgeAssistant.Infrastructure.Configuration;

public sealed class AzureOpenAIOptions
{
    public const string SectionName = "AzureOpenAI";

    public string Endpoint { get; init; } = string.Empty;

    public string ApiKey { get; init; } = string.Empty;

    public string ChatDeployment { get; init; } = string.Empty;

    public string EmbeddingDeployment { get; init; } = string.Empty;
}