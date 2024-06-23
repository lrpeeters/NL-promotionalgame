using System.Text.Json;
using System.Text.Json.Serialization;

namespace PromotionalGame.Storage.Json.Constants;

internal static class ScratchboardConstants
{
    public const string ScratchboardNameFormat = "PromotionalGame-Scratchboard";

    public static JsonSerializerOptions SerializerOptions => GetSerializerOptions();

    private static JsonSerializerOptions GetSerializerOptions()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }
}
