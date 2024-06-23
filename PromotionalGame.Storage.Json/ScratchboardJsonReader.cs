using System.Text.Json;
using PromotionalGame.Storage.Json.Constants;
using PromotionalGame.Storage.Json.IO;
using PromotionalGame.Storage.Models;

namespace PromotionalGame.Storage.Json;

internal class ScratchboardJsonReader(IScratchboardDatasourceLoader loader) : IScratchboardReader
{
    public async Task<ScratchableField?> GetFieldByEmailAddress(string emailAddress)
    {
        var board = await GetScratchboard();
        return board?.Fields.Find(f => f.ScratchedBy == emailAddress);
    }

    public async Task<ScratchableField?> GetFieldById(Guid fieldId)
    {
        var board = await GetScratchboard();
        return board?.Fields.Find(f => f.Id == fieldId);
    }

    public async Task<Scratchboard?> GetScratchboard()
    {
        await using var scratchboardStream = await loader.Load(AccessTypes.Read, ShareTypes.AllowOthersToWrite);
        var board = await JsonSerializer.DeserializeAsync<Scratchboard>(scratchboardStream, ScratchboardConstants.SerializerOptions);
        return board;
    }
}
