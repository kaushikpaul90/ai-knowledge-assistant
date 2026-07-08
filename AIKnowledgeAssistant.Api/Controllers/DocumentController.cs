using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIKnowledgeAssistant.Api.Controllers;

[ApiController]
[Route("api/documents")]
public sealed class DocumentController : Controller
{
    private readonly IDocumentIndexer _documentIndexer;

    public DocumentController(IDocumentIndexer documentIndexer)
    {
        _documentIndexer = documentIndexer;
    }

    [HttpPost]
    public async Task<IActionResult> Index(IndexDocumentRequest request)
    {
        await _documentIndexer.IndexAsync(request);
        return Ok(new { Message = "Document indexed successfully." });
    }
}