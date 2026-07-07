using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public sealed class EmbeddingController : ControllerBase
{
    private readonly IEmbeddingService _embeddingService;
    public EmbeddingController(IEmbeddingService embeddingService)
    {
        _embeddingService = embeddingService;
    }

    [HttpPost]
    public async Task<ActionResult<EmbeddingResponse>> Generate(EmbeddingRequest request)
    {
        var response = await _embeddingService.GenerateAsync(request);
        return Ok(response);
    }
}