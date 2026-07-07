using System.Reflection.Metadata;
using AIKnowledgeAssistant.Application.Interfaces;
using AIKnowledgeAssistant.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public sealed class VectorStoreDebugController : ControllerBase
{
    private readonly IVectorStore _vectorStore;

    public VectorStoreDebugController(IVectorStore vectorStore)
    {
        _vectorStore = vectorStore;
    }

    [HttpPost("seed")]
    public async Task<IActionResult> Seed()
    {
        var documents = new List<DocumentEmbedding>()
        {
            new DocumentEmbedding
            {
                Content = "Azure Kubernetes Service",
                Vector = new float[] { 0.20f, 0.60f }
            },
            new DocumentEmbedding
            {
                Content = "Azure Cosmos DB",
                Vector = new float[] { -0.30f, 0.10f }
            },
            new DocumentEmbedding
            {
                Content = "Azure Functions",
                Vector = new float[] { 0.15f, 0.55f }
            },
            new DocumentEmbedding
            {
                Content = "Azure Blob Storage",
                Vector = new float[] { -0.40f, -0.20f }
            }
        };

        foreach (var document in documents)
        {
            await _vectorStore.AddAsync(document);
        }

        return Ok(
            new
            {
                Message = "Seeded vector store with sample documents.",
                Count = await _vectorStore.CountAsync()
            }
        );
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync()
    {
        var queryEmbedding = new float[] { 0.18f, 0.58f };
        var result = await _vectorStore.SearchAsync(queryEmbedding, topK: 3);
        return Ok(
            result.Select(x => new
            {
                x.Content
            })
        );
    }
}