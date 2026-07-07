using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Infrastructure.DocumentProcessing;

public sealed class DocumentChunker : IDocumentChunker
{
    public IReadOnlyList<string> Chunk(string document, int chunkSize = 500, int overlap = 100)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(document);

        if (chunkSize <= overlap)
        {
            throw new ArgumentNullException("Chunk size must be larger than overlap.");
        }

        var chunks = new List<string>();
        var start = 0;

        while (start <= document.Length)
        {
            var length = Math.Min(chunkSize, document.Length - start);
            chunks.Add(document.Substring(start, length));
            start += chunkSize - overlap;
        }

        return chunks;
    }
}