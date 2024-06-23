namespace PromotionalGame.Storage.Models;

public class ScratchableField
{
    public Guid Id { get; set; }

    public ScratchPrizes Prize { get; set; }

    public string? ScratchedBy { get; set; }

    public DateTime? ScratchedAt { get; set; }

    public bool IsScratched => !string.IsNullOrWhiteSpace(ScratchedBy);
}
