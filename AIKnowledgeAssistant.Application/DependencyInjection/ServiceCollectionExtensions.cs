using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AIKnowledgeAssistant.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IChatService, ChatService>();

        services.AddScoped<IEmbeddingService, EmbeddingService>();

        services.AddScoped<IDocumentIndexer, DocumentIndexer>();

        return services;
    }
}