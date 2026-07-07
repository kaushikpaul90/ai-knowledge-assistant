namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IDocumentChunker
{
    IReadOnlyList<DocumentChunk> Chunk(string document, int maxChunkLength = 500, int overlapSentences = 1);
}