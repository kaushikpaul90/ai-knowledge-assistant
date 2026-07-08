using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Infrastructure.Prompting;

public sealed class PromptBuilder : IPromptBuilder
{
    public string BuildPrompt(string question, IReadOnlyList<SearchResult> context)
    {
        var formattedContext = string.Join("\n\n", context.Select(c =>
            $"""
                Document: {c.Document.Metadata.DocumentName}
                Score: {c.Score:F3}

                {c.Document.Content}
            """));

        return
            $"""
                You are an enterprise AI assistant.

                Answer ONLY using the supplied context.

                If the answer is not present, reply:

                "I don't know based on the supplied documents."

                Context:

                {formattedContext}

                Question:

                {question}
            """;
    }
}