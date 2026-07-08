using AIKnowledgeAssistant.Application.Configuration;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.Search;
using AIKnowledgeAssistant.Infrastructure.Similarity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIKnowledgeAssistant.Infrastructure.DependencyInjection;

internal static class VectorStoreRegistration
{
    public static IServiceCollection AddVectorStores(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IVectorStore, InMemoryVectorStore>();
        services.AddSingleton<ISimilarityCalculator, CosineSimilarityCalculator>();
        services.AddSingleton<IKeywordSearchService, KeywordSearchService>();
        services.Configure<RetrievalOptions>(configuration.GetSection("Retrieval"));

        return services;
    }
}