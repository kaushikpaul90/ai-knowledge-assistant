namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IAIClient
{
    Task<string> GetCompletionAsync(string prompt);
}