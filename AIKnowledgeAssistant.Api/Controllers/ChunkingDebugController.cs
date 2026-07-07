using AIKnowledgeAssistant.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIKnowledgeAssistant.Api.Controllers;

[ApiController]
[Route("api/debug/chunking")]
public class ChunkingDebugController : ControllerBase
{
    private readonly IDocumentChunker _documentChunker;

    public ChunkingDebugController(IDocumentChunker documentChunker)
    {
        _documentChunker = documentChunker;
    }

    [HttpGet]
    public IActionResult TestChunking()
    {
        var document = "Azure Kubernetes Service is Microsoft's managed Kubernetes platform. It simplifies deploying containerized applications. AKS supports auto scaling. It integrates with Azure Active Directory. It provides managed control plane.";

        var chunks = _documentChunker.Chunk(document, 50, 10);

        return Ok(chunks);
    }
}