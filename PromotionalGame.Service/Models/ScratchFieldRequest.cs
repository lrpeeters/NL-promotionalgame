namespace PromotionalGame.Service.Models;

internal class ScratchFieldRequest
{
    public Guid FieldId { get; set; }
    public string EmailAddress { get; set; } = null!;
}
