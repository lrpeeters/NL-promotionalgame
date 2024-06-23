using Microsoft.AspNetCore.Mvc;
using PromotionalGame.Api.Mappers;
using PromotionalGame.Api.Models;
using PromotionalGame.Service;

namespace PromotionalGame.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PromotionalGameController(IScratchService service, ILogger<PromotionalGameController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetScratchboard()
    {
        try
        {
            var result = await service.GetScratchboard();
            var response = result.Map();
            return StatusCode(response.HttpCode, response);
        }
        catch (Exception e)
        {
            var errorId = Guid.NewGuid();
            logger.LogError(e, "An unexpected error occurred with id {errorId} and message {errorMessage}.", errorId, e.Message);
            return StatusCode(500, new GameResponse { HttpCode = 500, ErrorMessage = $"An unexpected error occurred with id {errorId}" });
        }
    }

    [HttpPost("fields/{fieldId}/users/{emailAddress}")]
    public async Task<IActionResult> ScratchField(Guid fieldId, string emailAddress)
    {
        try
        {
            var result = await service.ScratchField(fieldId, emailAddress);
            var response = result.Map();
            return StatusCode(response.HttpCode, response);
        }
        catch (Exception e)
        {
            var errorId = Guid.NewGuid();
            logger.LogError(e, "An unexpected error occurred with id {errorId} and message {errorMessage}.", errorId, e.Message);
            return StatusCode(500, new GameResponse { HttpCode = 500, ErrorMessage = $"An unexpected error occurred with id {errorId}" });
        }
    }
}
