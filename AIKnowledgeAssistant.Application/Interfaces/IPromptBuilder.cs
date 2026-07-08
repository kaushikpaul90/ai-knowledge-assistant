using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IPromptBuilder
{
    string BuildPrompt(string question, IReadOnlyList<SearchResult> context);
}