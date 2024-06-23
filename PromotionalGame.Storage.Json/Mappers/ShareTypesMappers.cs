using PromotionalGame.Storage.Json.IO;

namespace PromotionalGame.Storage.Json.Mappers;

internal static class ShareTypesMappers
{
    public static FileShare Map(this ShareTypes shareType)
    {
        return shareType switch
        {
            ShareTypes.AllowOthersToRead => FileShare.Read,
            ShareTypes.AllowOthersToWrite => FileShare.ReadWrite,
            _ => throw new NotSupportedException($"The share type {shareType} is not supported.")
        };
    }
}
