using AIKnowledgeAssistant.Application.DTOs;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IRagService
{
    Task<RagResponse> AskAsync(RagRequest request);
}