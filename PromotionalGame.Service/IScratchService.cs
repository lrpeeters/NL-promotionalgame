using PromotionalGame.Service.Models;

namespace PromotionalGame.Service;

public interface IScratchService
{
    public Task<ScratchFieldResult> ScratchField(Guid fieldId, string emailAddress);
    public Task<Scratchboard?> GetScratchboard();
}
