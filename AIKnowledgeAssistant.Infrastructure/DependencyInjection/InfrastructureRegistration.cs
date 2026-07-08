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

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddAzureOpenAI(configuration);
        services.AddAzureSearch(configuration);
        services.AddDocumentProcessing();
        services.AddVectorStores(configuration);

        return services;
    }
}