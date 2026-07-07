using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class ChatService : IChatService
{
    private readonly IAIClient _aiClient;

    public ChatService(IAIClient aiClient)
    {
        _aiClient = aiClient;
    }

    public async Task<ChatResponse> AskAsync(ChatRequest request)
    {
        var answer = await _aiClient.GetCompletionAsync(request.Question);
        return new ChatResponse(answer);
    }
}