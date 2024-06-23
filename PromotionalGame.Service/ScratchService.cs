using PromotionalGame.Service.Mappers;
using PromotionalGame.Service.Models;
using PromotionalGame.Service.Validations;
using PromotionalGame.Storage;

namespace PromotionalGame.Service;

internal class ScratchService(IScratchboardReader reader, IScratchboardWriter writer, IScratchFieldValidator scratchFieldValidator) : IScratchService
{
    public async Task<Scratchboard?> GetScratchboard()
    {
        var board = await reader.GetScratchboard();
        return board.Map();
    }

    public async Task<ScratchFieldResult> ScratchField(Guid fieldId, string emailAddress)
    {
        var request = new ScratchFieldRequest
        {
            FieldId = fieldId,
            EmailAddress = emailAddress
        };

        var validationResult = await scratchFieldValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return validationResult.Map();
        }

        var result = await writer.ScratchField(fieldId, emailAddress);
        return result.Map();
    }
}
