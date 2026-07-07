using AIKnowledgeAssistant.Domain.Entities;

namespace AIKnowledgeAssistant.Application.Interfaces;

public interface IVectorStore
{
    Task AddAsync(DocumentEmbedding document);
    
    Task<IReadOnlyList<DocumentEmbedding>> SearchAsync(float[] embedding, int topK = 5);

    Task<int> CountAsync();
}