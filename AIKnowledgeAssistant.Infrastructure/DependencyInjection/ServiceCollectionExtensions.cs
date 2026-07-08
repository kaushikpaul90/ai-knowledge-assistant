using AIKnowledgeAssistant.Application.Configuration;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.AI;
using AIKnowledgeAssistant.Infrastructure.Configuration;
using AIKnowledgeAssistant.Infrastructure.DocumentProcessing;
using AIKnowledgeAssistant.Infrastructure.Prompting;
using AIKnowledgeAssistant.Infrastructure.Search;
using AIKnowledgeAssistant.Infrastructure.Similarity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIKnowledgeAssistant.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<AzureOpenAIOptions>(
            configuration.GetSection(AzureOpenAIOptions.SectionName)
        );

        services.AddSingleton<IAIClient, AzureOpenAIService>();
        services.AddSingleton<IVectorStore, InMemoryVectorStore>();
        services.AddSingleton<ISimilarityCalculator, CosineSimilarityCalculator>();
        services.AddSingleton<IDocumentChunker, DocumentChunker>();
        services.AddSingleton<IPromptBuilder, PromptBuilder>();
        services.Configure<RetrievalOptions>(configuration.GetSection("Retrieval"));
        services.AddSingleton<IKeywordSearchService, KeywordSearchService>();

        return services;
    }
}