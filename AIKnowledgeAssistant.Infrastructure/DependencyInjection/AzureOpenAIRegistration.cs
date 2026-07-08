using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.AI;
using AIKnowledgeAssistant.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIKnowledgeAssistant.Infrastructure.DependencyInjection;

internal static class AzureOpenAIRegistration
{
    public static IServiceCollection AddAzureOpenAI(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureOpenAIOptions>(
            configuration.GetSection(AzureOpenAIOptions.SectionName)
        );

        services.AddSingleton<IAIClient, AzureOpenAIService>();

        return services;
    }
}