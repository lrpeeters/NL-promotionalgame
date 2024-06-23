using System.Text.Json;
using PromotionalGame.Storage.Builders;
using PromotionalGame.Storage.Json.Configuration;

namespace PromotionalGame.Storage.Json;

internal class ScratchboardJsonInitializer(IScratchboardBuilder boardBuilder, ScratchboardJsonStorageConfiguration jsonConfiguration) : IScratchboardInitializer
{
    public async Task<string> InitializeNewGame(int numberOfFields)
    {
        var board = boardBuilder
            .WithFields(numberOfFields)
            .WithGrandPrize(1)
            .WithConsolationPrize(100)
            .Build();

        var location = jsonConfiguration.DatasourceLocation;
        var fileName = $"{DateTime.Now:yyyyMMddTHHmmss}-{jsonConfiguration.DatasourceName}";
        var path = Path.Combine(location, fileName);

        await using FileStream stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, board);
        return path;
    }
}
