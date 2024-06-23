using PromotionalGame.Storage.Models;

namespace PromotionalGame.Storage;

public interface IScratchboardReader
{
    Task<Scratchboard?> GetScratchboard();

    Task<ScratchableField?> GetFieldById(Guid fieldId);

    Task<ScratchableField?> GetFieldByEmailAddress(string emailAddress);
}
