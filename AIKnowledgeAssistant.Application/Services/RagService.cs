using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class RagService : IRagService
{
    private readonly IEmbeddingService _embeddingService;
    private readonly IVectorStore _vectorStore;
    private readonly IPromptBuilder _promptBuilder;
    private readonly IAIClient _aiClient;

    public RagService(IEmbeddingService embeddingService, IVectorStore vectorStore, IPromptBuilder promptBuilder, IAIClient aiClient)
    {
        _embeddingService = embeddingService;
        _vectorStore = vectorStore;
        _promptBuilder = promptBuilder;
        _aiClient = aiClient;
    }

    public async Task<RagResponse> AskAsync(RagRequest request)
    {
        // Step 1: Generate embedding for the user's question
        var embedding = await _embeddingService.GenerateAsync(new EmbeddingRequest(request.Question));

        // Step 2: Retrieve the most relevant chunks
        var documents = await _vectorStore.SearchAsync(
            new VectorSearchRequest
            {
                Embedding = embedding.Embedding,
                TopK = 5
            }
        );

        // Step 3: Build the prompt
        var prompt = _promptBuilder.BuildPrompt(request.Question, documents.Select(x => x.Content).ToList());

        // Step 4: Ask the LLM
        var answer = await _aiClient.GetChatCompletionAsync(prompt);

        // Step 5: Return answer + sources
        return new RagResponse(answer, documents.Select(x => x.Content).ToList());
    }
}