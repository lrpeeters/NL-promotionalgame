using PromotionalGame.Service.Models;

namespace PromotionalGame.Service.Validations
{
    internal interface IScratchFieldValidator
    {
        Task<ValidationResults> ValidateAsync(ScratchFieldRequest request);
    }
}
