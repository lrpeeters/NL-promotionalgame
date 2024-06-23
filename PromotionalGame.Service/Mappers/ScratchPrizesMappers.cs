namespace PromotionalGame.Service.Mappers;

internal static class ScratchPrizesMappers
{
    public static Models.ScratchPrizes? Map(this Storage.Models.ScratchPrizes? result)
    {
        if (result is null)
        {
            return null;
        }

        return result.Value.Map();
    }

    public static Models.ScratchPrizes Map(this Storage.Models.ScratchPrizes prize)
    {
        return prize switch
        {
            Storage.Models.ScratchPrizes.GrandPrize => Models.ScratchPrizes.GrandPrize,
            Storage.Models.ScratchPrizes.ConsolationPrize => Models.ScratchPrizes.ConsolationPrize,
            Storage.Models.ScratchPrizes.Bummer => Models.ScratchPrizes.Bummer,
            _ => throw new NotSupportedException($"The prize {prize} is not supported.")
        };
    }
}