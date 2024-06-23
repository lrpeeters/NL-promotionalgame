namespace PromotionalGame.Service.Mappers;

internal static class ScratchFieldResultMapper
{
    public static Models.ScratchFieldResult Map(this Storage.Models.ScratchFieldResult result)
    {
        return new()
        {
            ErrorMessage = result.ErrorMessage,
            Prize = result.Prize.Map(),
            ScratchStatus = result.ScratchStatus.Map()
        };
    }
}
