using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Infrastructure.DocumentProcessing;

public sealed class DocumentChunker : IDocumentChunker
{
    public IReadOnlyList<DocumentChunk> Chunk(string document, int maxChunkLength = 500, int overlapSentences = 1)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(document);

        var sentences = SplitIntoSentences(document);

        var chunks = new List<string>();

        var currentChunk = new List<string>();

        var currentLength = 0;

        foreach (var sentence in sentences)
        {
            if (currentLength + sentence.Length > maxChunkLength &&
                currentChunk.Count > 0)
            {
                chunks.Add(string.Join(" ", currentChunk));

                currentChunk = currentChunk
                    .TakeLast(overlapSentences)
                    .ToList();

                currentLength = currentChunk.Sum(x => x.Length);
            }

            currentChunk.Add(sentence);

            currentLength += sentence.Length;
        }

        if (currentChunk.Count > 0)
        {
            chunks.Add(string.Join(" ", currentChunk));
        }

        return chunks
                .Select((chunk, index) => new DocumentChunk
                {
                    ChunkNumber = index + 1,
                    Content = chunk
                })
                .ToList();
    }

    private static List<string> SplitIntoSentences(string text)
    {
        return text
            .Split(
                new[] { ". ", "? ", "! " },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim() + ".")
            .ToList();
    }
}