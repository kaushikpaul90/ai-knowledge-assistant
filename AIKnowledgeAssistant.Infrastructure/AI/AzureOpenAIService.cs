using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.Configuration;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace AIKnowledgeAssistant.Infrastructure.AI;
public sealed class AzureOpenAIService : IAIClient
{
    private readonly ChatClient _chatClient;
    private readonly EmbeddingClient _embeddingClient;

    public AzureOpenAIService(IOptions<AzureOpenAIOptions> options)
    {
        var settings = options.Value;
        var client = new AzureOpenAIClient(
            new Uri(settings.Endpoint),
            new AzureKeyCredential(settings.ApiKey)
        );
        _chatClient = client.GetChatClient(settings.ChatDeployment);
        _embeddingClient = client.GetEmbeddingClient(settings.EmbeddingDeployment);
    }

    public async Task<string> GetChatCompletionAsync(string prompt)
    {
        ChatCompletion completion = await _chatClient.CompleteChatAsync(
            new ChatMessage[]
            {
                new SystemChatMessage("You are a helpful enterprise AI assistant."),
                new UserChatMessage(prompt)
            }
        );
        return completion.Content[0].Text;
    }

    public async Task<float[]> GetEmbeddingAsync(string text)
    {
        OpenAIEmbedding embedding = await _embeddingClient.GenerateEmbeddingAsync(text);
        
        return embedding.ToFloats().ToArray();
    }
}