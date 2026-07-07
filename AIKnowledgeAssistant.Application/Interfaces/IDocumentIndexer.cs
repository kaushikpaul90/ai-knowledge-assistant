namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IDocumentIndexer
{
    Task IndexAsync(string document);
}