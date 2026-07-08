using AIKnowledgeAssistant.Application.DTOs;
using AIKnowledgeAssistant.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIKnowledgeAssistant.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RagController : ControllerBase
{
    private readonly IRagService _ragService;

    public RagController(IRagService ragService)
    {
        _ragService = ragService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(RagResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<RagResponse>> Ask(RagRequest request)
    {
        var response = await _ragService.AskAsync(request);
        return Ok(response);
    }
}