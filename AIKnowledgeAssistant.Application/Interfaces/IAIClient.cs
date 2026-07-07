namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IAIClient
{
    /// <summary>
    /// Generates a chat completion.
    /// </summary>
    Task<string> GetChatCompletionAsync(string prompt);

    /// <summary>
    /// Generates an embedding vector.
    /// </summary>
    Task<float[]> GetEmbeddingAsync(string text);
}