using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Infrastructure.Prompting;

public sealed class PromptBuilder : IPromptBuilder
{
    public string BuildPrompt(string question, IReadOnlyList<string> context)
    {
        string prompt = $"""
            You are an enterprise AI assistant.
            Answer ONLY using the context below.
            If the answer cannot be found in the context, say:
            "I don't know based on the supplied documents."
            Context
            {string.Join("\n\n", context)}
            Question
            {question}
        """;

        return prompt;
    }
}