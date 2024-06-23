namespace PromotionalGame.Storage.Json.Extensions;

internal static class StringExtensions
{
    public static void Guard(this string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
}
