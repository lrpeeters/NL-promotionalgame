namespace PromotionalGame.Service.Mappers;

internal static class ScratchableFieldMappers
{

    public static Models.ScratchableField Map(this Storage.Models.ScratchableField field)
    {
        return new()
        {
            Id = field.Id,
            IsScratched = field.IsScratched
        };
    }
}