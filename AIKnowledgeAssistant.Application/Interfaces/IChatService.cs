using AIKnowledgeAssistant.Application.DTOs;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IChatService
{
    Task<ChatResponse> AskAsync(ChatRequest request);
}