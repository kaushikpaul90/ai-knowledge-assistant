using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.DocumentProcessing;
using AIKnowledgeAssistant.Infrastructure.Prompting;
using Microsoft.Extensions.DependencyInjection;

namespace AIKnowledgeAssistant.Infrastructure.DependencyInjection;

internal static class DocumentProcessingRegistration
{
    public static IServiceCollection AddDocumentProcessing(
        this IServiceCollection services)
    {
        services.AddSingleton<IDocumentChunker, DocumentChunker>();
        services.AddSingleton<IPromptBuilder, PromptBuilder>();

        return services;
    }
}