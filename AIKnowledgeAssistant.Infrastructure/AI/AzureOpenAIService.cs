using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.Configuration;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

public sealed class AzureOpenAIService : IAIClient
{
    private readonly ChatClient _chatClient;

    public AzureOpenAIService(IOptions<AzureOpenAIOptions> options)
    {
        var settings = options.Value;
        var client = new AzureOpenAIClient(
            new Uri(settings.Endpoint),
            new AzureKeyCredential(settings.ApiKey)
        );
        _chatClient = client.GetChatClient(settings.ChatDeployment);
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

    public Task<float[]> GetEmbeddingAsync(string text)
    {
        throw new NotImplementedException();
    }
}