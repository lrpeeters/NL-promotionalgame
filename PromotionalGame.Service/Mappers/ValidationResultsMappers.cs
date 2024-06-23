using PromotionalGame.Service.Models;
using PromotionalGame.Service.Validations;

namespace PromotionalGame.Service.Mappers;

internal static class ValidationResultsMappers
{
    public static ScratchFieldResult Map(this ValidationResults results)
    {
        if (results.IsValid)
        {
            return new()
            {
                ScratchStatus = ScratchStatus.Success
            };
        }

        var message = string.Join(Environment.NewLine, results.Results.Select(r => r.Message));
        var status = results.Results.GetStatus();

        return new()
        {
            ScratchStatus = status,
            ErrorMessage = message
        };
    }

    private static ScratchStatus GetStatus(this List<ValidationResult> results)
    {
        return results.IfContains(ScratchStatus.Error) ??
            results.IfContains(ScratchStatus.InvalidScratch) ??
            results.IfContains(ScratchStatus.AlreadyScratched) ??
            ScratchStatus.Success;
    }

    private static ScratchStatus? IfContains(this List<ValidationResult> results, ScratchStatus status)
    {
        if (results.Exists(r => r.Status == status))
        {
            return status;
        }

        return null;
    }
}
