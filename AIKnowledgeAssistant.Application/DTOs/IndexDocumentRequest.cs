namespace AIKnowledgeAssistant.Application.DTOs;

public sealed record IndexDocumentRequest
(
    string Content,
    string DocumentName,
    string Department,
    string Author,
    string DocumentType = "Text"
);