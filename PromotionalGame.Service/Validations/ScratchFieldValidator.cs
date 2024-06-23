using PromotionalGame.Service.Models;
using PromotionalGame.Storage;

namespace PromotionalGame.Service.Validations;

/// <summary>
/// I would normally use fluent validations, but for convenience I used a simple class (to support the status in the result)
/// </summary>
/// <param name="reader"></param>
internal class ScratchFieldValidator(IScratchboardReader reader) : IScratchFieldValidator
{
    public async Task<ValidationResults> ValidateAsync(ScratchFieldRequest request)
    {
        var result = new ValidationResults();


        var fieldByEmailAddress = await reader.GetFieldByEmailAddress(request.EmailAddress);

        if (fieldByEmailAddress is not null)
        {
            result.Add(new() { Status = ScratchStatus.InvalidScratch, Message = $"User {request.EmailAddress} already scratched a field." });
        }

        var fieldById = await reader.GetFieldById(request.FieldId);

        if (fieldById is null)
        {
            result.Add(new() { Status = ScratchStatus.InvalidScratch, Message = $"Scratched field was not found." });
        }

        if (fieldById?.IsScratched == true)
        {
            result.Add(new() { Status = ScratchStatus.AlreadyScratched, Message = $"Scratched field was already opened." });
        }

        return result;
    }

}
