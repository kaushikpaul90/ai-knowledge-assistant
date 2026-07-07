public sealed class DocumentEmbedding
{
    public Guid ID { get; init; }
    public string Content { get; init; } = string.Empty;
    public float[] Vector { get; init; } = [];
    public Dictionary<string, string> Metadata { get; init; } = [];

}