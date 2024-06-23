namespace PromotionalGame.Storage.Json.Configuration;

public class ScratchboardJsonStorageConfiguration
{
    public const string SectionName = "ScratchboardJsonStorage";
    public string DatasourceLocation { get; set; } = null!;
    public string DatasourceName { get; set; } = null!;
}
