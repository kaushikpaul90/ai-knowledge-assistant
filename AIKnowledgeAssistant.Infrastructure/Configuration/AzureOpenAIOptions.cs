namespace AIKnowledgeAssistant.Infrastructure.Configuration;

public sealed class AzureOpenAIOptions
{
    public const string SectionName = "AzureOpenAI";
    public string Endpoint { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string ChatDeployment {get; set; } = string.Empty;
    public string EmbeddingDeployment {get; set; } = string.Empty;
}