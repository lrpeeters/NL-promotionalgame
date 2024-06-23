using PromotionalGame.Configuration.Models;
using PromotionalGame.Storage.Json.Configuration;
using PromotionalGame.Storage.Json.Extensions;
using PromotionalGame.Storage.Json.IO;
using PromotionalGame.Storage.Json.Mappers;

namespace PromotionalGame.Storage.Json;

internal class ScratchboardDatasourceLoader(IScratchboardInitializer initializer, ScratchboardJsonStorageConfiguration jsonConfiguration, GameSettingsConfiguration gameSettings) : IScratchboardDatasourceLoader
{
    public async Task<Stream> Load(AccessTypes accessType, ShareTypes shareType)
    {
        var scratchboardLocation = await GetDatasource();
        return File.Open(scratchboardLocation, FileMode.Open, accessType.Map(), shareType.Map());
    }

    private async Task<string> GetDatasource()
    {
        string path = jsonConfiguration.DatasourceLocation;

        path.Guard();

        var files = Directory.GetFiles(path, $"*{jsonConfiguration.DatasourceName}");

        var datasource = files
            .OrderByDescending(f => f)
            .FirstOrDefault();

        if (string.IsNullOrWhiteSpace(datasource))
        {
            datasource = await initializer.InitializeNewGame(gameSettings.NumberOfFields);
        }

        return datasource;
    }
}
