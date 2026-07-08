namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IPromptBuilder
{
    string BuildPrompt(string question, IReadOnlyList<string> context);
}