namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IDocumentChunker
{
    IReadOnlyList<string> Chunk(string document, int chunkSize = 500, int overlap = 100);
}