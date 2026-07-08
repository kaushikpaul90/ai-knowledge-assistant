using AIKnowledgeAssistant.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class AzureSearchRegistration
{
    public static IServiceCollection AddAzureSearch(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureSearchOptions>(configuration.GetSection(AzureSearchOptions.SectionName));

        return services;
    }
}