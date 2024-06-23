using PromotionalGame.Service.Models;

namespace PromotionalGame.Service.Validations;

public class ValidationResult
{
    public ScratchStatus Status { get; set; }

    public string? Message { get; set; }
}
