using Microsoft.AspNetCore.Mvc;
using PromotionalGame.Api.Models;
using PromotionalGame.Configuration.Models;
using PromotionalGame.Service;

namespace PromotionalGame.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PromotionalGameAdminController(IScratchAdminService service, GameSettingsConfiguration gameSettingsConfiguration, ILogger<PromotionalGameAdminController> logger) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> InitializeNewScratchboard()
    {
        try
        {
            await service.InitializeNewGame(gameSettingsConfiguration.NumberOfFields);
            return StatusCode(201, new GameResponse { HttpCode = 201 });
        }
        catch (Exception e)
        {
            var errorId = Guid.NewGuid();
            logger.LogError(e, "An unexpected error occurred with id {errorId} and message {errorMessage}.", errorId, e.Message);
            return StatusCode(500, new GameResponse { HttpCode = 500, ErrorMessage = $"An unexpected error occurred with id {errorId}" });
        }
    }
}
