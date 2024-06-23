namespace PromotionalGame.Service.Mappers;

internal static class ScratchStatusMappers
{
    public static Models.ScratchStatus Map(this Storage.Models.ScratchStatus status)
    {
        return status switch
        {
            Storage.Models.ScratchStatus.Success => Models.ScratchStatus.Success,
            Storage.Models.ScratchStatus.InvalidScratch => Models.ScratchStatus.InvalidScratch,
            Storage.Models.ScratchStatus.AlreadyScratched => Models.ScratchStatus.AlreadyScratched,
            Storage.Models.ScratchStatus.Error => Models.ScratchStatus.Error,
            _ => throw new NotSupportedException($"The status {status} is not supported.")
        };
    }
}