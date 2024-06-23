using PromotionalGame.Storage.Models;

namespace PromotionalGame.Storage;

public interface IScratchboardWriter
{
    public Task<ScratchFieldResult> ScratchField(Guid fieldId, string emailAddress);
}
