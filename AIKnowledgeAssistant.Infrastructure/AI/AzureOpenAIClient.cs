using Microsoft.Extensions.Options;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Infrastructure.Configuration;
using System.Text.Json;
using System.Text;

namespace AIKnowledgeAssistant.Infrastructure.AI;

public sealed class AzureOpenAIClient : IAIClient
{
    private readonly HttpClient _httpClient;
    private readonly AzureOpenAIOptions _options;

    public AzureOpenAIClient(HttpClient httpClient, IOptions<AzureOpenAIOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<string> GetCompletionAsync(string prompt)
    {
        var endpoint = $"{_options.Endpoint}/openai/deployments/{_options.ChatDeployment}/chat/completions?api-version=2025-01-01-preview";
        using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Headers.Add("api-key", _options.ApiKey);

        var body = new
        {
            messages = new[]
            {
                new
                {
                    role = "system",
                    content = "You are a helpful AI assistant."
                },
                new
                {
                    role = "user",
                    content = prompt
                }
            },
            temperature = 0.2,
            max_tokens = 800
        };

        request.Content = new StringContent(
            JsonSerializer.Serialize(body),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(json);

        return document.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? string.Empty;
    }
}