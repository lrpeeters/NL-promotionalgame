using PromotionalGame.Storage.Json.IO;

namespace PromotionalGame.Storage.Json.Mappers;

internal static class AccessTypesMappers
{
    public static FileAccess Map(this AccessTypes accessType)
    {
        return accessType switch
        {
            AccessTypes.Read => FileAccess.Read,
            AccessTypes.Write => FileAccess.Write,
            _ => throw new NotSupportedException($"The access type {accessType} is not supported.")
        };
    }
}
