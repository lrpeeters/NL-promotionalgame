using PromotionalGame.Api.Models;
using PromotionalGame.Service.Models;

namespace PromotionalGame.Api.Mappers;

internal static class ScratchboardMappers
{
    public static GameResponse Map(this Scratchboard? board)
    {
        return new GameResponse
        {
            Content = board,
            HttpCode = board.GetHttpCode(),
            ErrorMessage = board.GetErrorMessage()
        };
    }

    private static int GetHttpCode(this Scratchboard? board)
    {
        if (board is null)
        {
            return 404;
        }

        return 200;
    }

    private static string? GetErrorMessage(this Scratchboard? board)
    {
        if (board is null)
        {
            return "Scratch board was not found.";
        }

        return null;
    }
}
