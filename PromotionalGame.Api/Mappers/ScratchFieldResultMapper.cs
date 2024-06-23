using PromotionalGame.Api.Models;
using PromotionalGame.Service.Models;

namespace PromotionalGame.Api.Mappers;

internal static class ScratchFieldResultMapper
{
    public static GameResponse Map(this ScratchFieldResult? result)
    {
        return new()
        {
            Content = result?.Prize ?? ScratchPrizes.Bummer,
            HttpCode = result.GetHttpCode(),
            ErrorMessage = result.GetErrorMessage()
        };
    }

    private static int GetHttpCode(this ScratchFieldResult? result)
    {
        if (result is null)
        {
            return 404;
        }

        return result.ScratchStatus switch
        {
            ScratchStatus.AlreadyScratched => 409,
            ScratchStatus.Success => 200,
            ScratchStatus.InvalidScratch => 400,
            ScratchStatus.Error => 500,
            _ => 500
        };
    }

    private static string? GetErrorMessage(this ScratchFieldResult? result)
    {
        if (result is null)
        {
            return "Scratchable field was not found.";
        }

        return result.ErrorMessage;
    }
}
