using System.Text.Json;
using Microsoft.Extensions.Logging;
using PromotionalGame.Storage.Json.Constants;
using PromotionalGame.Storage.Json.IO;
using PromotionalGame.Storage.Models;

namespace PromotionalGame.Storage.Json;

internal class ScratchboardJsonWriter(IScratchboardReader reader, IScratchboardDatasourceLoader loader, ILogger<ScratchboardJsonWriter> logger) : IScratchboardWriter
{
    private static readonly SemaphoreSlim _lock = new(1, 1);

    public async Task<ScratchFieldResult> ScratchField(Guid fieldId, string emailAddress)
    {
        try
        {
            await _lock.WaitAsync();

            var scratchBoard = await reader.GetScratchboard();
            var scratchedField = scratchBoard?
                .Fields
                .Find(f => f.Id == fieldId);

            if (scratchedField is null)
            {
                return new()
                {
                    ScratchStatus = ScratchStatus.InvalidScratch,
                    ErrorMessage = $"Field with id {fieldId} does not exist.",
                    Prize = ScratchPrizes.Bummer
                };
            }

            scratchedField.ScratchedBy = emailAddress;
            scratchedField.ScratchedAt = DateTime.UtcNow;

            await using var stream = await loader.Load(AccessTypes.Write, ShareTypes.AllowOthersToRead);
            await JsonSerializer.SerializeAsync(stream, scratchBoard, ScratchboardConstants.SerializerOptions);

            return new()
            {
                ScratchStatus = ScratchStatus.Success,
                Prize = scratchedField.Prize
            };
        }
        catch (Exception ex)
        {
            var errorId = Guid.NewGuid();
            logger.LogError(ex, "An unexpected error with id {errorId} occurred when scratching field {fieldId}. Message: {errorMessage}", errorId, fieldId, ex.Message);
            return new()
            {
                ErrorMessage = $"An unexpected error with id {errorId} occurred when scratching field {fieldId}.",
                ScratchStatus = ScratchStatus.Error,
                Prize = ScratchPrizes.Bummer
            };
        }
        finally
        {
            _lock.Release();
        }
    }
}
