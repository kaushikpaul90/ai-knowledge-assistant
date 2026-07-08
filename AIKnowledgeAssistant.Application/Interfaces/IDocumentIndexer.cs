using AIKnowledgeAssistant.Application.DTOs;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IDocumentIndexer
{
    Task IndexAsync(IndexDocumentRequest request);
}