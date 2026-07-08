using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Application.Services;

public sealed class RagService : IRagService
{
    private readonly IRetriever _retriever;
    private readonly IEmbeddingService _embeddingService;
    private readonly IPromptBuilder _promptBuilder;
    private readonly IAIClient _aiClient;

    public RagService(
        IRetriever retriever,
        IEmbeddingService embeddingService,
        IPromptBuilder promptBuilder,
        IAIClient aiClient)
    {
        _retriever = retriever;
        _embeddingService = embeddingService;
        _promptBuilder = promptBuilder;
        _aiClient = aiClient;
    }

    public async Task<RagResponse> AskAsync(RagRequest request)
    {
        // Step 1: Generate embedding for the user's question
        var embedding = await _embeddingService.GenerateAsync(new EmbeddingRequest(request.Question));

        // Step 2: Retrieve the most relevant chunks
        var documents = await _retriever.RetrieveAsync(
            new VectorSearchRequest
            {
                Query = request.Question,
                Embedding = embedding.Embedding,
                TopK = 5
            }
        );

        // Step 3: Build the prompt
        var prompt = _promptBuilder.BuildPrompt(request.Question, documents);

        // Step 4: Ask the LLM
        var answer = await _aiClient.GetChatCompletionAsync(prompt);

        // Step 5: Determine highest score
        var highestScore = documents.Any() ? documents.Max(x => x.Score) : 0;

        // Step 6: Return answer + sources
        return new RagResponse(answer, documents.Select(x => x.Document.Content).ToList(), highestScore);
    }
}