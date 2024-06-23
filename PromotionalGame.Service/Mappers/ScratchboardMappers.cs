namespace PromotionalGame.Service.Mappers;

internal static class ScratchboardMappers
{
    public static Models.Scratchboard? Map(this Storage.Models.Scratchboard? board)
    {
        if (board is null)
        {
            return null;
        }

        return new()
        {
            Fields = board.Fields
                .Select(f => ScratchableFieldMappers.Map(f))
                .ToList(),
        };
    }
}
