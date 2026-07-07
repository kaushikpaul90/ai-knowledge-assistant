public sealed class DocumentChunk
{
    public required int ChunkNumber { get; init; }

    public required string Content { get; init; }

    public int CharacterCount => Content.Length;
}