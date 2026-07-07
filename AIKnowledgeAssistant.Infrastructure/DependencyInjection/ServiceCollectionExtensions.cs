using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Application.Services;
using AIKnowledgeAssistant.Infrastructure.AI;
using AIKnowledgeAssistant.Infrastructure.Configuration;
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

        services.AddHttpClient<IAIClient, AzureOpenAIClient>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}