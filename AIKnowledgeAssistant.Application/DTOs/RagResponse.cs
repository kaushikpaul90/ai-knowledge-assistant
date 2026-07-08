namespace AIKnowledgeAssistant.Application.DTOs;

public sealed record RagResponse(string Answer, IReadOnlyList<string> Sources, double HighestScore);